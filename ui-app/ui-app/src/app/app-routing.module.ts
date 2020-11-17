import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: '', redirectTo: 'feature', pathMatch: 'full'},
  {path: 'feature', loadChildren: () => import('../feature-modules/feature-two/feature-two.module').then(m => m.FeatureTwoModule)},
  {path: '**', redirectTo: 'feature', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
