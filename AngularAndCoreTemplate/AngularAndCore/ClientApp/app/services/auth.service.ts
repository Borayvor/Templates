import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { RequestResult } from './../models/request-result';
import { UserRegisterModel } from './../models/user-register.model';

@Injectable()
export class AuthService {
  private tokeyKey = 'token';
  private token: string;

  constructor(
    private http: Http
  ) { }

  register(user: UserRegisterModel) {
    this.http.post('/api/Auth/Register', { Username: user.username, Password: user.password })
      .subscribe(resp => {
        console.log(resp.headers.get('X-XSRF-TOKEN'));
      });
  }

  login(user: UserRegisterModel): Promise<RequestResult> {
    return this.http.post('/api/Auth/Login', { Username: user.username, Password: user.password })
      .toPromise()
      .then(response => {
        const result = response.json() as RequestResult;

        if (result.State === 1) {
          const json = result.Data as any;

          sessionStorage.setItem('token', json.accessToken);
        }
        return result;
      })
      .catch(this.handleError);
  }

  logout() { }

  checkLogin(): boolean {
    const token = sessionStorage.getItem(this.tokeyKey);

    return token != null;
  }

  getUserInfo(): Promise<RequestResult> {
    return this.authGet('/api/Auth');
  }

  private authPost(url: string, body: any): Promise<RequestResult> {
    const headers = this.initAuthHeaders();

    return this.http.post(url, body, { headers: headers }).toPromise()
      .then(response => response.json() as RequestResult)
      .catch(this.handleError);
  }

  private authGet(url): Promise<RequestResult> {
    const headers = this.initAuthHeaders();

    return this.http.get(url, { headers: headers }).toPromise()
      .then(response => response.json() as RequestResult)
      .catch(this.handleError);
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

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);

    return Promise.reject(error.message || error);
  }
}
