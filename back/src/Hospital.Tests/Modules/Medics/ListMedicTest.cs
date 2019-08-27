using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Medics
{
    [Binding]
    public class ListMedicTest : BaseTest
    {
        private IMedicService m_medicService;
        private IUserService m_userService;

        public ListMedicTest()
        {
            m_medicService = GetService<IMedicService>();
            m_userService = GetService<IUserService>();
        }

        [Given("I'm opening the medic list screen")]
        public async void ScreenListMedic()
        {
            await m_medicService.SaveAsync(new Medic()
            {
                User = new User()
                {
                    Name = "Fulano"
                },
                CRM = "123",
            });

            await m_medicService.SaveAsync(new Medic()
            {
                User = new User()
                {
                    Name = "Ciclano"
                },
                CRM = "456",
            });
        }

        [Then("All the medic should be listed below")]
        public async void ValidateListing()
        {
            IEnumerable<Medic> medics = await m_medicService.ListAsync();

            Assert.IsNotEmpty(medics, "Patients were not listed");
            Assert.AreEqual(medics.Count(), 2, "Incorrect count in the medic list");

            Medic medic = medics.First();
            User patientUser = await m_userService.FindByIdAsync(medic.UserId);

            Assert.NotNull(medic, "Medic not null");
            Assert.AreEqual(patientUser.Name, "Fulano", "Different name inserted");
            Assert.AreEqual(medic.CRM, "123", "Different CRM inserted");
            Assert.AreEqual(medic.UserId, 1, "Different UserID inserted");
        }
    }
}
