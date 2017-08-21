import { Injectable } from '@angular/core';
import { Http, Headers, Request, Response, RequestOptions, RequestOptionsArgs } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { HttpRequestOptions } from './../models/http-request-options';

@Injectable()
export class HttpRequestService {

  constructor(private http: Http) { }

  get(url: string, content = {}, headers = {}): Observable<Response> {
    const httpRequestOptions = this.createHttpRequesterOptions(url, content, headers);

    return this.http.get(httpRequestOptions.url, httpRequestOptions.headers)
      .map(this.extractData)
      .catch(this.handleError);
  }

  post(url: string, content = {}, headers = {}): Observable<Response> {
    const httpRequestOptions = this.createHttpRequesterOptions(url, content, headers);

    return this.http.post(httpRequestOptions.url, httpRequestOptions.content, httpRequestOptions.headers)
      .map(this.extractData)
      .catch(this.handleError);
  }

  put(url: string, content = {}, headers = {}): Observable<Response> {
    const httpRequestOptions = this.createHttpRequesterOptions(url, content, headers);

    return this.http.put(httpRequestOptions.url, httpRequestOptions.content, httpRequestOptions.headers)
      .map(this.extractData)
      .catch(this.handleError);
  }

  private extractData(res: Response): {} {
    const body = res;

    return body || {};
  }

  private handleError(error: Response | any) {
    let errMsg: string;

    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }

    console.error(errMsg);

    return Observable.throw(errMsg);
  }

  private createHttpRequesterOptions(url: string, content = {}, headers = {}): HttpRequestOptions {
    content = typeof content !== 'object' ? { content } : content;
    headers = !this.isEmptyObject(headers) ? new Headers(headers) : headers;

    return { url, content, headers };
  }

  private isEmptyObject(obj: object): boolean {
    return Object.keys(obj).length === 0 && obj.constructor === Object;
  }

}
