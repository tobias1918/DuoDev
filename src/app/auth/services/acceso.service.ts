import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../../settings/appsettings';
import { Observable } from 'rxjs';
import { ResponseAcceso } from './../models/ResponseAcceso';
import { Usuario } from '../models/Usuario';
import { Login } from '../models/Login';

@Injectable({
  providedIn: 'root'
})
export class AccesoService {

  private http=inject(HttpClient);
  private baseUrl:string = appsettings.apiUrl;

  constructor() { }

  registrarse(objeto:Usuario):Observable<ResponseAcceso>{
    return this.http.post<ResponseAcceso>(`${this.baseUrl}User/CrearUser`,objeto)
  }

  login(objeto:Login):Observable<ResponseAcceso>{
    return this.http.post<ResponseAcceso>(`${this.baseUrl}User/Login`,objeto)
  }

  validarToken(token:string):Observable<ResponseAcceso>{
    return this.http.get<ResponseAcceso>(`${this.baseUrl}User/ValidarToken?token${token}`)
  }


}
