using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Infra.Data.Repository;
using Hospital.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hospital.Domain.Interfaces.Repositories;

namespace Hospital.Service.Services
{
    public class MedicService : IMedicService
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MedicService(IMedicRepository medicRepository, IUnitOfWork unitOfWork)
        {
            _medicRepository = medicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Medic> DeleteAsync(string crm)
        {
            Medic existingMedic = await _medicRepository.FindByCrmAsync(crm);

            if (existingMedic == null)
                return null;

            try
            {
                _medicRepository.Remove(existingMedic);
                await _unitOfWork.CompleteAsync();
                return existingMedic;
            }
            catch (Exception e)
            {
                return null;
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
            existingMedic.Name = medic.Name;

            try
            {
                _medicRepository.Update(existingMedic);
                await _unitOfWork.CompleteAsync();
                return medic;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
