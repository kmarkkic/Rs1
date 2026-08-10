import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface AnimalTypeDto {
  id: number;
  name: string;
}

@Injectable({ providedIn: 'root' })
export class AnimalTypesApiService {
  private readonly baseUrl = `${environment.apiUrl}/animal-types`;
  private http = inject(HttpClient);

  list(): Observable<AnimalTypeDto[]> {
    return this.http.get<AnimalTypeDto[]>(this.baseUrl);
  }
}
