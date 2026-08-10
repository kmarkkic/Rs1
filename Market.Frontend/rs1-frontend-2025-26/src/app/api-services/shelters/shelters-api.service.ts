import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface ShelterDto {
  id: number;
  name: string;
  cityId: number;
}

@Injectable({ providedIn: 'root' })
export class SheltersApiService {
  private readonly baseUrl = `${environment.apiUrl}/shelters`;
  private http = inject(HttpClient);

  list(): Observable<ShelterDto[]> {
    return this.http.get<ShelterDto[]>(this.baseUrl);
  }
}
