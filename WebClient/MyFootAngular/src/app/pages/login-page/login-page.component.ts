import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PoNotificationService } from '@po-ui/ng-components';
import { GeralService } from 'src/app/services/geral/geral.service';
import { LoginService } from 'src/app/services/login-page/login.service';
import { LoginResponse } from 'src/app/utilitarios/DTO/loginDto';
import {Md5} from 'ts-md5/dist/md5';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  
  formulario: FormGroup;
  dadosLogin: LoginResponse;

  constructor(private formBuilder: FormBuilder,
    private poNotification: PoNotificationService,
    private loginService: LoginService,
    private router: Router,
    private servicoGeral: GeralService) { }

  ngOnInit(): void {

    this.formulario = this.formBuilder.group({
      senha: '',
      email: ''
    })
  }

  logar(){

    const emailAux = this.formulario.controls.email.value;
    const senhaAux = this.formulario.controls.senha.value;

    const md5 = new Md5();
    let senhaCript = md5.appendStr(this.formulario.controls.senha.value).end();

    this.loginService.buscarUsuario(emailAux, senhaCript).subscribe(dados => {
      console.log(dados);
      if(dados.habilitado == false){
        this.poNotification.warning(dados.mensagemErro);
        this.formulario.controls["email"].setValue("");
        this.formulario.controls["senha"].setValue("");
      }else{
        const date = new Date();
        this.poNotification.success("Logado com sucesso");

        this.servicoGeral.dataLogin = date.getDate();
        this.servicoGeral.seqUsuario = dados.seqLogin; 
        this.servicoGeral.tipoUsuario = dados.tipoUsuario;

        this.router.navigate(['/home']);
      }

    });
    
  }
}
