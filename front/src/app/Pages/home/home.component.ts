import { Component, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl,Validators } from '@angular/forms';
import { faHospital } from '@fortawesome/free-solid-svg-icons';
import { AuthorizationService } from 'src/app/Services/authorization.service';
import { Usuario } from 'src/app/Models/Usuario';
import { CookieService } from 'ngx-cookie-service';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],

})
export class HomeComponent implements OnInit {
  faHospital = faHospital;
  token: any;
  cookieValue:string;

  constructor(private router: Router
    , private service: AuthorizationService
    , private user: Usuario
  
  ) { }

  ngOnInit() {}

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);
  
  getErrorMessage() {
    return this.email.hasError('required') ? 'O campo está vázio' :
        this.email.hasError('email') ? 'Email não válido' :
            '';
  }
  getErrorMessagePassword() {
    return this.email.hasError('required') ? 'O campo está vázio' :
        
            '';
  }

  Logar() {
    var email = (<HTMLInputElement>document.getElementById("email")).value;
    var password = (<HTMLInputElement>document.getElementById("password")).value;
    this.user.email = email;
    this.user.password = password;

    this.service.postAuthentication(email, password).subscribe(data => {
      this.token = data;
      localStorage.setItem('token',this.token);
      console.log(localStorage.getItem('token'));
    
      if (this.token != null) {
        this.router.navigate(["dashboard"])
      }
    });
  }


}
