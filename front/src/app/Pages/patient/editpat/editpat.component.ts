import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/Models/Pacient';
import { Router } from '@angular/router';
import { PatientService } from 'src/app/Services/pacient.service';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSnackBar } from '@angular/material/snack-bar';


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
  sexPat = [
    { name: "Masculino", value: "M" },
    { name: "Feminino", value: "F" },
  ]
  colorsPat = [
    { name: "Branco", value: 0 },
    { name: "Negro", value: 1 },
    { name: "Pardo", value: 2 },
    { name: "Indigena", value: 3 },
    { name: "Nao Especificado", value: 4 },
  ]
  selectedCor = null;
  selectedSex = '';

  patient: Patient = new Patient();
  constructor(private router: Router,
    private service: PatientService,
    private _snackBar: MatSnackBar) { }


  ngOnInit() {
    this.EditPat();
  }

  EditPat() {
    let id = localStorage.getItem("id")
    let y: number;
    y = +id;
    this.service.getPatientId(y)
      .subscribe(data => {
        this.patient = data;
        console.log(this.patient)
      })

  }

  AtualizarPat(patient: Patient) {

    var name = (<HTMLInputElement>document.getElementById("nameP")).value;
    var birthdate = (<HTMLInputElement>document.getElementById("dateOfBirth")).value;
    var selectedOptionColor = this.selectedCor;
    var selectedOptionSex = this.selectedSex;

    patient.id = this.patient.id;
    patient.name = name;
    patient.sex = selectedOptionSex;
    patient.color = selectedOptionColor;
    patient.birthdate = birthdate;

    this.service.updatePatient(patient).subscribe(data => {
      this.patient = data;
      this.router.navigate(["list-patient"]);
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
