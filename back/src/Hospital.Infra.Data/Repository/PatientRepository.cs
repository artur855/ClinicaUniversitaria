using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hospital.Infra.Data.Repository
{
    public class PatientRepository :BaseRepository, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> List()
        {
            return await _context.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<Patient> Create(Patient patient)
        {
            var entityEntry = await _context.Patients.AddAsync(patient);
            return entityEntry.Entity;
        }

        public async Task<Patient> FindById(int id)
        {
            return await _context.Patients.SingleAsync(patient => patient.Id == id);
        }

        
        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}