import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Patient} from '../Models/Pacient'
import { environment } from 'src/environments/environment';
//import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http : HttpClient) { }

  Url = environment.url+"patients/";

  getPatients() {
    return this.http.get<Patient[]>(this.Url);
  }

  getPatientCpf(cpf: number) {
    return this.http.get<Patient>(this.Url + cpf);
  }

  createPatient(pat: Patient) {
    return this.http.post<Patient>(this.Url, pat)
  }

  updatePatient(pat: Patient) {
    return this.http.put<Patient>(this.Url + pat.id, pat)
  }

  deletePatient(pat: Patient) {
    return this.http.delete(this.Url + pat.id)
  }
}

