import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ModalComponent } from '../modal/modal.component';
import { ModalComponent2 } from '../modal-2/modal.component';


@Component({
  selector: 'app-card-sala-2',
  standalone: true,
  imports: [CommonModule,ModalComponent2],
  templateUrl: './card-sala.component.html',
  styleUrl: './card-sala.component.css'
})
export class CardSalaComponent2 {
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
    @Input() propertyForm!: number;

    @Output() reservaSeleccionada = new EventEmitter<any>();

    seleccionarReservaMultiple() {
      const data = this.construirDatos();
      this.reservaSeleccionada.emit(data); // Emitir los datos hacia el padre
    }

  // Método para construir el objeto con los atributos
   construirDatos() {
    return {
      prioridad: this.prioridad,
      piso: this.piso,
      nombreSala: this.nombreSala,
      capacidad: this.capacidad,
      horaInicio: this.horaInicio,
      horaFin: this.horaFin,
      idSala: this.idSala,
      idReserva: this.idReserva,
      codigoSala: this.codigoSala,
      propertyForm: this.propertyForm,
    };
  }

}
