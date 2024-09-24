using GestionSalas.Entity.DTOs;
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
        Task UpdateReserva(ReservaDTO reservaDTO);
        Task<Reserva> GetReservaId(int idReserva);
        Task<List<Reserva>> GetAllReservas();
        Task SaveChangesAsync();
    }
}
