using GestionSalas.API;
using GestionSalas.Entity.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración de dependencias
builder.Services.AddDependencies(builder.Configuration);


builder.Services.AddAuthentication(config => { 
    config.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        //hacer que las aplicaciones externas puedan usar nuestra api, y quienes pueden
        //acceder
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true, //validar el tiempo de vida del toke
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});




// Registrar los servicios de controladores
builder.Services.AddControllers();

// Registrar los servicios de autenticación/autorización
builder.Services.AddAuthorization();

// Registrar los servicios de Swagger
builder.Services.AddSwaggerGen();  // <-- Agrega esta línea para registrar Swagger

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewRule", app =>
    {
        //permitir cualquier origen, cualquier cabezera y que pueda usar cualquier metodo
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configuración de middleware, endpoints, etc.
if (app.Environment.IsDevelopment())
{
    // Usar Swagger en modo desarrollo
    app.UseSwagger();  // <-- Agrega Swagger como middleware
    app.UseSwaggerUI();  // <-- Habilita la interfaz de Swagger UI      
}

app.UseCors("NewRule");
app.UseAuthentication();

app.UseHttpsRedirection();

// Middleware de autorización
app.UseAuthorization();


// Mapea los controladores
app.MapControllers();


app.Run();
