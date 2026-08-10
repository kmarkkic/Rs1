import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ListAnimalsRequest, ListAnimalsResponse, ListAnimalsQueryDto } from './animals-api.models';
import { buildHttpParams } from '../../core/models/build-http-params';

@Injectable({ providedIn: 'root' })
export class AnimalsApiService {
  private readonly baseUrl = `${environment.apiUrl}/Animal`;
  private http = inject(HttpClient);

  list(request?: ListAnimalsRequest): Observable<ListAnimalsResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;
    return this.http.get<ListAnimalsResponse>(this.baseUrl, { params });
  }

  getById(id: number): Observable<ListAnimalsQueryDto> {
    return this.http.get<ListAnimalsQueryDto>(`${this.baseUrl}/${id}`);
  }
}