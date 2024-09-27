import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { crearReservaParam } from '../models/crearReservaParam';
import { SalaService } from '../services/salas-individuales.service';

@Component({
  selector: 'app-modal-2',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent2 implements OnInit {
  @Input() idSala!: number;
  @Input() idReserva!: number;
  @Input() codigoSala!: string;
  @Input() prioridad!: number;
  @Input() piso!: number;
  @Input() nombreSala!: string;
  @Input() capacidad!: number;
  @Input() horaFin!: string;
  @Input() horaInicio!: string;
  @Input() modalId!: string;
  @Input() propertyForm!: number;

  formCrearReserva!: FormGroup;

  constructor(private fb: FormBuilder, private salaService: SalaService) { }

  ngOnInit(): void {
    // Inicializa el formulario en ngOnInit para asegurar que los valores de los @Input ya estén presentes
    this.formCrearReserva = this.fb.group({
      prioridad: [this.prioridad, Validators.required],  // Inicializamos con el valor de los inputs
      idSala: [this.idSala, Validators.required],
      horaInicio: [this.horaInicio, Validators.required],
      horaFin: [this.horaFin, Validators.required],
      propertyForm: [this.propertyForm, Validators.required]
    });
  }

  crearReserva() {
    if (this.formCrearReserva.invalid) {
      console.log("Formulario inválido:", this.formCrearReserva.errors);
      return; // El formulario es inválido, no continuar
    }

    const idUsuario = localStorage.getItem('userId');

    // Convertir horaInicio y horaFin de string a Date en zona horaria local
    const currentDate = new Date();

    const [horaInicioHoras, horaInicioMinutos] = this.formCrearReserva.value.horaInicio.split(':').map(Number);
    const [horaFinHoras, horaFinMinutos] = this.formCrearReserva.value.horaFin.split(':').map(Number);

    const horaInicioDate = new Date(currentDate);
    horaInicioDate.setHours(horaInicioHoras, horaInicioMinutos, 0, 0);

    const horaFinDate = new Date(currentDate);
    horaFinDate.setHours(horaFinHoras, horaFinMinutos, 0, 0);

    // Formatear la fecha localmente en lugar de usar toISOString() para evitar desfase de UTC
    const formatLocalDateTime = (date: Date) => {
      const year = date.getFullYear();
      const month = String(date.getMonth() + 1).padStart(2, '0'); // Mes en base 0
      const day = String(date.getDate()).padStart(2, '0');
      const hours = String(date.getHours()).padStart(2, '0');
      const minutes = String(date.getMinutes()).padStart(2, '0');
      return `${year}-${month}-${day}T${hours}:${minutes}:00`; // Formato 'YYYY-MM-DDTHH:MM:SS'
    };

    const reserva: crearReservaParam = {
      idReserva: 0,  // O el valor que corresponda
      idUsuario: idUsuario ? Number(idUsuario) : 0, // Convertimos el idUsuario a número
      idSala: Number(this.formCrearReserva.value.idSala),
      priority: Number(this.formCrearReserva.value.propertyForm),
      horaInicio: formatLocalDateTime(horaInicioDate),
      horaFin: formatLocalDateTime(horaFinDate),
    };

    console.log('Reserva creada:', reserva);

    // Llamar al servicio para crear la reserva
    this.salaService.crearReserva(reserva).subscribe({
      next: (response: any) => {
        console.log('Reserva creada con éxito:', response);
        window.location.reload();
      },
      error: (error: any) => {
        console.error('Error al crear la reserva:', error);
      }
    });
  }
}
