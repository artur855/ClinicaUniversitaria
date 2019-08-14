import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMedicComponent } from './Pages/medico/add/addMedic.component';
import { ListMedicComponent } from './Pages/medico/list/listMedic.component';
import { EditMedicComponent } from './Pages/medico/edit/editMedic.component';

const routes: Routes = [
  { path: 'listar', component: ListMedicComponent },
  { path: 'add', component: AddMedicComponent },
  { path: 'edit', component: EditMedicComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
