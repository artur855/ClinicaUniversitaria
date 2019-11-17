using AutoMapper;
using Hospital.Application.Extensions;
using Hospital.Application.Command;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class ExamController : MainController
    {
        private IExamService _examService;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public ExamController(IExamService examService, 
                              IMapper mapper, 
                              INotificator notificator,
                              IUserService userService) : base(notificator)
        {
            _userService = userService;
            _examService = examService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PerformExam(PerformExamCommand performExamCommand)
        {
            //if (!ModelState.IsValid)
            //    return CustomResponse(ModelState);

            string userId = HttpContext.User.Claims.First()?.Value;

            User user = await _userService.FindByIdAsync(Convert.ToInt32(userId));

            if (user == null)
            {
                NotifyError("Não foi possível encontrar o usuário");
                return CustomResponse(statusCode: StatusCodes.Status404NotFound);
            }


            if (!(user.Medic is Resident))
            {
                NotifyError("Apenas residentes podem realizar o Exame");
                return CustomResponse(statusCode: StatusCodes.Status401Unauthorized);
            }

            Exam exam = _mapper.Map<PerformExamCommand, Exam>(performExamCommand);

            var examAdded = await _examService.SaveAsync<ExamValidator>(performExamCommand.Exam, exam);

            if (examAdded == null)
                return CustomResponse();

            return Ok();
        }
        
    }
}