import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Medico } from '../Models/Medico';
//import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class ServiceService {


  constructor(private http:HttpClient) { }

  Url = 'http://localhost:5000/api/medics/'



  getMedicos(){
    return this.http.get<Medico[]>(this.Url);
  }

  getMedicoId(id:number){
    return this.http.get<Medico>(this.Url+id);
  }

  createMedico (med: Medico){
    return this.http.post<Medico>(this.Url, med)
  }

  updateMedico(med:Medico){
    return this.http.put<Medico>(this.Url+med.id,med)
  }

  deleteMedico(med:Medico){
    return this.http.delete(this.Url+med.id)
  }
}
