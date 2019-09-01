using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Domain.Entities;
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
    public class ExamRequestController : ControllerBase
    {

        private IExamRequestService _examRequestService;


        public ExamRequestController(IExamRequestService examRequestService)
        {
            _examRequestService = examRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            var examRequests = await _examRequestService.ListAsync(int.Parse(userId));
            return Ok(examRequests);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExamRequest examRequest)
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            var newExamRequest =  await _examRequestService.SaveAsync(int.Parse(userId), examRequest);
            if (newExamRequest == null)
                return Unauthorized();
            return CreatedAtAction(nameof(Post), new {id = newExamRequest.Id}, newExamRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ExamRequest examRequest)
        {
            var userId = HttpContext.User.Claims.First()?.Value;
            try
            {
                await _examRequestService.DeleteAsync(int.Parse(userId), examRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}