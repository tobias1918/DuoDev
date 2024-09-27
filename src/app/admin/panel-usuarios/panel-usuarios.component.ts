import { Component } from '@angular/core';
import { ModalEditUsuarioComponent } from '../modal-edit-usuario/modal-edit-usuario.component';
import { CommonModule } from '@angular/common';
import { ModalEditUsuarioService } from '../modal-edit-usuario.service';
import { UsuarioEdit } from '../models/UsuarioEdit';
import { PanelUsuariosService } from '../services/panel-usuarios.service';


@Component({
  selector: 'app-panel-usuarios',
  standalone: true,
  imports: [ModalEditUsuarioComponent,CommonModule],
  templateUrl: './panel-usuarios.component.html',
  styleUrl: './panel-usuarios.component.css'
})
export class PanelUsuariosComponent {

  usuarios: UsuarioEdit[] = [];

  constructor(
    private modalEditUsuarioService: ModalEditUsuarioService,
    private panelUsuarioService: PanelUsuariosService
  ) {}

  ngOnInit() {
    console.log("entre");
    this.cargarUsuarios();
  }

  // Método para cargar todas las salas
  cargarUsuarios() {
    this.panelUsuarioService.traerUsuarios().subscribe({
      next: (data) => {  // Ahora 'data' es un array de Sala
        console.log(data);
        this.usuarios = data; // Asigna las salas obtenidas al array
        console.log('Salas cargadas:', this.usuarios);
      },
      error: (error: any) => {
        console.error('Error al cargar las salas:', error);
      },
    });
  }
  

  eliminarUsuario(id: number) {
    if (confirm('¿Estás seguro de que deseas eliminar este usuario?')) {
      this.modalEditUsuarioService.deleteUser(id).subscribe({
        next: (response) => {
          console.log('Usuario eliminado:', response);
          this.cargarUsuarios();
        },
        error: (error) => {
          console.error('Error al eliminar el usuario:', error);
          
        }
      });
    }
  }
}
