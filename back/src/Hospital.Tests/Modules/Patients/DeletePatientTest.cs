using System;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;
using Hospital.Service.Validators;

namespace Hospital.Tests.Modules.Patients
{
    [Binding]
    public class DeletePatientTest : BaseTest
    {
        private IPatientService _patientService;
        private Patient _patient;
        public DeletePatientTest()
        {
            _patientService = this.GetService<IPatientService>();
        }

        [Given("Eu abra a tela de deletar paciente")]
        public async void TelaDeletarPaciente()
        {
            await _patientService.SaveAsync<PatientValidator>(new Patient()
            {
                Birthdate = DateTime.ParseExact("09-10-1999", "dd-MM-yyyy",  System.Globalization.CultureInfo.InvariantCulture),
                User = new User()
                {
                    Name = "Arthur"
                },
                Sex = 'M',
                Color = PatientColors.Branco
            });
        }

        [Given("Escolha o cliente com Id (.*)")]
        public async void EscolherPaciente(int id)
        {
            _patient = await _patientService.FindByIdAsync(id);
        }

        [When("Eu clicar em deletar")]
        public async void DeletarPaciente()
        {
            await _patientService.DeleteAsync(_patient.Id);
        }

        [Then("O paciente deve ser deletado com sucesso")]
        public async void ValidarDelecao()
        {
            var patients = await _patientService.ListAsync();
            Assert.AreEqual(patients.Count(), 0);
        }

    }
}