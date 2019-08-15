import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMedicComponent } from './Pages/medico/add/addMedic.component';
import { ListMedicComponent } from './Pages/medico/list/listMedic.component';
import { EditMedicComponent } from './Pages/medico/edit/editMedic.component';
import { ListpatComponent } from './Pages/patient/listpat/listpat.component';
import { EditpatComponent } from './Pages/patient/editpat/editpat.component';





const routes: Routes = [
  { path: 'listar-medico', component: ListMedicComponent },
  { path: 'add-medico', component: AddMedicComponent },
  { path: 'edit-medico', component: EditMedicComponent },
  { path: 'list-patient', component: ListpatComponent},
  { path: 'edit-patient', component: EditpatComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
