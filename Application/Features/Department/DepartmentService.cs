using domain;
using infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Department
{
    public class DepartmentService
    {
        private readonly KpmContext _context;

        
        public DepartmentService(KpmContext context)
        {
            _context = context;
        }

        public async Task<List<Employees>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees?> GetEmployeeById(int id)
        {
            var employee = await _context.Employees
                .Where(e => e.EmployeeId == id)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync();

            return employee;
        }

        
        public async Task<(bool IsSuccess, string Message, Employees? Data)> AddEmployee(Employees employee)
        {
            try
            {
                var existingUser = await _context.Employees
                    .AnyAsync(e => e.Email.ToLower().Trim() == employee.Email.ToLower().Trim());

                if (existingUser)
                    return (false, "User Is Already Exist", null);

                var userToAdd = new Employees
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    ManagerId = employee.ManagerId
                };

                await _context.Employees.AddAsync(userToAdd);
                await _context.SaveChangesAsync();

                return (true, "Employee Added Successfully", userToAdd);
            }
            catch (Exception)
            {
                return (false, "ERROR WHILE Adding NEW USER", null);
            }
        }

        public async Task<(bool IsSuccess, string Message, Employees? Data)> UpdateEmployee(int id, Employees employee)
        {
            try
            {
                var existing = await _context.Employees.FindAsync(id);
                if (existing == null)
                    return (false, "Employee not found", null);

                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Email = employee.Email;
                existing.ManagerId = employee.ManagerId;

                _context.Employees.Update(existing);
                await _context.SaveChangesAsync();

                return (true, "Employee updated successfully", existing);
            }
            catch (Exception)
            {
                return (false, "ERROR WHILE UPDATING USER", null);
            }
        }

        public async Task<(bool IsSuccess, string Message)> DeleteEmployee(int id)
        {
            try
            {
                var existing = await _context.Employees.FindAsync(id);
                if (existing == null)
                    return (false, "Employee not found");

                _context.Employees.Remove(existing);
                await _context.SaveChangesAsync();

                return (true, "Employee deleted successfully");
            }
            catch (Exception)
            {
                return (false, "ERROR WHILE DELETING USER");
            }
        }

        
    }
}