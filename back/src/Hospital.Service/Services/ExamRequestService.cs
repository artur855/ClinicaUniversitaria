using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;

namespace Hospital.Service.Services
{
    public class ExamRequestService : BaseService, IExamRequestService
    {
        private readonly IExamRequestRepository _examRequestRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientService _patientService;

        public ExamRequestService(
            IExamRequestRepository examRequestRepository,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IPatientService patientService,
            INotificator notificator) : base(notificator)
        {
            _examRequestRepository = examRequestRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _patientService = patientService;
        }

        public async Task<IEnumerable<ExamRequest>> ListAsync(int userId)
        {
            var currentUser = await _userService.FindByIdAsync(userId);
            return _examRequestRepository.ListAsync(currentUser);
        }

        public async Task<ExamRequest> SaveAsync<V>(int userId, ExamRequest examRequest) where V : AbstractValidator<ExamRequest>
        {

            var currentUser = await _userService.FindByIdAsync(userId);
            if (currentUser.Medic == null)
            {
                Notify("Current user doesn't have permission to peform a exam request");
                return null;
            }

            Patient patient = await _patientService.FindByIdAsync(examRequest.Patient.Id);
            if (patient == null)
            {
                Notify("Unable to find patient to peform a exam request");
                return null;
            }

            examRequest.Patient = patient;
            examRequest.MedicId = currentUser.Medic.Id;

            if (!Validate(Activator.CreateInstance<ExamRequestValidator>(), examRequest))
                return null;

            await _examRequestRepository.InsertAsync(examRequest);
            await _unitOfWork.CompleteAsync();
            return examRequest;
        }

        public async Task<ExamRequest> DeleteAsync(int userId, int examRequestId)
        {
            var currentUser = await _userService.FindByIdAsync(userId);

            if (currentUser.Medic == null)
                throw new UnauthorizedAccessException("Apenas médicos podem cancelar pedidos de exames");

            ExamRequest examRequest = await FindByIdAsync(examRequestId);

            if (examRequest == null) 
            {
                Notify($"Unable to locate Exam with current ID {examRequestId}");
                return null;
            }

            await _examRequestRepository.RemoveAsync(examRequest.Id);

            await _unitOfWork.CompleteAsync();

            return examRequest;
        }

        public async Task<ExamRequest> FindByIdAsync(int id)
        {
            return await _examRequestRepository.FindByIdAsync(id);
        }

        public async Task<ExamRequest> SaveAsync<V>(ExamRequest examRequest) where V : AbstractValidator<ExamRequest>
        {
            await _examRequestRepository.InsertAsync(examRequest);

            return examRequest;
        }

        public async Task<ExamRequest> UpdateAsync<V>(ExamRequest examRequest) where V : AbstractValidator<ExamRequest>
        {
            var existingExamRequest = await _examRequestRepository.FindByIdAsync(examRequest.Id);

            return _examRequestRepository.Update(examRequest);
        }

        public async Task<ExamRequest> DeleteAsync(int id)
        {
            return await _examRequestRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<ExamRequest>> ListAsync()
        {
            return await _examRequestRepository.FindAllAsync();
        }
    }
}