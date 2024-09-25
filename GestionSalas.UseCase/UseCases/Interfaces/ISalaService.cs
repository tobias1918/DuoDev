using GestionSalas.Entity.DTOs.SalaDTOs;
using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Interfaces
{
    public interface ISalaService
    {
        Task CreateSala(SalaDTO sala);
        Task DeleteSala(int idSala);
        Task UpdateSala(UpdateSalaDTO sala);
        Task<Sala> GetSalaId(int idSala);
        //Task<List<Sala>> GetSalasAvailable(Sala sala);
        //Task<List<Sala>> GetSalasLowerReserv(Sala sala);
        Task<List<Sala>> GetReservs();
        Task<List<Sala>> GetAllSalas();
        Task SaveChangesAsync();
    }
}
