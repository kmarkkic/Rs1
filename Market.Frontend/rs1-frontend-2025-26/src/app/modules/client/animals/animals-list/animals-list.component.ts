import { Component, inject, OnInit, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AnimalsApiService } from '../../../../api-services/animals/animals-api.service';
import { ListAnimalsQueryDto, ListAnimalsRequest } from '../../../../api-services/animals/animals-api.models';

@Component({
  selector: 'app-animals-list',
  standalone: false,
  templateUrl: './animals-list.component.html',
  styleUrl: './animals-list.component.scss'
})
export class AnimalsListComponent implements OnInit {
  private api = inject(AnimalsApiService);
  private router = inject(Router);

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

  adoptAnimal(animal: ListAnimalsQueryDto): void {
    this.router.navigate(['/animals', animal.id, 'adopt']);
  }
}
