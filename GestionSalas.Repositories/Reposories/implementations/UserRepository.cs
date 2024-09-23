
using GestionSalas.Entity.DTOs;
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

    public class UserRepository : IUserRepository
    {
        protected readonly GestionSalasContext _context;

        public UserRepository(GestionSalasContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserId(int idUser)
        {
            try
            {
                return await _context.Users
                    .Where(c => !c.isDeleted) 
                    .FirstOrDefaultAsync(c => c.idUser == idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario. Error: ", ex);
            }
        }
        public async Task CreateUser(User user)
        { //VER PORQUE SI EL CORREO YA ESTA REGISTRADO LO QUE DEVUELVE ES EL ERROR QUE ESTA EN EL CATCH
            try
            {
                // Verifica si el correo ya está registrado
                bool userExists = await _context.Users.AnyAsync(e => e.email == user.email);

                if (userExists)
                {
                    throw new Exception("El correo ya está registrado");
                }

                // Agrega el nuevo usuario
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario. Error: ", ex);
            }



            /* try
             {
                 var userContx = _context.Users
                  .SingleOrDefaultAsync(e => e.email == user.email);

                 //if (userContx == null)
                 //{
                 //    _context.Users.Update(user);
                 //    await _context.SaveChangesAsync();
                 //}
                 //else
                 //{
                 //    throw new Exception("El correo ya esta registrado");
                 //}

                 bool userExists = await _context.Users
                 .AnyAsync(e => e.email == user.email);

                 if (userExists)
                 {
                     throw new Exception("El correo ya está registrado");
                 }

                 // Agrega el nuevo usuario
                 await _context.Users.AddAsync(user);
                 await _context.SaveChangesAsync();
             }
             catch (Exception ex) {
                 throw new Exception("Error al crear el usuario. Error: ", ex);
             }
             */
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario. Error: ", ex);
            }
        }

        public async Task DeleteUser(int idUser)
        {
            try
            {
                var user = await GetUserId(idUser);
                if (user != null)
                {
                    user.isDeleted = true; // Marca el usuario como eliminado
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario. Error: ", ex);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users
                    .Where(c => !c.isDeleted) // Solo obtiene usuarios no eliminados
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios. Error: ", ex);
            }

        }

        public async Task<User> VerifyLogin(User user)
        {
            var userContx = await _context.Users
                 .SingleOrDefaultAsync(e => e.email == user.email);


            if (userContx == null)
            {
                throw new Exception("El usuario no existe.");
            }
            else if (userContx.password != user.password)
            {
                throw new Exception("La contraseña es incorrecta");
            }
            
            return userContx;
            
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}


