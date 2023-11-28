using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Application.Queries;
using FirstProject.Models;
using FirstProject.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Application.QueryHandlers
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IEnumerable<Department>>
    {
        private readonly UsersdbContext _departments;

         public GetDepartmentsQueryHandler(UsersdbContext Department)
        {
            _departments = Department;
        }

        public  Task<IEnumerable<Department>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            // return  _Repository.GetDepartments();
             List<Department> Temp=_departments.Department.Include(x=>x.ChildrenDeprtment)
                 .Where(x=>x.ParentDepartment==null).
                 Select(f=>new Department {Deptid=f.Deptid,Deptname=f.Deptname,Description=f.Description,Parentid=f.Parentid, ChildrenDeprtment=f.ChildrenDeprtment}).ToList();
                // Managerid=f.Managerid,
            //  return Content(JsonConvert.SerializeObject(new {data= get_all(Temp)}, Formatting.Indented,"application/json"));
                    var allret= new {data= get_all(Temp) };
                    List<Department> aa=allret.data.ToList();
                    Task<IEnumerable<Department>> result = Task.FromResult(aa.Cast<Department>());
                    return result;
               //  return Content(JsonConvert.SerializeObject(new {data= get_all(Temp) },Formatting.Indented ));
                
             List<Department> get_all(List<Department> list){
                            int z=0;
                            List<Department> lists= new List<Department>();
                                if(list.Count>0){
                                    lists.AddRange(list);
                                }
                    foreach(Department x in list){
                Department DbDep=_departments.Department.Include(y => y.ChildrenDeprtment)
                                .Where(y => y.Deptid == x.Deptid)
                                .Select(y => new Department { Deptid = y.Deptid, Deptname = y.Deptname,Description = y.Description, Parentid = y.Parentid, ChildrenDeprtment = y.ChildrenDeprtment }).First();
                                //Managerid=f.Managerid,
                                if(DbDep.ChildrenDeprtment== null){
                                    z++;
                                    continue;
                                
                                }
                                List<Department> child= DbDep.ChildrenDeprtment.ToList();
                                DbDep.ChildrenDeprtment=get_all(child);
                                lists[z]=DbDep;
                                z++;
                    
                     }
                    return lists;
                    }             
        }
    }
}