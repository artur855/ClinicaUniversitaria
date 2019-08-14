import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './Pages/medico/add/add.component';
import { ListarComponent } from './Pages/medico/listar/listar.component';
import { EditComponent } from './Pages/medico/edit/edit.component';

const routes: Routes = [
  { path: 'listar', component: ListarComponent },
  { path: 'add', component: AddComponent },
  { path: 'edit', component: EditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
