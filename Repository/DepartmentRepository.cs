using System.Threading.Tasks;
using FirstProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web;
using System.Data;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Net.Mime;
namespace FirstProject.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly UsersdbContext _departments;

        public DepartmentRepository(UsersdbContext Department)
        {
            _departments = Department;
        }

          public  Task<IEnumerable<Department>> GetDepartments()
        {
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

        public async Task<Department> GetDepartment(Guid Deptid)
        {
            var depexist = _departments.Department.FirstOrDefault(o => o.Deptid == Deptid);
                return  depexist;
        }

            public bool DataExist(){
                var depexist=_departments.Department.Any(x=>x.Parentid==null);
                return depexist;
            }

            public bool ParentCorrection(Guid parentid){
                var depexist=_departments.Department.Any(o => o.Deptid == parentid);
                return  depexist;
            }
           public bool NameExist(String Deptname){
                Boolean depexist=_departments.Department.Any(o => o.Deptname == Deptname);
                 return depexist;
            }
        public async Task<Department> AddDepartment(Department dep)
        {
             var ad= _departments.Department.Add(dep);
             await _departments.SaveChangesAsync();
             dep.ChildrenDeprtment = null;                                                 
                return dep;
            //    return StatusCode(StatusCodes.Status200OK,
            //    "successfully Created new department");
        }

        public async Task<Department> UpdateDepartment(Department dep)
        {
                    //  return StatusCode(StatusCodes.Status200OK,
              //  "Correctly update the department");
           //this is allowed
       // var userManager = new UserManager();
      // object valf= RecMethod(id, (Guid)model.Parentid);
      // return valf;
       //   return StatusCode(StatusCodes.Status200OK,
        //        "Correctly update the department");


         List<Department> Temp=_departments.Department.Include(x=>x.ChildrenDeprtment)
                 .Where(x=>x.Parentid==dep.Deptid).
                 Select(f=>new Department {Deptid=f.Deptid,Deptname=f.Deptname,Description=f.Description,Parentid=f.Parentid, ChildrenDeprtment=f.ChildrenDeprtment}).ToList();
             //  private static Boolean cd = false;
                var  aa=false;

                get_all(Temp);
                if(aa==true || dep.Deptid==dep.Parentid){
                //    return StatusCode(StatusCodes.Status409Conflict,
                //    "Circular Dependency Error");
                throw new Exception("Circular Dependency Error");
                }else{
                    var result = _departments.Department.FirstOrDefault(b => b.Deptid == dep.Deptid);
                    if (result != null)
                    {
                      result.Deptname = dep.Deptname;
                     result.Description = dep.Description;
                      result.Parentid = dep.Parentid;
                    }
                else
                {
                 _departments.Department.Add(dep);
                }

            await _departments.SaveChangesAsync();
 
                            return result;
                
                  //  return StatusCode(StatusCodes.Status200OK,
                 //   "Correctly update the department");
                 //   }
                //    return StatusCode(StatusCodes.Status409Conflict,
               //     "unavailable Department calling");
                }
                // Managerid=f.Managerid,
            //  return Content(JsonConvert.SerializeObject(new {data= get_all(Temp)}, Formatting.Indented,"application/json"));
                

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
                                if(DbDep.Deptid==dep.Parentid){
                                    aa=true;
                                    break;
                                }
                                List<Department> child= DbDep.ChildrenDeprtment.ToList();
                                DbDep.ChildrenDeprtment=get_all(child);
                                lists[z]=DbDep;
                                z++;
                    
                     }
                    return lists;
                    }
            }

        public async Task<Department> DeleteDepartment(Guid id)
        {
             var dept= _departments.Department.Where(e => e.Deptid == id).Include(e=>e.ChildrenDeprtment).FirstOrDefault();
            _departments.Department.Remove(dept);
           await _departments.SaveChangesAsync();
           return dept;
          //  return StatusCode(StatusCodes.Status200OK,
          //      "Correctly Deleted the department");
        }

    }
}
