import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { appsettings } from '../settings/appsettings';

@Injectable({
  providedIn: 'root'
})
export class ModalEditSalaService {

  private baseUrl:string = appsettings.apiUrl;

  constructor(private http: HttpClient) {}

  // Método para actualizar un usuario
  updateSala(sala: any): Observable<any> {
    return this.http.put(`${this.baseUrl}Sala/ActualizarSala`, sala); // Asegúrate de que la URL sea la correcta
  }

  deleteSala(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}Sala/BorrarSala?id=${id}`);
  }

}
