import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs';
import { BaseService } from './base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/Rx';
import { UserRegistration } from '../models/user-registration';
import { ConfigService } from '../utils/config.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable()
export class UserService extends BaseService {
  baseUrl: string = '';

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;
  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }
  register(email: string, password: string, firstname: string, lastname: string): Observable<UserRegistration> {
    let body = JSON.stringify({ email, password, firstname, lastname });
    return this.http.post(this.baseUrl + "/accounts", body, httpOptions).map(res => true).catch(this.handleError);
  }
  login(userName, password) {
    return this.http
      .post(
        this.baseUrl + '/auth/login', JSON.stringify({ userName, password }), httpOptions)
      .map(res => JSON.parse(JSON.stringify(res)))
      .map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        localStorage.setItem('auth_access', res.access);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      })
      .catch(this.handleError);
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }  
}
