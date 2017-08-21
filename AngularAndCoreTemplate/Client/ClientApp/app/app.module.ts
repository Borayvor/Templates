import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, Headers } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';

import { HttpRequestService } from './services/http-request.service';
import { AuthService } from './services/auth.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './page_components/navmenu/navmenu.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [
    HttpRequestService,
    AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
