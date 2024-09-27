import { Component, inject, OnInit } from '@angular/core';
import { CardSalaComponent } from '../card-sala/card-sala.component';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SalaService } from '../services/salas-individuales.service';
import { salaResponse } from '../models/salasResponse';
import { salaRequest } from '../models/salasRequest';
import { CardSelectedComponent } from '../card-selected/card-selected.component';
import { ModalComponent } from '../modal/modal.component';
import { CardSalaComponent2 } from '../card-sala-2/card-sala.component';


@Component({
  selector: 'app-salas-multiples',
  standalone: true,
  imports:[CommonModule,CardSalaComponent2,CardSelectedComponent,ModalComponent,ReactiveFormsModule],
  templateUrl: './salas-multiples.component.html',
  styleUrls: ['./salas-multiples.component.css']
})
export class SalasMultiplesComponent{

  private salaService = inject(SalaService);
  formSalaMultiple: FormGroup;
  public listSala: salaResponse[] = [];

  public selectedSalas: salaResponse[] = [];


  constructor(private route: ActivatedRoute, private fb: FormBuilder) {
    this.formSalaMultiple = this.fb.group({
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

  propertyForm!: number;

  obtenerPrioridad() {
    this.propertyForm = Number(this.formSalaMultiple.value.prioridad);
  }

  onSubmit() {
    this.obtenerPrioridad(); // Llama a la función para asignar el valor
    console.log(this.propertyForm); // Verifica el valor en la consola
  }

  buscarSalasDisponibles() {
    this.obtenerPrioridad(); // Llama a la función para asignar el valor
    if (this.formSalaMultiple.valid) {
      const request: salaRequest = {
        piso: Number(this.formSalaMultiple.value.piso),
        hora: Number(this.formSalaMultiple.value.hora),
        minutos: Number(this.formSalaMultiple.value.minutos),
        duracion: Number(this.formSalaMultiple.value.duracion),
        prioridad: Number(this.formSalaMultiple.value.prioridad),
        capacidad: Number(this.formSalaMultiple.value.capacidad),
      };
      this.salaService.salasDisponibles(request).subscribe({
        next: (data) => {
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
