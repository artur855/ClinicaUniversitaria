import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Patient, PatientSex, PatientColor } from 'src/app/Models/Pacient';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { Router } from '@angular/router';
import { PatientService } from 'src/app/Services/pacient.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from 'src/app/Models/Usuario';
//import { ExamRequest } from 'src/app/Models/ExamRequest';
import {faSignOutAlt} from '@fortawesome/free-solid-svg-icons';
import * as moment from 'moment';
import { AuthenticationService } from 'src/app/Services/authentication.service';
@Component({
  selector: 'app-addpat',
  templateUrl: './addpat.component.html',
  styleUrls: ['./addpat.component.css'],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    // { provide: MAT_DATE_FORMATS, useValue: CUSTOM_DATE_FORMAT},
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ],
})

export class AddpatComponent implements OnInit {
  tSex = PatientSex;
  sexPat = []
  tColor = PatientColor;
  colorsPat = []

  faSignOutAlt= faSignOutAlt;

  private addMedForm = new FormGroup({
    sex: new FormControl(''),
    color: new FormControl(''),
    expectedDate: new FormControl(''),
    name: new FormControl(''),
    password: new FormControl(''),
    email: new FormControl(''),
  });

  constructor(private service: PatientService,
              private router: Router,
              private _snackBar: MatSnackBar,
              private serviceAuth: AuthenticationService) { }

  ngOnInit() {
    this.sexPat = Object.keys(this.tSex)
    this.colorsPat = Object.keys(this.tColor)
    this.colorsPat = this.colorsPat.splice(5, 5);
  }

  sair(){
    this.serviceAuth.sair();
  }

  Voltar() {
    this.router.navigate(["dashboard"]);
  }

  onSubmit() {
    var date = this.addMedForm.controls.expectedDate
    date.setValue(moment(date.value).format('L'));

    var patient = new Patient();
    patient.user = new Usuario();

    patient.sex = this.tSex[this.addMedForm.controls.sex.value]
    patient.color = this.tColor[this.addMedForm.controls.color.value]
    patient.birthdate = date.value
    patient.user.name = this.addMedForm.controls.name.value
    patient.user.password = this.addMedForm.controls.password.value
    patient.user.email = this.addMedForm.controls.email.value
    console.log(patient);
    this.service.createPatient(patient).subscribe(data => {
      patient = data;
      this.router.navigate(["dashboard"]);
      this.openSnackBarPat()
    });
    this.addMedForm.reset('')
  }

  openSnackBarPat() {
    var message = "Paciente adicionado!"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
