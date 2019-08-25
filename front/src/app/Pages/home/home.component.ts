import { Component, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { faHospital } from '@fortawesome/free-solid-svg-icons';
import { AuthorizationService } from 'src/app/Services/authorization.service';
import { Usuario } from 'src/app/Models/Usuario';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],

})
export class HomeComponent implements OnInit {
  faHospital = faHospital;
  token: any;
  constructor(private router: Router
    , private service: AuthorizationService
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
    this.user.senha = password;
    console.log(this.user.email);
    console.log(this.user.senha);

    this.service.postAuthentication(email,password).subscribe(data => {
      this.token = data;
      if(this.token != null){
        this.router.navigate(["dashboard"])
      }
    });
  }


}
