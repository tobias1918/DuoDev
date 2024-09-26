import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { IUsuario } from '../models/usuario.model';
import { AccesoService } from '../services/acceso.service';
import { Router } from '@angular/router';
import { Usuario } from '../models/Usuario';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  private accesoService=inject(AccesoService);
  private router = inject(Router);


  //LOGICA PARA ENVIAR FUNCIONES ENTRE COMPONENTES
  @Output() switchToLogin = new EventEmitter<void>();

  onLoginClick() {
    this.switchToLogin.emit(); // Emite un evento para cambiar a login
  }

  //CONSTRUCTOR
  formRegister: FormGroup;

  constructor(private fb: FormBuilder) {
    this.formRegister = this.fb.group({
      nombre: ['', [Validators.required, Validators.maxLength(50)]],
      apellido: ['', [Validators.required, Validators.maxLength(50)]],
      email: ['',[Validators.required, Validators.email, Validators.maxLength(100)],],
      password: ['', [Validators.required, Validators.maxLength(100)]],
      confirmacionPassword: ['',[Validators.required, Validators.maxLength(100)],],
    });

  //LOGICA FORMS


  // Mirar los cambios en ambos campos contraseñas
  this.formRegister.get('password')?.valueChanges.subscribe(() => {
    this.checkPasswords();
  });

  this.formRegister
    .get('confirmacionPassword')
    ?.valueChanges.subscribe(() => {
      this.checkPasswords();
    });
}

  checkPasswords() {
  const password = this.formRegister.get('password')?.value;
  const confirmPassword = this.formRegister.get(
    'confirmacionPassword'
  )?.value;

  if (password !== confirmPassword) {
    this.formRegister
      .get('confirmacionPassword')
      ?.setErrors({ mismatch: true });
    this.formRegister.get('password')?.setErrors({ mismatch: true }); // Opcional, si también deseas mostrar un error en el campo de contraseña
  } else {
    this.formRegister.get('confirmacionPassword')?.setErrors(null);
    this.formRegister.get('password')?.setErrors(null); // Opcional, si has añadido la validación en el campo de contraseña
  }
}


//LOGICA API 




registrarse() {
  if(this.formRegister.invalid)return;
  const objeto:Usuario = {
    idUser:0,
    name: this.formRegister.get('nombre')?.value,
    surname: this.formRegister.get('apellido')?.value,
    password: this.formRegister.get('password')?.value,
    email: this.formRegister.get('email')?.value,
    
  };
  console.log(objeto);

  this.accesoService.registrarse(objeto).subscribe({
    next:(data)=>{
      if(data.isSuccess){
        this.onLoginClick()
      }else{
        alert("No se pudo registrar");
      }
    }
  })
}



}
