import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Service/service.service';
import { Medico } from 'src/app/Models/Medico';
import { FormGroup} from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  addForm: FormGroup;
 

  constructor(
    private router: Router,
    private service: ServiceService,
    private  medico: Medico
  ) {
  }

  ngOnInit() {

  }

  onSubmit() {
    var nome = (<HTMLInputElement> document.getElementById("name")).value;
    var crm = (<HTMLInputElement> document.getElementById("crm")).value;

    this.medico.name= nome;
    console.log(this.medico.name)
    this.medico.crm = crm;
    console.log(this.medico.crm)

    console.log(this.medico)

    this.service.createMedico(this.medico).subscribe(data =>{
      this.medico = data;
      
      this.router.navigate(["listar"]);
    })
        
      
  }

}
