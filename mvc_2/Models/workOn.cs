using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class workOn
    {
        public int Hours { get; set; }

        [ForeignKey("employee")]
        public int ESSN { get; set; }
        public employee? employee { get; set; }

        [ForeignKey("project")]
        public int projectNum { get; set; }
        public project? Project { get; set; }
    }
}
