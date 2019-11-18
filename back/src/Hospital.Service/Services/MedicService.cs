using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Domain.Interfaces.Repositories;
using FluentValidation;
using Hospital.Domain.Interfaces;

namespace Hospital.Service.Services
{
    public class MedicService : BaseService, IMedicService
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public MedicService(
            IMedicRepository medicRepository,
            IUnitOfWork unitOfWork,
            IUserService userService,
            INotificator notificator) : base(notificator)
        {
            _medicRepository = medicRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Medic> DeleteAsync(int id)
        {
            return await _medicRepository.RemoveAsync(id);
        }

        public async Task<Medic> DeleteByCrmAsync(string crm)
        {
            Medic existingMedic = await _medicRepository.FindByCrmAsync(crm);

            if (existingMedic == null)
            {
                Notify($"Unable to locate Medic with current crm '{crm}'");
                return null;
            }

            await _medicRepository.RemoveAsync(existingMedic.Id);
            await _userService.DeleteAsync(existingMedic.User.Id);
            await _unitOfWork.CompleteAsync();
            return existingMedic;
        
        }

        public async Task<Medic> FindByCrm(string crm)
        {
            return await _medicRepository.FindByCrmAsync(crm);
        }

        public async Task<Medic> FindByIdAsync(int id)
        {
            return await _medicRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Medic>> ListAsync()
        {
            return await _medicRepository.FindAllAsync();
        }

        public async Task<Medic> SaveAsync<V>(Medic medic) where V : AbstractValidator<Medic>
        {

            if (!Validate(Activator.CreateInstance<V>(), medic))
                return null;

            await _medicRepository.InsertAsync(medic);
            await _unitOfWork.CompleteAsync();

            return medic;
        }

        public async Task<Medic> UpdateAsync<V>(Medic medic) where V : AbstractValidator<Medic>
        {
            if (!Validate(Activator.CreateInstance<V>(), medic))
                return null;

            Medic existingMedic = await _medicRepository.FindByCrmAsync(medic.CRM);

            if (existingMedic == null)
            {
                Notify($"Unable to locate the medic with current crm '{medic.CRM}'");
                return null;
            }

            if (medic is Docent)
            {
                (existingMedic as Docent).Titulation = (medic as Docent).Titulation;
            }
            else if (medic is Resident)
            {
                (existingMedic as Resident).InitialDate = (medic as Resident).InitialDate;
            }

            _medicRepository.Update(existingMedic);

            medic.User.Id = existingMedic.User.Id;

            if (medic.User != null)
                await _userService.UpdateAsync<UserValidator>(medic.User);

            await _unitOfWork.CompleteAsync();
            return existingMedic;

        }
    }
}
