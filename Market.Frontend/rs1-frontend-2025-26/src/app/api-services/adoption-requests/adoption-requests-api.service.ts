import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AdoptionRequestDto, CreateAdoptionRequestRequest } from './adoption-requests-api.models';

@Injectable({ providedIn: 'root' })
export class AdoptionRequestsApiService {
  private readonly baseUrl = `${environment.apiUrl}/adoption-requests`;
  private http = inject(HttpClient);

  create(request: CreateAdoptionRequestRequest): Observable<AdoptionRequestDto> {
    return this.http.post<AdoptionRequestDto>(this.baseUrl, request);
  }

  list(): Observable<AdoptionRequestDto[]> {
    return this.http.get<AdoptionRequestDto[]>(this.baseUrl);
  }

  getById(id: number): Observable<AdoptionRequestDto> {
    return this.http.get<AdoptionRequestDto>(`${this.baseUrl}/${id}`);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
