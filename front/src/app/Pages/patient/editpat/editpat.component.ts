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

  private editPatForm = new FormGroup({
    name: new FormControl(''),
    sex: new FormControl(''),
    color: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private service: PatientService,
    private router: Router,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.EditPat();
    this.sexPat = Object.keys(this.tSex)
    this.colorsPat = Object.keys(this.tColor)
    this.colorsPat = this.colorsPat.splice(5, 5);
  }

  Voltar(){
    this.router.navigate(["dashboard"])
  }

  EditPat() {
    this.patient.user = new Usuario();
    let id = parseInt(localStorage.getItem("idpat"))
    this.patient.id = id;
    this.service.getPatientId(id)
      .subscribe(data => {
        this.patient = data;
        
        var sexSlc: string;
        if (this.patient.sex == "F") { sexSlc = "Feminino" } else { sexSlc = "Masculino" }
        this.editPatForm.controls.color.setValue(data.color);
        this.editPatForm.controls.sex.setValue(sexSlc);
        this.editPatForm.controls.name.setValue(data.name);
        this.editPatForm.controls.email.setValue(data.email);
      });
  }

  onSubmit(patient: Patient) {
    /*
    var date = this.editPatForm.controls.expectedDate
    date.setValue(moment(date.value).format('L'));
    */
    patient = new Patient();
    patient.user = new Usuario();
    patient.id = this.patient.id;
    patient.sex = this.tSex[this.editPatForm.controls.sex.value]
    patient.color = this.tColor[this.editPatForm.controls.color.value]
    patient.birthdate = this.patient.birthdate;

    patient.user.name = this.editPatForm.controls.name.value
    patient.user.password = this.editPatForm.controls.password.value
    patient.user.email = this.editPatForm.controls.email.value
    console.log(patient.id)
    this.service.updatePatient(patient).subscribe(data => {
      this.patient = data;
      this.router.navigate(["dashboard"]);
      this.openSnackBarPat();
    });
    this.editPatForm.reset('')

  }

  openSnackBarPat() {
    var message = "Paciente atualizado"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

}
