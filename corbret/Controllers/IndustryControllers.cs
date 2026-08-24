// Controllers/IndustriesController.cs
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
    public class IndustriesController : ControllerBase
    {
        private readonly KpmContext _context;

        public IndustriesController(KpmContext context)
        {
            _context = context;
        }

        // GET: api/industries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Industry>>> GetIndustries()
        {
            return await _context.Industries
                .Include(i => i.Lessons)
                .Include(i => i.DepartmentFunctions)
                .ToListAsync();
        }

        // GET: api/industries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Industry>> GetIndustry(int id)
        {
            var industry = await _context.Industries
                .Include(i => i.Lessons)
                .Include(i => i.DepartmentFunctions)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (industry == null)
            {
                return NotFound();
            }

            return industry;
        }

        // PUT: api/industries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustry(int id, Industry industry)
        {
            if (id != industry.Id)
            {
                return BadRequest();
            }

            industry.ModifiedDate = DateTime.UtcNow;
            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/industries
        [HttpPost]
        public async Task<ActionResult<Industry>> PostIndustry(Industry industry)
        {
            industry.CreatedDate = DateTime.UtcNow;
            industry.ModifiedDate = DateTime.UtcNow;
            _context.Industries.Add(industry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndustry", new { id = industry.Id }, industry);
        }

        // DELETE: api/industries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndustry(int id)
        {
            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IndustryExists(int id)
        {
            return _context.Industries.Any(e => e.Id == id);
        }
    }
}