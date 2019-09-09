using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Interfaces.Repositories;

namespace Hospital.Service.Services
{
    public class MedicService : IMedicService
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public MedicService(IMedicRepository medicRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _medicRepository = medicRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Medic> DeleteAsync(string crm)
        {
            Medic existingMedic = await _medicRepository.FindByCrmAsync(crm);

            if (existingMedic == null)
                return null;

            try
            {
                _medicRepository.Remove(existingMedic);
                await _userService.DeleteAsync(existingMedic.User.Id);
                await _unitOfWork.CompleteAsync();
                return existingMedic;
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }

        public async Task<Medic> FindByCrm(string crm)
        {
            return await _medicRepository.FindByCrmAsync(crm);
        }

        public async Task<IEnumerable<Medic>> ListAsync()
        {
            return await _medicRepository.ListAsync();
        }

        public async Task<Medic> SaveAsync(Medic medic)
        {
            Activator.CreateInstance<MedicValidator>().Validate(medic);
            await _medicRepository.AddAsync(medic);
            await _unitOfWork.CompleteAsync();

            return medic;
        }

        public async Task<Medic> UpdateAsync(Medic medic)
        {
            Activator.CreateInstance<MedicValidator>().Validate(medic);

            Medic existingMedic = await _medicRepository.FindByCrmAsync(medic.CRM);

            if (existingMedic == null)
                return null;

            existingMedic.CRM = medic.CRM;

            if (medic is Docent)
            {
                (existingMedic as Docent).Titulation = (medic as Docent).Titulation;
            }
            else if (medic is Resident)
            {
                (existingMedic as Resident).InitialDate = (medic as Resident).InitialDate;
            }

            try
            {
                _medicRepository.Update(existingMedic);

                medic.User.Id = existingMedic.User.Id;

                if (medic.User != null)
                    await _userService.UpdateAsync(medic.User);

                await _unitOfWork.CompleteAsync();
                return existingMedic;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
