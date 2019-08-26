using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Medics
{
    [Binding]
    public class UpdateMedicTest : BaseTest
    {
        private IMedicService m_medicService;
        private Medic m_medic;

        public UpdateMedicTest()
        {
            m_medicService = this.GetService<IMedicService>();
        }

        [Given("I'm opening the update medic screen")]
        public void UpdateMedicScreen()
        {
            m_medicService.SaveAsync(new Medic()
            {
                User = new User()
                {
                    Name = "Faluno"
                },
                CRM = "123",
                UserId = 123
            });
        }

        [Given("I choose the medic by CRM (.*)")]
        public async void ChooseMedic(string crm)
        {
            m_medic = await m_medicService.FindByCrm(crm);
        }

        [Given("I'm updating the name (.*)")]
        public void UpdatingName(string name)
        {
            m_medic.User.Name = name;
        }

        [Given("I'm updating the CRM (.*)")]
        public void UpdatingUserID(string crm)
        {
            m_medic.CRM = crm;
        }

        [Given("I'm updating the UserID (.*)")]
        public void UpdatingUserID(int userID)
        {
            m_medic.UserId = userID;
        }

        [When("I'm clicking in the update button")]
        public async void UpdateButtonClick()
        {
            await m_medicService.UpdateAsync(m_medic);
        }

        [Then("The medic should be updated with sucess")]
        public async void ValidateUpdating()
        {
            Medic medic = await m_medicService.FindByCrm(m_medic.CRM);

            Assert.AreEqual(m_medic.User.Name, "Ciclano");
            Assert.AreEqual(m_medic.CRM, "456");
            Assert.AreEqual(m_medic.UserId, 456);
        }
    }
}
