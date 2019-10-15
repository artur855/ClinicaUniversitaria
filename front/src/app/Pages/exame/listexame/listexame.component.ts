import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ExamrequestService } from 'src/app/Services/examrequest.service';
import { ExamRequest } from 'src/app/Models/ExamRequest';
import { MatSnackBar } from '@angular/material/snack-bar';
import { faUserPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-listexame',
  templateUrl: './listexame.component.html',
  styleUrls: ['./listexame.component.css']
})
export class ListexameComponent implements OnInit {
  faUserPlus = faUserPlus;

  @Input() toggle: Boolean;

  exams: ExamRequest[];

  constructor(private service: ExamrequestService, private router: Router) { }

  ngOnInit() {
    this.service.getExams().subscribe(data => {
      this.exams = data;
    })
  }
  
  Adicionar() {
    this.router.navigate(["add-exam-request"]);
  }

  Delete(exam: ExamRequest) {
    this.service.deleteExam(exam)
      .subscribe(data => {
        this.exams = this.exams.filter(m => m !== exam);
      });
  }
}