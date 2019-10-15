import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ExamRequest } from '../Models/ExamRequest';

@Injectable({
  providedIn: 'root'
})
export class ExamrequestService {
  constructor(private http: HttpClient) { }

  Url = environment.url+"ExamRequest/";


  getExams() {
    return this.http.get<ExamRequest[]>(this.Url);
  }

  getExamId(id: number) {
    return this.http.get<ExamRequest>(this.Url + id);
  }

  createExam(exam: ExamRequest) {
    return this.http.post<ExamRequest>(this.Url, exam)
  }

  updateExam(exam: ExamRequest) {
    return this.http.put<ExamRequest>(this.Url , exam)
  }

  deleteExam(exam: ExamRequest) {
    return this.http.delete(this.Url + exam.id)
  }
}