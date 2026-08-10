import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface AnimalStatusDto {
  id: number;
  name: string;
}

@Injectable({ providedIn: 'root' })
export class AnimalStatusesApiService {
  private readonly baseUrl = `${environment.apiUrl}/animal-statuses`;
  private http = inject(HttpClient);

  list(): Observable<AnimalStatusDto[]> {
    return this.http.get<AnimalStatusDto[]>(this.baseUrl);
  }
}
