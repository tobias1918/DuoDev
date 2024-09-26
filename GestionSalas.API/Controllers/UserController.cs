using GestionSalas.Entity.DTOs.UserDTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace GestionSalas.API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Utilidades _utilidades;

        public UserController(IUserService userService, Utilidades utilidades)
        {
            _userService = userService;
            _utilidades = utilidades;
        }

        // GET: api/user
        [HttpGet("TraerTodosUsuarios")]
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

        [HttpGet("TraerUsuarioPorID")]
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

        [HttpPost("CrearUser")]
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("el User no puede ser nulo.");
            }

            try
            { 
                // encripto la contrasena antes de entrar adentro de las capas
                var hasPassword = _utilidades.EncriptarSHA256(userDTO.password);
                userDTO.password = hasPassword;

                await _userService.CreateUser(userDTO);
                return StatusCode(StatusCodes.Status200OK, new{isSuccess = true});
                
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpPut("ActualizarUser")]
        public async Task<ActionResult> Update([FromBody] UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null || updateUserDTO.idUser == 0)
            {
                return BadRequest("Cliente no válido.");
            }

            try
            {
                if (updateUserDTO.password != null) {
                    //si la contrasena viene en el dto la has
                    //y la envio has
                    var hasPassword = _utilidades.EncriptarSHA256(updateUserDTO.password);
                    updateUserDTO.password = hasPassword;
                }
                   
                await _userService.UpdateUser(updateUserDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("BorrarUser")]
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
        {
            try
            {
                //encripto la contrasena antes de enviar los datos hasta la capa repositories
                //porque luego no lo podria hacer
                var hasPassword = _utilidades.EncriptarSHA256(loginRequest.password);
                loginRequest.password = hasPassword;

                var user = await _userService.VerifyLogin(loginRequest);

                //si de la busqueda en el backend encontramos nuestro usuario y coinciden las credenciales, 
                //generamos el token
                if (user != null) { return StatusCode(StatusCodes.Status200OK, new {isSuccess = true, token = _utilidades
                .GenerarJWT(user)
                }); }

                // Aquí puedes devolver el usuario o algún otro tipo de respuesta
                return Ok(user); // Devolver el objeto User o cualquier otra información relevante
            }
            catch (Exception ex)
            {
                // Devolver el error como respuesta
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("ValidarToken")]
        public async Task<IActionResult> ValidarToken([FromQuery]string token)
        {
            try
            {
               bool respuesta = _utilidades.ValidationToken(token);
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = respuesta});
            }
            catch (Exception ex)
            {
                // Devolver el error como respuesta
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
