import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Medico } from '../Models/Medico';
//import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';



@Injectable({
  providedIn: 'root'
})
export class ServiceService {


  constructor(private http: HttpClient) { }

  Url = environment.url;



  getMedicos() {
    return this.http.get<Medico[]>(this.Url);
  }

  getMedicoCrm(crm: number) {
    return this.http.get<Medico>(this.Url + crm);
  }

  createMedico(med: Medico) {
    return this.http.post<Medico>(this.Url, med)
  }

  updateMedico(med: Medico) {
    return this.http.put<Medico>(this.Url + med.crm, med)
  }

  deleteMedico(med: Medico) {
    return this.http.delete(this.Url + med.crm)
  }
}
