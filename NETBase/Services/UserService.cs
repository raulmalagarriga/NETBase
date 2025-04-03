using Microsoft.AspNetCore.Mvc;
using NETBase.DTOs;
using NETBase.Interfaces.IRepositories;
using NETBase.Interfaces.IServices;
using NETBase.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NETBase.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(CreateUserDTO data)
        {
            try
            {
                // Validating username
                User validateUsername = await _userRepository.GetUserByUsername(data.Username);
                if (validateUsername != null) throw new Exception("Username already exists!");
                // Validating email
                User validateEmail = await _userRepository.GetUserByEmail(data.Email);
                if (validateEmail != null) throw new Exception("Email already exists!");
                // Mapping data to model User
                User NewUser = new()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password
                };
                bool createUser = await _userRepository.CreateUser(NewUser);
                return createUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(string code)
        {
            try
            {
                // Validating that the user exists
                User userToDelete = await _userRepository.GetUserByCode(code);
                if (userToDelete == null) throw new Exception("User not found");
                var deleteUser = await _userRepository.DeleteUser(code);
                return deleteUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetUserByCode(string code)
        {
            try
            {
                User Result = await _userRepository.GetUserByCode(code);
                if (Result == null) throw new Exception("User does not exists!");
                UserDTO ResultMapped = new()
                {
                    Code = Result.Code,
                    Username = Result.Password,
                    Email = Result.Email,
                    Password = Result.Password,
                };
                return ResultMapped;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            try
            {
                List<User> Result = await _userRepository.GetUsers();
                List<UserDTO> ResultMapped = Result.Select(user => new UserDTO
                {
                    Code = user.Code,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password
                }).ToList();

                return ResultMapped;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(UpdateUserDTO data)
        {
            try
            {
                bool userToUpdate = await _userRepository.UpdateUser(data);
                if (userToUpdate == false)
                {
                    throw new Exception("User does not exists!");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
