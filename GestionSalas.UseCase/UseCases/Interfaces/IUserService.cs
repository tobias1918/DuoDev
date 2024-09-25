﻿using GestionSalas.Entity.DTOs.UserDTOs;
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
        Task UpdateUser(UpdateUserDTO userDTO);
        Task DeleteUser(int idUser);
        Task<User> GetUserId(int idUser);
        Task<List<User>> GetAllUsers();
        Task<User> VerifyLogin(LoginDTO loginDTO);
        Task SaveChangesAsync();
    }
}
