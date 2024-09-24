using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.ContextGS.Data;
using GestionSalas.Repositories.Reposories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.Reposories.implementations
{
    public class ReservaRepository : IReservaRepository
    {
        protected readonly GestionSalasContext _context;

        public ReservaRepository(GestionSalasContext context)
        {
            _context = context;
        }

        public async Task CreateReserva(Reserva reserva)
        {
            try
            {
                bool reservaExist = await _context.Reserva.AnyAsync(r => r.idReserva == reserva.idReserva);
                bool usuarioExist = await _context.Users.AnyAsync(r => r.idUser == reserva.idUsuario);
                bool salaExist = await _context.Sala.AnyAsync(r => r.idSala == reserva.idSala);

                if (reservaExist)
                {
                    throw new Exception("Este idReserva ya existe");
                }
                if (!usuarioExist)
                {
                    throw new Exception("Este id usuario no existe");
                }
                if (!salaExist)
                {
                    throw new Exception("Este id sala no existe");
                }

                await _context.Reserva.AddAsync(reserva);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Lanza la excepción original sin crear una nueva
                throw;
            }

        }

        public async Task DeleteReserva(int idReserva)
        {
            try
            {
                Reserva reserva = await _context.Reserva.FirstOrDefaultAsync(r => r.idReserva == idReserva);

                if (reserva == null)
                {
                    throw new Exception("Reserva no encontrada");
                }

                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reserva. Error: ", ex);
            }
        }

        public async Task<List<Reserva>> GetAllReservas()
        {
            try
            {
                return await _context.Reserva.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las reservas. Error: ", ex);
            }
        }

        public async Task<Reserva> GetReservaId(int idReserva)
        {
            try
            {
                Reserva reserva = await _context.Reserva
                    .FirstOrDefaultAsync(r => r.idReserva == idReserva);

                if (reserva == null)
                {
                    throw new Exception("Reserva no encontrada");
                }

                return reserva;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la reserva. Error: ", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los cambios. Error: ", ex);
            }
        }

        public async Task UpdateReserva(Reserva reserva)
        {
            try
            {
                Reserva existingReserva = await _context.Reserva
                    .FirstOrDefaultAsync(r => r.idReserva == reserva.idReserva);

                if (existingReserva == null)
                {
                    throw new Exception("Reserva no encontrada");
                }

                // Actualizar los campos necesarios
                existingReserva.idUsuario = reserva.idUsuario;
                existingReserva.idSala = reserva.idSala;
                existingReserva.priority = reserva.priority;
                existingReserva.horaInicio = reserva.horaInicio;
                existingReserva.horaFin = reserva.horaFin;
                existingReserva.state = reserva.state;

                await UpdateReserva(existingReserva);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva. Error: ", ex);
            }
        }
    }
}
