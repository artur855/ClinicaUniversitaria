import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'front';

  constructor(private router:Router){
    
  }

  Medico(){
    this.router.navigate(["listar-medico"]);
  }

  Paciente(){
    this.router.navigate(["list-patient"]);
  }
}
