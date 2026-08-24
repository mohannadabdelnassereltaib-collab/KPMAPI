using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class LoginDTO
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}