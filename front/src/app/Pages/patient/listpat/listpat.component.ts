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
  colorsPat: PatientColor
  sexPat: PatientSex;

  @Input() toggle: Boolean;

  constructor(
    private service: PatientService,
    private router: Router
  ) { }

  ngOnInit() {
    
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


