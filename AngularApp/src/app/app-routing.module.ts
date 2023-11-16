import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RouteComponentComponent } from './route-component/route-component.component';
import { Guard } from './routerGuard.service';
import { TempForm } from './TemplateForm/demo.templateform' 


const routes: Routes = [
  {path:'', component:RouteComponentComponent},
  //{path:'form', component:TemplateForm}
  {path:'form/:id', component:TempForm,canActivate:[Guard]}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
