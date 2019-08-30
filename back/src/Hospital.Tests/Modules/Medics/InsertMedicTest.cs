using Hospital.Domain.Entities;
using System.Collections.Generic;
using Hospital.Domain.Interfaces.Services;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;

namespace Hospital.Tests.Modules.Medics
{
    [Binding]
    class InsertMedicTest : BaseTest
    {
        private IMedicService m_medicService;
        private Medic m_medic;

        public InsertMedicTest()
        {
            m_medicService = this.GetService<IMedicService>();
        }

        [Given("I'm opening the medic register screen")]
        public void MedicRegisterScreen()
        {
            m_medic = new Medic();
        }

        [Given("Insert the CRM (.*)")]
        public void InsertCRM(string crm)
        {
            m_medic.CRM = crm;
        }

        [Given("Insert the UserID (.*)")]
        public void InsertUserID(int userId)
        {
            m_medic.UserId = userId;
        }

        [When("I'm clicking in register screen")]
        public async void Cadastrar()
        {
            m_medic = await m_medicService.SaveAsync(m_medic);
        }

        [Then("My medic should be listed with CRM and UserID 123")]
        public async void ValidateRegister()
        {
            Assert.NotNull(m_medic, "Object not null");
            Assert.AreEqual(m_medic.CRM, "123");
            Assert.AreEqual(m_medic.UserId, 123);

            IEnumerable<Medic> medics = await m_medicService.ListAsync();
            Assert.AreEqual(medics.Count(), 0);
        }
    }
}
