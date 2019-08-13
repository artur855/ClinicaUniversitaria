using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IMedicRepository
    {
        Task<IEnumerable<Medic>> ListAsync();
        Task AddAsync(Medic medic);
        Task<Medic> FindByCrmAsync(string crm);
        void Update(Medic medic);
        void Remove(Medic medic);
    }
}
