import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Header } from './Layout/header.component';
import { Sidebar } from './Layout/sidebar.component';
import { Crud } from './Layout/crud.component';
import { NewpipePipe } from './newpipe.pipe';
import { TempForm } from './TemplateForm/demo.templateform';
import { FormsModule } from '@angular/forms';
import { HttpDemo } from './DemoClientHttp/demohttp.component';
import { HttpClientModule } from '@angular/common/http' ;


@NgModule({
  declarations: [
    AppComponent,
    Header,
    Sidebar,
    Crud,
    NewpipePipe,
    TempForm,
    HttpDemo
    
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
