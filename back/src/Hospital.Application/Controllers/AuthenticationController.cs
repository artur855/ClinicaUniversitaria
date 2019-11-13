using System.Threading.Tasks;
using Hospital.Domain.DTO;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : MainController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, INotificator notificator) : base (notificator)
        {
            _authenticationService = authenticationService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var token = await _authenticationService.Authenticate(loginDto);

            if (token == null)
                return Unauthorized(new {message = "Usuário ou senha inválido"});

            return Ok(token);
        }
    }
}