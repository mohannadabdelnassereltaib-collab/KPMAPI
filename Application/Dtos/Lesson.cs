using System;
namespace Application.DTOs
{
    public class LessonDTO
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string projectName { get; set; } = string.Empty;
        public int departmentId { get; set; }
        public int functionId { get; set; }
        public int industryId { get; set; }
        public string valueProposition { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string? imageUrl { get; set; }
        public string? personToContact { get; set; }
    }
}