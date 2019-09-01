using System;
using System.Linq;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Patients
{
    [Binding]
    public class ListPatientTest: BaseTest
    {
        private IPatientService _patientService;
        private IUserService _userService;

        public ListPatientTest()
        {
            _patientService = GetService<IPatientService>();
            _userService = GetService<IUserService>();
        }
        
        [Given("Eu abra a tela de listar pacientes")]
        public async void TelaListarPaciente(){
            await _patientService.SaveAsync(new Patient()
            {
                User = new User()
                {
                    Email = "arthur@email.com",
                    Name = "Arthur",
                    Password = "123"
                },
                Birthdate = new DateTime(1999, 10, 09),
                Color = PatientColors.Branco,
                Sex = 'M'
            });
        }

        [Then("Todos os pacientes devem ser listados")]
        public async void ValidarListagem()
        {
            var patients = await _patientService.ListAsync();
            Assert.IsNotEmpty(patients, "Pacientes não foram listados");
            Assert.AreEqual(patients.Count(), 1, "Número incorreto de pacientes");
            
            var patient = patients.First();
            var patientUser = await _userService.FindByIdAsync(patient.UserId);
        
            Assert.NotNull(patient, "Paciente nulo");
            Assert.AreEqual(patientUser.Name, "Arthur", "Nome diferente do inserido");
            Assert.AreEqual(patient.Sex, 'M', "Sexo diferente do inserido");
            Assert.AreEqual(patient.Birthdate, new DateTime(1999, 10, 09), "Data de nascimento diferente da inserida");
            Assert.AreEqual(patient.Color, PatientColors.Branco, "Cor diferente da inserida");
            Assert.Greater(patient.Id, 0, "Id negativo");
        }
    }

}