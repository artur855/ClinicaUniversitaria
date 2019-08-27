import { Component, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { faHospital } from '@fortawesome/free-solid-svg-icons';
import { Usuario } from 'src/app/Models/Usuario';
import { AuthenticationService } from 'src/app/Services/authentication.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],

})
export class HomeComponent implements OnInit {
  faHospital = faHospital;
  public error: String;

  constructor(private router: Router
    , private service: AuthenticationService
    , private user: Usuario
  ) { }

  ngOnInit() {
  }
  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  Logar() {
    var email = (<HTMLInputElement>document.getElementById("email")).value;
    var password = (<HTMLInputElement>document.getElementById("password")).value;
    this.user.email = email;
    this.user.password = password;

    this.service.postAuthentication(email, password).subscribe(data => {
      if (data) {
        this.router.navigate(["dashboard"])
      }
    });
  }


}
