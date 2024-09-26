import { Component } from '@angular/core';
import { ModalEditSalaComponent } from '../modal-edit-sala/modal-edit-sala.component';

import { CommonModule } from '@angular/common';
import { ModalEditSalaService } from '../modal-edit-sala.service';

@Component({
  selector: 'app-panel-salas',
  standalone: true,
  imports: [ModalEditSalaComponent,CommonModule],
  templateUrl: './panel-salas.component.html',
  styleUrl: './panel-salas.component.css'
})
export class PanelSalasComponent {

  salas = [
    { id: 1, nombreSala: 'A1' ,capacidad:' 23',piso:0},
    { id: 2, nombreSala: 'A2' ,capacidad:' 32', piso:0},
    { id: 3, nombreSala: 'A3' ,capacidad:' 40',piso:0 },
    { id: 4, nombreSala: 'A4' ,capacidad:' 32',piso:0 },
    { id: 5, nombreSala: 'B1' ,capacidad:' 18',piso:1}
  ];

  constructor(private modalEditSalaService: ModalEditSalaService) {}

  eliminarSala(id: number) {
    if (confirm('¿Estás seguro de que deseas eliminar esta sala?')) {
      this.modalEditSalaService.deleteSala(id).subscribe({
        next: (response) => {
          console.log('Usuario eliminado:', response);
          location.reload();
        },
        error: (error) => {
          console.error('Error al eliminar el usuario:', error);
          
        }
      });
    }
  }
}
