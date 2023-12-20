using System;
using System.Collections.Generic;

namespace RegistrationLogin.Models
{
    public partial class LoginUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
    }
}
