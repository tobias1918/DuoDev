import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-page',
  standalone: true,
  imports: [RouterOutlet, RouterLink, CommonModule],
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent  {
  menuOption: string = '';

  onOption(menuOption: string) {
    this.menuOption = menuOption;
  }

  constructor(private router: Router) {} // Inyecta el Router
  userId: number | null = null;

  ngOnInit(): void {
    this.getUserId();
  }


  getUserId(): void {
    const userIdString = localStorage.getItem('userId');
    this.userId = userIdString ? parseInt(userIdString, 10) : null;
    console.log('User ID:', this.userId);
  }

  cerrarSesion(): void {
    // Eliminar el token y el userId del localStorage
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    

    // Redirigir al usuario a la página de signup
    this.router.navigate(['/signup']);
  }
}
