import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HomeComponent } from './features/home/components/home.component';
import { ReservasComponent } from './features/reservas/components/reservas.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterLink,CommonModule,HomeComponent,ReservasComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FEGestionDeSalas';

  menuOption:string='';

  onOption(menuOption:string){
    this.menuOption=menuOption;
  }
}
