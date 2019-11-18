using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Newtonsoft.Json;

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
        
        public async Task<IEnumerable<ExamReport>> ListApprovedAsync(int userId)
        {
            return await _examReportRepository.ListApprovedAsync();
        }

        public async Task<IEnumerable<ExamReport>> ListWaitingAsync(int userId)
        {
            return await _examReportRepository.ListWaitingAsync();
        }

        public async Task<ExamReport> SaveAsync<V>(int userId, ExamReport examReport) where V : AbstractValidator<ExamReport>
        {
            var medic = await _medicService.FindByIdAsync(userId);
            if (!(medic is Medic))
            {
                throw new Exception("Usuario não é um médico");
            }
            
            var examRequest = await _examRequestService.FindByIdAsync(examReport.ExamRequestId);
            if (examRequest == null)
            {
                throw new Exception("Pedido de exame não existe");
            }
            
            var newExamReport = new ExamReport
            {
                Medic = medic,
                ExamRequest = examRequest,
                Description = examReport.Description,
                Cid = examReport.Cid,
                Status = ExamReportStatus.ANDAMENTO
            };
            var report = await _examReportRepository.SaveAsync(newExamReport);
            await _unitOfWork.CompleteAsync();
            return report;
        }

        public async void UpdateStatus(int userId, ExamReport examReport)
        {
            var medic = await _medicService.FindByIdAsync(userId);

            if (medic == null)
            {
                throw new Exception("Médico inválido");
            }

            if (examReport.Status == ExamReportStatus.APROVADO || examReport.Status == ExamReportStatus.NEGADO)
            {
                _examReportRepository.UpdateStatus(examReport);
                return;
            }
            else
            {
                throw new Exception("Status inválido");
            }


        }
    }
}