import { CommonModule } from '@angular/common';
import { Component} from '@angular/core';
import { CardSalaComponent } from '../card-sala/card-sala.component';
import { ModalComponent } from '../modal/modal.component';
import { CardSelectedComponent } from '../card-selected/card-selected.component';

@Component({
  selector: 'app-salas-multiples',
  standalone: true,
  imports:[CommonModule,CardSalaComponent,CardSelectedComponent,ModalComponent],
  templateUrl: './salas-multiples.component.html',
  styleUrls: ['./salas-multiples.component.css']
})
export class SalasMultiplesComponent{
  
  
}
