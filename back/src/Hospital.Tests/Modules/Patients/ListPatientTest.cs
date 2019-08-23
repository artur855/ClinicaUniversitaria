using System;
using System.Linq;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Tests.Modules;

namespace Hospital.Tests.Modules.Patients
{
    [Binding]
    public class ListPatientTest: BaseTest
    {
        private IPatientService _patientService;

        public ListPatientTest()
        {
            _patientService = GetService<IPatientService>();
        }
        
        [Given("Eu abra a tela de listar pacientes")]
        public async void TelaListarPaciente(){
            await _patientService.Save(new Patient()
            {
                User = new User()
                {
                    Name = "Arthur"
                },
                Birthdate = new DateTime(1999, 10, 09),
                Color = PatientColors.Branco,
                Sex = 'M'
            });
        }

        [Then("Todos os pacientes devem ser listados")]
        public async void ValidarListagem()
        {
            var patients = await _patientService.List();

            Assert.IsNotEmpty(patients, "Pacientes não foram listados");
            Assert.AreEqual(patients.Count(), 1, "Número incorreto de pacientes");
            
            var patient = patients.First();

            Assert.NotNull(patient, "Paciente nulo");
            Assert.AreEqual(patient.User.Name, "Arthur", "Nome diferente do inserido");
            Assert.AreEqual(patient.Sex, 'M', "Sexodiferente do inserido");
            Assert.AreEqual(patient.Birthdate, new DateTime(1999, 10, 09), "Data de nascimento diferente da inserida");
            Assert.AreEqual(patient.Color, PatientColors.Branco, "Cor diferente da inserida");
            Assert.Greater(patient.Id, 0, "Id negativo");
        }
    }

}