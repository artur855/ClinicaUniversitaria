import { Component, OnInit, Input } from '@angular/core';
import { Patient, PatientColor, PatientSex } from 'src/app/Models/Pacient';
import { Router } from '@angular/router';
import { faUserPlus } from '@fortawesome/free-solid-svg-icons'
import { PatientService } from 'src/app/Services/pacient.service';

@Component({
  selector: 'app-listpat',
  templateUrl: './listpat.component.html',
  styleUrls: ['./listpat.component.css'],
})
export class ListpatComponent implements OnInit {
  closeResult: string;
  patients: Patient[];
  faUserPlus = faUserPlus;
  sexPat = [
    { name: "Masculino", value: "M" },
    { name: "Feminino", value: "F" },
  ]
  colorsPat = [
    { name: "Branco", value: "0" },
    { name: "Negro", value: "1" },
    { name: "Pardo", value: "2" },
    { name: "Indigena", value: "3" },
    { name: "Nao Especificado", value: "4" },
  ]

  @Input() toggle: Boolean;

  constructor(
    private service: PatientService,
    private router: Router
  ) { }

  ngOnInit() {
    //this.service.getPatients().subscribe(data => {
      // for (let i = 0; i < data.length; i++) {
      //   if (data[i].sex == "F") {
      //     data[i].sex = "Feminino"
      //   }
      //   if (data[i].sex == "M") {
      //     data[i].sex = "Masculino"
      //   }
      //   data[i].birthdate = data[i].birthdate;
      //   for (let j = 0; j < this.colorsPat.length; j++)
      //     if (data[i].color == this.colorsPat[j].value) {
      //       data[i].color = this.colorsPat[j].name
      //     }
      // }
      this.service.getPatients().subscribe(data => {
        console.log(data);
      });
  }

  AdicionarPat() {
    this.router.navigate(["add-patient"]);
  }

  EditarPat(id): void {
    localStorage.setItem("idpat", id)
    this.router.navigate(["edit-patient"]);
  }

  DeletePat(patient: Patient) {
    this.service.deletePatient(patient)
      .subscribe(data => {
        this.patients = this.patients.filter(m => m !== patient);
      });
  }
}


