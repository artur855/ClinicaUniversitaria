import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MedicService } from 'src/app/Services/medico.service';
import { Medico,Titulacao } from 'src/app/Models/Medico';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormControl, FormGroup } from '@angular/forms';
import { Usuario } from 'src/app/Models/Usuario';
import { faSignOutAlt } from  '@fortawesome/free-solid-svg-icons'


@Component({
  selector: 'app-edit',
  templateUrl: './editMedic.component.html',
  styleUrls: ['./editMedic.component.css']
}) export class EditMedicComponent implements OnInit {
  
  faSignOutAlt = faSignOutAlt;

  tMed = Titulacao;
  tmeds = [];
  tValues = [];

  medico: Medico = new Medico();
  constructor(private router: Router, private service: MedicService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.Editar();
    this.tmeds = Object.keys(this.tMed)
    for (let i = 0; i < 3; i++) {
      this.tValues[i] = this.tmeds[i + 3]
    }
  }

  private editMedForm = new FormGroup({
    name: new FormControl(''),
    crm: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    titulation: new FormControl('')
  });
  

  Editar() {
    let crm = localStorage.getItem("crm");
    this.medico.crm = crm
    this.service.getMedicoCrm(crm)
      .subscribe(data => {
        console.log(data);
        this.editMedForm.controls.name.setValue(data.name);
        this.editMedForm.controls.crm.setValue(data.crm);
        this.editMedForm.controls.email.setValue(data.email);
      });

  }

  Voltar() {
    this.router.navigate(["dashboard"]);
  }

  onSubmit(medico: Medico) {
    var ctrl=  this.editMedForm.controls;
    medico = new Medico();
    medico.user = new Usuario();
    
    medico.user.name = ctrl.name.value;
    medico.user.password = ctrl.password.value; 
    medico.user.email = ctrl.email.value; 
    medico.crm = ctrl.crm.value;
    medico.titulation = ctrl.titulation.value; 

    this.service.updateMedico(medico)
      .subscribe(data => {
        this.medico = data;
        this.openSnackBarPat();
        this.router.navigate(["dashboard"]);
      });
  }

  openSnackBarPat() {
    this._snackBar.open("Medico atualizado com sucesso!", "Fechar", {
      duration: 2000,
    });
  }

}