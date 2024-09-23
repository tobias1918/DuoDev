import { Component, OnInit } from '@angular/core';
import { CardSalaComponent } from '../card-sala/card-sala.component';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-salas-individuales',
  standalone: true,
  imports: [CardSalaComponent,CommonModule],
  templateUrl: './salas-individuales.component.html',
  styleUrl: './salas-individuales.component.css'
})
export class SalasIndividualesComponent implements OnInit {
  salas: any[] = [];
  numeroAsistentes: number=0;
  horario: string ='';
  prioridad: string ='';

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.numeroAsistentes = params['numeroAsistentes'];
      this.horario = params['horario'];
      this.prioridad = params['prioridad'];

   
      console.log(`${this.numeroAsistentes+this.horario+this.prioridad}`)
    });
  }

  

}
