import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlayerRoutingModule } from './player-routing.module';
import { CRUDComponent } from './crud/crud.component';


@NgModule({
  declarations: [CRUDComponent],
  imports: [
    CommonModule,
    PlayerRoutingModule
  ]
})
export class PlayerModule { }
