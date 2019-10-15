using Hospital.Domain.DTO;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Authentication
{
    [Binding]
    public class LoginPatientTest : BaseTest
    {

        private LoginDTO _loginDto;
        private IAuthenticationService _authenticationService;
        private IUserService _userService;
        private JwtTokenDTO _jwtTokenDto;
        
        public LoginPatientTest()
        {
            _authenticationService = this.GetService<IAuthenticationService>();
            _userService = this.GetService<IUserService>();
        }

        [Given("Eu abra a tela de login")]
        public async void AbrirTelaLogin()
        {
            _loginDto = new LoginDTO();
            await _userService.SaveAsync<UserValidator>(new User
            {
                Name = "Arthur",
                Email = "email@email.com",
                Password = "123"
            });
        }

        [Given("Eu insira o email (.*)")]
        public void InserirLogin(string email)
        {
            _loginDto.Email = email;
        }

        [Given("Eu insira a senha (.*)")]
        public void InserirSenha(string senha)
        {
            _loginDto.Password = senha;
        }

        [When("Eu clicar em login")]
        public async void ClicarLogin()
        {
            _jwtTokenDto = await _authenticationService.Authenticate(_loginDto);
        }

        [Then("O usuario dese ser logado com sucesso")]
        public void ValidarLogin()
        {
            Assert.IsNotNull(_jwtTokenDto, "Token é nulo");
            Assert.IsNotEmpty(_jwtTokenDto.Token, "Token vazio");
        }
        


    }
}