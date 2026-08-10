import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface BreedDto {
  id: number;
  name: string;
  animalTypeId: number;
}

@Injectable({ providedIn: 'root' })
export class BreedsApiService {
  private readonly baseUrl = `${environment.apiUrl}/breeds`;
  private http = inject(HttpClient);

  list(): Observable<BreedDto[]> {
    return this.http.get<BreedDto[]>(this.baseUrl);
  }
}
