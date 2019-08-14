using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infra.Data.Repository
{
    public class PatientRepository :BaseRepository, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _context.Patients.AsNoTracking().ToListAsync();
        }

        public Task AddAsync(Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<Patient> FindByCrmAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Patient patient)
        {
            throw new System.NotImplementedException();
        }
    }
}