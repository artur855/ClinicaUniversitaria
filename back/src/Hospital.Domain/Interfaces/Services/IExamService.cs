using FluentValidation;
using Hospital.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IExamService : IService<Exam>
    {
        Task<Exam> SaveAsync<V>(IFormFile file, Exam exam) where V : AbstractValidator<Exam>;
    }
}
