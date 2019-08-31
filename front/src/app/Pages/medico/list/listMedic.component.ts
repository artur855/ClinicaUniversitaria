import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import{MedicService} from '../../../Services/medico.service'
import { Medico } from 'src/app/Models/Medico';
import { faUserPlus } from '@fortawesome/free-solid-svg-icons'
@Component({
  selector: 'app-listar',
  templateUrl: './listMedic.component.html',
  styleUrls: ['./listMedic.component.css']
})
export class ListMedicComponent implements OnInit {
  faUserPlus =faUserPlus;

  @Input() toggle: Boolean;

  medicos:Medico[];

  constructor(private service:MedicService, private router:Router) { }

  ngOnInit() {
    this.service.getMedicos().subscribe(data =>{
      console.log(data)
      this.medicos = data;
    })
  }
  Adicionar(){
    this.router.navigate(["add-medico"]);
  }

  Editar(medico:Medico):void{
    localStorage.setItem("crm",medico.crm.toString());
    this.router.navigate(["edit-medico"]);
  }

  Delete(medico:Medico){
  
    this.service.deleteMedico(medico)
    .subscribe(data => {
      this.medicos=this.medicos.filter(m=>m!==medico);
    });
    }
  }

