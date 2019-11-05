import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ExamRequest, TypeExam } from 'src/app/Models/ExamRequest';
import { MAT_DATE_LOCALE, DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import * as moment from 'moment';
import { Router } from '@angular/router';
import { ExamrequestService } from 'src/app/Services/examrequest.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MedicService } from 'src/app/Services/medico.service';
import { PatientService } from 'src/app/Services/pacient.service';

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
  values = []

  crms = [];
  patientsId = [];
  constructor(
    private router: Router,
    private service: ExamrequestService,
    private _snackBar: MatSnackBar,
    private serviceMed: MedicService,
    private servicePat: PatientService) { }

  private addExamForm = new FormGroup({
    hypothesis: new FormControl(''),
    expectedDate: new FormControl({ value: '', updateOn: 'submit' }),
    examName: new FormControl(''),
    recomendation: new FormControl(''),
    medicCrm: new FormControl(''),
    patientId: new FormControl(''),
  });

  ngOnInit() {
    this.exams = Object.keys(this.tpExam)
    for (let i = 0; i < 4; i++) {
      this.values[i] = this.exams[i + 4]
    }
    this.serviceMed.getMedicos().subscribe(data => {
      for (let i = 0; i < data.length; i++) {
        this.crms[i] = data[i].crm
      }
    });
    this.servicePat.getPatients().subscribe(data => {
      for (let i = 0; i < data.length; i++) {
        this.patientsId[i] = data[i].id;
      }
    });

  }

  onSubmit() {
    var date = this.addExamForm.controls.expectedDate
    date.setValue(moment(date.value).format('L'));
    //console.log(date.value)
    //Caso não queira usar resetando o form deve-se extrair a data pois o control aceita apenas Moment
    //e quando retorna apenas a data ele mostra o control como invalid
    //var dateTrated = moment(date.value).format('L');
    var examRequest = new ExamRequest();
    examRequest = this.addExamForm.value;
    //console.log(this.addExamForm.value);
    this.service.createExam(examRequest).subscribe(() => {
      var newWin = window.open();
      //newWin.document.write(htmlPedido);
      // newWin.document.write("htmlPedido");
      // newWin.document.write("pedido.html");
      // newWin.document.write(pedido.html);
      // newWin.document.write(pedidohtml);

    });
    this.router.navigate(["dashboard"]);
    this.addExamForm.reset('')
  }

Voltar() {
  this.router.navigate(["dashboard"]);
}

openSnackBarPat() {
  var message = "Exame adicionado com sucesso!"
  var action = "Fechar"
  this._snackBar.open(message, action, {
    duration: 2000,
  });
}
}
