import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const API_BASE_URL = 'https://localhost:7152';
const API_REFLECTION_ENDPOINT = '/api/reflection';

@Injectable({
  providedIn: 'root',
})
export class ReflectionService {
  private readonly apiUrl = `${API_BASE_URL}${API_REFLECTION_ENDPOINT}`;

  constructor(private http: HttpClient) {}

  getImporters(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/importers`);
  }
}
