import { CommonModule } from '@angular/common';
import { Component, Input, input } from '@angular/core';

@Component({
  selector: 'app-card-mis-salas',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './card-mis-salas.component.html',
  styleUrl: './card-mis-salas.component.css'
})
export class CardMisSalasComponent {
  @Input() prioridad!: string;
  @Input() piso!: number;
  @Input() habitacion!: number;
  @Input() capacidad!: number;
}
