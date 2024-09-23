using GestionSalas.Entity.DTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.Reposories.interfaces;
using GestionSalas.UseCase.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Implementations
{
    public class SalaService : ISalaService
    {
        public readonly ISalaRepository _salaRepository;
        public SalaService (ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task CreateSala(SalaDTO salaDTO)
        {
            try
            {
                var sala = new Sala
                {
                    nameSala = salaDTO.nameSala,
                    codSala = salaDTO.codSala,
                    floorSala = salaDTO.floorSala,
                    capacitySala = salaDTO.capacitySala,
                };
                await _salaRepository.CreateSala(sala);
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear sala. Error: ", ex);
            }

        }

        public async Task UpdateSala(SalaDTO salaDTO)
        {
            try
            {
                if(salaDTO.idSala !=0 && salaDTO != null)
                {
                    Sala sala = await GetSalaId(salaDTO.idSala);

                    if (sala != null) 
                    {
                        
                        if (salaDTO.nameSala != null)
                            sala.nameSala = salaDTO.nameSala;

                        if (salaDTO.codSala != null)
                            sala.codSala = salaDTO.codSala;

                        if (salaDTO.floorSala != null)
                            sala.floorSala = salaDTO.floorSala;

                        if (salaDTO.capacitySala != null)
                            sala.capacitySala = salaDTO.capacitySala;
                        
                    }
                   
                    await _salaRepository.UpdateSala(sala);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar sala. Error: ", ex);
            }

        }
        
        public async Task DeleteSala(int idSala)
        {
            try
            {
                _salaRepository.DeleteSala(idSala);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al borrar la sala. Error: ", ex);
            }
        }

        public async Task<Sala> GetSalaId(int idSala)
        {
            try
            {
               return await _salaRepository.GetSalaId(idSala);
                
            }catch (Exception ex)
            {
                throw new Exception("Error al obtener la sala. Error: ", ex);
            }

        }
           
        public async Task<List<Sala>> GetAllSalas()
        {
            try
            {
                return await _salaRepository.GetAllSalas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las salas. Error: ", ex);
            }
        }
        
        public async Task<List<Sala>> GetReservs()
        {
            return await _salaRepository.GetReservs(); //REVISARR POR LA LOGICA
        }
        public async Task SaveChangesAsync()
        {
            await _salaRepository.SaveChangesAsync();
        }
    }
}
