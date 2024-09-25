import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalEditUsuarioService {

  private apiUrl = 'https://example.com/api/usuarios'; // URL de la API de ejemplo

  constructor(private http: HttpClient) {}

  // Método para actualizar un usuario
  updateUser(user: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${user.id}`, user); // Actualiza el usuario basado en su ID
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }


}
