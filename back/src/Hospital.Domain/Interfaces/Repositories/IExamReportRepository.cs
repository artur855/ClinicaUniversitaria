using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IExamReportRepository : IRepository<ExamReport>
    {
        Task<IEnumerable<ExamReport>> ListWaitingAsync();
        Task<IEnumerable<ExamReport>> ListApprovedAsync();
        Task<ExamReport> SaveAsync(ExamReport examReport);
        void UpdateStatus(ExamReport examReport);
    }
}