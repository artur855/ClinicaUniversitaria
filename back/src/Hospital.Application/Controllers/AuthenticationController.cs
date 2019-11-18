using System.Threading.Tasks;
using AutoMapper;
using Hospital.Application.Command;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Application.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : MainController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationService authenticationService, 
                                        INotificator notificator,
                                        IMapper mapper) : base (notificator)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var token = await _authenticationService.Authenticate(_mapper.Map<LoginCommand, User>(loginCommand));

            if (token == null)
                return Unauthorized(new {message = "Usuário ou senha inválido"});

            return Ok(new { Token = token});
        }
    }
}