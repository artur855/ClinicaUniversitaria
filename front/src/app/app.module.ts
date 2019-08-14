import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddComponent } from './Pages/medico/add/add.component';
import { ListarComponent } from './Pages/medico/listar/listar.component';
import { EditComponent } from './Pages/medico/edit/edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Medico } from 'src/app/Models/Medico';
import { ServiceService } from './Services/medico.service'
import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router';
import { NavBarComponent } from './ComponentCommons/nav-bar/nav-bar.component';


@NgModule({
  declarations: [
    AppComponent,
    AddComponent,
    ListarComponent,
    EditComponent,
    NavBarComponent,
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
