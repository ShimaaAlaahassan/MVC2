using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class Department
    {
        [Key]
        public int? Number { get; set; }
        public string? Name { get; set; }
        [ForeignKey("EmpManage")]
        public int? emp_m { get; set; }
        public virtual List<employee>? EmpWork { get; set; }
        public virtual employee? EmpManage { get; set; }

        public List<location>? DepartmentLocations { get; set; }
        public List<project>? Projects { get; set; }

      

      
       

    }
}
