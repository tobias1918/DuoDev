import { Component, inject, OnInit } from '@angular/core';
import { CardSalaComponent } from '../card-sala/card-sala.component';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SalaService } from '../services/salas-individuales.service';
import { salaResponse } from '../models/salasResponse';
import { salaRequest } from '../models/salasRequest';


@Component({
  selector: 'app-salas-individuales',
  standalone: true,
  imports: [CardSalaComponent,CommonModule,ReactiveFormsModule],
templateUrl: './salas-individuales.component.html',
  styleUrl: './salas-individuales.component.css'
})


export class SalasIndividualesComponent implements OnInit {

  private salaService = inject(SalaService);
  formSalaIndividual: FormGroup;
  public listSala: salaResponse[] = [];

  constructor(private route: ActivatedRoute, private fb: FormBuilder) {
    this.formSalaIndividual = this.fb.group({
      piso: ['', [Validators.required]],
      hora: ['', [Validators.required]],
      minutos: ['', [Validators.required]],
      duracion: ['', [Validators.required]],
      prioridad: ['', [Validators.required]],
      capacidad: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }

  buscarSalasDisponibles() {
    if (this.formSalaIndividual.valid) {
      const request: salaRequest = {
        piso: Number(this.formSalaIndividual.value.piso),
        hora: Number(this.formSalaIndividual.value.hora),
        minutos: Number(this.formSalaIndividual.value.minutos),
        duracion: Number(this.formSalaIndividual.value.duracion),
        prioridad: Number(this.formSalaIndividual.value.prioridad),
        capacidad: Number(this.formSalaIndividual.value.capacidad),
      };
      console.log(request);
      this.salaService.salasDisponibles(request).subscribe({
        next: (data) => {
          console.log(data); // Asegúrate de que esto es un array
          if (Array.isArray(data) && data.length > 0) {
            this.listSala = data.map(item => {
              return {
                ...item,
                horaInicio: this.formatTime(item.horaInicio),
                horaFin: this.formatTime(item.horaFin)
              };
            });
          } else {
            this.listSala = []; // Resetea la lista si no hay salas disponibles
          }
        },
        error: (error) => {
          console.error(error.message);
        }
      });
    } else {
      // Manejo de errores de validación, si es necesario
      console.log("Formulario inválido");
    }
  }

  private formatTime(dateTime: Date): string {
    const date = new Date(dateTime);
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${hours}:${minutes}`;
  }


  

}
