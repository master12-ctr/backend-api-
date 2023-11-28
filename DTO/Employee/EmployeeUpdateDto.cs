namespace FirstProject.DTO
{
    public class EmployeeUpdateDto
    {
        public  string? Empname { get; set; }
        public  string? Salary { get; set; }
         public Guid? Deptid {get;set;}=null;
    }
}
