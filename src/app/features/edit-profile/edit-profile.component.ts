import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../profile/profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-profile',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  formUpdate: FormGroup;

  constructor(private fb: FormBuilder, private userService: UserService, private router: Router) {
    this.formUpdate = this.fb.group({
      nombre: ['', [Validators.required, Validators.maxLength(50)]],
      apellido: ['', [Validators.required, Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      password: ['', [Validators.maxLength(100)]], // Haciendo que sea opcional para permitir el envío de null
      confirmacionPassword: ['', [Validators.maxLength(100)]],
    });

    // Logic for checking password match
    this.formUpdate.get('password')?.valueChanges.subscribe(() => {
      this.checkPasswords();
    });

    this.formUpdate.get('confirmacionPassword')?.valueChanges.subscribe(() => {
      this.checkPasswords();
    });
  }

  ngOnInit(): void {
    // Load user data to populate form (optional, if you want to pre-fill the form)
    this.loadUserData();
  }

  checkPasswords() {
    const password = this.formUpdate.get('password')?.value;
    const confirmPassword = this.formUpdate.get('confirmacionPassword')?.value;

    if (password !== confirmPassword) {
      this.formUpdate.get('confirmacionPassword')?.setErrors({ mismatch: true });
      this.formUpdate.get('password')?.setErrors({ mismatch: true });
    } else {
      this.formUpdate.get('confirmacionPassword')?.setErrors(null);
      this.formUpdate.get('password')?.setErrors(null);
    }
  }

  registrarse() {
    if (this.formUpdate.invalid) return;

    const userId = localStorage.getItem("userId"); // Obtener el ID del usuario desde localStorage

    const user = {
      idUser: userId ? Number(userId) : null, // Convertir a número si existe
      name: this.formUpdate.get('nombre')?.value,
      surname: this.formUpdate.get('apellido')?.value,
      password: this.formUpdate.get('password')?.value || null, // Enviar null si la contraseña está vacía
      email: this.formUpdate.get('email')?.value || null, // Enviar null si el email está vacío
      rol: 0 // Seteando rol en 0
    };

    this.userService.editPerfil(user).subscribe({
      next: (data) => {
        if (data.isSuccess) {
          // Redirigir o mostrar mensaje de éxito
          this.router.navigate(['/profile']);
        } else {
          alert("No se pudo actualizar el perfil");
        }
      },
      error: (err) => {
        console.error('Error updating profile', err);
        alert("Ocurrió un error al actualizar el perfil");
      }
    });
  }

  // Método opcional para cargar los datos del usuario al editar
  loadUserData(): void {
    const userId = localStorage.getItem("userId");
    if (userId) {
      this.userService.getUser(Number(userId)).subscribe(data => {
        this.formUpdate.patchValue({
          nombre: data.name,
          apellido: data.surname,
          email: data.email,
          // No se llena la contraseña por razones de seguridad
        });
      });
    }
  }
}
