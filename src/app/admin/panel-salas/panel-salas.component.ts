import { Component, OnInit } from '@angular/core';
import { ModalEditSalaComponent } from '../modal-edit-sala/modal-edit-sala.component';
import { CommonModule } from '@angular/common';
import { ModalEditSalaService } from '../modal-edit-sala.service';
import { PanelUsuariosService } from '../services/panel-usuarios.service';
import { Sala } from '../models/sala';

@Component({
  selector: 'app-panel-salas',
  standalone: true,
  imports: [ModalEditSalaComponent, CommonModule],
  templateUrl: './panel-salas.component.html',
  styleUrls: ['./panel-salas.component.css'],
})
export class PanelSalasComponent implements OnInit {

  salas: Sala[] = [];

  constructor(
    private modalEditSalaService: ModalEditSalaService,
    private panelUsuarioService: PanelUsuariosService
  ) {}

  ngOnInit() {
    console.log("entre");
    this.cargarSalas();
  }

  // Método para cargar todas las salas
  cargarSalas() {
    this.panelUsuarioService.traerSalas().subscribe({
      next: (data) => {  // Ahora 'data' es un array de Sala
        console.log(data);
        this.salas = data; // Asigna las salas obtenidas al array
        console.log('Salas cargadas:', this.salas);
      },
      error: (error: any) => {
        console.error('Error al cargar las salas:', error);
      },
    });
  }
  
  eliminarSala(idSala: number) {
    const confirmacion = confirm('¿Estás seguro de que deseas eliminar esta sala?');
    if (confirmacion) {
      this.modalEditSalaService.deleteSala(idSala).subscribe({
        next: (response) => {
          console.log('Sala eliminada:', response);
          this.cargarSalas(); // Recarga la lista de salas después de eliminar
        },
        error: (error) => {
          console.error('Error al eliminar la sala:', error);
        },
      });
    }
  }
 
}
