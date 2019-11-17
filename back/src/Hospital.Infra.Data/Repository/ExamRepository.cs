using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infra.Data.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(HospitalContext context) : base(context)
        {

        }

    }
}
