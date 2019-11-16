using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Repositories
{
    public interface IExamReportRepository : IRepository<ExamReport>
    {
        Task<IEnumerable<ExamReport>> ListAsync();
        Task<ExamReport> SaveAsync(ExamReport examReport);
    }
}