﻿using GestionSalas.Repositories.ContextGS.Data;
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

            // Registro de repositorios
            services.AddScoped<IUserRepository, UserRepository>();

            // Registro de servicios
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<ISalaService, SalaService>();

            return services;
        }
    }
}
