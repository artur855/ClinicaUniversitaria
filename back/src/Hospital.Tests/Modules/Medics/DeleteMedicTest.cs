using System.Collections.Generic;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;

namespace Hospital.Tests.Modules.Medics
{
    [Binding]
    public class DeleteMedicTest : BaseTest
    {
        private IMedicService m_medicService;
        private Medic m_medic;

        public DeleteMedicTest()
        {
            m_medicService = this.GetService<IMedicService>();
        }

        [Given("I'm opening the medic delete screen")]
        public async void MedicDeleteScreen()
        {
            await m_medicService.SaveAsync(new Medic()
            {
                CRM = "123456",
                UserId = 1,
                User = new User()
                {
                    Name = "Fulano"
                },
            });
        }

        [Given("Choose the medic with CRM (.*)")]
        public async void InsertName(string crm)
        {
            m_medic = await m_medicService.FindByCrm(crm);
        }

        [When("I'm clicking at delete")]
        public async void ChoosingToDeleteMedic()
        {
            await m_medicService.DeleteAsync(m_medic.CRM);
        }

        [Then("The medic should be deleted with sucess")]
        public async void ValidateDeleting()
        {
            IEnumerable<Medic> medics = await m_medicService.ListAsync();
            Assert.AreEqual(medics.Count(), 0);
        }
    }
}
