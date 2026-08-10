import { Component, inject, OnInit, signal } from '@angular/core';
import { AdoptionRequestsApiService } from '../../../../api-services/adoption-requests/adoption-requests-api.service';
import { AdoptionRequestDto } from '../../../../api-services/adoption-requests/adoption-requests-api.models';
import { DialogHelperService } from '../../../shared/services/dialog-helper.service';
import { DialogButton, DialogType } from '../../../shared/models/dialog-config.model';
import { ToasterService } from '../../../../core/services/toaster.service';

@Component({
  selector: 'app-adoption-requests-list',
  standalone: false,
  templateUrl: './adoption-requests-list.component.html',
  styleUrl: './adoption-requests-list.component.scss'
})
export class AdoptionRequestsListComponent implements OnInit {
  private api = inject(AdoptionRequestsApiService);
  private dialogHelper = inject(DialogHelperService);
  private toaster = inject(ToasterService);

  requests = signal<AdoptionRequestDto[]>([]);
  displayedColumns = ['animal', 'applicant', 'status', 'createdAt', 'actions'];

  ngOnInit(): void {
    this.loadRequests();
  }

  loadRequests(): void {
    this.api.list().subscribe(result => this.requests.set(result));
  }

  viewDetails(request: AdoptionRequestDto): void {
    this.api.getById(request.id).subscribe(details => {
      this.dialogHelper.open({
        type: DialogType.INFO,
        title: `Zahtjev za "${details.animalName}"`,
        message: `Podnosilac: ${details.applicantFullName}\nStatus: ${details.statusName}\n\n${details.message}`,
        icon: 'info',
        buttons: [{ type: DialogButton.CLOSE }]
      }).subscribe();
    });
  }

  deleteRequest(request: AdoptionRequestDto): void {
    this.dialogHelper.open({
      type: DialogType.WARNING,
      title: 'Brisanje zahtjeva za udomljavanje',
      message: `Da li ste sigurni da želite obrisati zahtjev za životinju "${request.animalName}"?`,
      icon: 'delete_forever',
      buttons: [
        { type: DialogButton.CANCEL },
        { type: DialogButton.DELETE, color: 'warn' }
      ]
    }).subscribe(result => {
      if (result?.button === DialogButton.DELETE) {
        this.performDelete(request);
      }
    });
  }

  private performDelete(request: AdoptionRequestDto): void {
    this.api.delete(request.id).subscribe({
      next: () => {
        this.toaster.success('Zahtjev je uspješno obrisan.');
        this.loadRequests();
      },
      error: () => {
        this.toaster.error('Greška pri brisanju zahtjeva.');
      }
    });
  }
}
