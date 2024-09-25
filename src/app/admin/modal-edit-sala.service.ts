import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalEditSalaService {

  private apiUrl = 'https://example.com/api/usuarios'; // URL de la API de ejemplo

  constructor(private http: HttpClient) {}

  // Método para actualizar un usuario
  updateSala(sala: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${sala.id}`, sala); // Actualiza el usuario basado en su ID
  }

  deleteSala(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
