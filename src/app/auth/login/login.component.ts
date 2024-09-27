import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccesoService } from '../services/acceso.service';
import { Router } from '@angular/router';
import { Login } from '../models/Login';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  private accesoService=inject(AccesoService);
  private router = inject(Router);

 



  // PASAR FUNCIONES ENTRE COMPONENTES
  @Output() switchToRegister = new EventEmitter<void>();

  onRegisterClick() {
    this.switchToRegister.emit(); // Emite un evento para cambiar a registro
  }

  // LOGICA FORMULARIO LOGIN

  loginForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)],],
      password: ['', [Validators.required, Validators.maxLength(100)]],
    });
  }

  // LOGICA LOGIN

  // onLogin(form: FormGroup) {
  //   console.log(form)
  // }

  iniciarSesion() {
    if (this.loginForm.invalid) return;
  
    const objeto: Login = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
    };
  
    this.accesoService.login(objeto).subscribe({
      next: (data) => {
        if (data.isSuccess) {
          localStorage.setItem("token", data.token);
  
          // Llamar al método para obtener el ID de usuario
          this.obtenerIdUsuario();
        } else {
          alert("Las credenciales son incorrectas");
        }
      },
      error: (error) => {
        console.log(error.message);
      }
    });
  }

  obtenerIdUsuario() {
    // Aquí puedes hacer la llamada a tu endpoint
    this.accesoService.obtenerIdUsuario().subscribe({
      next: (data) => {
        // Supongamos que `data.id` es el ID que quieres almacenar
        console.log(data)
        localStorage.setItem("userId", data.userId);
        this.router.navigate(["home"]);
      },
      error: (error) => {
        console.log("Error al obtener el ID de usuario:", error.message);
      }
    });
  }











}
