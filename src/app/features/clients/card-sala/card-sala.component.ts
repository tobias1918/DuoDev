import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';


@Component({
  selector: 'app-card-sala',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './card-sala.component.html',
  styleUrl: './card-sala.component.css'
})
export class CardSalaComponent {
    @Input() prioridad!: string;
    @Input() piso!: number;
    @Input() habitacion!: number;
    @Input() capacidad!: number;

  listReservas:any[]=[
    {
        "salaID": 1,
        "piso": 1,
        "habitacion": 1,
        "capacidad": 35,
        "horario": [
            {
                "HoraInicio": "09:00",
                "HoraFin": "10:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "10:00",
                "HoraFin": "11:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "11:00",
                "HoraFin": "12:00",
                "Disponible": false,
                "Prioridad": "media"
            },
            {
                "HoraInicio": "12:00",
                "HoraFin": "13:00",
                "Disponible": false,
                "Prioridad": "baja"
            },
            {
                "HoraInicio": "13:00",
                "HoraFin": "14:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "14:00",
                "HoraFin": "15:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "15:00",
                "HoraFin": "16:00",
                "Disponible": false,
                "Prioridad": "media"
            },
            {
                "HoraInicio": "16:00",
                "HoraFin": "17:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "17:00",
                "HoraFin": "18:00",
                "Disponible": false,
                "Prioridad": "baja"
            }
        ]
    },
    {
        "salaID": 2,
        "piso": 1,
        "habitacion": 2,
        "capacidad": 20,
        "horario": [
            {
                "HoraInicio": "09:00",
                "HoraFin": "10:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "10:00",
                "HoraFin": "11:00",
                "Disponible": false,
                "Prioridad": "media"
            },
            {
                "HoraInicio": "11:00",
                "HoraFin": "12:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "12:00",
                "HoraFin": "13:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "13:00",
                "HoraFin": "14:00",
                "Disponible": false,
                "Prioridad": "baja"
            },
            {
                "HoraInicio": "14:00",
                "HoraFin": "15:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "15:00",
                "HoraFin": "16:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "16:00",
                "HoraFin": "17:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "17:00",
                "HoraFin": "18:00",
                "Disponible": false,
                "Prioridad": "media"
            }
        ]
    },
    {
        "salaID": 3,
        "piso": 1,
        "habitacion": 3,
        "capacidad": 25,
        "horario": [
            {
                "HoraInicio": "09:00",
                "HoraFin": "10:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "10:00",
                "HoraFin": "11:00",
                "Disponible": false,
                "Prioridad": "baja"
            },
            {
                "HoraInicio": "11:00",
                "HoraFin": "12:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "12:00",
                "HoraFin": "13:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "13:00",
                "HoraFin": "14:00",
                "Disponible": false,
                "Prioridad": "media"
            },
            {
                "HoraInicio": "14:00",
                "HoraFin": "15:00",
                "Disponible": false,
                "Prioridad": "baja"
            },
            {
                "HoraInicio": "15:00",
                "HoraFin": "16:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "16:00",
                "HoraFin": "17:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "17:00",
                "HoraFin": "18:00",
                "Disponible": true,
                "Prioridad": null
            }
        ]
    },
    {
        "salaID": 4,
        "piso": 1,
        "habitacion": 4,
        "capacidad": 30,
        "horario": [
            {
                "HoraInicio": "09:00",
                "HoraFin": "10:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "10:00",
                "HoraFin": "11:00",
                "Disponible": false,
                "Prioridad": "media"
            },
            {
                "HoraInicio": "11:00",
                "HoraFin": "12:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "12:00",
                "HoraFin": "13:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "13:00",
                "HoraFin": "14:00",
                "Disponible": false,
                "Prioridad": "baja"
            },
            {
                "HoraInicio": "14:00",
                "HoraFin": "15:00",
                "Disponible": false,
                "Prioridad": "media"
            },
            {
                "HoraInicio": "15:00",
                "HoraFin": "16:00",
                "Disponible": true,
                "Prioridad": null
            },
            {
                "HoraInicio": "16:00",
                "HoraFin": "17:00",
                "Disponible": false,
                "Prioridad": "alta"
            },
            {
                "HoraInicio": "17:00",
                "HoraFin": "18:00",
                "Disponible": true,
                "Prioridad": null
            }
        ]
    }
]

pageSize: number = 6;  // Número de horarios por página (6 para una grilla de 2x3)
currentPage: number = 0;  // Página actual
totalPages: number = 0;  // Total de páginas
pagedHorarios: any[] = [];  // Horarios que se mostrarán en la página actual

ngOnInit() {
  this.calculateTotalPages();
  this.updatePagedHorarios();
}

// Calcula el número total de páginas basándose en los horarios de la reserva actual
calculateTotalPages() {
  const currentReserva = this.listReservas[this.currentPage];
  this.totalPages = Math.ceil(currentReserva.horario.length / this.pageSize);
}

// Actualiza los horarios que se mostrarán en la página actual
updatePagedHorarios() {
  const currentReserva = this.listReservas[this.currentPage];  // Reserva actual
  const startIndex = this.currentPage * this.pageSize;
  this.pagedHorarios = currentReserva.horario.slice(startIndex, startIndex + this.pageSize);
}

// Cambia a la siguiente página
nextPage() {
  if (this.currentPage < this.totalPages - 1) {
    this.currentPage++;
    this.updatePagedHorarios();
  }
}

// Cambia a la página anterior
prevPage() {
  if (this.currentPage > 0) {
    this.currentPage--;
    this.updatePagedHorarios();
  }
}








}
