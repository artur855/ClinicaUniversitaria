import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/Models/Pacient';
import { Router } from '@angular/router';
import { PatientService } from 'src/app/Services/pacient.service';

@Component({
  selector: 'app-listpat',
  templateUrl: './listpat.component.html',
  styleUrls: ['./listpat.component.css']
})
export class ListpatComponent implements OnInit {
  closeResult: string;
  patients: Patient[];
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
  constructor(
    private service: PatientService,
    private router: Router
  ) { }

  ngOnInit() {
    var year,month,day;
    this.service.getPatients().subscribe(data => {
      for (let i = 0; i < data.length; i++){
        if (data[i].sex == "F") {
          data[i].sex = "Feminino"
        }
        if (data[i].sex == "M") {
          data[i].sex = "Masculino"
        }
        var x=data[i].birthdate.substr(0, data[i].birthdate.length - 9);
        var date = [] = x.split("-")
        year = date[0] 
        day= date[1]
        month = date[2]
        var dateCorrect = day+"/"+month+"/"+year
        data[i].birthdate = dateCorrect;
        
      }
      for (let i=0; i < data.length; i++) {
        for (let j=0; j < this.colorsPat.length; j++)
          if (data[i].color == this.colorsPat[j].value) {
            data[i].color = this.colorsPat[j].name
          }
      }
      
      this.patients = data;

    })
  }

  AdicionarPat() {
    this.router.navigate(["add-patient"]);
  }

  EditarPat(id): void {
    localStorage.setItem("id", id)
    this.router.navigate(["edit-patient"]);
  }

  DeletePat(patient: Patient) {
    this.service.deletePatient(patient)
      .subscribe(data => {
        this.patients = this.patients.filter(m => m !== patient);
      });
  }
}


