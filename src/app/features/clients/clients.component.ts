import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/components/home.component';
import { ReservasComponent } from './reservas/components/reservas.component';

@Component({
  selector: 'app-clients',
  standalone: true,
  imports: [RouterOutlet,RouterLink,CommonModule,HomeComponent,ReservasComponent],
  templateUrl: './clients.component.html',
  styleUrl: './clients.component.css'
})
export class ClientsComponent {

}
