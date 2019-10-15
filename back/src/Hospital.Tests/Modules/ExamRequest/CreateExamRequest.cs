using System;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.ExamRequest
{
    [Binding]
    public class CreateExamRequest : BaseTest
    {

        private IPatientService _patientService;
        private IMedicService _medicService;
        private IExamRequestService _examRequestService;
        private Medic _medic;
        private Patient _patient;
        private Domain.Entities.ExamRequest _examRequest;
        
        public CreateExamRequest()
        {
            _medicService = GetService<IMedicService>();
            _patientService = GetService<IPatientService>();
            _examRequestService = GetService<IExamRequestService>();
        }

        [Given("Eu abra a tela para fazer pedidos de exames")]
        public void AbrirTelaCadastrarPedidoExame() 
        {
            _medic = new Medic
            {
                CRM = "123",
                User = new User
                {
                    Name = "Medico",
                    Email = "medico@email.com",
                    Password = "123"
                }
            };
            _medicService.SaveAsync<MedicValidator>(_medic);
            _patientService.SaveAsync<PatientValidator>(new Patient
            {
                Birthdate = DateTime.Now.Subtract(TimeSpan.FromDays(365*10)),
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
                Medic =  _medic
            };
            
        }

        [Given("Eu adicionar o identificador do paciente (.*)")]
        public async void EscolherPaciente(int idPaciente)
        {
            _patient = await _patientService.FindByIdAsync(idPaciente);
            _examRequest.Patient = _patient;
        }

        [Given("Escolha o exame (.*)")]
        public void EscolherExame(string exame)
        {
            Enum.TryParse(exame, out ExamType exameType);
            _examRequest.ExamName = exameType;
        }

        [Given("Escolha a data (.*) para realizar o exame")]
        public void EscolherDataExame(DateTime dataExame)
        {
            _examRequest.ExpectedDate = dataExame;
        }

        [Given("Informe o hípotese (.*)")]
        public void EscolherHipotese(string hypothesis)
        {
            _examRequest.Hypothesis = hypothesis;
        }

        [When("Eu clicar em emitir pedido")]
        public async void ClicarEmitirPedido()
        {
            await _examRequestService.SaveAsync<ExamRequestValidator>(_medic.UserId,_examRequest);
        }

        [Then("O sistema salvar e imprimir o pedido de exame")]
        public async void ValidarEmissaoPedido()
        {
            var examRequests = await _examRequestService.ListAsync(_medic.UserId);
            Assert.IsNotEmpty(examRequests, "Nenhum pedido de exame foi cadastrado");
        }
        
    }
}