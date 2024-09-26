import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ModalComponent } from '../modal/modal.component';


@Component({
  selector: 'app-card-sala',
  standalone: true,
  imports: [CommonModule,ModalComponent],
  templateUrl: './card-sala.component.html',
  styleUrl: './card-sala.component.css'
})
export class CardSalaComponent {
    @Input() idSala!: number;
    @Input() idReserva!: number;
    @Input() codigoSala!: string;
    @Input() prioridad!: number;
    @Input() piso!: number;
    @Input() nombreSala!: string;
    @Input() capacidad!: number;
    @Input() horaFin!: string;
    @Input() horaInicio!: string;
    @Input() modalId!: string;




}
