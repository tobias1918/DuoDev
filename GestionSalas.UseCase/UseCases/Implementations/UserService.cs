using AutoMapper;
using GestionSalas.Entity.DTOs;
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
                name = userDTO.name,
                surname = userDTO.surname,
                email = userDTO.email,
                password = userDTO.password,
            };
       
            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            if (userDTO.idUser != 0 && userDTO != null)
            {

                User user = await GetUserId(userDTO.idUser);

                ////if (user != null)
                ////{

                ////    if (userDTO.name != null)
                ////        user.nameSala = userDTO.nameSala;

                ////    if (userDTO.codSala != null)
                ////        user.codSala = userDTO.codSala;

                ////    if (userDTO.floorSala.HasValue)
                ////        user.floorSala = userDTO.floorSala.Value;

                ////    if (userDTO.capacitySala.HasValue)
                ////        user.capacitySala = userDTO.capacitySala.Value;

                ////}




            }
        }
        public async Task DeleteUser(int idUser)
        {
            await _userRepository.DeleteUser(idUser);
        }

        public async Task<UserDTO> GetUserId(int id)
        {
           var user =  await _userRepository.GetUserId(id);
            return new UserDTO
            {
                idUser = user.idUser,
                name = user.name,
                surname = user.surname,
                email = user.email,
                password = user.password,
            };
        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var usersDTOs = new List<UserDTO>();
            var users = await _userRepository.GetAllUsers();

            foreach (var user in users)
            {
                var userDTO = new UserDTO
                {
                    idUser = user.idUser,
                    name = user.name,
                    surname = user.surname,
                    email = user.email,
                    password = user.password,

                };
                usersDTOs.Add(userDTO);
            }

            return usersDTOs;

        }
        
        public async Task<User> VerifyLogin(LoginDTO loginDTO)
        {
            var user = new User
            {
                email = loginDTO.email,
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
