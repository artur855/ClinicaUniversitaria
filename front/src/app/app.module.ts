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
import { NgbDate, NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { MaterialModule } from './modules/material-module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EditpatComponent } from './Pages/patient/editpat/editpat.component';
import { ListpatComponent } from './Pages/patient/listpat/listpat.component';
import { Patient } from './Models/Pacient';
import { AddpatComponent } from './Pages/patient/addpat/addpat.component';



@NgModule({
  declarations: [
    AppComponent,
    AddMedicComponent,
    ListMedicComponent,
    EditMedicComponent,
    EditpatComponent,
    ListpatComponent,
    AddpatComponent,
  ],
  imports: [
    NgbModule,
    MaterialModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    BrowserAnimationsModule
  ],
  providers: [ServiceService, Medico,Patient],
  bootstrap: [AppComponent]
})
export class AppModule { }
