using GestionSalas.API;
using GestionSalas.Entity.Entidades;

var builder = WebApplication.CreateBuilder(args);

// Configuración de dependencias
builder.Services.AddDependencies(builder.Configuration);

//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Registrar los servicios de controladores
builder.Services.AddControllers();

// Registrar los servicios de autenticación/autorización
builder.Services.AddAuthorization();

// Registrar los servicios de Swagger
builder.Services.AddSwaggerGen();  // <-- Agrega esta línea para registrar Swagger

var app = builder.Build();

// Configuración de middleware, endpoints, etc.
if (app.Environment.IsDevelopment())
{
    // Usar Swagger en modo desarrollo
    app.UseSwagger();  // <-- Agrega Swagger como middleware
    app.UseSwaggerUI();  // <-- Habilita la interfaz de Swagger UI      
}

app.UseHttpsRedirection();

// Middleware de autorización
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

app.Run();
