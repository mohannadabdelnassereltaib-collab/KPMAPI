// Controllers/DepartmentFunctionsController.cs
using domain;
using infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentFunctionsController : ControllerBase
    {
        private readonly KpmContext _context;

        public DepartmentFunctionsController(KpmContext context)
        {
            _context = context;
        }

        // GET: api/departmentfunctions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentFunction>>> GetDepartmentFunctions()
        {
            return await _context.DepartmentFunctions
                .Include(df => df.Function)
                .Include(df => df.Department)
                .ToListAsync();
        }

        // GET: api/departmentfunctions/function/5/department/3
        [HttpGet("function/{functionId}/department/{departmentId}")]
        public async Task<ActionResult<DepartmentFunction>> GetDepartmentFunction(int functionId, int departmentId)
        {
            var departmentFunction = await _context.DepartmentFunctions
                .Include(df => df.Function)
                .Include(df => df.Department)
                .FirstOrDefaultAsync(df => df.FunctionId == functionId && df.DepartmentId == departmentId);

            if (departmentFunction == null)
            {
                return NotFound();
            }

            return departmentFunction;
        }

        // GET: api/departmentfunctions/function/5
        [HttpGet("function/{functionId}")]
        public async Task<ActionResult<IEnumerable<DepartmentFunction>>> GetDepartmentFunctionsByFunction(int functionId)
        {
            return await _context.DepartmentFunctions
                .Include(df => df.Function)
                .Include(df => df.Department)
                .Where(df => df.FunctionId == functionId)
                .ToListAsync();
        }

        // GET: api/departmentfunctions/department/5
        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<DepartmentFunction>>> GetDepartmentFunctionsByDepartment(int departmentId)
        {
            return await _context.DepartmentFunctions
                .Include(df => df.Function)
                .Include(df => df.Department)
                .Where(df => df.DepartmentId == departmentId)
                .ToListAsync();
        }

        // POST: api/departmentfunctions
        [HttpPost]
        public async Task<ActionResult<DepartmentFunction>> PostDepartmentFunction(DepartmentFunction departmentFunction)
        {
            _context.DepartmentFunctions.Add(departmentFunction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartmentFunctionExists(departmentFunction.FunctionId, departmentFunction.DepartmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartmentFunction",
                new { functionId = departmentFunction.FunctionId, departmentId = departmentFunction.DepartmentId },
                departmentFunction);
        }

        // DELETE: api/departmentfunctions/function/5/department/3
        [HttpDelete("function/{functionId}/department/{departmentId}")]
        public async Task<IActionResult> DeleteDepartmentFunction(int functionId, int departmentId)
        {
            var departmentFunction = await _context.DepartmentFunctions
                .FirstOrDefaultAsync(df => df.FunctionId == functionId && df.DepartmentId == departmentId);

            if (departmentFunction == null)
            {
                return NotFound();
            }
            _context.DepartmentFunctions.Remove(departmentFunction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentFunctionExists(int functionId, int departmentId)
        {
            return _context.DepartmentFunctions.Any(e => e.FunctionId == functionId && e.DepartmentId == departmentId);
        }
    }
}