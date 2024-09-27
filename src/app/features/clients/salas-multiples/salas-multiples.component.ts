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
import { multiReserva } from '../models/multiReserva';
import { SalasMultiplesService } from './salas-multiples.service';
import { SalaMultiplesService } from '../services/salas-multiples.service';


@Component({
  selector: 'app-salas-multiples',
  standalone: true,
  imports:[CommonModule,CardSalaComponent2,CardSelectedComponent,ModalComponent,ReactiveFormsModule],
  templateUrl: './salas-multiples.component.html',
  styleUrls: ['./salas-multiples.component.css']
})
export class SalasMultiplesComponent{


  listSalasMultiples:any[]=[
  ];

  private salaService = inject(SalaService);
  formSalaMultiple: FormGroup;
  public listSala: salaResponse[] = [];

  public selectedSalas: salaResponse[] = [];


  constructor(private route: ActivatedRoute, private fb: FormBuilder,private salaMultiplesService: SalaMultiplesService) {
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


  listReservasMultiples: any[] = []; // Inicializar la lista

  manejarReservaSeleccionada(data: any) {
    this.listReservasMultiples.push(data); // Agregar los datos a la lista
    console.log('Lista de reservas múltiples:', this.listReservasMultiples);
  }

   // Método para eliminar todas las reservas
   eliminarTodo() {
    this.listReservasMultiples = []; // Vaciar la lista
    console.log('Lista de reservas eliminada:', this.listReservasMultiples);
  }

   // Método para calcular la capacidad total
   get capacidadTotal(): number {
    return this.listReservasMultiples.reduce((total, reserva) => total + reserva.capacidad, 0);
  }

  confirmarMultiReservas() {
    const multiReservas: multiReserva[] = this.listReservasMultiples.map(sala => {
        const fechaActual = new Date(); // Obtener la fecha actual
        const [horaInicio, minutosInicio] = sala.horaInicio.split(':').map(Number); // Separar horas y minutos
        const [horaFin, minutosFin] = sala.horaFin.split(':').map(Number); // Separar horas y minutos

        // Crear objetos de fecha con la hora correspondiente y restar 3 horas
        const fechaHoraInicio = new Date(fechaActual.getFullYear(), fechaActual.getMonth(), fechaActual.getDate(), horaInicio - 3, minutosInicio);
        const fechaHoraFin = new Date(fechaActual.getFullYear(), fechaActual.getMonth(), fechaActual.getDate(), horaFin - 3, minutosFin);

        return {
            idReserva: 0, // Asegúrate de asignar un valor correcto si es necesario
            idUsuario: this.getUserId(), // Lógica para obtener el id del usuario
            idSala: sala.idSala,
            priority: sala.propertyForm, // Usar propertyForm como priority
            horaInicio: fechaHoraInicio.toISOString(), // Convertir a formato ISO
            horaFin: fechaHoraFin.toISOString(), // Convertir a formato ISO
            state: 'Reservado' // O el estado que necesites
        };
    });

    console.log("esto es multi");
    console.log(multiReservas);
    
    // Cambiar aquí para usar multiReservas en lugar de ListMultiReserva
    this.salaMultiplesService.crearMultiReservas(multiReservas).subscribe(
        response => {
            console.log(response);
            console.log('Reservas creadas con éxito', response);
            // Aquí puedes manejar la respuesta, por ejemplo, mostrar un mensaje o limpiar la lista
            this.eliminarTodo(); // Limpiar la lista si es necesario
        },
        error => {
            console.error('Error al crear reservas', error);
            // Manejo de errores
        }
    );
}



  getUserId(): number {
    const userId = localStorage.getItem('userId');
    return userId ? Number(userId) : 1; // Devuelve 1 si no se encuentra el ID
}

  // Método para eliminar una reserva específica por su idSala
  eliminarReserva(idSala: number) {
    this.listReservasMultiples = this.listReservasMultiples.filter(reserva => reserva.idSala !== idSala);
    console.log('Reserva eliminada con idSala:', idSala);
    console.log('Lista actualizada:', this.listReservasMultiples);
  }

  


  

}
