import { Component } from '@angular/core';
import { ModalEditUsuarioComponent } from '../modal-edit-usuario/modal-edit-usuario.component';
import { CommonModule } from '@angular/common';
import { ModalEditUsuarioService } from '../modal-edit-usuario.service';


@Component({
  selector: 'app-panel-usuarios',
  standalone: true,
  imports: [ModalEditUsuarioComponent,CommonModule],
  templateUrl: './panel-usuarios.component.html',
  styleUrl: './panel-usuarios.component.css'
})
export class PanelUsuariosComponent {

  usuarios = [
    { id: 1, nombre: 'Tobias' ,apellido:' Molina', email: 'tobias@gmail.com', rol: 'usuario' },
    { id: 2, nombre: 'Juan' ,apellido:' Perez', email: 'juan@gmail.com',  rol: 'usuario' },
    { id: 3, nombre: 'Ana' ,apellido:' Rodriguez', email: 'ana@gmail.com', rol: 'admin' },
    { id: 4, nombre: 'Lucas' ,apellido:' Sanchez', email: 'lucas@gmail.com',  rol: 'usuario' },
    { id: 5, nombre: 'Maria' ,apellido:' Lopez', email: 'maria@gmail.com', rol: 'usuario' }
  ];

  constructor(private modalEditUsuarioService: ModalEditUsuarioService) {}

  eliminarUsuario(id: number) {
    if (confirm('¿Estás seguro de que deseas eliminar este usuario?')) {
      this.modalEditUsuarioService.deleteUser(id).subscribe({
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
