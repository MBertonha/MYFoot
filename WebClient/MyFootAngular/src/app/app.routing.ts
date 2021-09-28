import { ModuleWithProviders } from "@angular/compiler/src/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { RecuperacaoSenhaComponent } from "./pages/recuperacao-senha/recuperacao-senha.component";

const APP_ROUTES: Routes = [
    { path: '', component: LoginPageComponent },
    { path: 'home', component: HomeComponent},
    { path: 'recuperacao', component: RecuperacaoSenhaComponent}
]

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES); 