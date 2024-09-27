import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { appsettings } from '../settings/appsettings';
import { UsuarioEdit } from './models/UsuarioEdit';

@Injectable({
  providedIn: 'root'
})
export class ModalEditUsuarioService {

  private baseUrl:string = appsettings.apiUrl;

  constructor(private http: HttpClient) {}

  // Método para actualizar un usuario
   // Método para actualizar un usuario
   updateUser(UsuarioEdit: UsuarioEdit): Observable<any> {
    return this.http.put(`${this.baseUrl}User/ActualizarUser`, UsuarioEdit); // Asegúrate de que la URL sea la correcta
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}User/BorrarUser?id=${id}`);
  }


}
