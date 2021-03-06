using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IExamRequestRepository : IRepository<ExamRequest>
    {
        IEnumerable<ExamRequest> ListAsync(User user);
    }
}