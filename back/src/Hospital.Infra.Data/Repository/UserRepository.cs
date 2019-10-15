using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HospitalContext context) : base(context) { }

        public async Task<User> Authenticate(string email, string password)
        {
           return await DbSet.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public override async Task<User> FindByIdAsync(int id)
        {
            return await DbSet.Include(u => u.Medic).Include(u => u.Patient).SingleOrDefaultAsync(user => user.Id == id);
        }

    }
}
