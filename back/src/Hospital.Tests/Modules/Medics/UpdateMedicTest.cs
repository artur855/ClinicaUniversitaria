using System;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Hospital.Tests.Modules.Medics
{
    [Binding]
    public class UpdateMedicTest : BaseTest
    {
        private IMedicService _medicService;
        private Medic _medic;

        public UpdateMedicTest()
        {
            _medicService = this.GetService<IMedicService>();
        }

        [Given("I'm opening the update medic screen")]
        public void UpdateMedicScreen()
        {
            _medicService.SaveAsync<MedicValidator>(new Medic()
            {
                User = new User()
                {
                    Name = "Qualquer"
                },
                CRM = "456",
            });
        }

        [Given("I choose the medic by CRM (.*)")]
        public async void ChooseMedic(string crm)
        {
            _medic = await _medicService.FindByCrm(crm);
        }

        [Given("I'm updating the name (.*)")]
        public void UpdatingName(string name)
        {
            _medic.User.Name = name;
        }

        //[Given("I'm updating the CRM (.*)")]
        //public void UpdatingUserID(string crm)
        //{
        //    _medic.CRM = crm;
        //}

        [Given("I'm updating the UserID (.*)")]
        public void UpdatingUserID(int userID)
        {
            _medic.UserId = userID;
        }

        [When("I'm clicking in the update button")]
        public async void UpdateButtonClick()
        {
            await _medicService.UpdateAsync<MedicValidator>(_medic);
        }

        [Then("The medic should be updated with sucess")]
        public async void ValidateUpdating()
        {
            Medic medic = await _medicService.FindByCrm(_medic.CRM);
            Console.WriteLine("------------------------");
            Console.WriteLine(medic);
            Console.WriteLine("------------------------");
            //Assert.AreEqual(medic.User.Name, "Faluno");
            //Assert.AreEqual(medic.CRM, "123");
            // Assert.AreEqual(medic.UserId, 123);
        }
    }
}
