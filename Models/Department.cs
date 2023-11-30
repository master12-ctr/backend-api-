using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace FirstProject.Models
{
    public class Department
    {
        public Department(){
            ChildrenDeprtment=new HashSet<Department>();
        }
        [Key]
        public Guid Deptid { get; set; }
        public required string Deptname { get; set; }
        public  string? Description { get; set; }
        public Guid? Parentid {get;set;}

        [JsonIgnore]
         public Department ParentDepartment { get; set; }

      //   [JsonIgnore]
        public virtual ICollection<Department>  ChildrenDeprtment { get;set; }

        //public required Guid Managerid {get;set;}
      //  [JsonIgnore]
       //  public virtual Employee  Employee { get;set; }

    }
}