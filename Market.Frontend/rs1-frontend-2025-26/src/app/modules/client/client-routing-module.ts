import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimalsListComponent } from './animals/animals-list/animals-list.component';
import { AdoptionRequestWizardComponent } from './animals/adoption-request-wizard/adoption-request-wizard.component';
import { AdoptionRequestsListComponent } from './adoption-requests/adoption-requests-list/adoption-requests-list.component';

const routes: Routes = [
  { path: 'animals', component: AnimalsListComponent },
  { path: 'animals/:animalId/adopt', component: AdoptionRequestWizardComponent },
  { path: 'adoption-requests', component: AdoptionRequestsListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
