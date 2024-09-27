using GestionSalas.Entity.DTOs.ReservaDTOs;
using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Interfaces
{
    public interface IReservaService
    {
        Task CreateReserva(ReservaDTO reservaDTO);
        Task DeleteReserva(int idReserva);
        Task UpdateReserva(UpdateReservaDTO reservaDTO);
        Task<Reserva> GetReservaId(int idReserva);
        Task<List<Reserva>> GetAllReservas();
        Task SaveChangesAsync();
        Task<List<ResponseSalasDisponiblesDTO>> GetSalasDisponibles (DateTime horaInicio, DateTime horaFin, int capacidad, int piso, int prioridad);
        Task<List<Reserva>> GetUserReservasSimples(int idUser);
        Task<List<List<Reserva>>> GetUserReservasMultiples(int idUser);
        Task CreateMultiReserv(List<Reserva> reservaList);

        //dynamic para indicar que puedo devolver una lista de cualquier tipo
    }
}
