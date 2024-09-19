import { Routes } from '@angular/router';
import { AuthComponent } from './features/auth/auth.component';
import { HomeComponent } from './features/home/components/home.component';
import { ReservasComponent } from './features/reservas/components/reservas.component';
import { SalasIndividualesComponent } from './features/clients/salas-individuales/salas-individuales.component';
import { SalasMultiplesComponent } from './features/clients/salas-multiples/salas-multiples.component';
import { MisReservasComponent } from './features/clients/mis-reservas/mis-reservas.component';


export const routes: Routes = [
    { path: 'signup', component: AuthComponent},
    { path: '', component: HomeComponent},
    { path: 'reserva',component: ReservasComponent},
    { path: 'reserva/salas-individuales', component:SalasIndividualesComponent},
    { path: 'reserva/salas-multiples', component:SalasMultiplesComponent},
    { path: 'mis-reservas', component:MisReservasComponent},

   // { path: '**', redirectTo:'signup',pathMatch:'full'},
   
];
