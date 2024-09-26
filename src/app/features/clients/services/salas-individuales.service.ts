import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { appsettings } from '../../../settings/appsettings';
import { salaResponseList } from '../models/salaResponseList';
import { salaRequest } from './../models/salasRequest';

@Injectable({
  providedIn: 'root'
})
export class SalaService {

  private http=inject(HttpClient);
  private baseUrl:string = appsettings.apiUrl;

  constructor() { }

  salasDisponibles(request:salaRequest):Observable<salaResponseList>{
    return this.http.post<salaResponseList>(`${this.baseUrl}Reserva/reservasDisponible`,request)
  }

}
