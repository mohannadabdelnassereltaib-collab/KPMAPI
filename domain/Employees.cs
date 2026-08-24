using System;
using System.Collections.Generic;
using System.Text;

namespace domain
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public Employees? Manager { get; set; }
    }
}
