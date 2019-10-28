import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MedicService } from 'src/app/Services/medico.service';
import { Medico, Titulacao } from 'src/app/Models/Medico';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormGroup, FormControl } from '@angular/forms';
import { Usuario } from 'src/app/Models/Usuario';

@Component({
  selector: 'app-add',
  templateUrl: './addMedic.component.html',
  styleUrls: ['./addMedic.component.css'],

})
export class AddMedicComponent implements OnInit {
  tMed = Titulacao;
  tmeds = []
  tValues = []


  private addMedForm = new FormGroup({
    name: new FormControl(''),
    crm: new FormControl(''),
    email: new FormControl(''),
    titulation: new FormControl(''),
    password: new FormControl(''),
  });


  constructor(
    private router: Router,
    private service: MedicService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.tmeds = Object.keys(this.tMed)
    for (let i = 0; i < 3; i++) {
      this.tValues[i] = this.tmeds[i + 3]
    }
    console.log(this.tValues)
  }

  Voltar(){
    this.router.navigate(["dashboard"]);
  }

  onSubmit() {
    //console.log(this.addMedForm.value);
    var med = new Medico();
    med.crm = this.addMedForm.controls.crm.value;
    med.titulation = this.addMedForm.controls.titulation.value;
    med.user = new Usuario();
    med.user.email = this.addMedForm.controls.email.value;
    med.user.name = this.addMedForm.controls.name.value;
    med.user.password = this.addMedForm.controls.password.value;
    console.log(med)
    this.service.createMedico(med).subscribe(data => {
      med = data;
      this.router.navigate(["dashboard"]);
      this.openSnackBarPat()
    })
  }

  openSnackBarPat() {
    var message = "Médico adicionado!"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
