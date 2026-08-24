using System;
using System.Collections.Generic;
using System.Text;

namespace domain
{
    public class DepartmentFunction
    {
        public int FunctionId { get; set; }

        public int DepartmentId { get; set; }

        public Function Function { get; set; } = null!;

        public DepartmentFunction Department { get; set; } = null!;
    }
}
