import { NgModule } from '@angular/core';

import { ClientRoutingModule } from './client-routing-module';
import { SharedModule } from '../shared/shared-module';
import { AnimalsListComponent } from './animals/animals-list/animals-list.component';
import { AdoptionRequestWizardComponent } from './animals/adoption-request-wizard/adoption-request-wizard.component';

@NgModule({
  declarations: [
    AnimalsListComponent,
    AdoptionRequestWizardComponent
  ],
  imports: [
    SharedModule,
    ClientRoutingModule
  ]
})
export class ClientModule { }
