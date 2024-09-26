import { Routes } from '@angular/router';

import { SalasIndividualesComponent } from './features/clients/salas-individuales/salas-individuales.component';
import { SalasMultiplesComponent } from './features/clients/salas-multiples/salas-multiples.component';
import { MisReservasComponent } from './features/clients/mis-reservas/mis-reservas.component';
import { HomeComponent } from './features/home/components/home.component';
import { ReservasComponent } from './features/reservas/components/reservas.component';
import { AuthComponent } from './auth/auth.component';
import { PageComponent } from './features/page.component';
import { ProfileComponent } from './features/profile/profile.component';
import { authGuard } from './custom/auth.guard';
import { EditProfileComponent } from './features/edit-profile/edit-profile.component';
import { PanelUsuariosComponent } from './admin/panel-usuarios/panel-usuarios.component';
import { PanelSalasComponent } from './admin/panel-salas/panel-salas.component';
import { authInterceptor } from './custom/auth.interceptor';



export const routes: Routes = [
    { path: 'signup', component: AuthComponent},

    {
        path: '', 
        component: PageComponent, // El PageComponent es el contenedor principal
        children: [
          { path: 'home', component: HomeComponent,},
          { path: 'reserva', component: ReservasComponent },
          { path: 'reserva/salas-individuales', component: SalasIndividualesComponent },
          { path: 'reserva/salas-multiples', component: SalasMultiplesComponent },
          { path: 'mis-reservas', component: MisReservasComponent },
          { path: 'perfil', component: ProfileComponent },
          { path: 'editar-perfil', component: EditProfileComponent },
          { path: 'panel-usuario', component: PanelUsuariosComponent },
          { path: 'panel-salas', component: PanelSalasComponent },
          { path: '', redirectTo: 'home', pathMatch: 'full' } // Redirige a home si no hay una ruta
          
        ]
      },
      { path: '**', redirectTo: 'home', pathMatch: 'full'},

   
];
