// DTOs / BaseDTOs.cs
using System;

namespace YourProject.DTOs
{
    public abstract class BaseDtos
    {
        public int Id { get; set; }
    }

    public abstract class BaseAuditDTO : BaseDtos
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}