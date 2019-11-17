using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infra.Data.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(HospitalContext context) : base(context)
        {

        }


        public override async Task<Exam> FindByIdAsync(int id)
        {
            return await DbSet
                .Include(e => e.ExamRequest)
                    .ThenInclude(er => er.Medic)
                    .ThenInclude(m => m.User)
                .Include(e => e.ExamRequest)
                    .ThenInclude(er => er.Patient)
                    .ThenInclude(p => p.User)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Exam>> FindAllAsync()
        {
            return await DbSet
                .Include(e => e.ExamRequest)
                    .ThenInclude(er => er.Medic)
                    .ThenInclude(m => m.User)
                .Include(e => e.ExamRequest)
                    .ThenInclude(er => er.Patient)
                    .ThenInclude(p => p.User).ToListAsync();
        }
    }
}
