import { Component, OnInit } from '@angular/core';
import { Patient, PatientSex, PatientColor } from 'src/app/Models/Pacient';
import { Router } from '@angular/router';
import { PatientService } from 'src/app/Services/pacient.service';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from 'src/app/Models/Usuario';
import { TypeExam } from 'src/app/Models/ExamRequest';
import { FormGroup, FormControl } from '@angular/forms';
import { MedicService } from 'src/app/Services/medico.service';
import { ExamrequestService } from 'src/app/Services/examrequest.service';


@Component({
  selector: 'app-editpat',
  templateUrl: './editpat.component.html',
  styleUrls: ['./editpat.component.css'],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ],
})

export class EditpatComponent implements OnInit {
  tSex = PatientSex;
  sexPat = []
  tColor = PatientColor;
  colorsPat = []
  private patient: Patient = new Patient();
  

  private editMedForm = new FormGroup({
    sex: new FormControl(this.patient.sex),
    color : new FormControl(this.patient.color),
    expectedDate: new FormControl(this.patient.birthdate),
    name : new FormControl(this.patient.user.name),
    email : new FormControl(this.patient.user.email),
    password : new FormControl(''),
  });

  constructor(private service: PatientService,
    private router: Router,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.sexPat = Object.keys(this.tSex)
    this.colorsPat = Object.values(this.tColor)
    this.colorsPat = this.colorsPat.splice(0,5);
  }

  
  EditPat() {
    this.patient.user = new Usuario();
    let id = localStorage.getItem("idpat")
    let y: number;
    y = parseInt(id);
    this.service.getPatientId(y)
      .subscribe(data => {
        this.patient = data;
      })

  }

  AtualizarPat(patient: Patient) {
/*
    var name = (<HTMLInputElement>document.getElementById("nameP")).value;
    var email = (<HTMLInputElement>document.getElementById("emailP")).value;
    var birthdate = (<HTMLInputElement>document.getElementById("dateOfBirth")).value;
    var selectedOptionColor = this.selectedCor;
    var selectedOptionSex = this.selectedSex;
    patient.id = this.patient.id;
    patient.user.name = name;
    patient.user.email = email;
    patient.sex = selectedOptionSex;
    patient.color = selectedOptionColor;

    var dateParts = birthdate.split('/');
    var day = parseInt(dateParts[0]);
    var month = parseInt(dateParts[1]) - 1;
    var year = parseInt(dateParts[2]);

    var date = new Date(year, month, day);
    this.patient.birthdate = date;

    this.service.updatePatient(patient).subscribe(data => {
      this.patient = data;
      this.router.navigate(["dashboard"]);
    });*/
  }

  openSnackBarPat() {
    var message = "Paciente atualizado"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

}
