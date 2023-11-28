using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Application.Commands;
using FirstProject.Models;
using FirstProject.Repository;
using MediatR;

namespace FirstProject.Application.CommandHandlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department >
    {
          private readonly IDepartmentRepository _Repository;

        public CreateDepartmentCommandHandler(IDepartmentRepository Repository)
        {
            _Repository = Repository;
        }

        Task<Department> IRequestHandler<CreateDepartmentCommand, Department>.Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {

                    var depexist=_Repository.DataExist();
                    var nameexist=_Repository.NameExist(request.Deptname);
                    //    try{
                     if(!nameexist){
                    if(depexist){
                      if(request.Parentid==null){
                         throw new Exception("There is exist parent department so you must have choose parent department");
                      }
                  var parentcor=_Repository.ParentCorrection((Guid)request.Parentid);
                    if(parentcor){
                   var departmentId = Guid.NewGuid();
                        Department DEP = new Department()
                            {
                            Deptid = departmentId,
                            Deptname = request.Deptname,
                          //  Managerid= command.Managerid,
                            Description = request.Description,
                            Parentid = request.Parentid,
                                };
                  var dep= _Repository.AddDepartment(DEP);
                  return dep;
                    }else{
                    throw new Exception("incorrect parent department");
                }
                    }
                    else{
                        if(request.Parentid==null){
                      var departmentId = Guid.NewGuid();
                        Department DEP = new Department()
                            {
                            Deptid = departmentId,
                            Deptname = request.Deptname,
                          //  Managerid= command.Managerid,
                            Description = request.Description,
                            Parentid = request.Parentid,
                                };
                  var dep= _Repository.AddDepartment(DEP);
                  return dep;
                        }else{
                   throw new Exception("There is not parent department This Department must be parent!");
                        }
                    }    
                     }else{
                    throw new Exception("Dublicate Department Name Exist");
                     }
                
        }


    }
}