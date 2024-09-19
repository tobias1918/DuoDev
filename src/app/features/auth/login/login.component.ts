import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  // PASAR FUNCIONES ENTRE COMPONENTES
  @Output() switchToRegister = new EventEmitter<void>();

  onRegisterClick() {
    this.switchToRegister.emit(); // Emite un evento para cambiar a registro
  }

   // LOGICA FORMULARIO LOGIN

   loginForm: FormGroup;
   constructor(private fb: FormBuilder) {
     this.loginForm = this.fb.group({
      email: ['',[Validators.required, Validators.email, Validators.maxLength(100)],],
      password: ['', [Validators.required, Validators.maxLength(100)]],
          });
    }

    // LOGICA LOGIN

    onLogin(form:FormGroup) {
      console.log(form)
    }













}
