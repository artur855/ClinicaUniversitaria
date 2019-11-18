import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ExamRequest } from '../Models/ExamRequest';
import { ExamRequestReport } from '../Models/ExamRequestReport';

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
    return this.http.post<ExamRequestReport>(this.Url, exam).toPromise();
  }

  updateExam(exam: ExamRequest) {
    return this.http.put<ExamRequest>(this.Url , exam)
  }

  deleteExam(exam: ExamRequest) {
    return this.http.delete(this.Url + exam.id)
  }
}
