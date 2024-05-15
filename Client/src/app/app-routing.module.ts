import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DijeloviComponent } from './dijelovi/dijelovi.component';
import { DioComponent } from './dio/dio.component';

const routes: Routes = [
  {path: '', component: DijeloviComponent},
  {path: 'dio/:id', component: DioComponent},
  {path: '**', component: DijeloviComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
