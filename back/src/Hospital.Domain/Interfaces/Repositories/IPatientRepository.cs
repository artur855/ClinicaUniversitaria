using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> List();
        Task<Patient> Create(Patient patient);
        Task<Patient> FindById(int id);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
}