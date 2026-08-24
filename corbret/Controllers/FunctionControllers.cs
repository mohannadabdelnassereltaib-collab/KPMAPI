// Controllers/FunctionsController.cs
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
    public class FunctionsController : ControllerBase
    {
        private readonly KpmContext _context;

        public FunctionsController(KpmContext context)
        {
            _context = context;
        }

        // GET: api/functions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Function>>> GetFunctions()
        {
            return await _context.Functions
                .Include(f => f.Lessons)
                .Include(f => f.DepartmentFunctions)
                .ToListAsync();
        }

        // GET: api/functions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Function>> GetFunction(int id)
        {
            var function = await _context.Functions
                .Include(f => f.Lessons)
                .Include(f => f.DepartmentFunctions)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (function == null)
            {
                return NotFound();
            }

            return function;
        }

        // PUT: api/functions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunction(int id, Function function)
        {
            if (id != function.Id)
            {
                return BadRequest();
            }

            function.LastModifiedDate = DateTime.UtcNow;
            _context.Entry(function).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/functions
        [HttpPost]
        public async Task<ActionResult<Function>> PostFunction(Function function)
        {
            function.CreatedDate = DateTime.UtcNow;
            function.LastModifiedDate = DateTime.UtcNow;
            _context.Functions.Add(function);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunction", new { id = function.Id }, function);
        }

        // DELETE: api/functions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFunction(int id)
        {
            var function = await _context.Functions.FindAsync(id);
            if (function == null)
            {
                return NotFound();
            }

            _context.Functions.Remove(function);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FunctionExists(int id)
        {
            return _context.Functions.Any(e => e.Id == id);
        }
    }
}