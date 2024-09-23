import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { IProduct } from '../models/Product.model';
import { IUsuario } from '../models/usuario.model';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {

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

  private _registerService = inject(RegisterService);

  usuarioList:IUsuario[]=[];

  ngOnInit(): void {
    this._registerService.getUsuarios().subscribe((data:IUsuario[])=>{
      console.log(data);
      this.usuarioList = data;
    });
  }


listUsuarios: any[] = [
  {
    nombre: 'Tobias',
    apellido: 'Molina',
    email: 'tobias@gmail.com',
    password: 'password',
    confirmacionPassword: 'password',
  },
  {
    nombre: 'Franco',
    apellido: 'Lopez',
    email: 'franco@gmail.com',
    password: 'password2',
    confirmacionPassword: 'password2',
  },
  {
    nombre: 'Uriel',
    apellido: 'Gonzalez',
    email: 'uriel@gmail.com',
    password: 'password3',
    confirmacionPassword: 'password3',
  },
];




registrarse() {
  const usuario: any = {
    nombre: this.formRegister.get('nombre')?.value,
    apellido: this.formRegister.get('apellido')?.value,
    email: this.formRegister.get('email')?.value,
    password: this.formRegister.get('password')?.value,
  };

  console.log(usuario);
  this.listUsuarios.push(usuario);
  this.formRegister.reset();
}








}
