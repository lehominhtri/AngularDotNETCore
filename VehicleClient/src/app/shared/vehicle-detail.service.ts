import { VehicleDetail } from './vehicle-detail.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { VehicleMaker } from './vehicle-maker.model';

@Injectable({
  providedIn: 'root'
})
export class VehicleDetailService {
  formData: VehicleDetail= {
    VIN: null,
    VehicleMaker: null,
    VehicleModel: null,
    InspectionDate: null,
    InspectorName: null,
    InspectionLocation: null,
    InspectionStatus: null,
    InspectionNotes: null
  };
  
  isAdd: boolean;
  readonly rootURL = 'http://localhost:58064/api';
  list : VehicleDetail[];

  makerList: VehicleMaker[];

  constructor(private http: HttpClient) { }

  postVehicleDetail() {
    return this.http.post(this.rootURL + '/VehicleDetail', this.formData);
  }
  putVehicleDetail() {
    return this.http.put(this.rootURL + '/VehicleDetail/'+ this.formData.VIN, this.formData);
  }
  deleteVehicleDetail(id) {
    return this.http.delete(this.rootURL + '/VehicleDetail/'+ id);
  }
  getVehicleMakersList() {
    this.http.get(this.rootURL + '/VehicleMaker')
    .toPromise()
    .then(res => this.makerList = res as VehicleMaker[]);
  }
  refreshList(){
    this.http.get(this.rootURL + '/VehicleDetail')
    .toPromise()
    .then(res => this.list = res as VehicleDetail[]);
  }
}
