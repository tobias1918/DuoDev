import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ModalEditUsuarioService } from './../modal-edit-usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-modal-edit-usuario',
  standalone: true,
  imports:[ReactiveFormsModule,CommonModule],
  templateUrl: './modal-edit-usuario.component.html',
  styleUrls: ['./modal-edit-usuario.component.css']
})
export class ModalEditUsuarioComponent implements OnInit {
  

  @Input() modalId!: string;
  @Input() usuario: any; // Recibe el usuario desde el componente padre

  private modalEditUsuarioService=inject(ModalEditUsuarioService);
  private router = inject(Router);

  editUserForm!: FormGroup;
  

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.editUserForm = this.fb.group({
      id:[this.usuario?.id],
      nombre: [this.usuario?.nombre || '', [Validators.required, Validators.minLength(3)]],
      apellido: [this.usuario?.apellido || '', [Validators.required, Validators.minLength(3)]],
      email: [this.usuario?.email || '', [Validators.required, Validators.email]],
      rol: [this.usuario?.rol || 'usuario', Validators.required], // Valor inicial y validación del rol
    });
  }

  guardarCambios() {
    if (this.editUserForm.valid) {
      const updatedUser = this.editUserForm.value;
      this.modalEditUsuarioService.updateUser(updatedUser).subscribe({
        next: (response) => console.log('Usuario actualizado:', response),
        error: (error) => console.error('Error al actualizar el usuario:', error),
      });
    }
  }



}


