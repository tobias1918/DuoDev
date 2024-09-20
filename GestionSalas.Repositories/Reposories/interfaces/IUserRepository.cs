using GestionSalas.Entity.DTOs;
using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.Repositories.Reposories.interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int idUser);
        Task<User> GetUserId(int idUser);
        Task<User> VerifyLogin(User user);
        Task<List<User>> GetAllUsers();
        Task SaveChangesAsync();
    }
}
