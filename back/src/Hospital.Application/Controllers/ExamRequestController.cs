using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Mime;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class ExamRequestController : MainController
    {

        private IExamRequestService _examRequestService;
        private readonly IMapper _mapper;

        public ExamRequestController(
            IExamRequestService examRequestService,
            IMapper mapper,
            INotificator notificator) : base (notificator)
        {
            _examRequestService = examRequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            var examRequests = await _examRequestService.ListAsync(int.Parse(userId));

            return Ok(_mapper.Map<IEnumerable<ExamRequest>, IEnumerable<ExamRequestDTO>>(examRequests));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExamRequestCommand examRequestCommand)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var examRequest = _mapper.Map<ExamRequestCommand, ExamRequest>(examRequestCommand);
            var userId = HttpContext.User.Claims.First()?.Value;
            var newExamRequest = await _examRequestService.SaveAsync<ExamRequestValidator>(int.Parse(userId), examRequest);
            
            if (newExamRequest == null) 
                return CustomResponse();

            var path = Path.Join(Directory.GetCurrentDirectory(), "templates/examRequestReport.html");

            var examRequestDTO = _mapper.Map<ExamRequest, ExamRequestDTO>(newExamRequest);

            string html = System.IO.File.ReadAllText(path);

            html = ReplaceHtml(examRequestDTO, html);

            return Ok(new Dictionary<string, string>() {
                    {"html", html }
                });
        }

        [HttpDelete("{examRequestId}")]
        public async Task<IActionResult> Delete(int examRequestId)
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            try
            {
                ExamRequest examRequest = await _examRequestService.DeleteAsync(int.Parse(userId), examRequestId);
                if (examRequest == null)
                    return CustomResponse(statusCode: StatusCodes.Status404NotFound);

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        public string ReplaceHtml(ExamRequestDTO examRequest, string html)
        {

            html = html.Replace("NomePaciente", examRequest.MedicName);
            html = html.Replace("NomeExame", examRequest.ExamName);
            html = html.Replace("DataExame", examRequest.ExpectedDate);

            return html;
        }
}
}