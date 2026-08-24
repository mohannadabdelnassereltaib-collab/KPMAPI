using Application.DTOs;
using infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Lesson
{
    public class LessonService
    {
        public readonly KpmContext _context;

        public LessonService(KpmContext context)
        {
            _context = context;
        }

        public async Task<LessonDTO?> CreateLesson(LessonDTO dto)
        {
            if (dto is null || string.IsNullOrWhiteSpace(dto.title))
                throw new ArgumentException("Lesson title is required.");

            // Validate related entities using the correct DTO fields
            var departmentExists = await _context.Departments.AnyAsync(d => d.Id == dto.departmentId);
            var functionExists = await _context.Functions.AnyAsync(f => f.Id == dto.functionId);
            var industryExists = await _context.Industries.AnyAsync(i => i.Id == dto.industryId);

            if (!departmentExists || !functionExists || !industryExists)
                return null;

            var newLesson = new domain.Lesson
            {
                
                Title = dto.title,
                ProjectName = dto.projectName,
                DepartmentId = dto.departmentId,
                FunctionId = dto.functionId,
                IndustryId = dto.industryId,
                ValueProposition = dto.valueProposition,
                Description = dto.description,
                imageUrl = dto.imageUrl,
                personToContact = dto.personToContact
            };

            _context.Lessons.Add(newLesson);
            await _context.SaveChangesAsync();

            return new LessonDTO
            {
                id = newLesson.Id,
                title = newLesson.Title,
                projectName = newLesson.ProjectName,
                departmentId = newLesson.DepartmentId,
                functionId = newLesson.FunctionId,
                industryId = newLesson.IndustryId,
                valueProposition = newLesson.ValueProposition,
                description = newLesson.Description,
                imageUrl = newLesson.imageUrl!,
                personToContact = newLesson.personToContact!
            };
        }

        public async Task<List<LessonDTO>> GetAllLessons()
        {
            return await _context.Lessons
                .Select(x => new LessonDTO
                {
                    id = x.Id,
                    title = x.Title,
                    projectName = x.ProjectName,
                    departmentId = x.DepartmentId,
                    functionId = x.FunctionId,
                    industryId = x.IndustryId,
                    valueProposition = x.ValueProposition,
                    description = x.Description,
                    imageUrl = x.imageUrl!,
                    personToContact = x.personToContact!
                })
                .ToListAsync();
        }

        public async Task<LessonDTO?> GetLessonById(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
                return null;

            return new LessonDTO
            {
                id = lesson.Id,
                title = lesson.Title,
                projectName = lesson.ProjectName,
                departmentId = lesson.DepartmentId,
                functionId = lesson.FunctionId,
                industryId = lesson.IndustryId,
                valueProposition = lesson.ValueProposition,
                description = lesson.Description,
                imageUrl = lesson.imageUrl!,
                personToContact = lesson.personToContact!
            };
        }

        public async Task<bool> UpdateLesson(LessonDTO dto)
        {
            var lesson = await _context.Lessons.FindAsync(dto.id);
            if (lesson == null)
                return false;

            lesson.Title = dto.title;
            lesson.ProjectName = dto.projectName;
            lesson.DepartmentId = dto.departmentId;
            lesson.FunctionId = dto.functionId;
            lesson.IndustryId = dto.industryId;
            lesson.ValueProposition = dto.valueProposition;
            lesson.Description = dto.description;
            lesson.imageUrl = dto.imageUrl;
            lesson.personToContact = dto.personToContact;

            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
                return false;

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}