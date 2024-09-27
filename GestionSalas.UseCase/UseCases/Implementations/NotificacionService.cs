using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.Reposories.implementations;
using GestionSalas.Repositories.Reposories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Implementations
{
    public class NotificacionService : INotificacionesRepository
    {
        private readonly INotificacionesRepository _notificacionesRepository;

        public NotificacionService( INotificacionesRepository notificacionesRepository)
        {
            _notificacionesRepository = notificacionesRepository;
        }


        public async Task DeleteNotificacion(int idNotificacion) 
        {
            try
            {
               await _notificacionesRepository.DeleteNotificacion(idNotificacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar Notificacion, Error: ",ex);
            }
           
        }

        public async Task<List<Notificacion>> GetUserNotificaciones(int idUser) 
        {
            try
            {
                var listNotificaciones = await _notificacionesRepository.GetUserNotificaciones(idUser);
                return listNotificaciones;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar Notificacion, Error: ", ex);
            }
        }
    }
}
