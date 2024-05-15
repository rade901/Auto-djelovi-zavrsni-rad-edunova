import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Dio } from '../_modeli/dio';

@Injectable({
  providedIn: 'root'
})
export class DijeloviService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  dohvatiSveDijelove(){
    return this.http.get<Dio[]>(this.baseUrl + 'dijelovi');
  }

  dohvatiDioPoId(id: any){
    return this.http.get<Dio>(this.baseUrl + 'dijelovi/' + id);
  }

  spremiNoviDio(model: any){
    return this.http.post(this.baseUrl + 'dijelovi', model);
  }

  obrisiDio(id: number){
    return this.http.delete(this.baseUrl + 'dijelovi/'+id);
  }

  azurirajDio(model: any){
    return this.http.put(this.baseUrl + 'dijelovi/'+ model.id, model);
  }
}
