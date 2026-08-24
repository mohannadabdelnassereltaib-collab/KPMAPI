using Application.Features.Department;
using domain;
using Microsoft.AspNetCore.Mvc;

namespace corbreet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DepartmentService _service;
        
        public EmployeeController(DepartmentService service)
        {
            _service = service;
        }

        // GET: api/Employee/GetAllEmployees
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetAllEmployees()
        {
            var employees = await _service.GetAllEmployees();
            return Ok(employees);
        }

        // GET: api/Employee/GetEmployeeById/5
        [HttpGet("GetEmployeeById/{Id}")]
        public async Task<ActionResult<Employees>> GetEmployee(int Id)
        {
            var employee = await _service.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound($"user with id {Id} is not exist");
            }
            return Ok(employee);
        }

        // POST: api/Employee/AddEmployee
        [HttpPost("AddEmployee")]
        public async Task<ActionResult<Employees>> AddEmployee(Employees employee)
        {
            var added = await _service.AddEmployee(employee);
            return Ok(added);
        }
    }
}