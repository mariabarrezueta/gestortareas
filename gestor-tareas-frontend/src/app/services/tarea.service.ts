import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tarea } from '../models/tarea.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TareaService {
  private apiUrl = 'https://gestortareas20250629235635-f8aud6huetdyaqhy.canadacentral-01.azurewebsites.net/api/tarea' ;

  constructor(private http: HttpClient) {}

  getTareas(): Observable<Tarea[]> {
    return this.http.get<Tarea[]>(this.apiUrl);
  }

  crearTarea(tarea: Tarea): Observable<Tarea> {
    return this.http.post<Tarea>(this.apiUrl, tarea);
  }

  eliminarTarea(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  actualizarTarea(id: number, tarea: Tarea): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, tarea);
  }
}

