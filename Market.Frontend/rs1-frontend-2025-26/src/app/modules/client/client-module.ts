import { NgModule } from '@angular/core';

import { ClientRoutingModule } from './client-routing-module';
import { SharedModule } from '../shared/shared-module';
import { AnimalsListComponent } from './animals/animals-list/animals-list.component';
import { AnimalUpsertDialogComponent } from './animals/animal-upsert-dialog/animal-upsert-dialog.component';

@NgModule({
  declarations: [
    AnimalsListComponent,
    AnimalUpsertDialogComponent
  ],
  imports: [
    SharedModule,
    ClientRoutingModule
  ]
})
export class ClientModule { }
