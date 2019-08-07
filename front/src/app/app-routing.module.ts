import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './medico/add/add.component';
import { ListarComponent } from './medico/listar/listar.component';
import { EditComponent } from './medico/edit/edit.component';
import { RemoveComponent } from './medico/remove/remove.component';


const routes: Routes = [
  {path:'listar', component:ListarComponent},
  {path:'add', component:AddComponent},
  {path:'edit', component:EditComponent},
  {path:'remove', component:RemoveComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
