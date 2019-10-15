using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IMedicRepository : IRepository<Medic>
    {
        Task<Medic> FindByCrmAsync(string crm);
    }
}
