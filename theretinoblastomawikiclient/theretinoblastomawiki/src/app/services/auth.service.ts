import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  //path to BE 
  private loginPath = environment.apiUrl + "identity/login"
  private registerPath = environment.apiUrl + "identity/register"
  // injected in the constructor, the service will be used by dependency injection
  constructor(private http: HttpClient) { }

  // data = payload send to the back end , observable is similar to promise

  login(data): Observable<any> {
    return this.http.post(this.loginPath, data)
  }

  register(data): Observable<any> {
    return this.http.post(this.registerPath, data)
  }

  // save the JWT token

  saveToken(token){
    localStorage.setItem('token', token)
  }

  getToken(){
    return localStorage.getItem('token')
  }
}
