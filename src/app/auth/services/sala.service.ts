import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../../settings/appsettings';
import { ResponseSala } from '../models/ResponseSala';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalaService {

  private http=inject(HttpClient);
  private baseUrl:string = appsettings.apiUrl;

  constructor() { }

  lista():Observable<ResponseSala>{
    return this.http.get<ResponseSala>(`${this.baseUrl}/sala/traerTodasLasSalas`)
  }

}
