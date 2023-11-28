
using FirstProject.Application.Command;
using FirstProject.Models;
using FirstProject.Repository;
using MediatR;

namespace FirstProject.Application.CommandHandlers
{
    public class UpdateDepartmentCommandHandler: IRequestHandler<UpdateDepartmentCommand, Department>
    {
      private readonly IDepartmentRepository _Repository;
        public UpdateDepartmentCommandHandler(IDepartmentRepository Repository)
    {
            _Repository = Repository;
    }

        public async Task<Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
                            Department DEP = new Department()
                            {
                            Deptid = request.Deptid,
                            Deptname = request.Deptname,
                          //  Managerid= command.Managerid,
                            Description = request.Description,
                            Parentid = request.Parentid,
                                };
                   return await _Repository.UpdateDepartment(DEP);
        }
    }
    }