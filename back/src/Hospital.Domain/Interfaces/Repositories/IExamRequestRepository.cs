using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IExamRequestRepository
    {
        IEnumerable<ExamRequest> ListAsync(User user);
        Task SaveAsync(ExamRequest examRequest);
        void Remove(ExamRequest examRequest);
    }
}