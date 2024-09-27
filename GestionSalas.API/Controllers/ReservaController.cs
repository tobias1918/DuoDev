using GestionSalas.Entity.DTOs.ReservaDTOs;
using GestionSalas.Entity.DTOs.UserDTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.UseCase.UseCases.Implementations;
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
        [HttpPut("updateReserva")]
        public async Task<ActionResult> UpdateReserva([FromBody] UpdateReservaDTO updateReservaDTO)
        {
            try
            {
                if (updateReservaDTO == null || updateReservaDTO.idReserva == 0)
                {
                    return BadRequest("Reserva no válida.");
                }
                else if (updateReservaDTO.idSala == 0)
                {
                    return BadRequest("Sala no válida.");
                }
                else if (updateReservaDTO.idUsuario == 0)
                {
                    return BadRequest("Usuario no válida.");
                }

                await _reservaService.UpdateReserva(updateReservaDTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la reserva: {ex.Message}");
            }
        }

        // GET: api/Reserva/reservasDisponible}
        [HttpPost("reservasDisponible")]
        public async Task<ActionResult> ReservasDisponibles([FromBody] ReservaDisponibleDTO reservaDisponibleDTO)
        {
            try
            {
                if (reservaDisponibleDTO == null )
                {
                    return BadRequest("peticion no válida.");
                }

                DateTime horaInicio = DateTime.Now.Date.AddHours(reservaDisponibleDTO.hora).AddMinutes(reservaDisponibleDTO.minutos);
                DateTime horaFin = horaInicio.AddMinutes(reservaDisponibleDTO.duracion);
                List<ResponseSalasDisponiblesDTO> listaSalasDisponibles = await _reservaService.GetSalasDisponibles(horaInicio, horaFin, reservaDisponibleDTO.capacidad, reservaDisponibleDTO.piso, reservaDisponibleDTO.prioridad);
                return Ok(listaSalasDisponibles);

                
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

        [HttpGet("getUserReservaSimples")]
        public async Task<ActionResult> GetUserReservasSimples(int idUser)
        {
            try
            {
                if (idUser == null || idUser == 0)
                {
                    return BadRequest("Usuario no valido.");
                }

                var listReservs = await _reservaService.GetUserReservasSimples(idUser);


                return Ok(listReservs);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar las reservas del usuario: {ex.Message}");
            }
           
        }

        [HttpGet("getUserReservaMultiples")]
        public async Task<ActionResult> GetUserReservasMultiples(int idUser)
        {
            try
            {
                if (idUser == null || idUser == 0)
                {
                    return BadRequest("Usuario no valido.");
                }

                var listReservs = await _reservaService.GetUserReservasMultiples(idUser);


                return Ok(listReservs);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar las reservas del usuario: {ex.Message}");
            }

        }

        [HttpPost("CrearMultiReserva")]
        public async Task<IActionResult> CreateMultiReserv([FromBody] List<Reserva> reservas)
        {
            try
            {
                await _reservaService.CreateMultiReserv(reservas);
                return Ok("Reservas creadas exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear reservas: {ex.Message}");
            }
        }
    }
}
