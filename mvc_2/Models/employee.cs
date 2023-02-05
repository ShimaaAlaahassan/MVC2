using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class employee
    {

        [Key]
        public int SSN { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "money")]
        public int? Salary { get; set; }
        public List<workOn>? WorksOnProjects { get; set; }

        public List<Dependent>? Dependents { get; set; }

        public employee? SuperVisor { get; set; }

        public List<employee>? Employees { get; set; }

        [ForeignKey("deptWork")]
        public int? deptId_w { get; set; }
       
       

        public virtual Department? deptWork { get; set; }
        public virtual Department? deptManage { get; set; }

    }
}
