using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;

namespace Hospital.Service.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository PatientRepository;
        private readonly IUnitOfWork UnitOfWork;

        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            this.PatientRepository = patientRepository;
            this.UnitOfWork = unitOfWork;
        }
        
        public Task<Medic> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Medic>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Medic> SaveAsync(Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<Medic> UpdateAsync(int id, Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<Medic> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}