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
  selected2: string = "oi"
  selectedSex = ""
  private patient: Patient = new Patient();

  private editMedForm = new FormGroup({
    name: new FormControl(''),
    sex: new FormControl(''),
    color: new FormControl(''),
    expectedDate: new FormControl({ value: '', updateOn: 'submit' }),
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
    this.service.getPatientId(id)
      .subscribe(data => {
        this.patient = data;
        var sexSlc: string;
        if (this.patient.sex == "F") { sexSlc = "Feminino" } else { sexSlc = "Masculino" }
        this.editMedForm.controls.color.setValue(this.tColor[data.color]);
        this.editMedForm.controls.sex.setValue(sexSlc);
        this.editMedForm.controls.name.setValue(data.user.name);
        this.editMedForm.controls.email.setValue(data.user.email);
        this.editMedForm.controls.password.setValue(data.user.password);

      })
  }

  onSubmit(patient: Patient) {
    var date = this.editMedForm.controls.expectedDate
    date.setValue(moment(date.value).format('L'));

    patient = new Patient();
    patient.user = new Usuario();

    patient.sex = this.tSex[this.editMedForm.controls.sex.value]
    patient.color = this.tColor[this.editMedForm.controls.color.value]
    patient.birthdate = date.value

    patient.user.name = this.editMedForm.controls.name.value
    patient.user.password = this.editMedForm.controls.password.value
    patient.user.email = this.editMedForm.controls.email.value
    console.log(patient)
    this.service.updatePatient(patient).subscribe(data => {
      this.patient = data;
      this.router.navigate(["dashboard"]);
      this.openSnackBarPat();
    });
    this.editMedForm.reset('')

  }

  openSnackBarPat() {
    var message = "Paciente atualizado"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

}
