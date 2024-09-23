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
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {


            builder.ToTable("salas");
            //declaro la id
            builder.HasKey(u => u.idSala);  
            //la asigno
            builder.Property(u => u.idSala)
            .IsRequired()
            .HasColumnName("id_sala")
            .HasColumnType("int");

            //doy contexto para los atributos de la tabla 
            builder.Property(u => u.nameSala)
           .IsRequired()
           .HasColumnName("name")
           .HasMaxLength(50)
           .HasColumnType("varchar");


            builder.Property(u => u.codSala)
           .IsRequired()
           .HasColumnName("cod_sala")
           .HasMaxLength(10)
           .HasColumnType("varchar");

            builder.Property(u => u.floorSala)
           .IsRequired()
           .HasColumnName("floor_sala")
           .HasColumnType("tinyint");

            builder.Property(u => u.capacitySala)
           .IsRequired()
           .HasColumnName("capacity_sala")
           .HasColumnType("tinyint");

            builder.Property(u => u.isDeleted)
            .HasColumnName("is_deleted")
            .HasColumnType("bit") //bit para el bool en sql server
            .IsRequired();
        }
    }
}
