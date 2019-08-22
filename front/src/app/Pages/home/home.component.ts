import { Component, OnInit, Input, Output , EventEmitter, ElementRef} from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { faHospital} from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  
})
export class HomeComponent implements OnInit {
  faHospital = faHospital;
  constructor(private router:Router) { }

  ngOnInit() {
  }
  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });


  Logar(){
    this.router.navigate(["dashboard"])
  }

}
