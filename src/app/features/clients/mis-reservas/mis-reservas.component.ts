import { Component } from '@angular/core';
import { CardSalaComponent } from "../card-sala/card-sala.component";
import { CardMisSalasComponent } from '../card-mis-salas/card-mis-salas.component';


@Component({
  selector: 'app-mis-reservas',
  standalone: true,
  imports: [CardMisSalasComponent],
  templateUrl: './mis-reservas.component.html',
  styleUrl: './mis-reservas.component.css'
})
export class MisReservasComponent {
  salas = [
    { prioridad: 'Alta', piso: 1, habitacion: 2, capacidad: 21 },
    { prioridad: 'Media', piso: 2, habitacion: 3, capacidad: 20 },
    { prioridad: 'Baja', piso: 3, habitacion: 1, capacidad: 22 }
  ];
}
