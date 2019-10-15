using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Domain.Command
{
    public class UserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
