import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ExamRequest, TypeExam } from 'src/app/Models/ExamRequest';

@Component({
  selector: 'app-pedidoexame',
  templateUrl: './pedidoexame.component.html',
  styleUrls: ['./pedidoexame.component.css']
})
export class PedidoexameComponent implements OnInit {
  
  exams : TypeExam[];
  
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
