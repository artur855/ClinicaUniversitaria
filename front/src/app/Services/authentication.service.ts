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

  Url = environment.url + 'Authentication/login';

  getToken() {
    if (!this.Token && this.cookieService.check('JwtToken')) {
      this.Token = this.cookieService.get('JwtToken');
    }
    return this.Token;
  }


  postAuthentication(email: string, password: string) {
    var observable = this.http.post(this.Url, { email, password });
    observable.subscribe((tokenDto) => {
      console.log(tokenDto);
      this.Token = tokenDto['token'];
      this.cookieService.set('JwtToken', this.Token);
    });
    return observable;
  }
}
