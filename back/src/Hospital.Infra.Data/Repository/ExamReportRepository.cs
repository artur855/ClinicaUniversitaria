using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infra.Data.Repository
{
    public class ExamReportRepository : Repository<ExamReport>, IExamReportRepository
    {
        public ExamReportRepository(HospitalContext context) : base(context)
        {
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(ExamReport obj)
        {
            throw new NotImplementedException();
        }

        public ExamReport Update(ExamReport obj)
        {
            throw new NotImplementedException();
        }

        public Task<ExamReport> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ExamReport> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamReport>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamReport>> Where(Expression<Func<ExamReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExamReport>> ListAsync()
        {
            return await Context.ExamReports.ToListAsync();
        }

        public async Task<ExamReport> SaveAsync(ExamReport examReport)
        {
            return (await Context.ExamReports.AddAsync(examReport)).Entity;
        }

       
    }
}