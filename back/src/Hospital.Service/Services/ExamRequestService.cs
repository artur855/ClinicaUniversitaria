using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;

namespace Hospital.Service.Services
{
    public class ExamRequestService : IExamRequestService
    {
        private IExamRequestRepository _examRequestRepository;
        private IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        
        public ExamRequestService(IExamRequestRepository examRequestRepository, IUserService userService, IUnitOfWork unitOfWork)
        {
            _examRequestRepository = examRequestRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ExamRequest>> ListAsync(int userId)
        {
            var currentUser = await _userService.FindByIdAsync(userId);
            return _examRequestRepository.ListAsync(currentUser);
        }

        public async Task<ExamRequest> SaveAsync(int userId, ExamRequest examRequest)
        {
            var currentUser = await _userService.FindByIdAsync(userId);
            if (currentUser.Medic == null)
                return null;
            Activator.CreateInstance<ExamRequestValidator>().Validate(examRequest);
            await _examRequestRepository.SaveAsync(examRequest);
            await _unitOfWork.CompleteAsync();
            return examRequest;
        }

        public async Task DeleteAsync(int userId, ExamRequest examRequest)
        {
            var currentUser = await _userService.FindByIdAsync(userId);
            if (currentUser.Medic == null)
                throw new UnauthorizedAccessException("Apenas médicos podem cancelar pedidos de exames");
            _examRequestRepository.Remove(examRequest);
        }
    }
}