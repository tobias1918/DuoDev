using GestionSalas.Entity.DTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionSalas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        // GET: api/Reserva/getReservaById/{id}
        [HttpGet("getReservaById/{id}")]
        public async Task<ActionResult<ReservaDTO>> GetReservaById(int id)
        {
            try
            {
                var reserva = await _reservaService.GetReservaId(id);
                if (reserva == null)
                {
                    return NotFound("Reserva no encontrada");
                }

                var reservaDTO = new ReservaDTO
                {
                    idReserva = reserva.idReserva,
                    idUsuario = reserva.idUsuario,
                    idSala = reserva.idSala,
                    priority = reserva.priority,
                    horaInicio = reserva.horaInicio,
                    horaFin = reserva.horaFin
                };

                return Ok(reservaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // GET: api/Reserva
        [HttpGet("getAllReservas")]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetAllReservas()
        {
            try
            {
                var reservas = await _reservaService.GetAllReservas();
                var reservasDTO = reservas.Select(r => new ReservaDTO
                {
                    idReserva = r.idReserva,
                    idUsuario = r.idUsuario,
                    idSala = r.idSala,
                    priority = r.priority,
                    horaInicio = r.horaInicio,
                    horaFin = r.horaFin
                });

                return Ok(reservasDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // POST: api/Reserva
        [HttpPost("createReserva")]
        public async Task<ActionResult> CreateReserva([FromBody] ReservaDTO reservaDTO)
        {
            try
            {
                if (reservaDTO == null)
                {
                    return BadRequest("Datos inválidos");
                }

                await _reservaService.CreateReserva(reservaDTO);
                return StatusCode(201, "Creado con exito");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la reserva: {ex.Message}");
            }
        }

        // PUT: api/Reserva/{id}
        [HttpPut("updateReserva/{id}")]
        public async Task<ActionResult> UpdateReserva(int id, [FromBody] ReservaDTO reservaDTO)
        {
            try
            {
                if (id != reservaDTO.idReserva)
                {
                    return BadRequest("El ID de la reserva no coincide");
                }

                await _reservaService.UpdateReserva(reservaDTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la reserva: {ex.Message}");
            }
        }

        // DELETE: api/Reserva/{id}
        [HttpDelete("deleteReserva/{id}")]
        public async Task<ActionResult> DeleteReserva(int id)
        {
            try
            {
                var reserva = await _reservaService.GetReservaId(id);

                if (reserva == null)
                {
                    return NotFound("Reserva no encontrada");
                }

                await _reservaService.DeleteReserva(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la reserva: {ex.Message}");
            }
        }
    }
}
