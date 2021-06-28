import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';
 
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { VehicleDetailsComponent } from './vehicle-details/vehicle-details.component';
import { VehicleDetailComponent } from './vehicle-details/vehicle-detail/vehicle-detail.component';
import { VehicleDetailListComponent } from './vehicle-details/vehicle-detail-list/vehicle-detail-list.component';
import { VehicleDetailService } from './shared/vehicle-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    VehicleDetailsComponent,
    VehicleDetailComponent,
    VehicleDetailListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    DatePickerModule,
    ToastrModule.forRoot()
  ],
  providers: [VehicleDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
