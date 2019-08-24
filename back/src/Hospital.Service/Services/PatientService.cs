using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;

namespace Hospital.Service.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async  Task<Patient> FindById(int id)
        {
            return await _patientRepository.FindById(id);
        }

        public async Task<IEnumerable<Patient>> List()
        {
            return await _patientRepository.List();
        }

        public async Task<Patient> Save(Patient patient)
        {
            Activator.CreateInstance<PatientValidator>().Validate(patient);
            await _patientRepository.Create(patient);
            await _unitOfWork.CompleteAsync();
            return patient;
        }

        public async Task<Patient> Update(Patient patient)
        {
            var existPatient = await _patientRepository.FindById(patient.Id);
            Activator.CreateInstance<PatientValidator>().Validate(patient);
            existPatient.Update(patient);
            _patientRepository.Update(existPatient);
            await _unitOfWork.CompleteAsync();
            return existPatient;
        }

        public async Task Delete(int id)
        {
            var patient = await _patientRepository.FindById(id);
            if (patient == null) return;
            _patientRepository.Remove(patient);
            await _unitOfWork.CompleteAsync();
        }
    }
}