import { Component, OnInit, ɵConsole } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ExamRequest, TypeExam } from 'src/app/Models/ExamRequest';
import { MAT_DATE_LOCALE, DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import * as moment from 'moment';
import { Router } from '@angular/router';
import { ExamrequestService } from 'src/app/Services/examrequest.service';

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

  constructor(private router:Router,private service:ExamrequestService) { }

  private addExamForm = new FormGroup({
    hypothesis: new FormControl(''),
    expectedDate: new FormControl({value:'',  updateOn: 'submit'}),
    examName: new FormControl(''),
    recomendation: new FormControl(''),
    medicCrm:new FormControl(''),
    patientId: new FormControl(''),
  });

  onSubmit() {
    var date =this.addExamForm.controls.expectedDate 
    date.setValue(moment(date.value).format('L'));

    //Caso não queira usar resetando o form deve-se extrair a data pois o control aceita apenas Moment
    //e quando retorna apenas a data ele mostra o control como invalid
    //var dateTrated = moment(date.value).format('L');

    var examRequest = new ExamRequest();
    examRequest = this.addExamForm.value;
    console.log(examRequest)
     this.service.createExam(examRequest).subscribe(data =>{
      this.router.navigate(['list-exam-request']);
    });

  
    console.log(examRequest)
    this.addExamForm.reset('')

  }


  ngOnInit() {
    this.exams = Object.keys(this.tpExam)
    for(let i =0;i<4;i++){
     this.values[i] = this.exams[i+4]
    }
    console.log(this.values)
  }

}
