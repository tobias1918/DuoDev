using GestionSalas.Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.ContextGS.Contexto
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuarios");
            //declaro la id
            builder.HasKey(u => u.idUser);
            //la asigno
            builder.Property(u => u.idUser)
            .IsRequired()
            .HasColumnName("id_user")
            .HasColumnType("int");

            //doy contexto para los atributos de la tabla 
            builder.Property(u => u.name)
           .IsRequired()
           .HasColumnName("name")
           .HasMaxLength(50)
           .HasColumnType("varchar");


            builder.Property(u => u.surname)
           .IsRequired()
           .HasColumnName("surname")
           .HasMaxLength(50)
           .HasColumnType("varchar");

            builder.Property(u => u.email)
           .IsRequired()
           .HasColumnName("email")
           .HasMaxLength(255)
           .HasColumnType("varchar");

            builder.Property(u => u.password)
           .IsRequired()
           .HasColumnName("password")
           .HasMaxLength(255)
           .HasColumnType("varchar");


            builder.Property(u => u.rol)
           .HasColumnName("rol")
           .HasColumnType("bit") //bit para el bool en sql server
           .IsRequired();

            builder.Property(u => u.isDeleted)
           .HasColumnName("is_deleted")
           .HasColumnType("bit") //bit para el bool en sql server
           .IsRequired();



        }
    }
}
