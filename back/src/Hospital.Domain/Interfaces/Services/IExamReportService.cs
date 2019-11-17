using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IExamReportService
    {
        Task<IEnumerable<ExamReport>> ListAsync(int userId);
        Task<ExamReport> SaveAsync<V>(int userId, ExamReport examReport) where V : AbstractValidator<ExamReport>;

    }
}