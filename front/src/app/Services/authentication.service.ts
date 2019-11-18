import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private cookieService: CookieService,private router:Router) { }

  private Token: string;
  private emailLogin: string;

  Url = environment.url + 'Authentication/login';

  sair(){
    this.cookieService.delete('JwtToken');
    this.cookieService.delete('token');
    this.router.navigate(['/']);
  }

  getEmailUser(){
    return this.cookieService.get('emailUser');
  }


  getToken() {
    if (!this.Token && this.cookieService.check('JwtToken')) {
      this.Token = this.cookieService.get('JwtToken');
    }
    return this.Token;
  }

  //deve checar email se é de médico para mostrar a tela certa de acordo com cada usuário
  postAuthentication(email: string, password: string) {
    var observable = this.http.post(this.Url, { email, password });
    observable.subscribe((tokenDto) => {
      this.Token = tokenDto['token'];
      this.cookieService.set('JwtToken', this.Token);
      this.cookieService.set('emailUser', email);
      
    });
    return observable;
  }
}
