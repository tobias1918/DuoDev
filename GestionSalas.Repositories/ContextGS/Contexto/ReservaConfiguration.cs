using GestionSalas.Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionSalas.Repositories.ContextGS.Contexto
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            // Nombre de la tabla
            builder.ToTable("reservas");

            // Configuración de la clave primaria
            builder.HasKey(r => r.idReserva);
            builder.Property(r => r.idReserva)
                .IsRequired()
                .HasColumnName("id_reserva")
                .HasColumnType("int");

            // Configuración del idUsuario como llave foránea
            builder.Property(r => r.idUsuario)
                .IsRequired()
                .HasColumnName("id_usuario")
                .HasColumnType("int");

            builder.HasOne<User>() // Relación con la entidad Usuario
                .WithMany()            // Un usuario puede tener muchas reservas
                .HasForeignKey(r => r.idUsuario)  // Define idUsuario como la clave foránea
                .OnDelete(DeleteBehavior.Cascade);  // Configura el comportamiento de borrado

            // Configuración del idSala como llave foránea
            builder.Property(r => r.idSala)
                .IsRequired()
                .HasColumnName("id_sala")
                .HasColumnType("int");

            builder.HasOne<Sala>()   // Relación con la entidad Sala
                .WithMany()          // Una sala puede tener muchas reservas
                .HasForeignKey(r => r.idSala)  // Define idSala como clave foránea
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la prioridad
            builder.Property(r => r.priority)
                .IsRequired()
                .HasColumnName("priority")
                .HasColumnType("tinyint");

            // Configuración de la hora de inicio
            builder.Property(r => r.horaInicio)
                .IsRequired()
                .HasColumnName("hora_inicio")
                .HasColumnType("datetime");

            // Configuración de la hora de fin
            builder.Property(r => r.horaFin)
                .IsRequired()
                .HasColumnName("hora_fin")
                .HasColumnType("datetime");

            // Configuración del estado
            builder.Property(r => r.state)
                .IsRequired()
                .HasColumnName("state")
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");
        }
    }
}
