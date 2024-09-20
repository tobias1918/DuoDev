using GestionSalas.Entity.DTOs;
using GestionSalas.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserDTO userDTO);
        Task UpdateUser(UserDTO userDTO);
        Task DeleteUser(int idUser);
        Task<UserDTO> GetUserId(int idUser);
        Task<List<UserDTO>> GetAllUsers();
        Task<User> VerifyLogin(LoginDTO loginDTO);
        Task SaveChangesAsync();
    }
}
