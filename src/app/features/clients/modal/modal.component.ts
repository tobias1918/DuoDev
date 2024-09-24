import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  @Input() prioridad!: string;
  @Input() piso!: number;
  @Input() nombreSala!: string;
  @Input() capacidad!: number;
  @Input() horaFin!: string;
  @Input() horaInicio!: string;
  @Input() modalId!: string;
}
