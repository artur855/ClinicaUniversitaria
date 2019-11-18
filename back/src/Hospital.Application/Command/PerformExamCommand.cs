using Hospital.Application.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Application.Command
{
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "Exam")]
    public class PerformExamCommand
    {
        public int ExamRequestId { get; set; }
        public IFormFile ExamFile { get; set; }
        public string Date { get; set; }
    }
}
