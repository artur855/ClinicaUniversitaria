import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { MedicService } from 'src/app/Services/medico.service';
import { Medico } from 'src/app/Models/Medico';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add',
  templateUrl: './addMedic.component.html',
  styleUrls: ['./addMedic.component.css'],
  
})
export class AddMedicComponent implements OnInit {
  
  @Input() addMed= false;
  constructor(
    private router: Router,
    private service: MedicService,
    private medico: Medico,
    private _snackBar: MatSnackBar
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
      this.addMed = true;
      this.router.navigate(["dashboard"]);
      this.openSnackBarPat()
    })
  }

  openSnackBarPat() {
    var message = "Médico adicionado!"
    var action = "Fechar"
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
