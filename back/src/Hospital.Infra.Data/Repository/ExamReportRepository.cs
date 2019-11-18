using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace Hospital.Infra.Data.Repository
{
    public class ExamReportRepository : Repository<ExamReport>, IExamReportRepository
    {
        public ExamReportRepository(HospitalContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<ExamReport>> ListAsync()
        {
            return await Context.ExamReports.ToListAsync();
        }

        public async Task<IEnumerable<ExamReport>> ListWaitingAsync()
        {
            return await Context.ExamReports
                .Include(er => er.Medic)
                .Include(er => er.ExamRequest)
                .Where(er => er.Status == ExamReportStatus.ANDAMENTO)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExamReport>> ListApprovedAsync()
        {
            return await Context.ExamReports
                .Include(er => er.Medic)
                .Include(er => er.ExamRequest)
                .Where(er => er.Status == ExamReportStatus.APROVADO)
                .ToListAsync();
        }

        public async Task<ExamReport> SaveAsync(ExamReport examReport)
        {
            return (await Context.ExamReports.AddAsync(examReport)).Entity;
        }

        public async Task<ExamReport> FindByIdAsync(int id)
        {
            return await Context.ExamReports.Include(er => er.Medic).Include(er => er.ExamRequest).SingleAsync(er => er.Id == id);
        }

        public void UpdateStatus(ExamReport examReport)
        {
            Context.ExamReports.Update(examReport);
        }

       
    }
}