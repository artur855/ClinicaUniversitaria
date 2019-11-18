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
    public class PatientService : BaseService, IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public PatientService(
            IPatientRepository patientRepository, 
            IUnitOfWork unitOfWork,
            IUserService userService,
            INotificator notificator) : base(notificator)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        
        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _patientRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _patientRepository.FindAllAsync();
        }

        public async Task<Patient> SaveAsync<V>(Patient patient) where V : AbstractValidator<Patient>
        {
            if (!Validate(Activator.CreateInstance<V>(), patient))
                return null;

            await _patientRepository.InsertAsync(patient);

            if (patient.User != null)
                await _userService.SaveAsync<UserValidator>(patient.User);

            await _unitOfWork.CompleteAsync();
            return patient;
        }

        public async Task<Patient> UpdateAsync<V>(Patient patient) where V : AbstractValidator<Patient>
        {
            var existPatient = await _patientRepository.FindByIdAsync(patient.Id);

            if (existPatient == null)
            {
                Notify($"Unable to lacate patient with current id {patient.Id}");
                return null;
            }


            if (!Validate(Activator.CreateInstance<V>(), patient))
                return null;

            existPatient.Update(patient);
            _patientRepository.Update(existPatient);

            patient.User.Id = existPatient.User.Id;

            if (patient.User != null)
                await _userService.UpdateAsync<UserValidator>(patient.User);

            await _unitOfWork.CompleteAsync();
            return existPatient;
        }

        public async Task<Patient> DeleteAsync(int id)
        {
            var patient = await _patientRepository.FindByIdAsync(id);

            if (patient == null)
            {
                Notify($"Unable to find patient with current id {id}");
                return null;
            }

            await _patientRepository.RemoveAsync(patient.Id);

            await _userService.DeleteAsync(patient.UserId);

            await _unitOfWork.CompleteAsync();

            return patient;
        }

    }
}