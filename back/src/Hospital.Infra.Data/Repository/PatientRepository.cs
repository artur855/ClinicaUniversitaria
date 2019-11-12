using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hospital.Infra.Data.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context) { }

        public override async Task<IEnumerable<Patient>> FindAllAsync()
        {
            return await DbSet.AsNoTracking().Include(m => m.User).ToListAsync();
        }

        public override async Task<Patient> FindByIdAsync(int id)
        {
            return await DbSet.Include(p => p.User).SingleOrDefaultAsync(patient => patient.Id == id);
        }

    }
}