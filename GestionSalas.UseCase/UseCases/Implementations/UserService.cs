using AutoMapper;
using GestionSalas.Entity.DTOs.UserDTOs;
using GestionSalas.Entity.Entidades;
using GestionSalas.Repositories.Reposories.implementations;
using GestionSalas.Repositories.Reposories.interfaces;
using GestionSalas.UseCase.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalas.UseCase.UseCases.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            var user = new User
            {
                idUser = userDTO.idUser,
                name = userDTO.name.ToLower(),
                surname = userDTO.surname.ToLower(),
                email = userDTO.email.ToLower(),
                password = userDTO.password,
            };
       
            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(UpdateUserDTO userDTO)
        {
            if (userDTO.idUser != 0 && userDTO != null)
            {

                User user = await GetUserId(userDTO.idUser);

                if (user != null)
                {
                    if (userDTO.name != null) user.name = userDTO.name.ToLower();

                    if (userDTO.surname != null) user.surname = userDTO.surname.ToLower();

                    if (userDTO.email != null) user.email = userDTO.email.ToLower();

                    if (userDTO.password != null) user.password = userDTO.password;

                    if (userDTO.rol != null) user.rol = (byte)userDTO.rol;
                }
                await _userRepository.UpdateUser(user);
            }
        }
        public async Task DeleteUser(int idUser)
        {
            await _userRepository.DeleteUser(idUser);
        }

        public async Task<User> GetUserId(int id)
        {
           var user =  await _userRepository.GetUserId(id);
            return new User
            {
                idUser = user.idUser,
                name = user.name,
                surname = user.surname,
                email = user.email,
                password = user.password,
            };
        }
        public async Task<List<User>> GetAllUsers()
        {
            var listaUserSalida = new List<User>();
            var users = await _userRepository.GetAllUsers();

            foreach (var user in users)
            {   
                
                var userSalida = new User
                {
                    idUser = user.idUser,
                    name = user.name,
                    surname = user.surname,
                    email = user.email,
                    password = user.password,

                };
                listaUserSalida.Add(userSalida);
            }

            return listaUserSalida;

        }
        
        public async Task<User> VerifyLogin(LoginDTO loginDTO)
        {
            var user = new User
            {
                email = loginDTO.email.ToLower(),
                password = loginDTO.password,
            };
            return await _userRepository.VerifyLogin(user);

        }
        

        public async Task SaveChangesAsync()
        {
            _userRepository.SaveChangesAsync();
        }
    }
}
