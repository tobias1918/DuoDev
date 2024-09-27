import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { ModalEditUsuarioService } from '../modal-edit-usuario.service';
import { ModalEditSalaService } from '../modal-edit-sala.service';
import { UsuarioEdit } from '../models/UsuarioEdit';

@Component({
  selector: 'app-modal-edit-usuario',
  standalone: true,
  imports:[ReactiveFormsModule,CommonModule],
  templateUrl: './modal-edit-usuario.component.html',
  styleUrls: ['./modal-edit-usuario.component.css']
})
export class ModalEditUsuarioComponent implements OnInit {
  

  @Input() modalId!: string;
  @Input() usuario: any; // El objeto usuario llega desde el componente padre

  editUserForm!: FormGroup;

  constructor(private fb: FormBuilder, private modalEditUsuarioService: ModalEditUsuarioService) {}

  ngOnInit(): void {
    // Inicializa el formulario
    this.editUserForm = this.fb.group({
      idUser: [null], // Campo oculto para el ID
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      rol: [null, Validators.required], // Default role selection
    });

    // Establece los valores del usuario si está disponible
    if (this.usuario) {
      this.setFormValues();
    }
  }

  // Establece los valores del usuario en el formulario
  setFormValues() {
    this.editUserForm.patchValue({
      idUser: this.usuario.idUser,
      name: this.usuario.name,
      surname: this.usuario.surname,
      email: this.usuario.email,
      rol: this.usuario.rol
    });
  }

  // Método para guardar los cambios
  guardarCambios() {
    if (this.editUserForm.valid) {
      const updatedUser = this.editUserForm.value;
      const request: UsuarioEdit = {
        idUser: this.editUserForm.value.idUser,
        name: this.editUserForm.value.name,
        surname: this.editUserForm.value.surname,
        password:null,
        email:this.editUserForm.value.email,
        rol: Number(this.editUserForm.value.rol),
      }
      this.modalEditUsuarioService.updateUser(updatedUser).subscribe({
        next: (response) => {
          console.log('Usuario actualizado:', response);
          window.location.reload();
          // Aquí puedes agregar la lógica para cerrar el modal o hacer algo después de la actualización
        },
        error: (error) => {
          console.error('Error al actualizar el usuario:', error);
        },
      });
    }
  }

}


