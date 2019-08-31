import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-pedidoexame',
  templateUrl: './pedidoexame.component.html',
  styleUrls: ['./pedidoexame.component.css']
})
export class PedidoexameComponent implements OnInit {
 
  profileForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
  });

  onSubmit() {
    console.log(this.profileForm.get('firstName').value);
  }
  
  constructor() { }

  ngOnInit() {
  }

}
