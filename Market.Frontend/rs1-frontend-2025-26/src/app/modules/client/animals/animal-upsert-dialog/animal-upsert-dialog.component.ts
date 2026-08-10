import { Component, inject, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { forkJoin } from 'rxjs';
import { AnimalsApiService } from '../../../../api-services/animals/animals-api.service';
import { ListAnimalsQueryDto } from '../../../../api-services/animals/animals-api.models';
import { BreedsApiService, BreedDto } from '../../../../api-services/breeds/breeds-api.service';
import { AnimalTypesApiService, AnimalTypeDto } from '../../../../api-services/animal-types/animal-types-api.service';
import { SheltersApiService, ShelterDto } from '../../../../api-services/shelters/shelters-api.service';
import { CitiesApiService, CityDto } from '../../../../api-services/cities/cities-api.service';
import { AnimalStatusesApiService, AnimalStatusDto } from '../../../../api-services/animal-statuses/animal-statuses-api.service';
import { ToasterService } from '../../../../core/services/toaster.service';

export interface AnimalUpsertDialogData {
  animal?: ListAnimalsQueryDto;
}

@Component({
  selector: 'app-animal-upsert-dialog',
  standalone: false,
  templateUrl: './animal-upsert-dialog.component.html',
  styleUrl: './animal-upsert-dialog.component.scss'
})
export class AnimalUpsertDialogComponent implements OnInit {
  private fb = inject(FormBuilder);
  private animalsApi = inject(AnimalsApiService);
  private breedsApi = inject(BreedsApiService);
  private animalTypesApi = inject(AnimalTypesApiService);
  private sheltersApi = inject(SheltersApiService);
  private citiesApi = inject(CitiesApiService);
  private animalStatusesApi = inject(AnimalStatusesApiService);
  private toaster = inject(ToasterService);
  private dialogRef = inject(MatDialogRef<AnimalUpsertDialogComponent>);

  @Inject(MAT_DIALOG_DATA) data: AnimalUpsertDialogData;

  form!: FormGroup;
  isEditMode = false;
  isLoading = false;
  isLoadingDropdowns = true;

  breeds: BreedDto[] = [];
  filteredBreeds: BreedDto[] = [];
  animalTypes: AnimalTypeDto[] = [];
  shelters: ShelterDto[] = [];
  cities: CityDto[] = [];
  animalStatuses: AnimalStatusDto[] = [];

  genderOptions = [
    { value: 'Muški', label: 'Muški' },
    { value: 'Ženski', label: 'Ženski' }
  ];

  constructor(@Inject(MAT_DIALOG_DATA) data: AnimalUpsertDialogData) {
    this.data = data;
    this.isEditMode = !!data?.animal;
  }

  ngOnInit(): void {
    this.buildForm();
    this.loadDropdowns();
  }

  private buildForm(): void {
    const a = this.data?.animal;
    this.form = this.fb.group({
      name: [a?.name ?? '', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      description: [a?.description ?? '', Validators.maxLength(500)],
      age: [a?.age ?? null, [Validators.required, Validators.min(0), Validators.max(50)]],
      gender: [a?.gender ?? '', Validators.required],
      animalTypeId: [a?.animalTypeId ?? null, Validators.required],
      breedId: [a?.breedId ?? null, Validators.required],
      shelterId: [a?.shelterId ?? null, Validators.required],
      cityId: [a?.cityId ?? null, Validators.required],
      animalStatusId: [a?.animalStatusId ?? null, Validators.required],
      ownerId: [a?.ownerId ?? 1],
      isVaccinated: [a?.isVaccinated ?? false],
      isSterilized: [a?.isSterilized ?? false]
    });

    this.form.get('animalTypeId')!.valueChanges.subscribe(typeId => {
      this.filteredBreeds = typeId
        ? this.breeds.filter(b => b.animalTypeId === typeId)
        : this.breeds;
      if (this.form.get('breedId')!.value) {
        const currentBreed = this.breeds.find(b => b.id === this.form.get('breedId')!.value);
        if (currentBreed && currentBreed.animalTypeId !== typeId) {
          this.form.get('breedId')!.setValue(null);
        }
      }
    });
  }

  private loadDropdowns(): void {
    forkJoin({
      breeds: this.breedsApi.list(),
      animalTypes: this.animalTypesApi.list(),
      shelters: this.sheltersApi.list(),
      cities: this.citiesApi.list(),
      animalStatuses: this.animalStatusesApi.list()
    }).subscribe({
      next: (result) => {
        this.breeds = result.breeds;
        this.animalTypes = result.animalTypes;
        this.shelters = result.shelters;
        this.cities = result.cities;
        this.animalStatuses = result.animalStatuses;

        const typeId = this.form.get('animalTypeId')!.value;
        this.filteredBreeds = typeId
          ? this.breeds.filter(b => b.animalTypeId === typeId)
          : this.breeds;

        this.isLoadingDropdowns = false;
      },
      error: () => {
        this.toaster.error('Greška pri učitavanju podataka');
        this.isLoadingDropdowns = false;
      }
    });
  }

  onSubmit(): void {
    this.form.markAllAsTouched();
    if (this.form.invalid || this.isLoading) return;

    this.isLoading = true;
    const v = this.form.value;

    if (this.isEditMode && this.data.animal) {
      this.animalsApi.update({
        id: this.data.animal.id,
        name: v.name,
        description: v.description || null,
        age: v.age,
        gender: v.gender,
        breedId: v.breedId,
        animalTypeId: v.animalTypeId,
        shelterId: v.shelterId,
        ownerId: v.ownerId ?? 1,
        cityId: v.cityId,
        animalStatusId: v.animalStatusId,
        isVaccinated: v.isVaccinated,
        isSterilized: v.isSterilized
      }).subscribe({
        next: () => {
          this.toaster.success('Životinja uspješno izmijenjena');
          this.dialogRef.close(true);
        },
        error: () => {
          this.toaster.error('Greška pri izmjeni životinje');
          this.isLoading = false;
        }
      });
    } else {
      this.animalsApi.create({
        name: v.name,
        description: v.description || null,
        age: v.age,
        gender: v.gender,
        breedId: v.breedId,
        animalTypeId: v.animalTypeId,
        shelterId: v.shelterId,
        ownerId: v.ownerId ?? 1,
        cityId: v.cityId,
        animalStatusId: v.animalStatusId,
        isVaccinated: v.isVaccinated,
        isSterilized: v.isSterilized
      }).subscribe({
        next: () => {
          this.toaster.success('Životinja uspješno dodana');
          this.dialogRef.close(true);
        },
        error: () => {
          this.toaster.error('Greška pri dodavanju životinje');
          this.isLoading = false;
        }
      });
    }
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }

  hasError(controlName: string, errorType?: string): boolean {
    const control = this.form.get(controlName);
    if (!control || !control.touched) return false;
    return errorType ? control.hasError(errorType) : control.invalid;
  }
}
