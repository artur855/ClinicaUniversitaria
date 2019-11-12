using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Entities
{
    public class Notification
    {
        public string Message { get; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
