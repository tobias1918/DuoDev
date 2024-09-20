using GestionSalas.Entity.DTOs;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionSalas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            try
            {
                var user = await _userService.GetUserId(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("el User no puede ser nulo.");
            }

            try
            {
                await _userService.CreateUser(userDTO);
                return CreatedAtAction(nameof(GetById), new { id = userDTO.idUser }, userDTO);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO == null || id != userDTO.idUser)
            {
                return BadRequest("Cliente no válido.");
            }

            try
            {
                await _userService.UpdateUser(userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
        {
            try
            {
                var user = await _userService.VerifyLogin(loginRequest);

                // Aquí puedes devolver el usuario o algún otro tipo de respuesta
                return Ok(user); // Devolver el objeto User o cualquier otra información relevante
            }
            catch (Exception ex)
            {
                // Devolver el error como respuesta
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
