import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { PoModule } from '@po-ui/ng-components';
import { routing } from './app.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PoTemplatesModule } from '@po-ui/ng-templates';
import { RecuperacaoSenhaComponent } from './pages/recuperacao-senha/recuperacao-senha.component';
import { HomeComponent } from './pages/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './services/login-page/login.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminIndexComponent } from './pages/admin-index/admin-index.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    HomeComponent,
    RecuperacaoSenhaComponent,
    AdminIndexComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    PoModule,
    PoTemplatesModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    routing
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
