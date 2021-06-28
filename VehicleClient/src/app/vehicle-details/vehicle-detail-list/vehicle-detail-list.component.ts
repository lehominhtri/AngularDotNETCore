import { VehicleDetail } from '../../shared/vehicle-detail.model';
import { VehicleDetailService } from '../../shared/vehicle-detail.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {formatDate} from '@angular/common';

@Component({
  selector: 'app-vehicle-detail-list',
  templateUrl: './vehicle-detail-list.component.html',
  styles: []
})
export class VehicleDetailListComponent implements OnInit {

  constructor(private service: VehicleDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
    this.service.getVehicleMakersList();
  }

  populateForm(pd: VehicleDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  convertStatus(status:boolean) {
    if (status) return 'Pass';
    return 'Fail';
  }

  formatDateTime(datetime:any) {
    return formatDate(datetime,'MM-dd-yyyy','en-US');
  }
  onDelete(VIN) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteVehicleDetail(VIN)
        .subscribe(res => {          
          this.service.refreshList();
          //reset form data
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
          this.toastr.warning('Deleted successfully', 'Vehicle Detail Register');
        },
          err => {
            debugger;
            console.log(err);
          })
    }
  }

  getMakerName(value: any): string {
      return this.service.makerList.find(x => x.Maker_ID == value).Maker_Name;
  }
}
