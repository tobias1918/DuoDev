using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.Reposories.interfaces
{
    public interface IReservaRepository
    {
        Task CreateReserva(Reserva reserva);
        Task DeleteReserva(int idReserva);
        Task UpdateReserva(Reserva reserva);
        Task<Reserva> GetReservaId(int idReserva);
        Task<List<Reserva>> GetAllReservas();
        Task SaveChangesAsync();
    }
}
