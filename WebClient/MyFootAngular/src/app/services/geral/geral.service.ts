import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GeralService {

  seqUsuario: number;
  tipoUsuario: number;
  dataLogin: number;

  constructor() { }
}
