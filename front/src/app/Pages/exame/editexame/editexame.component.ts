import { Component, OnInit } from '@angular/core';
import { ExamRequest, TypeExam } from 'src/app/Models/ExamRequest';
import { Router } from '@angular/router';
import { ExamrequestService } from 'src/app/Services/examrequest.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormGroup, FormControl } from '@angular/forms';
import { MAT_DATE_LOCALE, DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import * as moment from 'moment';

@Component({
  selector: 'app-editexame',
  templateUrl: './editexame.component.html',
  styleUrls: ['./editexame.component.css'],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    // { provide: MAT_DATE_FORMATS, useValue: CUSTOM_DATE_FORMAT},
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ],
})
export class EditexameComponent implements OnInit {
  exam: ExamRequest = new ExamRequest();

  //exams values e tpexam são utilizados para extrair os dados do enum
  exams = []
  values = []
  tpExam = TypeExam;

  //criação form
  private editExamForm = new FormGroup({
    crm_medico: new FormControl(''),
    type_exame: new FormControl(''),
    data_prevista: new FormControl({ value: '', updateOn: 'submit' }),
    recomendacao: new FormControl(''),
    hipotese_cid: new FormControl(''),
    id_paciente: new FormControl(''),
  });

  constructor(private router: Router, private service: ExamrequestService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    //pegando id do medico
    this.Editar

    //setando valor do enum na array values
    this.exams = Object.keys(this.tpExam)
    for (let i = 0; i < 4; i++) {
      this.values[i] = this.exams[i + 4]
    }
  }

  //Pegando Id do exame do LocalStorage e setando id
  Editar() {
    let idExam = parseInt(localStorage.getItem("idExam"));
    this.exam.id = idExam
    this.service.getExamId(idExam)
      .subscribe(data => {
        this.exam = data;
      })

  }
  onSubmit(exam: ExamRequest) {
    var date = this.editExamForm.controls.data_prevista
    date.setValue(moment(date.value).format('L'));

    //Caso não queira usar resetando o form deve-se extrair a data pois o control aceita apenas Moment
    //e quando retorna apenas a data ele mostra o control como invalid
    //var dateTrated = moment(date.value).format('L');

    var examRequest = new ExamRequest();
    examRequest = this.editExamForm.value;

    this.service.updateExam(exam)
      .subscribe(data => {
        this.exam = data;
        this.router.navigate(["list-exam-request"]);
      });

    this.editExamForm.reset('')
    console.log(examRequest)

  }
  openSnackBarPat() {
    var message = "Exame atualizado!"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
} 
