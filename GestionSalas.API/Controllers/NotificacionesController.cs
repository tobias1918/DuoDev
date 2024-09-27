using GestionSalas.Entity.DTOs.ReservaDTOs;
using GestionSalas.Entity.DTOs.SalaDTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.UseCase.UseCases.Implementations;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionSalas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;

        public NotificacionController(INotificacionService notificacionService)
        {
            _notificacionService = notificacionService;
        }

        [HttpGet("GetUserNotificaciones")]
        public async Task<ActionResult<List<Notificacion>>> GetUserNotificaciones(int idUser)
        {
            try
            {
                var notificaciones = await _notificacionService.GetUserNotificaciones(idUser);
                return Ok(notificaciones);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("DeleteNotificacion")]
        public async Task<ActionResult<List<Notificacion>>> DeleteNotificacion(int idNotificacion)
        {
            try
            {
                await _notificacionService.DeleteNotificacion(idNotificacion);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }

}
