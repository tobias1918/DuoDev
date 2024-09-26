using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GestionSalas.Entity;
using GestionSalas.Entity.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace GestionSalas.API
{
    public class Utilidades
    {
        private readonly IConfiguration _configuration;

        public Utilidades(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Con esto encriptamos la contrasena
        public string EncriptarSHA256(string s)
        {
            using (SHA256 sha256has = SHA256.Create()) 
            {
                //computar el has
                byte[] bytes = sha256has.ComputeHash(Encoding.UTF8.GetBytes(s));//convertir parametro en byte y en un array de bytes
               

                //ahora convertimos el array de bytes a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                   builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        //generar json web tokens
        public string GenerarJWT(User user)
        {
            //crear la informacion del usario para el token

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.idUser.ToString()),
                new Claim(ClaimTypes.Name , user.name),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Surname, user.surname),
                new Claim(ClaimTypes.Role.ToString(), user.rol.ToString()),

            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credenciales = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            //crear los detalles del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }

        public bool ValidationToken(string token)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                //hacer que las aplicaciones externas puedan usar nuestra api, y quienes pueden
                //acceder
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true, //validar el tiempo de vida del toke
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]))
            };

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int? GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                return int.Parse(userIdClaim.Value);
            }

            return null;
        }


    }
}
