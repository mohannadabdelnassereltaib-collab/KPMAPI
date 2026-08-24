using System;
using System.Collections.Generic;
using System.Text;

namespace domain
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
            = new List<Lesson>();

        public ICollection<DepartmentFunction> DepartmentFunctions { get; set; }
            = new List<DepartmentFunction>();

    }
}
