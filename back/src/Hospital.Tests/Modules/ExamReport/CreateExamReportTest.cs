using System;
using Hospital.Application.Command;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.ExamReport
{
    [Binding]
    public class CreateExamReportTest : BaseTest
    {
        
        private Resident _resident;
        private Domain.Entities.ExamReport _examReport;
        private Domain.Entities.ExamReport _newExamReport;
        private Domain.Entities.ExamRequest _examRequest;

        private IMedicService _medicService;
        private IExamRequestService _examRequestService;
        private IExamReportService _examReportService;

        private CreateExamReportTest()
        {
            _examReportService = GetService<IExamReportService>();
            _medicService = GetService<IMedicService>();
            _examRequestService = GetService<IExamRequestService>();
            
            _newExamReport = new Domain.Entities.ExamReport();
            
            _resident = new Resident()
            {
                CRM = "123",
                InitialDate = DateTime.Now,
                User = new User
                {
                    Id = 1,
                 Email   = "resident@email.com",
                 Name = "resident",
                 Password = "123",
                }
            };
            
            _examRequest = new Domain.Entities.ExamRequest
            {
                Id = 1,
                Hypothesis = "Cancer no coracao",
                ExamName = ExamType.Ecocardiograma,
                Recomendation = "Descansar"
            };

            _medicService.SaveAsync<MedicValidator>(_resident);
            _examRequestService.SaveAsync<ExamRequestValidator>(_examRequest);
        }

        [Given("Eu abra a tela para publicar o laudo do exame")]
        public void EuAbraATelaParaPublicarOLaudoDoExame()
        {
        }

        [Given("Eu escolha o exame de id (.*)")]
        public void EuEscolhaOExame(int ExamId)
        {
            _newExamReport.ExamRequestId = ExamId;
        }

        [Given("Eu irei adicionar a descrição (.*)")]
        public void EuIreiAdicionarADescricao(string Description)
        {
            _newExamReport.Description = Description;
        }

        [Given(" E a minha hipótese do CID da doença seja (.*)")]
        public void EuAdicioneAHiposeteComo(int Cid)
        {
            _newExamReport.Cid = Cid;
        }

        [When("Eu clicar em emitir laudo")]
        public async void EuClicarEmEmitirLaudo()
        {


            _examReport = await _examReportService.SaveAsync<ExamReportValidator>(_resident.User.Id, _newExamReport);
        }

        [Then("O sistema devera emitir o laudo em meu nome")]
        public void OSistemaDeveraEmitirOLaudoEmMeuNome()
        {
            Console.WriteLine("asdasd");
        }
    }
}