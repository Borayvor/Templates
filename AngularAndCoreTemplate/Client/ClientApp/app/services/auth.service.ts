import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';

import { RequestResult } from './../models/request-result';
import { UserRegisterModel } from './../models/user-register.model';

import { HttpRequestService } from './http-request.service';

import { HttpRequestOptions } from './../models/http-request-options';

@Injectable()
export class AuthService {
  private tokeyKey = 'token';
  private token: string;

  constructor(
    private http: HttpRequestService
  ) { }

  register(user: UserRegisterModel): Observable<any> {
    return this.http.post(
      '/api/Auth/Register',
      { Username: user.username, Password: user.password })
      .map(response => {
        const result = response.json() as RequestResult;

        return result;
      });
  }

  login(user: UserRegisterModel): Observable<any> {
    return this.http.post(
      '/api/Auth/Login',
      { Username: user.username, Password: user.password })
      .map(response => {
        const result = response.json() as RequestResult;

        if (result.State === 1) {
          const json = result.Data as any;

          sessionStorage.setItem('token', json.accessToken);
        }

        return result;
      });
  }

  logout() { }

  checkLogin(): boolean {
    const token = sessionStorage.getItem(this.tokeyKey);

    return token != null;
  }

  private getLocalToken(): string {
    if (!this.token) {
      this.token = sessionStorage.getItem(this.tokeyKey);
    }
    return this.token;
  }

  private initAuthHeaders(): Headers {
    const token = this.getLocalToken();

    if (token == null) {
      throw new Error('No token');
    }

    const headers = new Headers();
    headers.append('Authorization', 'Bearer ' + token);

    return headers;
  }
}
