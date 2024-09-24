using GestionSalas.Entity.DTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.Reposories.interfaces;
using GestionSalas.UseCase.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Implementations
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task CreateReserva(ReservaDTO reservaDTO)
        {
            try
            {
                var reserva = new Reserva
                {
                    idUsuario = reservaDTO.idUsuario,
                    idSala = reservaDTO.idSala,
                    priority = reservaDTO.priority,
                    horaInicio = reservaDTO.horaInicio,
                    horaFin = reservaDTO.horaFin,
                    state = "reservado"
                };

                await _reservaRepository.CreateReserva(reserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la reserva. Error: ", ex);
            }
        }

        public async Task UpdateReserva(ReservaDTO reservaDTO)
        {
            try
            {
                var reserva = await _reservaRepository.GetReservaId(reservaDTO.idReserva);

                if (reserva != null)
                {
                    reserva.idUsuario = reservaDTO.idUsuario;
                    reserva.idSala = reservaDTO.idSala;
                    reserva.priority = reservaDTO.priority;
                    reserva.horaInicio = reservaDTO.horaInicio;
                    reserva.horaFin = reservaDTO.horaFin;

                    await _reservaRepository.UpdateReserva(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la reserva. Error: ", ex);
            }
        }

        public async Task DeleteReserva(int idReserva)
        {
            try
            {
                await _reservaRepository.DeleteReserva(idReserva);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar la reserva. Error: ", ex);
            }
        }

        public async Task<Reserva> GetReservaId(int idReserva)
        {
            try
            {
                var reserva = await _reservaRepository.GetReservaId(idReserva);

                if (reserva != null)
                {
                    return new Reserva
                    {
                        idReserva = reserva.idReserva,
                        idUsuario = reserva.idUsuario,
                        idSala = reserva.idSala,
                        priority = reserva.priority,
                        horaInicio = reserva.horaInicio,
                        horaFin = reserva.horaFin
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la reserva. Error: ", ex);
            }
        }

        public async Task<List<Reserva>> GetAllReservas()
        {
            try
            {
                var reservas = await _reservaRepository.GetAllReservas();

                return reservas.Select(reserva => new Reserva
                {
                    idReserva = reserva.idReserva,
                    idUsuario = reserva.idUsuario,
                    idSala = reserva.idSala,
                    priority = reserva.priority,
                    horaInicio = reserva.horaInicio,
                    horaFin = reserva.horaFin,
                    state = reserva.state
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las reservas. Error: ", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _reservaRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los cambios. Error: ", ex);
            }
        }
    }
}
