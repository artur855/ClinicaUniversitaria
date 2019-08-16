using System;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Infra.Data.Repository;
using Hospital.Service.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Patients
{
    [Binding]
    public class InsertPatientTest
    {
        private Patient _patient;
        private IPatientService _patientService;
        
        public InsertPatientTest(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        [Given("Eu abra a tela de cadastrar paciente")]
        public void TelaCadastrarPaciente()
        {
            _patient = new Patient();
        }
        [Given("Insira o nome (.*)")]
        public void InserirNome(string nome)
        {
            _patient.Name = nome;
        }

        [Given("Insira a data de nascimento (.*)")]
        public void InserirDataNascimento(DateTime dataNascimento)
        {
            _patient.Birthdate = dataNascimento;
        }

        [Given("Insira a cor (.*)")]
        public void InserirCor(string cor)
        {
            Enum.TryParse(cor, out PatientColors color);
            _patient.Color = color;
        }

        [Given("Insira o sexo (.*)")]
        public void InserirSexo(char sexo)
        {
            _patient.Sex = sexo;
        }
        
        [When("Eu clicar em cadastrar")]
        public async void Cadastrar()
        {
            _patient = await _patientService.Save(_patient);
        }

        [Then("Meu cliente deve ser listado com id maior que 0")]
        public void ValidarCadastro()
        {
            Assert.NotNull(_patient, "Objeto nulo");
            Assert.Greater(_patient.Id, 0, "Id menor do que zero");
            Assert.Equals(_patient.Age, 19);
        }
        
        

    }
}