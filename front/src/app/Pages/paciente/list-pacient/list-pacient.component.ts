import { Component, OnInit } from '@angular/core';
import { PacientService } from 'src/app/Services/pacient.service';
import { Router } from '@angular/router';
import { Pacient } from 'src/app/Models/Pacient';

@Component({
  selector: 'app-list-pacient',
  templateUrl: './list-pacient.component.html',
  styleUrls: ['./list-pacient.component.css']
})
export class ListPacientComponent implements OnInit {

  pacients :Pacient[];
  constructor(private service:PacientService, private router:Router) { }

  ngOnInit() {
  }

}
