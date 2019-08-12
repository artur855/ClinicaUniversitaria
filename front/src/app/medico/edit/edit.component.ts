import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';
import { Medico } from 'src/app/Models/Medico';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})export class EditComponent implements OnInit {

  medico :Medico=new Medico();
  constructor(private router:Router,private service:ServiceService) { }

  ngOnInit() {
    this.Editar();
  }

  Editar(){
    let id=localStorage.getItem("id");
    this.service.getMedicoId(+id)
    .subscribe(data=>{
      
      this.medico=data;
      console.log(this.medico)
    })

  }
  Atualizar(medico:Medico){
    var nome = (<HTMLInputElement> document.getElementById("name")).value;
    var CRM = (<HTMLInputElement> document.getElementById("CRM")).value;
    medico.name=nome;
    medico.CRM=CRM;
    console.log(medico)
    this.service.updateMedico(medico)
    .subscribe(data=>{
      this.medico=data;
      alert("Atualizado");
      this.router.navigate(["listar"]);
    })
  }

}