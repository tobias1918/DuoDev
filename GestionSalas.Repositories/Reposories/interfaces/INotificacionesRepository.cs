﻿using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.Reposories.interfaces
{
    public interface INotificacionesRepository
    {
     
        Task DeleteNotificacion(int idNotificacion);
        Task<List<Notificacion>> GetUserNotificaciones(int idUser);
        Task SaveChangesAsync();
    }
}
