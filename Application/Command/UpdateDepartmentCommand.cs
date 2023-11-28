using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.DTO;
using FirstProject.Models;
using MediatR;

namespace FirstProject.Application.Command
{
    public class UpdateDepartmentCommand:IRequest<Department>
    {
        public UpdateDepartmentCommand(Guid deptid, string deptname, string? description, Guid? parentid)
        {
            Deptid=deptid;
            Deptname = deptname;
            Description = description;
            Parentid = parentid;
        }
           public  Guid Deptid { get; set; }
          public  string Deptname { get; set; }
         public string? Description { get; set; }
         public Guid? Parentid { get; set; }
    }
}