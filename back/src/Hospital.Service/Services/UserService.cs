using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hospital.Domain.DTO;
using Hospital.Service.Config;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(int id)
        {
            User user = await FindByIdAsync(id);
            _userRepository.Remove(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userRepository.FindById(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.List();
        }

        public async Task<User> SaveAsync(User user)
        {
            Activator.CreateInstance<UserValidator>().Validate(user);
            User newUser = await _userRepository.Create(user);
                
            await _unitOfWork.CompleteAsync();

            return newUser;
        }

        public async Task<User> UpdateAsync(User user)
        {
            Activator.CreateInstance<UserValidator>().Validate(user);

            User existingUser = await FindByIdAsync(user.Id);
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();

            return existingUser;
        }
    }
}
