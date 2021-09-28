import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PoNotificationService } from '@po-ui/ng-components';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  
  formulario: FormGroup;

  constructor(private formBuilder: FormBuilder, private poNotification: PoNotificationService) { }

  ngOnInit(): void {

    this.formulario = this.formBuilder.group({
      senha: '',
      email: ''
    })
  }
}
