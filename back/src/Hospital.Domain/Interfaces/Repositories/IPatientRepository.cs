using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task AddAsync(Patient patient);
        Task<Patient> FindByCrmAsync(int id);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
}