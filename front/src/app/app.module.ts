import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { AddMedicComponent } from './Pages/medico/add/addMedic.component';
import { ListMedicComponent } from './Pages/medico/list/listMedic.component';
import { EditMedicComponent } from './Pages/medico/edit/editMedic.component';

import { EditpatComponent } from './Pages/patient/editpat/editpat.component';
import { ListpatComponent } from './Pages/patient/listpat/listpat.component';
import { AddpatComponent } from './Pages/patient/addpat/addpat.component';

import { DashboardComponent } from './Pages/dashboard/dashboard.component';

import { HomeComponent } from './Pages/home/home.component';

import { ListexameComponent } from './Pages/exame/listexame/listexame.component';
import { PedidoexameComponent } from './Pages/exame/addexame/pedidoexame.component';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule} from '@angular/http';
import { RouterModule } from '@angular/router';
import { NgbDate, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MaterialModule } from './modules/material-module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LayoutModule } from '@angular/cdk/layout';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatNativeDateModule } from '@angular/material/core';


import { AuthenticationInterceptor } from './Interceptors/authentication.interceptor';
import { Patient } from './Models/Pacient';
import { Medico } from 'src/app/Models/Medico';
import { AuthGuard } from './Guards/auth.guard';
import { Usuario } from './Models/Usuario';

import { AuthenticationService } from './Services/authentication.service';
import { CookieService } from 'ngx-cookie-service';
import { PatientService } from './Services/pacient.service';
import { MedicService } from './Services/medico.service';
import { UploadfileComponent } from './Pages/uploadFile/uploadfile.component';
import { Upload } from './Models/Upload';

@NgModule({
  declarations: [
    AppComponent,
    AddMedicComponent,
    ListMedicComponent,
    EditMedicComponent,
    EditpatComponent,
    ListpatComponent,
    AddpatComponent,
    HomeComponent,
    DashboardComponent,
    PedidoexameComponent,
    ListexameComponent,
    UploadfileComponent,
  ],
  imports: [
    NgbModule,
    MaterialModule,
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    HttpModule,
    RouterModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    NoopAnimationsModule,
    LayoutModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatSidenavModule,
    MatToolbarModule,
    MatNativeDateModule,
  ],
  providers: [
    AuthenticationService,
    MedicService,
    CookieService,
    AuthGuard,
    Medico,
    Patient,
    Usuario,
    Upload,
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },PatientService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
