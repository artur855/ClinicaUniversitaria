import { Component, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
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

  public profileForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(public router: Router
    , public service: AuthenticationService
  ) { }

  ngOnInit() { }

  onSubmit() {
    var user = new Usuario();
    user.email = this.profileForm.controls.email.value;
    user.password = this.profileForm.controls.password.value;
    this.service.postAuthentication(user.email, user.password).subscribe(data => {
      if (data) {
        this.router.navigate(['dashboard']);
      }
    });
  }


}
