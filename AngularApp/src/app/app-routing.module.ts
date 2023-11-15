import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RouteComponentComponent } from './route-component/route-component.component';


const routes: Routes = [
  {path:'', component:RouteComponentComponent},
  //{path:'form', component:TemplateForm}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
