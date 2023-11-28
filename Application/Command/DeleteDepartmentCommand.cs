using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;
using MediatR;
namespace FirstProject.Application.Command
{
    public class DeleteDepartmentCommand: IRequest<Department>
    {
      public Guid Deptid { get; set; }
    }
}