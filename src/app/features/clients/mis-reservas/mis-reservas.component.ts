import { Component, OnInit } from '@angular/core';
import { CardSalaComponent } from "../card-sala/card-sala.component";
import { CardMisSalasComponent } from '../card-mis-salas/card-mis-salas.component';
import { reservaModel } from '../models/reservaModel';
import { MisReservasService } from '../services/mis-reservas.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-mis-reservas',
  standalone: true,
  imports: [CardMisSalasComponent,CommonModule],
  templateUrl: './mis-reservas.component.html',
  styleUrl: './mis-reservas.component.css'
})
export class MisReservasComponent implements OnInit {
  reservas: reservaModel[] = []; // Lista donde guardaremos las reservas
  reservasMultiples:reservaModel[][]=[];
  constructor(private misReservasService: MisReservasService) {}

  ngOnInit(): void {
    this.getUserReservas();
    this.getUsersMultiReservas();
  }

  getUserReservas(): void {
    const userId = Number(localStorage.getItem('userId')); // Recuperar el ID del usuario del localStorage
    this.misReservasService.getUserSalasSimples(userId).subscribe(
      (data: reservaModel[]) => {
        this.reservas = data;
      },
      (error) => {
        console.error('Error al obtener reservas', error);
      }
    );
}

getUsersMultiReservas(): void {
  const userId = Number(localStorage.getItem('userId')); // Recuperar el ID del usuario del localStorage
  this.misReservasService.getUserSalasMultiples(userId).subscribe(
    (data: reservaModel[][]) => {
      console.log(data);
      console.log("e");
      this.reservasMultiples = data; // Guardamos las reservas múltiples
    },
    (error) => {
      console.error('Error al obtener reservas', error);
    }
  );
}


}
