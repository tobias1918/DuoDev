import { Component, inject, Input } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalEditSalaService } from '../modal-edit-sala.service';

@Component({
  selector: 'app-modal-edit-sala',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './modal-edit-sala.component.html',
  styleUrl: './modal-edit-sala.component.css'
})
export class ModalEditSalaComponent {
  @Input() modalId!: string;
  @Input() sala: any; // Recibe el usuario desde el componente padre

  private modalEditSalaService=inject(ModalEditSalaService);
  private router = inject(Router);

  editSalaForm!: FormGroup;
  

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.editSalaForm = this.fb.group({
      id:[this.sala?.id],
      nombreSala: [this.sala?.nombreSala || '', [Validators.required, Validators.minLength(3)]],
      capacidad: [this.sala?.capacidad || '', [Validators.required, Validators.email,Validators.pattern('^[0-9]*$')]],
    });
  }

  guardarCambios() {
    if (this.editSalaForm.valid) {
      const updatedUser = this.editSalaForm.value;
      this.modalEditSalaService.updateSala(updatedUser).subscribe({
        next: (response) => console.log('Usuario actualizado:', response),
        error: (error) => console.error('Error al actualizar el usuario:', error),
      });
    }
  }

}
