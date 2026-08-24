using System;
using System.Collections.Generic;
using System.Text;

namespace domain
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = null;
        public string ProjectName { get; set; } = null;
        public int DepartmentId { get; set; }
        public int FunctionId { get; set; }
        public int IndustryId { get; set; }
        public string ValueProposition { get; set; } = null;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string TargetAudience { get; set; } = null!;
        public string Engage1 { get; set; } = null!;
        public string PersonaFocalPoint { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DepartmentFunction Department { get; set; } = null!;
        public Function Function { get; set; } = null!;
        public Industry Industry { get; set; } = null!;
        public string? imageUrl { get; set; }
        public string? personToContact { get; set; }
    }
}
