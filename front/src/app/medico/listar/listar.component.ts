import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import{ServiceService} from '../../Service/service.service'
import { Medico } from 'src/app/Models/Medico';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})
export class ListarComponent implements OnInit {

  medicos:Medico[];
  constructor(private service:ServiceService, private router:Router) { }

  ngOnInit() {
    this.service.getMedicos().subscribe(data =>{
      this.medicos = data;
    })
  }

  Editar(medico:Medico):void{
    localStorage.setItem("id",medico.id.toString());
    this.router.navigate(["edit"]);
  }

  Delete(medico:Medico){
  
    this.service.deleteMedico(medico)
    .subscribe(data => {
      this.medicos=this.medicos.filter(m=>m!==medico);
    });
    }
  }

