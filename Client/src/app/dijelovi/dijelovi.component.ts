import { Component, OnInit } from '@angular/core';
import { DijeloviService } from '../_services/dijelovi.service';
import { Dio } from '../_modeli/dio';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dijelovi',
  templateUrl: './dijelovi.component.html',
  styleUrls: ['./dijelovi.component.css']
})
export class DijeloviComponent implements OnInit{

  noviDio = {
    naziv: '',
    cijena: 5.99,
    sifra: '',
    proizvodac: ''
  }
  dijelovi: Dio[] = [];

  constructor(private dijeloviService: DijeloviService, private toastrService: ToastrService){}

  ngOnInit(): void {
    this.dohvatiSveDijelove();
  }

  dohvatiSveDijelove(){
    this.dijelovi = [];
    this.dijeloviService.dohvatiSveDijelove().subscribe({
      next: response => {
        response.map((item: Dio) => {
          this.dijelovi.push(item);
        });
        console.log(response);
      },
      error: error => {
        console.error(error);
      }
    });
  }

  obrisiDio(dio: Dio){
    console.log(dio);
    this.dijeloviService.obrisiDio(dio.id).subscribe({
      next: response => {
        this.toastrService.success("Obrisano");
        this.dohvatiSveDijelove();
      },
      error: error => {
        console.error(error);
      }
    })
  }

  spremiNoviDio(){
    this.dijeloviService.spremiNoviDio(this.noviDio).subscribe({
      next: response => {
        this.noviDio = {
          naziv: '',
          cijena: 5.99,
          sifra: '',
          proizvodac: ''
        };
        this.toastrService.success("Dio spremljen.");
        this.dohvatiSveDijelove();
      },
      error: error => {
        console.error(error);
      }
    })
  }

}
