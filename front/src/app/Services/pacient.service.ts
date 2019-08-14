import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Pacient} from '../Models/Pacient'
//import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class PacientService {

  constructor(private http : HttpClient) { }

  Url = environment.url;



  getPacients() {
    return this.http.get<Pacient[]>(this.Url);
  }

  getPacientCpf(cpf: number) {
    return this.http.get<Pacient>(this.Url + cpf);
  }

  createPacient(pac: Pacient) {
    return this.http.post<Pacient>(this.Url, pac)
  }

  updatePacient(pac: Pacient) {
    return this.http.put<Pacient>(this.Url + pac.cpf, pac)
  }

  deletePacient(pac: Pacient) {
    return this.http.delete(this.Url + pac.cpf)
  }
}

