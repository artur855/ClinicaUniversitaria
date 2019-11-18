using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Application.Command;
using Hospital.Application.DTO;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ExamReportController : MainController
    {
        private readonly IExamReportService _examReportService;
        private readonly IMapper _mapper;
        public ExamReportController(
            IExamReportService examReportService, 
            IMapper mapper,
            INotificator notificator) : base(notificator) {
            _examReportService = examReportService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("approved")]
        public async Task<ActionResult> GetApproved()
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            var reports = (await _examReportService.ListApprovedAsync(int.Parse(userId)))
                .Select(er => _mapper.Map<ExamReport, ExamReportDTO>(er));
            return Ok(reports);
        }

        [HttpGet]
        [Route("waiting")]
        public async Task<ActionResult> GetWaiting()
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            var reports = (await _examReportService.ListWaitingAsync(int.Parse(userId)))
                .Select(er => _mapper.Map<ExamReport, ExamReportDTO>(er));
            return Ok(reports);
            
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExamReportCommand examReportCommand)
        {
            var userId = int.Parse(HttpContext.User.Claims.First()?.Value);
            var examReport = _mapper.Map<ExamReportCommand, ExamReport>(examReportCommand);
            examReport.MedicId = userId;
            var report = await _examReportService.SaveAsync<ExamReportValidator>(userId, examReport);
            var dto = _mapper.Map<ExamReport, ExamReportDTO>(report);
            return Ok(dto);
        }

        [HttpPost]
        [Route("updateStatus")]
        public ActionResult UpdateStatus(UpdateExamReportCommand updateExamReportCommand)
        {
            var userId = int.Parse(HttpContext.User.Claims.First()?.Value);
            _examReportService.UpdateStatus(userId, _mapper.Map<UpdateExamReportCommand, ExamReport>(updateExamReportCommand));
            return Ok(); 
        }
        
    }
}