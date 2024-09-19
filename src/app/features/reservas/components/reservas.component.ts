import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-reservas',
  standalone: true,
  imports: [RouterLink,CommonModule,ReactiveFormsModule],
  templateUrl: './reservas.component.html',
  styleUrl: './reservas.component.css'
})
export class ReservasComponent {

  salasIndividualesForm: FormGroup;
  constructor(private fb: FormBuilder, private router: Router) {
    this.salasIndividualesForm = this.fb.group({
      numeroAsistentes: [''],
      horario: [''],
      prioridad: ['']
    });
  }

  onSubmit() {
    console.log(this.salasIndividualesForm.value)
    const formData = this.salasIndividualesForm.value;
    this.router.navigate(['/reserva/salas-individuales'], { queryParams: formData });
  }


}
