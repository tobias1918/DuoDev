using GestionSalas.Entity.DTOs.SalaDTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.UseCase.UseCases.Implementations;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionSalas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;
        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }



        [HttpGet("TraerTodasLasSalas")]
        public async Task<ActionResult<List<SalaDTO>>> GetAllSalas()
        {
            try
            {
                var salas = await _salaService.GetAllSalas();
                return Ok(salas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        [HttpGet("TraerSalaPorID")]
        public async Task<ActionResult<SalaDTO>> GetSalaId(int id)
        {
            try
            {
                var sala = await _salaService.GetSalaId(id);
                if (sala == null)
                {
                    return NotFound();
                }
                return Ok(sala);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("CrearSala")]
        public async Task<ActionResult> CreateSala([FromBody] SalaDTO salaDTO)
        {
            if (salaDTO == null)
            {
                return BadRequest("el User no puede ser nulo.");
            }

            try
            {
                await _salaService.CreateSala(salaDTO);
                return CreatedAtAction(nameof(GetSalaId), new { id = salaDTO.idSala }, salaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("ActualizarSala")]
        public async Task<ActionResult> UpdateSala([FromBody] UpdateSalaDTO UpdateSalaDTO)
        {
            if (UpdateSalaDTO.idSala == 0 || UpdateSalaDTO == null)
            {
                return BadRequest("Sala no válida.");
            }
            try
            {
                await _salaService.UpdateSala(UpdateSalaDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("BorrarSala")]
        public async Task<ActionResult> DeleteSala(int id)
        {
            try
            { 
                await _salaService.DeleteSala(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}

    