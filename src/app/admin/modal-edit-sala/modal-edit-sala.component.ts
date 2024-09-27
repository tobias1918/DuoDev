import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalEditSalaService } from '../modal-edit-sala.service';

@Component({
  selector: 'app-modal-edit-sala',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './modal-edit-sala.component.html',
  styleUrls: ['./modal-edit-sala.component.css'], // Cambié a `styleUrls` para el plural correcto
})
export class ModalEditSalaComponent implements OnInit {
  @Input() modalId!: string;
  @Input() sala: any; // Recibe la sala desde el componente padre

  private modalEditSalaService = inject(ModalEditSalaService);
  private router = inject(Router);

  editSalaForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.editSalaForm = this.fb.group({
      idSala: [this.sala?.idSala || ''], // Asegúrate de recibir `idSala` del padre
      nameSala: [this.sala?.nameSala || '', [ Validators.maxLength(20)]],
      codSala: [this.sala?.codSala || '', [ Validators.maxLength(3)]],
      capacitySala: [this.sala?.capacitySala || '', [ Validators.pattern('^[0-9]*$')]], // Cambié el validador
    });
  }

  guardarCambiosa() {
    console.log("entre al guardar cambios")
    if (this.editSalaForm.valid) {
      const updatedSala = this.editSalaForm.value; // Obtén los valores actualizados
      console.log(this.editSalaForm.value)
      this.modalEditSalaService.updateSala(updatedSala).subscribe({
        next: (response) => {
          console.log('Sala actualizada:', response);
          window.location.reload();
        },
        error: (error) => {
          console.error('Error al actualizar la sala:', error);
        },
      });
    }
  }
}
