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
import * as moment from 'moment';

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
    var date =this.editMedForm.controls.expectedDate 
    date.setValue(moment(date.value).format('L'));

    patient.user = new Usuario();
    //patient.examRequests = new ExamRequest()[''] ;
    patient.sex = this.editMedForm.controls.sex.value
    patient.color = this.editMedForm.controls.color.value
    patient.birthdate = date.value
    patient.user.name= this.editMedForm.controls.name.value
    patient.user.email = this.editMedForm.controls.email.value
    //patient.examRequests = [];
    this.service.updatePatient(patient).subscribe(data => {
      this.patient = data;
      this.router.navigate(["dashboard"]);
    });
  

  }

  openSnackBarPat() {
    var message = "Paciente atualizado"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

}
