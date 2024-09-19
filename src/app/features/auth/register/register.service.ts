import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUsuario } from '../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private _http = inject(HttpClient);
  private urlBase:string = 'https://e22b89b2-ee4e-4f4a-a276-cd76a4473efc.mock.pstmn.io/api/usuario';

  getUsuarios():Observable<IUsuario[]>{
    return this._http.get<IUsuario[]>(this.urlBase);
  }




}
