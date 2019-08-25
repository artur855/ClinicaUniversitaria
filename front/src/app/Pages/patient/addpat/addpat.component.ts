import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/Services/pacient.service';
import { Router } from '@angular/router';
import { Patient } from 'src/app/Models/Pacient';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from 'src/app/Models/Usuario';

@Component({
  selector: 'app-addpat',
  templateUrl: './addpat.component.html',
  styleUrls: ['./addpat.component.css'],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ],

})
export class AddpatComponent implements OnInit {
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
  constructor(private service: PatientService,
    private router: Router,
    private patient: Patient,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  onSubmitPat() {
    var name = (<HTMLInputElement>document.getElementById("nameP")).value;
    var email = (<HTMLInputElement>document.getElementById("emailP")).value;
    var senha = (<HTMLInputElement>document.getElementById("senhaP")).value;
    var birthdate = (<HTMLInputElement>document.getElementById("dateOfBirth")).value;
    var selectedOptionColor = this.selectedCor;
    var selectedOptionSex = this.selectedSex;
    this.patient.usuario = new Usuario();
    this.patient.usuario.email = email;
    this.patient.usuario.name = name;
    this.patient.usuario.senha = senha;
    this.patient.sex = selectedOptionSex;
    this.patient.color = selectedOptionColor;
    this.patient.birthdate = birthdate;

    this.service.createPatient(this.patient).subscribe(data => {
      this.patient = data;
      this.router.navigate(["list-patient"]);
    });
  }

  openSnackBarPat() {
    var message = "Paciente adicionado!"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
