import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeatureTwoComponent } from './feature-two.component';
import { FeatureTwoRoutingModule } from './feature-two-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { MedicineListComponent } from './components/medicine-list/medicine-list.component';

@NgModule({
  imports: [
    CommonModule,
    FeatureTwoRoutingModule
  ],
  declarations: [FeatureTwoComponent,MedicineListComponent]
})
export class FeatureTwoModule { }
