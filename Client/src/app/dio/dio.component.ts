import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DijeloviService } from '../_services/dijelovi.service';
import { Dio } from '../_modeli/dio';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dio',
  templateUrl: './dio.component.html',
  styleUrls: ['./dio.component.css']
})
export class DioComponent implements OnInit{

  dio: any;
  dioID: string = '';

  constructor(private route: ActivatedRoute, private dijeloviService: DijeloviService, 
    private toasterService: ToastrService){}


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.dioID = params['id'];
      this.dijeloviService.dohvatiDioPoId(this.dioID).subscribe({
        next: response => {
          console.log(response);
          this.dio = response;
          console.log(this.dio);
        },
        error: error => {
          console.error(error);
        }
      })

    });
  }

  spremiDio(){
    this.dijeloviService.azurirajDio(this.dio).subscribe({
      next: response => {
        this.toasterService.success("Dio ažuriran");
      },
      error: error => {
        console.error(error);
      }
    })
  }
}
