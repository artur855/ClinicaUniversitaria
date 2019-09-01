using System;
using System.Globalization;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Patients
{
    [Binding]
    public class UpdatePatient : BaseTest
    {
        private IPatientService _patientService;
        private Patient _patient;

        public UpdatePatient()
        {
            _patientService = this.GetService<IPatientService>();
        }

        [Given("Eu abra a tela de atualizar pacientes")]
        public void TelaAtualizarPaciente()
        {
            _patientService.SaveAsync(new Patient()
            {
                User = new User()
                {
                    Name = "Bebe"
                },
                Color = PatientColors.Naoespecificado,
                Sex = 'M',
                Birthdate = DateTime.Now
            });
        }

        [Given("Eu escolha o cliente com Id (.*)")]
        public async void EscolherPaciente(int id)
        {
            _patient = await _patientService.FindById(id);
        }

        [Given("Eu insira o nome (.*)")]
        public void InserirNome(string nome)
        {
            _patient.User.Name = nome;
        }

        [Given("Eu insira a data de nascimento para (.*)")]
        public void InserirDataNascimento(DateTime datNasc)
        {
            _patient.Birthdate = DateTime.ParseExact(datNasc.ToString("MM-dd-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        [Given("Eu insira a cor (.*)")]
        public void InserirCor(PatientColors cor)
        {
            _patient.Color = cor;
        }

        [When("Eu clicar no botao atualizar")]
        public async void ClicarAtualizar()
        {
            await _patientService.Update(_patient);
        }

        [Then("O paciente deve ser atualizado com sucesso")]
        public async void ValidarAtualizacao()
        {
            var patient = await _patientService.FindById(_patient.Id);
            Assert.AreEqual(patient.Birthdate.Year, 1999);
            Assert.AreEqual(patient.Birthdate.Month, 10);
            Assert.AreEqual(patient.Birthdate.Day, 9);
            Assert.AreEqual(patient.User.Name, "Arthur");
            Assert.AreEqual(patient.Color, PatientColors.Branco);
            
        }

    }
}