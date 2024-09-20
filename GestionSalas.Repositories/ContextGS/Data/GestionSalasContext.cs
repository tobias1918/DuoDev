using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.ContextGS.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.ContextGS.Data
{
    public class GestionSalasContext : DbContext
    {
        //public GestionSalasContext(DbContextOptions<GestionSalasContext> options) : base(options) { }
        //public DbSet<User> Users { get; set; }

        //// Configuración adicional del modelo si es necesario
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configuración de entidades
        //    modelBuilder.ApplyConfigurationsFromAssembly(
        //        Assembly.GetExecutingAssembly());
        //    modelBuilder.ApplyConfiguration(new UserConfiguration());
        //}

        public GestionSalasContext(DbContextOptions<GestionSalasContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
