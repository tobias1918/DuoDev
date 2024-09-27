﻿using GestionSalas.Entity.DTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.ContextGS.Data;
using GestionSalas.Repositories.Reposories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GestionSalas.Repositories.Reposories.implementations
{
  public class SalaRepository : ISalaRepository
    {
        protected readonly GestionSalasContext _context;
     
        public SalaRepository(GestionSalasContext context)
        {
            _context = context;
        }

        public async Task CreateSala(Sala sala)
        {
            // CrearErroresPersonalizados

            // Verifica si la sala existe 
            try
            {
                bool salaExist = await _context.Sala.AnyAsync(e => e.codSala == sala.codSala);

                if (salaExist)
                {
                    throw new Exception("Esta Sala ya existe");
                }
                await _context.Sala.AddAsync(sala);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la sala. Error: ");
            }

        }

        public async Task<Sala> GetSalaId(int idSala)
        {
            try
            {
                try
                {
                    return await _context.Sala
                        .Where(c => !c.isDeleted)
                        .FirstOrDefaultAsync(c => c.idSala == idSala);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el usuario. Error: ", ex);
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Error al obtener la sala. Error: ", ex);
            }

        }
        public async Task DeleteSala(int idSala)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                Sala sala = await _context.Sala.FirstOrDefaultAsync(s => s.idSala == idSala);
                var reservas = await _context.Reserva.Where(r=>r.idSala == idSala).ToListAsync();
                if(sala != null)
                {
                    sala.isDeleted = true;

                    _context.Sala.Update(sala);
                    await _context.SaveChangesAsync();
                }
                if(reservas != null)
                {
                    foreach (var reserva in reservas)
                    {
                        _context.Reserva.Remove(reserva);
                    }
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();

            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateSala(Sala sala)
        {

            try
            {

                //Verifico si ya existe una endidad con el mismo id en el contexto local
                //si existe la desvinculamos del contexto para evitar el error de duplicado

                var existingSale = _context.Sala.Local.FirstOrDefault(u => u.idSala == sala.idSala);
                if (existingSale != null)
                {
                    //Desvinculo la entidad rastreada en en paso anterior
                    _context.Entry(existingSale).State = EntityState.Detached;
                }

                _context.Sala.Update(sala);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario. Error: ", ex);
            }

        }

        public async Task<List<Sala>> GetAllSalas()
        {
            try
            {
                return await _context.Sala.Where(s => !s.isDeleted).ToListAsync();

            }catch(Exception ex)
            {
                throw new Exception("Error al obtener la lista de salas. Error: ", ex);
            }
        }

        public async Task<List<Sala>> GetReservs()
        {

            return await _context.Sala.Where(s => !s.isDeleted).ToListAsync();
            //lo de arriba es para que no moleste pero despues tengo que cambiar la logica para ver si
            //la busqueda de las reservas las hago llando desde la sala o desde las reservas
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
 
}
