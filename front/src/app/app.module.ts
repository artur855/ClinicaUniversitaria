import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddMedicComponent } from './Pages/medico/add/addMedic.component';
import { ListMedicComponent } from './Pages/medico/list/listMedic.component';
import { EditMedicComponent } from './Pages/medico/edit/editMedic.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Medico } from 'src/app/Models/Medico';
import {HttpModule} from '@angular/http';
import {HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { RouterModule } from '@angular/router';
import { NgbDate, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MaterialModule } from './modules/material-module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EditpatComponent } from './Pages/patient/editpat/editpat.component';
import { ListpatComponent } from './Pages/patient/listpat/listpat.component';
import { Patient } from './Models/Pacient';
import { AddpatComponent } from './Pages/patient/addpat/addpat.component';
import { HomeComponent } from './Pages/home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { LayoutModule } from '@angular/cdk/layout';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Usuario } from './Models/Usuario';
import { AuthenticationInterceptor } from './Interceptors/authentication.interceptor';
import { AuthenticationService } from './Services/authentication.service';
import { CookieService } from 'ngx-cookie-service';
import { AuthGuard } from './Guards/auth.guard';
import { PatientService } from './Services/pacient.service';
import { MedicService } from './Services/medico.service';
import { PedidoexameComponent } from './Pages/exame/addexame/pedidoexame.component';
import { MatNativeDateModule } from '@angular/material/core';
import { ListexameComponent } from './Pages/exame/listexame/listexame.component';
import { EditexameComponent } from './Pages/exame/editexame/editexame.component';

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
    EditexameComponent,
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
    MatNativeDateModule
  ],
  providers: [
    AuthenticationService,
    MedicService,
    PatientService,
    CookieService,
    AuthGuard,
    Medico,
    Patient,
    Usuario,
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
