using Hospital.Domain.Entities;
using Hospital.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;

namespace Hospital.Infra.Data.Repository
{
    public class MedicRepository : Repository<Medic>, IMedicRepository
    {
        public MedicRepository(HospitalContext context) : base(context) { }
        
        public async Task<Medic> FindByCrmAsync(string crm)
        {
            //Medic medic = await DbSet.Include(m => m.User).SingleAsync(m => m.CRM == crm);
            Medic medic2 = await DbSet.Select(m => m.User.Medic).SingleAsync(m => m.CRM == crm);
            return medic2;
        }

        public override async Task<IEnumerable<Medic>> FindAllAsync()
        {
            return await DbSet.Include(m => m.User).AsNoTracking().ToListAsync();
        }

    }
}
