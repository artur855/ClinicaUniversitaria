using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Domain.Command;
using Hospital.Domain.DTO;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")] 
    public class ExamRequestController : ControllerBase
    {

        private IExamRequestService _examRequestService;
        private readonly IMapper _mapper;

        public ExamRequestController(IExamRequestService examRequestService, IMapper mapper)
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
            var examRequest = _mapper.Map<ExamRequestCommand, ExamRequest>(examRequestCommand);
            var userId = HttpContext.User.Claims.First()?.Value;
            var newExamRequest = await _examRequestService.SaveAsync<ExamRequestValidator>(int.Parse(userId), examRequest);
            if (newExamRequest == null)
                return Unauthorized();
            var path = Path.Join(Directory.GetCurrentDirectory(), "templates/examRequestReport.html");
            var stream = new FileStream(path, FileMode.Open);
            var response = File(stream, MediaTypeNames.Text.Html);
            return Ok(new ExamRequestDTO
            {
                examRequestReport = response
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
                    return NotFound();

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}