using AutoMapper;
using Hospital.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class ExamReportController : ControllerBase
    {
        private IExamReportService _examReportService;
        private readonly IMapper _mapper;
        
        
        
    }
}