import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MedicService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './editMedic.component.html',
  styleUrls: ['./editMedic.component.css']
}) export class EditMedicComponent implements OnInit {

  medico: Medico = new Medico();
  constructor(private router: Router, private service: MedicService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.Editar();
  }

  private editMedForm = new FormGroup({
    name: new FormControl(''),
    crm : new FormControl(''),
    email : new FormControl(''),
    password : new FormControl(''),
    titulation : new FormControl('')
  })

  Editar() {
    let crm = localStorage.getItem("crm");
    this.medico.crm = crm
    this.service.getMedicoCrm(parseInt(crm))
      .subscribe(data => {

        this.medico = data;
        console.log(this.medico)
      })

  }

  Voltar(){
    this.router.navigate(["dashboard"]);
  }

  Atualizar(medico: Medico) {
    var nome = (<HTMLInputElement>document.getElementById("name")).value;

    medico.user.name = nome;
    medico.crm = this.medico.crm;

    this.service.updateMedico(medico)
      .subscribe(data => {
        this.medico = data;
        this.router.navigate(["dashboard"]);
      })
  }

  openSnackBarPat() {
    var message = "Medico atualizado!"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

}