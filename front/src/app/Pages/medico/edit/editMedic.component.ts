import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit',
  templateUrl: './editMedic.component.html',
  styleUrls: ['./editMedic.component.css']
}) export class EditMedicComponent implements OnInit {

  medico: Medico = new Medico();
  constructor(private router: Router, private service: ServiceService,private _snackBar:MatSnackBar) { }

  ngOnInit() {
    this.Editar();
  }

  Editar() {
    let crm = localStorage.getItem("crm");
    this.medico.crm = crm
    this.service.getMedicoCrm(+crm)
      .subscribe(data => {

        this.medico = data;
      })

  }
  
  Atualizar(medico: Medico) {
    var nome = (<HTMLInputElement>document.getElementById("name")).value;
    
    medico.name = nome;
    medico.crm = this.medico.crm;
   
    this.service.updateMedico(medico)
      .subscribe(data => {
        this.medico = data;
        this.router.navigate(["listar-medico"]);
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