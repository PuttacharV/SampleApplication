import { MedicineListComponent } from './components/medicine-list/medicine-list.component';
import { FeatureTwoComponent } from './feature-two.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    { path: '', component: MedicineListComponent },
    { path: 'feature2', component: FeatureTwoComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeatureTwoRoutingModule { }
