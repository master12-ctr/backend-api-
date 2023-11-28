using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;
using MediatR;

namespace FirstProject.Application.Commands
{
    public class CreateDepartmentCommand:IRequest<Department>
    {
        public CreateDepartmentCommand(string deptname, string? description, Guid? parentid)
        {
            Deptname = deptname;
            Description = description;
            Parentid = parentid;
        }
          public  string Deptname { get; set; }
         public string? Description { get; set; }
         public Guid? Parentid { get; set; }
    }
}







