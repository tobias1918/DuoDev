import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../../../settings/appsettings';
import { ListMultiReserva } from '../models/ListMultiReserva';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalaMultiplesService {

  private http=inject(HttpClient);
  private baseUrl:string = appsettings.apiUrl;

  constructor() { }


  crearMultiReservas(request:any):Observable<any>{
    console.log("crearMultiReserva")
    console.log(request[0])
    return this.http.post<any>(`${this.baseUrl}Reserva/crearMultiReserva`,request)
  }



}
