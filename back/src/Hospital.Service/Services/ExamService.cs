using FluentValidation;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Services
{
    public class ExamService : BaseService, IExamService
    {

        private INotificator _notificator;
        private IExamRepository _examRepository;
        private IUnitOfWork _unitOfWork;

        public ExamService(INotificator notificator, 
                           IExamRepository examRepository, 
                           IUnitOfWork unitOfWork) : base(notificator)
        {
            _examRepository = examRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Exam> DeleteAsync(int id)
        {
            Exam examRemoved = await _examRepository.RemoveAsync(id);

            if (examRemoved == null)
                Notify($"Exam {id} não foi encontrado");

            return examRemoved;

        }

        public async Task<Exam> FindByIdAsync(int id)
        {
            Exam exam = await _examRepository.FindByIdAsync(id);

            if (exam == null)
                Notify($"Exam {id} não foi encontrado");

            return exam;

        }

        public async Task<IEnumerable<Exam>> ListAsync()
        {
            return await _examRepository.FindAllAsync();
        }

        public async Task<Exam> SaveAsync<V>(IFormFile file, Exam exam) where V : AbstractValidator<Exam>
        {
            var imagePrefix = Guid.NewGuid().ToString();

            string filePath = await UploadFile(file, imagePrefix);

            if (filePath == null)
            {
                return null;
            }

            exam.ExamPath = filePath;

            return await SaveAsync<V>(exam);
            
        }

        private async Task<string> UploadFile(IFormFile file, string imagePrefix)
        {
            if (file == null || file.Length == 0)
            {
                Notify("Forneça um arquivo");
                return null;
            }

            if (file.Length > 200000)
            {
                Notify("Arquivo muito grande");
                return null;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\assets", 
                                    imagePrefix + ".pdf");

            if (File.Exists(path))
            {
                Notify("Arquivo com este nome já existe");
                return null;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;

        }

        public async Task<Exam> SaveAsync<V>(Exam exam) where V : AbstractValidator<Exam>
        {
            if (!Validate(Activator.CreateInstance<V>(), exam))
                return null;

            await _examRepository.InsertAsync(exam);
            await _unitOfWork.CompleteAsync();

            return exam;
        }

        public Task<Exam> UpdateAsync<V>(Exam obj) where V : AbstractValidator<Exam>
        {
            throw new NotImplementedException();
        }
    }
}
