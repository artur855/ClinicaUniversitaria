import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/Models/Pacient';
import { Router } from '@angular/router';
import { PatientService } from 'src/app/Services/pacient.service';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-listpat',
  templateUrl: './listpat.component.html',
  styleUrls: ['./listpat.component.css']
})
export class ListpatComponent implements OnInit {
  closeResult: string;
  patients: Patient[];
  constructor(private service: PatientService, private router: Router,private modalService: NgbModal) { }

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

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
}


