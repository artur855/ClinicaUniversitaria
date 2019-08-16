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

  constructor(
    private service: PatientService,
    private router: Router
    ){ }

  ngOnInit() {
    this.service.getPatients().subscribe(data => {
      this.patients = data;
    })
  }

  AdicionarPat() {
    this.router.navigate(["add-patient"]);
  }

  EditarPat(patient: Patient): void {
    localStorage.setItem("id", patient.id.toString());
    this.router.navigate(["edit-patient"]);
  }

  DeletePat(patient: Patient) {

    this.service.deletePatient(patient)
      .subscribe(data => {
        this.patients = this.patients.filter(m => m !== patient);
      });
  }
}


