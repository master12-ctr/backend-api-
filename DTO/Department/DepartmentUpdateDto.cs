using System.ComponentModel.DataAnnotations;
using FirstProject.Models;
namespace FirstProject.DTO
{
    public class DepartmentUpdateDto
    {
         public  Guid Deptid { get; set; }
         [Required(ErrorMessage ="Name is required")]
        public  string? Deptname { get; set; }
        public  string? Description { get; set; }
        
        public Guid? Parentid {get;set;}
       // public  Guid? Managerid { get; set; }
        public static explicit operator DepartmentUpdateDto(Department? v)
        {
            throw new NotImplementedException();
        }
    }
}