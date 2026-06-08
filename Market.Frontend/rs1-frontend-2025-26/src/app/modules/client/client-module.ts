import {NgModule} from '@angular/core';

import {ClientRoutingModule} from './client-routing-module';
import {SharedModule} from '../shared/shared-module';
import { AnimalsListComponent } from './animals/animals-list/animals-list.component';


@NgModule({
  declarations: [
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
    AnimalsListComponent
  ]
})
export class ClientModule { }