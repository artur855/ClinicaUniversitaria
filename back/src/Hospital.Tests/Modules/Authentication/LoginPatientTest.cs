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

        private User _user;
        private IAuthenticationService _authenticationService;
        private IUserService _userService;
        private string _jwtToken;
        
        public LoginPatientTest()
        {
            _authenticationService = this.GetService<IAuthenticationService>();
            _userService = this.GetService<IUserService>();
        }

        [Given("Eu abra a tela de login")]
        public async void AbrirTelaLogin()
        {
            _user = new User();
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
            _user.Email = email;
        }

        [Given("Eu insira a senha (.*)")]
        public void InserirSenha(string senha)
        {
            _user.Password = senha;
        }

        [When("Eu clicar em login")]
        public async void ClicarLogin()
        {
            _jwtToken = await _authenticationService.Authenticate(_user);
        }

        [Then("O usuario dese ser logado com sucesso")]
        public void ValidarLogin()
        {
            Assert.IsNotNull(_jwtToken, "Token é nulo");
            Assert.IsNotEmpty(_jwtToken, "Token vazio");
        }
        


    }
}