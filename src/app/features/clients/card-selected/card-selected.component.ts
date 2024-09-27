import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-card-selected',
  standalone: true,
  imports: [],
  templateUrl: './card-selected.component.html',
  styleUrl: './card-selected.component.css'
})
export class CardSelectedComponent {
  @Input() idSala!: number;
  @Input() idReserva!: number;
  @Input() codigoSala!: string;
  @Input() prioridad!: number;
  @Input() piso!: number;
  @Input() nombreSala!: string;
  @Input() capacidad!: number;
  @Input() horaFin!: string;
  @Input() horaInicio!: string;
  @Input() propertyForm!: number;

  @Output() eliminarReserva = new EventEmitter<number>();

  // Método que acepta el idSala como argumento y lo emite
  eliminar(idSala: number) {
    this.eliminarReserva.emit(idSala); // Emitimos el idSala al padre
  }

}
