using Application.DTOs;
using infra;
using infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.DepartmentFunction
{
    public class departmentFunctionService
    {
        public readonly KpmContext _context;

        public departmentFunctionService(KpmContext context)
        {
            _context = context;
        }

        public async Task<departmentFunctionDTO?> CreateDepartmentFunction(departmentFunctionDTO dto)
        {
            if (dto is null)
                throw new ArgumentException("Invalid data.");

            var functionExists = await _context.Functions.AnyAsync(f => f.Id == dto.functionID);
            var departmentExists = await _context.Departments.AnyAsync(d => d.Id == dto.departmentID);

            if (!functionExists || !departmentExists)
                return null;

            var exists = await _context.DepartmentFunctions
                .AnyAsync(x => x.FunctionId == dto.functionID && x.DepartmentId == dto.departmentID);

            if (exists)
                return null;

            var newDepartmentFunction = new domain.DepartmentFunction
            {
                FunctionId = dto.functionID,
                DepartmentId = dto.departmentID
            };

            _context.DepartmentFunctions.Add(newDepartmentFunction);
            await _context.SaveChangesAsync();

            return new departmentFunctionDTO
            {
                functionID = newDepartmentFunction.FunctionId,
                departmentID = newDepartmentFunction.DepartmentId
            };
        }

        public async Task<List<departmentFunctionDTO>> GetAllDepartmentFunctions()
        {
            return await _context.DepartmentFunctions
                .Select(x => new departmentFunctionDTO
                {
                    functionID = x.FunctionId,
                    departmentID = x.DepartmentId
                })
                .ToListAsync();
        }

        public async Task<departmentFunctionDTO?> GetDepartmentFunction(int functionId, int departmentId)
        {
            var entity = await _context.DepartmentFunctions
                .FirstOrDefaultAsync(x => x.FunctionId == functionId && x.DepartmentId == departmentId);

            if (entity == null)
                return null;

            return new departmentFunctionDTO
            {
                functionID = entity.FunctionId,
                departmentID = entity.DepartmentId
            };
        }

        public async Task<bool> DeleteDepartmentFunction(int functionId, int departmentId)
        {
            var entity = await _context.DepartmentFunctions
                .FirstOrDefaultAsync(x => x.FunctionId == functionId && x.DepartmentId == departmentId);

            if (entity == null)
                return false;

            _context.DepartmentFunctions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}