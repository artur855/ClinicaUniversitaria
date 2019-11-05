using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Domain.DTO
{
    public class ExamRequestDTO
    {
        public FileResult examRequestReport { get; set; }
    }
}
