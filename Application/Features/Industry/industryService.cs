using Application.DTOs;
using infra.Data;
using infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.Industry
{
    public class IndustryService
    {
        public readonly KpmContext _context;

        public IndustryService(KpmContext context)
        {
            _context = context;
        }

        public async Task<IndustryDTO?> CreateIndustry(IndustryDTO industryDTO)
        {
            if (industryDTO is null || string.IsNullOrWhiteSpace(industryDTO.name))
                throw new ArgumentException("Industry name is required.");

            var normalizedName = industryDTO.name.Trim();

            var exists = await _context.Industries
                .AnyAsync(e => e.Name.Trim() == normalizedName);

            if (exists)
                return null;

            var newIndustry = new domain.Industry
            {
                
                Name = normalizedName,
                CreatedDate = DateTime.UtcNow
            };

            try
            {
                _context.Industries.Add(newIndustry);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return new IndustryDTO
            {
                id = newIndustry.Id,
                name = newIndustry.Name
            };
        }

        public async Task<List<IndustryDTO>> GetAllIndustries()
        {
            var industries = await _context.Industries.ToListAsync();
            var industryDTOs = new List<IndustryDTO>();
            foreach (var industry in industries)
            {
                industryDTOs.Add(new IndustryDTO
                {
                    id = industry.Id,
                    name = industry.Name
                });
            }
            return industryDTOs;
        }

        public async Task<IndustryDTO?> GetIndustryById(int id)
        {
            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
                return null;
            return new IndustryDTO
            {
                id = industry.Id,
                name = industry.Name
            };
        }

        public async Task<bool> UpdateIndustry(int id, IndustryDTO industryDTO)
        {
            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
                return false;
            industry.Name = industryDTO.name;
            industry.ModifiedDate = DateTime.UtcNow;
            _context.Industries.Update(industry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteIndustry(int id)
        {
            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
                return false;
            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}