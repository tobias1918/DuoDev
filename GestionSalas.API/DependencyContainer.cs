using GestionSalas.Repositories.ContextGS.Data;
using GestionSalas.Repositories.Reposories.implementations;
using GestionSalas.Repositories.Reposories.interfaces;
using GestionSalas.UseCase.UseCases.Implementations;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionSalas.API
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            // Configuración del DbContext
            services.AddDbContext<GestionSalasContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Connection1")));

            //Encripta la contraseña y genera el token
            services.AddSingleton<Utilidades>();


            // Registro de repositorios
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            
            // Registro de servicios
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReservaService, ReservaService>();


            services.AddScoped<INotificacionesRepository, NotificacionRepository>();
            services.AddScoped<INotificacionService, NotificacionService>();


            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<ISalaService, SalaService>();

            return services;
        }
    }
}
