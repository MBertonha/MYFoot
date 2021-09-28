import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PoNotificationService } from '@po-ui/ng-components';
import { LoginResponse } from 'src/app/utilitarios/DTO/loginDto';
import { UrlApiPadrao } from 'src/app/utilitarios/urlApi';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private poNotification: PoNotificationService) { }

  apiUrl = UrlApiPadrao.endereco;

  buscarUsuario(email, senha){
    return this.http.get<LoginResponse>(`${this.apiUrl}Login/usuario?email=${email}&senha=${senha}`);
  }
}
