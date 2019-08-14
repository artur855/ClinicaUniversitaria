import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';


@Component({
  selector: 'app-edit',
  templateUrl: './editMedic.component.html',
  styleUrls: ['./editMedic.component.css']
}) export class EditMedicComponent implements OnInit {

  medico: Medico = new Medico();
  constructor(private router: Router, private service: ServiceService) { }

  ngOnInit() {
    this.Editar();
  }

  Editar() {
    let crm = localStorage.getItem("crm");
    this.service.getMedicoCrm(+crm)
      .subscribe(data => {

        this.medico = data;
        console.log(this.medico)
      })

  }
  Atualizar(medico: Medico) {
    var nome = (<HTMLInputElement>document.getElementById("name")).value;
    var crm = (<HTMLInputElement>document.getElementById("CRM")).value;
    medico.name = nome;
    medico.crm = crm;
    console.log(medico)
    this.service.updateMedico(medico)
      .subscribe(data => {
        this.medico = data;
        alert("Atualizado");
        this.router.navigate(["listar"]);
      })
  }

}