using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IExamRequestService : IService<ExamRequest>
    {
        Task<IEnumerable<ExamRequest>> ListAsync(int userId);
        Task<ExamRequest> SaveAsync<V>(int userId, ExamRequest examRequest) where V : AbstractValidator<ExamRequest>;
        Task<ExamRequest> DeleteAsync(int userId, int examRequestId);
    }
}