import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';

@Component({
  selector: 'app-add',
  templateUrl: './addMedic.component.html',
  styleUrls: ['./addMedic.component.css']
})
export class AddMedicComponent implements OnInit {
  


  constructor(
    private router: Router,
    private service: ServiceService,
    private medico: Medico
  ) {
  }

  ngOnInit() {

  }

  onSubmit() {
    var nome = (<HTMLInputElement>document.getElementById("name")).value;
    var CRM = (<HTMLInputElement>document.getElementById("CRM")).value;

    this.medico.name = nome;

    this.medico.crm = CRM;

    this.service.createMedico(this.medico).subscribe(data => {
      this.medico = data;

      this.router.navigate(["listar-medico"]);
    })

  }

}
