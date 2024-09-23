﻿using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.Reposories.interfaces
{
    public interface ISalaRepository
    {
        Task CreateSala(Sala sala);
        Task DeleteSala(int idSala);
        Task UpdateSala(Sala sala);
        Task<Sala> GetSalaId(int idSala);
        //Task<List<Sala>> GetSalasAvailable(Sala sala);
        //Task<List<Sala>> GetSalasLowerReserv(Sala sala);
        Task<List<Sala>> GetReservs();
        Task<List<Sala>> GetAllSalas();
        Task SaveChangesAsync();
    }
}

//SEGUIR DESDE ACA