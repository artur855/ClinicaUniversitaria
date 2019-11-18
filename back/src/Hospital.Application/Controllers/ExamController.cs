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
using Hospital.Application.DTO;
using System.Collections.Generic;
using System.Collections;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                NotifyError("id inexistente");
                return CustomResponse(statusCode: StatusCodes.Status400BadRequest);
            }

            Exam exam = await _examService.FindByIdAsync(id);

            if (exam == null)
                return CustomResponse(statusCode: StatusCodes.Status400BadRequest);

            return Ok(_mapper.Map<Exam, ExamDTO>(exam));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exams = await _examService.ListAsync();

            return Ok(_mapper.Map<IEnumerable<Exam>, IEnumerable<ExamDTO>>(exams));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                NotifyError("id inexistente");
                return CustomResponse(statusCode: StatusCodes.Status400BadRequest);
            }

            Exam exam = await _examService.DeleteAsync(id);

            if (exam == null)
                return CustomResponse(statusCode: StatusCodes.Status400BadRequest);

            return NoContent();

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

            var examAdded = await _examService.SaveAsync<ExamValidator>(performExamCommand.ExamFile, exam);

            if (examAdded == null)
                return CustomResponse();

            return Ok();
        }
        
    }
}