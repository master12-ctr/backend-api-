using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Application.Command
{
    public class updateDepartmentCommand
    {
        public  string Deptid { get; set; }
          public  string Deptname { get; set; }
         public string? Description { get; set; }
         public Guid? Parentid { get; set; }
    }
}