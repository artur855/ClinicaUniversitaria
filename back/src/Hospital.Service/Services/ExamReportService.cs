using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Hospital.Domain.Command;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;

namespace Hospital.Service.Services
{
    public class ExamReportService : IExamReportService
    {

        private readonly IMedicService _medicService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExamReportRepository _examReportRepository;
        private readonly IExamRequestService _examRequestService;

        public ExamReportService(IMedicService medicService, IUnitOfWork unitOfWork, IExamReportRepository examReportRepository, IExamRequestService examRequestService)
        {
            _medicService = medicService;
            _unitOfWork = unitOfWork;
            _examReportRepository = examReportRepository;
            _examRequestService = examRequestService;
        }
        
        public async Task<IEnumerable<ExamReport>> ListAsync(int userId)
        {
            var resident = (Resident) await _medicService.FindByIdAsync(userId);
            if (resident == null)
            {
                
            }

            return await _examReportRepository.ListAsync();
        }

        public async Task<ExamReport> SaveAsync<V>(int userId, ExamReportCommand examReportCommand) where V : AbstractValidator<ExamReport>
        {
            var resident = (Resident) await _medicService.FindByIdAsync(userId);
            if (resident == null)
            {
                throw new Exception("Usuario não é um residente");
            }
            
            var examRequest = await _examRequestService.FindByIdAsync(examReportCommand.ExamRequestId);
            if (examRequest == null)
            {
                throw new Exception("Pedido de exame não existe");
            }
            
            var examReport = new ExamReport
            {
                Resident = resident,
                ExamRequest = examRequest,
                Description = examReportCommand.Description,
                Cid = examReportCommand.Cid
            };
            
            return await _examReportRepository.SaveAsync(examReport);
        }
    }
}