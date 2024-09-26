using GestionSalas.Entity.DTOs.ReservaDTOs;
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

        public async Task<List<ResponseSalasDisponiblesDTO>> GetDisponiblesSalas(DateTime horaInicio, DateTime horaFin, int capacidad, int piso, int prioridad)
        {
            // Rango de horas a consultar
            var start = horaInicio;  // Se ajusta para utilizar horaInicio directamente
            var end = horaFin;       // Se ajusta para utilizar horaFin directamente

            var salasDisponibles = await _context.Sala
                .Where(s => !s.isDeleted && s.capacitySala >= capacidad && s.floorSala == piso)
                .GroupJoin(
                    _context.Reserva
                        .Where(r => r.horaInicio < end && r.horaFin > start),
                    sala => sala.idSala,
                    reserva => reserva.idSala,
                    (sala, reservas) => new { Sala = sala, Reservas = reservas })
                .SelectMany(
                    sr => sr.Reservas.DefaultIfEmpty(),
                    (sr, reserva) => new
                    {
                        Sala = sr.Sala,
                        Reserva = reserva
                    })
                .Where(x => x.Reserva.idReserva == null || x.Reserva.priority < prioridad)
                .Select(x => new ResponseSalasDisponiblesDTO
                {
                    id_sala = x.Sala.idSala,
                    name = x.Sala.nameSala,         // Asegúrate de que `Name` esté definido en tu modelo
                    capacity_sala = x.Sala.capacitySala,
                    floor_sala = x.Sala.floorSala,
                    cod_sala = x.Sala.codSala,
                    id_reserva = x.Reserva != null ? x.Reserva.idReserva : -1, 
                    priority = x.Reserva != null ? x.Reserva.priority : -1 ,
                    horaInicio = horaInicio,
                    horaFin = horaFin
                })
                .ToListAsync();

            return salasDisponibles;
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

                //Verifico si ya existe una endidad con el mismo id en el contexto local
                //si existe la desvinculamos del contexto para evitar el error de duplicado

                var existingReserv = _context.Reserva.Local.FirstOrDefault(u => u.idReserva == reserva.idSala);
                if (existingReserv != null)
                {
                    //Desvinculo la entidad rastreada en en paso anterior
                    _context.Entry(existingReserv).State = EntityState.Detached;
                }

                _context.Reserva.Update(reserva);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva. Error: ", ex);
            }
        }

       
    }
}
