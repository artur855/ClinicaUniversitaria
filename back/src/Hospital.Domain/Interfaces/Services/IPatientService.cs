using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IPatientService
    {
        Task<Patient> FindById(int id);
        Task<IEnumerable<Patient>> List();
        Task<Patient> Save(Patient patient);
        Task<Patient> Update(Patient patient);
        Task Delete(int id);
    }
}