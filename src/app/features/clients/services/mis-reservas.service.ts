import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { appsettings } from '../../../settings/appsettings';
import { salaResponseList } from '../models/salaResponseList';
import { salaRequest } from './../models/salasRequest';
import { crearReservaParam } from './../models/crearReservaParam';
import { reservaModel } from '../models/reservaModel';

@Injectable({
  providedIn: 'root'
})
export class MisReservasService {

  private http=inject(HttpClient);
  private baseUrl:string = appsettings.apiUrl;

  constructor() { }

  getUserSalasSimples(id:number):Observable<reservaModel[]>{
    return this.http.get<reservaModel[]>(`${this.baseUrl}Reserva/getUserReservaSimples?idUser=${id}`)
  }

  getUserSalasMultiples(id: number): Observable<reservaModel[][]> {
    return this.http.get<reservaModel[][]>(`${this.baseUrl}Reserva/getUserReservaMultiples?idUser=${id}`);
  }


 


}
