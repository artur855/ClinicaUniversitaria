import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Medico } from '../Models/Medico';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

 
  constructor(private http:HttpClient) { }

  Url = 'http://localhost:8082/medicos'

  getMedicos(){
    return this.http.get<Medico[]>(this.Url);
  }
}
