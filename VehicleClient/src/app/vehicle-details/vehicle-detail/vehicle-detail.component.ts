import { VehicleDetailService } from '../../shared/vehicle-detail.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { VehicleMaker } from 'src/app/shared/vehicle-maker.model';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styles: []
})
export class VehicleDetailComponent implements OnInit {

  constructor(private service: VehicleDetailService,
    private toastr: ToastrService) { }

  public today: Date = new Date();

  ngOnInit() {
    this.resetForm();
  }


  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      VIN: '',
      VehicleMaker: '',
      VehicleModel: '',
      InspectionDate: null,
      InspectorName: '',
      InspectionLocation: '',
      InspectionStatus: false,
      InspectionNotes: ''
    }
    this.service.isAdd = true;
  }

  onSubmit(form: NgForm) {
    if (this.service.isAdd)
      if (this.service.list.findIndex(x => x.VIN === this.service.formData.VIN) >= 0) {
        this.toastr.error('Duplicate VIN #', 'Vehicle Detail Register');
      } else {
        this.insertRecord(form);
      }
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postVehicleDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Vehicle Detail Register');
        this.service.refreshList();
      },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
  updateRecord(form: NgForm) {
    this.service.putVehicleDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Submitted successfully', 'Vehicle Detail Register');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

  getMakerID(value: any): void {
    debugger;
    if (value !== 'SELECT') {
      this.service.formData.VehicleMaker = this.service.makerList.find(x => x.Maker_ID == value).Maker_ID;
    }
  }
}
