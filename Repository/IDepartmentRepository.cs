using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Repository
{
    public interface IDepartmentRepository
    {
    Task <IEnumerable<Department>> GetDepartments();
    Task<Department> GetDepartment(Guid Deptid);
     public bool NameExist(string Deptname);
     public bool ParentCorrection(Guid Parentid);
     public bool DataExist();
    Task<Department> AddDepartment(Department department);
    Task<Department> UpdateDepartment(Department department);
    Task<Department> DeleteDepartment(Guid Deptid);
    }
}