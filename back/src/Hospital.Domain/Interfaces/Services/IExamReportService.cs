using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IExamReportService
    {
        Task<IEnumerable<ExamReport>> ListApprovedAsync(int userId);
        Task<IEnumerable<ExamReport>> ListWaitingAsync(int userId);
        Task<ExamReport> SaveAsync<V>(int userId, ExamReport examReport) where V : AbstractValidator<ExamReport>;
        void UpdateStatus(int userId, ExamReport examReport);
    }
}