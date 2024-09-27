using GestionSalas.Entity.DTOs.ReservaDTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.ContextGS.Data;
using GestionSalas.Repositories.Reposories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

                var salaOcupada = await _context.Reserva.FirstOrDefaultAsync(r => r.horaInicio <= reserva.horaFin
                && r.horaFin >= reserva.horaInicio && r.idSala == reserva.idSala);
                  
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
                if (salaOcupada != null)
                {
                    Sala sala = await _context.Sala.FirstOrDefaultAsync(s => s.idSala == reserva.idSala);
                    
                    Notificacion notificacion = new Notificacion
                    {
                        idNotificacion = 0,
                        idUser = reserva.idUsuario,
                        titulo = "Tu reserva Fue eliminada por una de mayor prioridad",
                        mensaje = $"Tu reserva a la sala {sala.nameSala} " +
                        $" Codigo {sala.codSala} fue eliminada por una de mayor prioridad, Por favor vuelva a " +
                        $"crear una reserva en un horario distinto o a otra sala",
                       
                    };
                    _context.Notificacion.Add(notificacion);
                    _context.Reserva.Remove(salaOcupada);
                    _context.SaveChanges();
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
                        .Where(r => r.horaInicio <= end && r.horaFin >= start),
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

                Notificacion notificacion = new Notificacion
                {
                    idNotificacion = 0, 
                    idUser = reserva.idUsuario,
                    titulo = "Tu reserva cambió de estado",
                    mensaje = $"Tu reserva tuvo un cambio de estado a {reserva.state}",
                   
                };
                _context.Notificacion.Add(notificacion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva. Error: ", ex);
            }
        }

        public async Task<List<Reserva>> GetUserReservasSimples(int idUser) 
        {

            var reservasComunes = new List<Reserva>();

            try
            {
                // Obtener todas las reservas del usuario
                var todasReservas = await _context.Reserva
                    .Where(r => r.idUsuario == idUser)
                    .ToListAsync();

                // Agregar solo reservas que no están en multireservas
                for (int i = 0; i < todasReservas.Count; i++)
                {
                    var reservaActual = todasReservas[i];
                    bool esMultiReserva = false;

                    for (int j = 0; j < todasReservas.Count; j++)
                    {
                        if (i != j && reservaActual.horaInicio == todasReservas[j].horaInicio &&
                            reservaActual.horaFin == todasReservas[j].horaFin &&
                            reservaActual.idSala != todasReservas[j].idSala)
                        {
                            esMultiReserva = true;
                            break; // Si se encuentra una multi-reserva, salir del bucle
                        }
                    }

                    // Agregar solo si no es parte de una multi-reserva
                    if (!esMultiReserva)
                    {
                        reservasComunes.Add(reservaActual);
                    }
                }

                if (reservasComunes.Count == 0)
                {
                    throw new Exception($"No se encontraron reservas comunes para el usuario {idUser}");
                }

                return reservasComunes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetUserReservsComunes: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener las reservas comunes", ex);
            }

        }
        public async Task<List<List<Reserva>>> GetUserReservasMultiples(int idUser)
        {
            var multiReservas = new List<List<Reserva>>();
            var reservasAgregadas = new HashSet<int>(); // Para evitar agregar duplicados

            try
            {
                // Obtener todas las reservas del usuario
                var todasReservas = await _context.Reserva
                    .Where(r => r.idUsuario == idUser)
                    .ToListAsync();

                // Buscar multireservas
                for (int i = 0; i < todasReservas.Count; i++)
                {
                    var reservaActual = todasReservas[i];

                    // Verificar si ya se ha procesado la reserva actual
                    if (reservasAgregadas.Contains(reservaActual.idReserva))
                        continue;

                    var grupoMultiReserva = new List<Reserva> { reservaActual };

                    for (int j = 0; j < todasReservas.Count; j++)
                    {
                        if (i != j && reservaActual.horaInicio == todasReservas[j].horaInicio &&
                            reservaActual.horaFin == todasReservas[j].horaFin &&
                            reservaActual.idSala != todasReservas[j].idSala)
                        {
                            grupoMultiReserva.Add(todasReservas[j]);
                            reservasAgregadas.Add(todasReservas[j].idReserva); // Marcar como agregada
                        }
                    }

                    // Solo agregar el grupo si contiene más de una reserva
                    if (grupoMultiReserva.Count > 1)
                    {
                        multiReservas.Add(grupoMultiReserva);
                        reservasAgregadas.Add(reservaActual.idReserva); // Marcar como agregada
                    }
                }

                if (multiReservas.Count == 0)
                {
                    throw new Exception($"No se encontraron multireservas para el usuario {idUser}");
                }

                return multiReservas; // Devuelve solo la lista de grupos de reservas
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetUserReservsMultiReservas: {ex.Message}");
                throw new Exception("Ocurrió un error al obtener las multireservas", ex);
            }
        }

        public async Task CreateMultiReserv(List<Reserva> multiReservas)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            {

                try
                {
                    foreach (var reserva in multiReservas)
                    {

                        var salaOcupada = await _context.Reserva.FirstOrDefaultAsync(r => r.horaInicio < reserva.horaFin
                         && r.horaFin > reserva.horaInicio && r.idSala == reserva.idSala);

                        if (salaOcupada != null)
                        {
                            Sala sala = await _context.Sala.FirstOrDefaultAsync(s => s.idSala == reserva.idSala);

                            Notificacion notificacion = new Notificacion
                            {
                                idNotificacion = 0,
                                idUser = reserva.idUsuario,
                                titulo = "Tu reserva Fue eliminada por una de mayor prioridad",
                                mensaje = $"Tu reserva a la sala {sala.nameSala} " +
                                $" Codigo {sala.codSala} fue eliminada por una de mayor prioridad, Por favor vuelva a " +
                                $"crear una reserva en un horario distinto o a otra sala",
                             
                            };
                            _context.Notificacion.Add(notificacion);
                            _context.Reserva.Remove(salaOcupada);
                            _context.SaveChanges();
                        }

                        await _context.Reserva.AddAsync(reserva);
                    }

                    // Confirmar cambios
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw; // Devolver la excepción para que el controlador la maneje
                }
            }
        }
    }
}
