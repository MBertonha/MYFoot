import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PoNotificationService } from '@po-ui/ng-components';
import { DtoResponse } from 'src/app/utilitarios/DTO/dto';
import { UsuarioResponse } from 'src/app/utilitarios/DTO/usuarioDto';
import { UrlApiPadrao } from 'src/app/utilitarios/urlApi';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient, private poNotification: PoNotificationService) { }

  apiUrl = UrlApiPadrao.endereco;

  buscarUsuario(seqLogin){
    return this.http.get<DtoResponse>(`${this.apiUrl}Usuario?SeqLogin=${seqLogin}`);
  }

  buscarTime(seqTime){
    return this.http.get<DtoResponse>(`${this.apiUrl}Time?SeqTime=${seqTime}`);
  }

  buscarJogador(seqJogador){
    return this.http.get<DtoResponse>(`${this.apiUrl}Jogador?SeqJogador=${seqJogador}`);
  }
}
