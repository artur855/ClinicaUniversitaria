import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { EmailValidator } from '@angular/forms';
import { Usuario } from '../Models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(private http: HttpClient) { }

  Url = environment.url + "Authentication/login";

  getToken() {
    return this.http.get<String>(this.Url);
  }

 
  postAuthentication(email:string, password:string) {
    return this.http.post(this.Url,{email,password})  
  }
}
