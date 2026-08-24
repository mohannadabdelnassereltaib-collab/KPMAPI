using Application.DTOs;
using infra.Data;
using infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Department
{
    public class functionService
    {
        public readonly KpmContext _context;

        public functionService(KpmContext context)
        {
            _context = context;
        }

        public async Task<functionDTO?> CreateFunction(functionDTO functionDTO)
        {
            if (functionDTO is null || string.IsNullOrWhiteSpace(functionDTO.name))
                throw new ArgumentException("Function name is required.");
            var normalizedName = functionDTO.name.Trim().ToLower();

            var exists = await _context.Functions
                .AnyAsync(e => e.Name.ToLower().Trim() == normalizedName);

            if (exists)
                return null;

            var newFunction = new domain.Function
            {
                
                Name = functionDTO.name,
                CreatedDate = DateTime.UtcNow
            };

            try
            {
                _context.Functions.Add(newFunction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return new functionDTO
            {
                Id = newFunction.Id,
                name = newFunction.Name
            };
        }

        public async Task<List<functionDTO>> GetAllFunctions()
        {
            var functions = await _context.Functions.ToListAsync();
            var functionDTOs = new List<functionDTO>();
            foreach (var function in functions)
            {
                functionDTOs.Add(new functionDTO
                {
                    Id = function.Id,
                    name = function.Name
                });
            }
            return functionDTOs;
        }

        public async Task<functionDTO?> GetFunctionById(Guid id)
        {
            var function = await _context.Functions.FindAsync(id);
            if (function == null)
                return null;
            return new functionDTO
            {
                Id = function.Id,
                name = function.Name
            };
        }

        public async Task<bool> UpdateFunction( int Id, functionDTO functionDTO)
            
        {
            var function = await _context.Functions.FindAsync( Id);
            if (function == null)
                return false;
            function.Name = functionDTO.name;
            function.LastModifiedDate = DateTime.UtcNow;
            _context.Functions.Update(function);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFunction( int Id)
        {
            var department = await _context.Functions.FindAsync(Id);
            if (department == null)
                return false;
            _context.Functions.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}