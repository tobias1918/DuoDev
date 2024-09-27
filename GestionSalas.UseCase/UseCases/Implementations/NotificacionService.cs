using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.Reposories.interfaces;
using GestionSalas.UseCase.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Implementations
{
    public class NotificacionService : INotificacionService // Cambia esto
    {
        protected readonly INotificacionesRepository _notificacionesRepository;

        public NotificacionService(INotificacionesRepository notificacionesRepository)
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
                throw new Exception("Error al borrar Notificación", ex);
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
                throw new Exception("Error al obtener notificaciones", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _notificacionesRepository.SaveChangesAsync();
        }
    }
}
