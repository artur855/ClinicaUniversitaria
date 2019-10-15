using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IMedicService : IService<Medic>
    {
        Task<Medic> FindByCrm(string crm);
        Task<Medic> DeleteByCrmAsync(string crm);
    }
}
