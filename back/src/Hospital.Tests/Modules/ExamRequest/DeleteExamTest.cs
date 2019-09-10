using System;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.ExamRequest
{
    [Binding]
    class DeleteExamTest : BaseTest
    {

        private IPatientService _patientService;
        private IMedicService _medicService;
        private IExamRequestService _examRequestService;
        private Medic _medic;
        private Patient _patient;
        private Domain.Entities.ExamRequest _examRequest;

        public DeleteExamTest()
        {
            _medicService = GetService<IMedicService>();
            _patientService = GetService<IPatientService>();
            _examRequestService = GetService<IExamRequestService>();
        }


        public async System.Threading.Tasks.Task OpenExamInsertScreenAsync()
        {
            await _medicService.SaveAsync(_medic = new Medic
            {
                CRM = "123",
                User = new User
                {
                    Name = "Medico",
                    Email = "medico@email.com",
                    Password = "123"
                }
            });
            await _patientService.SaveAsync(new Patient
            {
                Birthdate = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 10)),
                Color = PatientColors.Branco,
                Sex = 'M',
                User = new User
                {
                    Email = "paciente@email.com",
                    Name = "Paciente",
                    Password = "123"
                }
            });
            _examRequest = new Domain.Entities.ExamRequest()
            {
                Medic = _medic
            };

            _patient = await _patientService.FindById(1);
            _examRequest.Patient = _patient;
        }

        [Given("Eu abra a tela que procura os exames (.*)")]
        public async System.Threading.Tasks.Task ChooseExamAsync(string exame)
        {
            await OpenExamInsertScreenAsync();

            Enum.TryParse(exame, out ExamType exameType);
            _examRequest.ExamName = exameType;

            await _examRequestService.SaveAsync(_medic.UserId, _examRequest);
        }

        [When("Eu clicar em deletar exame")]
        public async System.Threading.Tasks.Task DeleteExamAsync()
        {
            await _examRequestService.DeleteAsync(_medic.UserId, _examRequest.Id);
        }

        [Then("O sistema atualiza e verifica")]
        public async void Verify()
        {
            var examRequests = await _examRequestService.ListAsync(_medic.UserId);
            Assert.IsEmpty(examRequests, "Nenhum pedido de exame foi cadastrado");
        }
    }
}
