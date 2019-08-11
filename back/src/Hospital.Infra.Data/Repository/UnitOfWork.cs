using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _context;

        public UnitOfWork(HospitalContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
