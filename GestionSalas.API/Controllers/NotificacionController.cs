using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.ContextGS.Data;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionSalas.API.Controllers
{
    public class NotificacionController : ControllerBase
    {
        protected readonly INotificacionService _context;

        public NotificacionController(INotificacionService notificacionService)
        {
            _context = notificacionService;
        }
        // LOGICA PARA NOTIFICAR AL USUARIO DE LOS CAMBIOS EN SUS SALAS
        [HttpGet("TraerNotificaciones")]
        public async Task<ActionResult<List<Notificacion>>> GetUserNotificaciones(int idUser)
        {
            try
            {
                var listNotificaciones = await _context.GetUserNotificaciones(idUser);
                return Ok(listNotificaciones);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
    }
}
