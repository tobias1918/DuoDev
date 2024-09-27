import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserService } from './profile.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {


  id: string | null = localStorage.getItem("userId");
  user: any; // Para almacenar la información del usuario

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    if (this.id) {
      this.getUserDetails(Number(this.id));
    }
  }

  getUserDetails(id: number): void {
    this.userService.getUser(id).subscribe(
      (data) => {
        this.user = data; // Almacena la información del usuario
      },
      (error) => {
        console.error('Error fetching user data', error);
      }
    );
  }
}
