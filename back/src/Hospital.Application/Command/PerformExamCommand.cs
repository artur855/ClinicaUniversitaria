using Hospital.Application.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Application.Command
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "date")]
    public class PerformExamCommand
    {
        public int ExamRequestId { get; set; }
        public IFormFile Exam { get; set; }
        public string Date { get; set; }
    }
}
