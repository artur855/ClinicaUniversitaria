import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Medico } from '../Models/Medico';
//import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MedicService {

  constructor(private http: HttpClient) { }

  Url = environment.url+"medics/";

  getMedicos() {
    return this.http.get<Medico[]>(this.Url);
  }

  getMedicoCrm(crm: string) {
    return this.http.get<Medico>(this.Url + crm);
  }

  createMedico(med: Medico) {
    return this.http.post<Medico>(this.Url, med)
  }

  updateMedico(med: Medico) {
    return this.http.put<Medico>(this.Url , med)
  }

  deleteMedico(med: Medico) {
    return this.http.delete(this.Url + med.crm)
  }
}
