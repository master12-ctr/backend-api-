using FirstProject.Models;
using FirstProject.Repository;
using MediatR;
using FirstProject.Application.Command;

namespace FirstProject.Application.CommandHandlers
{
    public class DeleteDepartmentCommandHandler: IRequestHandler<DeleteDepartmentCommand, Department>
    {
          private readonly IDepartmentRepository _Repository;
        public DeleteDepartmentCommandHandler(IDepartmentRepository Repository)
    {
            _Repository = Repository;
    }

        public Task<Department> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
             var departmentToDelete = _Repository.ParentCorrection(request.Deptid);
            if (!departmentToDelete)
            {
                throw new Exception($"Department with Id = {request.Deptid} not found");
            }
             var dept=_Repository.DeleteDepartment(request.Deptid) ?? throw new Exception($"Error when try to Delete the Department");
            return dept;
        }
    }
}