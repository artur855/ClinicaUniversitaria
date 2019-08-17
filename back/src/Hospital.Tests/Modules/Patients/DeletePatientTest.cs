using System;
using System.Collections.Generic;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Infra.Data.Repository;
using Hospital.Service.Services;
using TechTalk.SpecFlow;
using Tests.Modules;
using System.Linq;
using NUnit.Framework;

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
            await _patientService.Save(new Patient()
            {
                Birthdate = DateTime.ParseExact("09-10-1999", "dd-MM-yyyy",  System.Globalization.CultureInfo.InvariantCulture),
                Name = "Arthur",
                Sex = 'M',
                Color = PatientColors.Branco
            });
        }

        [Given("Escolha o cliente com Id (.*)")]
        public async void EscolherPaciente(int id)
        {
            _patient = await _patientService.FindById(id);
        }

        [When("Eu clicar em deletar")]
        public async void DeletarPaciente()
        {
            await _patientService.Delete(_patient.Id);
        }

        [Then("O cliente deve ser deletado com sucesso")]
        public async void ValidarDelecao()
        {
            var patients = await _patientService.List();
            Assert.AreEqual(patients.Count(), 0);
        }

    }
}