import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface CityDto {
  id: number;
  name: string;
}

@Injectable({ providedIn: 'root' })
export class CitiesApiService {
  private readonly baseUrl = `${environment.apiUrl}/cities`;
  private http = inject(HttpClient);

  list(): Observable<CityDto[]> {
    return this.http.get<CityDto[]>(this.baseUrl);
  }
}
