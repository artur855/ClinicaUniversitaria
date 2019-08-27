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
    public class MedicRepository : BaseRepository, IMedicRepository
    {
        public MedicRepository(HospitalContext context) : base(context)
        {
        }

        public async Task AddAsync(Medic medic)
        {
            await _context.Medics.AddAsync(medic);
        }
        
        public async Task<Medic> FindByCrmAsync(string crm)
        {
            var x = await _context.Set<Medic>().FindAsync(crm);
            return x;
        }

        public async Task<IEnumerable<Medic>> ListAsync()
        {
            return await _context.Set<Medic>().Include(m => m.User).AsNoTracking().ToListAsync();
        }

        public void Remove(Medic medic)
        {
            _context.Medics.Remove(medic);
        }

        public void Update(Medic medic)
        {
            _context.Medics.Update(medic);
        }

    }
}
