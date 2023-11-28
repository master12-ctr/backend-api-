using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;
using MediatR;

namespace FirstProject.Application.Queries
{
    public class GetDepartmentsQuery:IRequest<IEnumerable<Department>>
    {
                 
    }
}