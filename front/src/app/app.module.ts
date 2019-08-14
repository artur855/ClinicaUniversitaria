import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AddMedicComponent } from './Pages/medico/add/addMedic.component';
import { ListMedicComponent } from './Pages/medico/list/listMedic.component';
import { EditMedicComponent } from './Pages/medico/edit/editMedic.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Medico } from 'src/app/Models/Medico';
import { ServiceService } from './Services/medico.service'

import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router';
import { NavBarComponent } from './ComponentCommons/nav-bar/nav-bar.component';
import { LstComponent } from './Pages/paciente/list/lst.component';


@NgModule({
  declarations: [
    AppComponent,
    AddMedicComponent,
    ListMedicComponent,
    EditMedicComponent,
    NavBarComponent,
    LstComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [ServiceService, Medico],
  bootstrap: [AppComponent]
})
export class AppModule { }
