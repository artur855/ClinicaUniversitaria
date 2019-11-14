import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  private Token: string;
  private emailLogin: string;

  Url = environment.url + 'Authentication/login';

  sair(){
    this.cookieService.delete('JwtToken');
    this.cookieService.delete('token');
    //retornar id do médico se for médico
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
      console.log(tokenDto);
      this.Token = tokenDto['token'];
      this.cookieService.set('JwtToken', this.Token);
      this.cookieService.set('emailLogin', this.emailLogin);
    });
    return observable;
  }
}
