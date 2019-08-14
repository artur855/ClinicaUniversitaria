using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IMedicService
    {
        Task<Medic> FindByCrm(string crm);
        Task<IEnumerable<Medic>> ListAsync();
        Task<Medic> SaveAsync(Medic medic);
        Task<Medic> UpdateAsync(string crm, Medic medic);
        Task<Medic> DeleteAsync(string crm);
    }
}
