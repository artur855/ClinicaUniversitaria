import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import{ServiceService} from '../../../Services/medico.service'
import { Medico } from 'src/app/Models/Medico';

@Component({
  selector: 'app-listar',
  templateUrl: './listMedic.component.html',
  styleUrls: ['./listMedic.component.css']
})
export class ListMedicComponent implements OnInit {

  medicos:Medico[];
  constructor(private service:ServiceService, private router:Router) { }

  ngOnInit() {
    this.service.getMedicos().subscribe(data =>{
      this.medicos = data;
    })
  }

  Editar(medico:Medico):void{
    localStorage.setItem("crm",medico.crm.toString());
    this.router.navigate(["edit"]);
  }

  Delete(medico:Medico){
  
    this.service.deleteMedico(medico)
    .subscribe(data => {
      this.medicos=this.medicos.filter(m=>m!==medico);
    });
    }
  }

