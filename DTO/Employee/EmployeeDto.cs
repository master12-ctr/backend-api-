
using FirstProject.Models;
namespace FirstProject.DTO
{
    public class EmployeeDto
    {
        public Guid Empid { get; set; }
        public required string Empname { get; set; }
        public  string Salary { get; set; }
         public Guid? Deptid {get;set;}=null;
    }
}