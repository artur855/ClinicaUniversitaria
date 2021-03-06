import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Patient } from '../Models/Pacient'
import { environment } from 'src/environments/environment';
//import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) {};
  
  Url = environment.url + "Patients/";

  getPatients() {
    return this.http.get<Patient[]>(this.Url);
  }

  getPatientId(id: number) {
    return this.http.get<Patient>(this.Url + id);
  }

  createPatient(pat: Patient) {
    return this.http.post<Patient>(this.Url, pat);
  }

  updatePatient(pat: Patient) {
    return this.http.put<Patient>(this.Url, pat)
  }

  deletePatient(pat: Patient) {
    return this.http.delete(this.Url + pat.id)
  }
}

