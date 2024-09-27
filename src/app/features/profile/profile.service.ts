import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { appsettings } from '../../settings/appsettings';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http=inject(HttpClient);
  private baseUrl:string = appsettings.apiUrl;

  constructor() { }

  getUser(id:number):Observable<any>{
    return this.http.get<any>(`${this.baseUrl}User/TraerUsuarioPorID?id=${id}`)
  }

  editPerfil(user:any):Observable<any>{
    return this.http.put<any>(`${this.baseUrl}User/ActualizarUser`,user)
  }



 


}
