import { Inject, Injectable } from '@angular/core';
import { appsettings } from '../../settings/appsettings';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sala } from '../models/sala';
import { UsuarioEdit } from '../models/UsuarioEdit';

@Injectable({
  providedIn: 'root'
})
export class PanelUsuariosService {

 
  private baseUrl:string = appsettings.apiUrl;

  constructor(private http: HttpClient) {}

  // Método para actualizar un usuario
  traerSalas(): Observable<Sala[]> {
    return this.http.get<Sala[]>(`${this.baseUrl}Sala/TraerTodasLasSalas`);
  }

  traerUsuarios(): Observable<UsuarioEdit[]> {
    return this.http.get<UsuarioEdit[]>(`${this.baseUrl}User/TraerTodosUsuarios`);
  }


}
