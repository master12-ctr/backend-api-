
using System.ComponentModel.DataAnnotations;
using FirstProject.Models;
namespace FirstProject.DTO
{
    public class DepartmentDto
    {
        public Guid Deptid { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public required string Deptname { get; set; }
        public  string? Description { get; set; }
        
        public Guid? Parentid {get;set;}
        // public required Guid Managerid { get; set; }
        public static explicit operator DepartmentDto(Department? v)
        {
            throw new NotImplementedException();
        }
    }
}