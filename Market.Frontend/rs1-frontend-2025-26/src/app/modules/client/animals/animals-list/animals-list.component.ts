import { Component, inject, OnInit, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AnimalsApiService } from '../../../../api-services/animals/animals-api.service';
import { ListAnimalsQueryDto, ListAnimalsRequest } from '../../../../api-services/animals/animals-api.models';
import { DialogHelperService } from '../../../shared/services/dialog-helper.service';
import { DialogButton } from '../../../shared/models/dialog-config.model';
import { ToasterService } from '../../../../core/services/toaster.service';
import { AnimalUpsertDialogComponent } from '../animal-upsert-dialog/animal-upsert-dialog.component';

@Component({
  selector: 'app-animals-list',
  standalone: false,
  templateUrl: './animals-list.component.html',
  styleUrl: './animals-list.component.scss'
})
export class AnimalsListComponent implements OnInit {
  private api = inject(AnimalsApiService);
  private dialog = inject(MatDialog);
  private dialogHelper = inject(DialogHelperService);
  private toaster = inject(ToasterService);

  animals = signal<ListAnimalsQueryDto[]>([]);
  totalItems = signal(0);
  page = signal(1);
  pageSize = signal(10);
  displayedColumns = ['name', 'age', 'gender', 'breed', 'status', 'actions'];

  ngOnInit(): void {
    this.loadAnimals();
  }

  loadAnimals(): void {
    const request = new ListAnimalsRequest();
    request.paging.page = this.page();
    request.paging.pageSize = this.pageSize();

    this.api.list(request).subscribe(result => {
      this.animals.set(result.items);
      this.totalItems.set(result.totalItems);
    });
  }

  openCreateDialog(): void {
    const ref = this.dialog.open(AnimalUpsertDialogComponent, {
      width: '600px',
      disableClose: true,
      data: {}
    });

    ref.afterClosed().subscribe(saved => {
      if (saved) this.loadAnimals();
    });
  }

  openEditDialog(animal: ListAnimalsQueryDto): void {
    const ref = this.dialog.open(AnimalUpsertDialogComponent, {
      width: '600px',
      disableClose: true,
      data: { animal }
    });

    ref.afterClosed().subscribe(saved => {
      if (saved) this.loadAnimals();
    });
  }

  confirmDelete(animal: ListAnimalsQueryDto): void {
    this.dialogHelper.confirmDelete(animal.name).subscribe(result => {
      if (result?.button === DialogButton.DELETE) {
        this.api.delete(animal.id).subscribe({
          next: () => {
            this.toaster.success('Životinja uspješno obrisana');
            this.loadAnimals();
          },
          error: () => this.toaster.error('Greška pri brisanju životinje')
        });
      }
    });
  }
}
