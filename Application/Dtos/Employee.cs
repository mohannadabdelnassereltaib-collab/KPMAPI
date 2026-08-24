using Application.DTOs;
using System;
using System.Collections.Generic;

namespace YourProject.DTOs
{
 
    public class EmployeeResponseDTO : BaseDtos
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public EmployeeSummaryDTO? Manager { get; set; }
        public List<EmployeeSummaryDTO> Subordinates { get; set; } = new List<EmployeeSummaryDTO>();
    }


    public class EmployeeSummaryDTO : BaseDtos
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
    }


    public class EmployeeCreateDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
    }

    
    public class EmployeeUpdateDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
    }

    
    public class EmployeeFilterDTO
    {
        public string? SearchTerm { get; set; }
        public int? ManagerId { get; set; }
        public bool? HasManager { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}