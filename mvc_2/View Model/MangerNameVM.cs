using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2.Models;

namespace MVC2.View_Model
{
    public class MangerNameVM
    {
        public SelectList empmanager;
        public int Number { get; set; }
        public string? Name { get; set; }
        public int? mngrSSN { get; set; }
        public string? Fname { get; set; }

        public virtual employee? employeeManege { get; set; }
        // public SelectList manager { get; set; }

    }
}
