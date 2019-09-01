import { Component, OnInit, ɵConsole } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ExamRequest, TypeExam } from 'src/app/Models/ExamRequest';
import { MAT_DATE_LOCALE, DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import * as moment from 'moment';

// export const CUSTOM_DATE_FORMAT = {
//   parse: {
//     dateInput: 'DD/MM/YYYY',
//   },
//   display: {
//     dateInput: 'DD/MM/YYYY',
//     monthYearLabel: 'MMMM YYYY',
//     dateA11yLabel: 'DD/MM/YYYY',
//     monthYearA11yLabel: 'MMMM YYYY',
//   },
// };

@Component({
  selector: 'app-pedidoexame',
  templateUrl: './pedidoexame.component.html',
  styleUrls: ['./pedidoexame.component.css'],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    // { provide: MAT_DATE_FORMATS, useValue: CUSTOM_DATE_FORMAT},
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ],
})
export class PedidoexameComponent implements OnInit {
 
  tpExam = TypeExam;
  exams = []
  values= []

  private addExamForm = new FormGroup({
    type_exame: new FormControl(''),
    data_prevista: new FormControl({value:'',  updateOn: 'submit'}),
    recomendacao: new FormControl(''),
    hipotese_cid: new FormControl(''),
    id_paciente: new FormControl(''),
  });

  onSubmit() {
    var date =this.addExamForm.controls.data_prevista 
    date.setValue(moment(date.value).format('L'));

    //Caso não queira usar resetando o form deve-se extrair a data pois o control aceita apenas Moment
    //e quando retorna apenas a data ele mostra o control como invalid
    //var dateTrated = moment(date.value).format('L');

    var examRequest = new ExamRequest();
    examRequest = this.addExamForm.value;
    
    console.log(examRequest)
    this.addExamForm.reset('')

  }

  constructor() { }

  ngOnInit() {
    this.exams = Object.keys(this.tpExam)
    for(let i =0;i<4;i++){
     this.values[i] = this.exams[i+4]
    }
    console.log(this.values)
  }

}
