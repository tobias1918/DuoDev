import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-profile',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './edit-profile.component.html',
  styleUrl: './edit-profile.component.css'
})
export class EditProfileComponent {


  
  //CONSTRUCTOR
  formUpdate: FormGroup;

  constructor(private fb: FormBuilder) {
    this.formUpdate = this.fb.group({
      nombre: ['', [Validators.required, Validators.maxLength(50)]],
      apellido: ['', [Validators.required, Validators.maxLength(50)]],
      email: ['',[Validators.required, Validators.email, Validators.maxLength(100)],],
      password: ['', [Validators.required, Validators.maxLength(100)]],
      confirmacionPassword: ['',[Validators.required, Validators.maxLength(100)],],
    });

  //LOGICA FORMS


  // Mirar los cambios en ambos campos contraseñas
  this.formUpdate.get('password')?.valueChanges.subscribe(() => {
    this.checkPasswords();
  });

  this.formUpdate
    .get('confirmacionPassword')
    ?.valueChanges.subscribe(() => {
      this.checkPasswords();
    });
}

  checkPasswords() {
  const password = this.formUpdate.get('password')?.value;
  const confirmPassword = this.formUpdate.get(
    'confirmacionPassword'
  )?.value;

  if (password !== confirmPassword) {
    this.formUpdate
      .get('confirmacionPassword')
      ?.setErrors({ mismatch: true });
    this.formUpdate.get('password')?.setErrors({ mismatch: true }); // Opcional, si también deseas mostrar un error en el campo de contraseña
  } else {
    this.formUpdate.get('confirmacionPassword')?.setErrors(null);
    this.formUpdate.get('password')?.setErrors(null); // Opcional, si has añadido la validación en el campo de contraseña
  }
}


//LOGICA API 

  // private _registerService = inject(RegisterService);

  // usuarioList:IUsuario[]=[];

  // ngOnInit(): void {
  //   this._registerService.getUsuarios().subscribe((data:IUsuario[])=>{
  //     console.log(data);
  //     this.usuarioList = data;
  //   });
  // }





 registrarse() {
//   if(this.formRegister.invalid)return;
//   const objeto:Usuario = {
//     nombre: this.formRegister.get('nombre')?.value,
//     apellido: this.formRegister.get('apellido')?.value,
//     email: this.formRegister.get('email')?.value,
//     password: this.formRegister.get('password')?.value,
//   };

//   this.accesoService.registrarse(objeto).subscribe({
//     next:(data)=>{
//       if(data.isSuccess){
//         this.router.navigate(["/signup"])
//       }else{
//         alert("No se pudo registrar");
//       }
//     }
  // })
 }

}
