using FluentValidation;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<User> DeleteAsync(int id)
        {
            User user = await FindByIdAsync(id);
            return await _userRepository.RemoveAsync(user.Id);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.FindAllAsync();
        }

        public async Task<User> SaveAsync<V>(User user) where V : AbstractValidator<User>
        {
            Activator.CreateInstance<UserValidator>().Validate(user);
            await _userRepository.InsertAsync(user);
                
            await _unitOfWork.CompleteAsync();

            return user;
        }

        public async Task<User> UpdateAsync<V>(User user) where V : AbstractValidator<User>
        {
            Activator.CreateInstance<UserValidator>().Validate(user);
            User existingUser = await FindByIdAsync(user.Id);

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();

            return existingUser;
        }
    }
}
