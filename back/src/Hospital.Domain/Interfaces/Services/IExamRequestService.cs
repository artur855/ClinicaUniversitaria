using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IExamRequestService
    {
        Task<ExamRequest> FindByIdAsync(int id);
        Task<IEnumerable<ExamRequest>> ListAsync(int userId);
        Task<ExamRequest> SaveAsync(int userId, ExamRequest examRequest);
        Task<ExamRequest> DeleteAsync(int userId, int examRequestId);
    }
}