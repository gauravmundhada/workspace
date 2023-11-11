import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Header } from './Layout/header.component';
import { Sidebar } from './Layout/sidebar.component';
import { Crud } from './Layout/crud.component';


@NgModule({
  declarations: [
    AppComponent,
    Header,
    Sidebar,
    Crud
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
