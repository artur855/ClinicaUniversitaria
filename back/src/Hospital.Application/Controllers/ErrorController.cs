using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
             
            var ExceptionMessage = "";
            if (exceptionHandlerPathFeature?.Path == "/index")
            {
                ExceptionMessage = " from home page";
            }
            
            return Ok(new Dictionary<string, string> {
                                      {"Erro", ExceptionMessage}
                                  });
        }
    }
}