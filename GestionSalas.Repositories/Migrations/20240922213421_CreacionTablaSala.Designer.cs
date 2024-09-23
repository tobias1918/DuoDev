﻿// <auto-generated />
using GestionSalas.Repositories.ContextGS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionSalas.Repositories.Migrations
{
    [DbContext(typeof(GestionSalasContext))]
    [Migration("20240922213421_CreacionTablaSala")]
    partial class CreacionTablaSala
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestionSalas.Entity.Entidades.Sala", b =>
                {
                    b.Property<int>("idSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_sala");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSala"), 1L, 1);

                    b.Property<byte>("capacitySala")
                        .HasColumnType("tinyint")
                        .HasColumnName("capacity_sala");

                    b.Property<string>("codSala")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("cod_sala");

                    b.Property<byte>("floorSala")
                        .HasColumnType("tinyint")
                        .HasColumnName("floor_sala");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("nameSala")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("idSala");

                    b.ToTable("salas", (string)null);
                });

            modelBuilder.Entity("GestionSalas.Entity.Entidades.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<bool>("rol")
                        .HasColumnType("bit")
                        .HasColumnName("rol");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("surname");

                    b.HasKey("idUser");

                    b.ToTable("usuarios", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
