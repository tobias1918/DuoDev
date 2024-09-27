import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { appsettings } from '../../../settings/appsettings';
import { salaResponseList } from '../models/salaResponseList';
import { salaRequest } from './../models/salasRequest';
import { crearReservaParam } from './../models/crearReservaParam';

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

  crearReserva(crearReservaParam:crearReservaParam):Observable<any>{
    return this.http.post<any>(`${this.baseUrl}Reserva/createReserva`,crearReservaParam)
  }



}
