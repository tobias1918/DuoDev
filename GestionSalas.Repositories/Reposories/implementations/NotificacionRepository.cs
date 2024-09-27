using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.ContextGS.Data;
using GestionSalas.Repositories.Reposories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.Reposories.implementations
{
    public class NotificacionRepository : INotificacionesRepository
    {
        protected readonly GestionSalasContext _context;
        public NotificacionRepository(GestionSalasContext context) 
        {
            _context = context;
        }
       
        public async Task DeleteNotificacion(int idNotificacion)
        {
            try
            {
                var notificacion = await _context.Notificacion.FindAsync(idNotificacion);
                if (notificacion != null)
                {
                    _context.Notificacion.Remove(notificacion);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario. Error: ", ex);
            }
        }

        public async Task<List<Notificacion>> GetUserNotificaciones(int idUser)
        {
            try
            {
                var notificaciones = await _context.Notificacion.Where(n => n.idUser == idUser).ToListAsync();
                return notificaciones;
            }
            catch (Exception ex)
            {
                throw new Exception("error al traer las notificaciones del usuario, error: ", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
