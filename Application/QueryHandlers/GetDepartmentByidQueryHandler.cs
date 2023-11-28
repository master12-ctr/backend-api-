using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Application.Queries;
using FirstProject.Models;
using FirstProject.Repository;
using MediatR;
namespace FirstProject.Application.QueryHandlers
{
    public class GetDepartmentByIdQueryHandler: IRequestHandler<GetDepartmentByidQuery, Department>
    {
        private readonly UsersdbContext _departments;

        public GetDepartmentByIdQueryHandler(UsersdbContext Department)
        {
            _departments = Department;
        }

        public async Task<Department> Handle(GetDepartmentByidQuery query, CancellationToken cancellationToken)
        {
        var depexist = await Task.Run(() => _departments.Department.FirstOrDefault(o => o.Deptid == query.Deptid));
        return depexist ?? throw new Exception("Department does not exist");
        }
    }               
}