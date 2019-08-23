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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(HospitalContext context) : base(context) { }

        public async Task<User> Create(User user)
        {
            EntityEntry<User> entityEntry = await _context.Users.AddAsync(user);
            return entityEntry.Entity;
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _context.Users.ToListAsync();
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> Authenticate(string email, string password)
        {
           return await _context.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
