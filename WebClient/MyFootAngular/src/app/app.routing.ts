import { ModuleWithProviders } from "@angular/compiler/src/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginPageComponent } from "./pages/login-page/login-page.component";

const APP_ROUTES: Routes = [
    { path: '', component: LoginPageComponent}
]

export const routing: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES); 