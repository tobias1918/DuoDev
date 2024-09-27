using GestionSalas.Entity.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.ContextGS.Contexto
{
    public class NotificacionConfiguration : IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.ToTable("notificaciones");
            //declaro la id
            builder.HasKey(u => u.idNotificacion);
            //la asigno
            builder.Property(u => u.idNotificacion)
            .IsRequired()
            .HasColumnName("id_notificacion")
            .HasColumnType("int");

            //doy contexto para los atributos de la tabla 
            builder.Property(u => u.idUser)
           .IsRequired()
           .HasColumnName("id_user")
           .HasColumnType("int");


            builder.Property(u => u.titulo)
           .IsRequired()
           .HasColumnName("titulo")
           .HasMaxLength(70)
           .HasColumnType("varchar");

            builder.Property(u => u.mensaje)
            .IsRequired()
            .HasColumnName("mensaje")
            .HasMaxLength(500)
            .HasColumnType("varchar");

          
        }
    }
}
