import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Upload } from '../Models/Upload';

@Injectable({
  providedIn: 'root'
})

export class UploadfileService {
  constructor(private http: HttpClient) {};
  
  Url = environment.url + "Exam";

  getPatients() {
    return this.http.get<Upload[]>(this.Url);
  }

  getExamId(id: number) {
    return this.http.get<Upload>(this.Url + id);
  }

  insertExam(upld: Upload) {
    return this.http.post<Upload>(this.Url, upld);
  }

  deleteExame(upld: Upload) {
    return this.http.delete(this.Url + upld.id)
  }
}
