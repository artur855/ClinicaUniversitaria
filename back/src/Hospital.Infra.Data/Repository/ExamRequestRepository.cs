using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infra.Data.Repository
{
    public class ExamRequestRepository : BaseRepository, IExamRequestRepository
    {
        public ExamRequestRepository(HospitalContext context) : base(context)
        {
        }

        public IEnumerable<ExamRequest> ListAsync(User user)
        {
            if (user.Patient != null)
                return _context.ExamRequests.AsNoTracking()
                    .Include(er => er.Medic).ThenInclude(m => m.User)
                    .Include(er => er.Patient).ThenInclude(p => p.User)
                    .Where(er => er.PatientId == user.Patient.Id);
            if (user.Medic != null)
                return _context.ExamRequests.AsNoTracking()
                    .Include(er => er.Medic).ThenInclude(m => m.User)
                    .Include(er => er.Patient).ThenInclude(p => p.User)
                    .Where(er => er.MedicCrm == user.Medic.CRM);
            return null;
        }

        public async Task SaveAsync(ExamRequest examRequest)
        {
            await _context.ExamRequests.AddAsync(examRequest);
        }

        public void Remove(ExamRequest examRequest)
        {
            _context.ExamRequests.Remove(examRequest);
            _context.SaveChanges();
        }
    }
}