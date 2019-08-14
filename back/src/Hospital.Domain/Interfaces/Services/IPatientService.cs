using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IPatientService
    {
        Task<Medic> FindById(int id);
        Task<IEnumerable<Medic>> ListAsync();
        Task<Medic> SaveAsync(Patient patient);
        Task<Medic> UpdateAsync(int id, Patient patient);
        Task<Medic> DeleteAsync(int id);
    }
}