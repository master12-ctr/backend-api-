
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FirstProject.Models
{
    public class Employee
    {
        [Key]
        public Guid Empid { get; set; }
        public required string Empname { get; set; }
        public  string Salary { get; set; }
         public Guid? Deptid {get;set;}=null;

         [JsonIgnore]
         public  Department? Department { get; set; }
    }
}
