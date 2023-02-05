using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;


namespace MVC2.Controllers
{
    public class workOnController : Controller
    {
        private MVC_DemoDbContext db;
        public workOnController()
        {
            db = new MVC_DemoDbContext();
        }

        public IActionResult AddEmployeesToProjects(int id)
        {
            List<project> projects = db.projects.Where(p => p.DeptNum == id).ToList();
            List<employee> employees = db.employees.Where(p => p.deptId_w == id).ToList();

            ViewBag.emps = employees;

            return View(projects);
        }

        workOn worksOnProject1;
        public IActionResult AddEmployeesToProjectsToDB(List<int> Projects, List<int> Employees)
        {

            foreach (var project in Projects)
            {
                foreach (var employee in Employees)
                {
                    workOn worksOnProject = new workOn()
                    {
                        ESSN = employee,
                        projectNum = project
                    };
                    worksOnProject1 = db.workOns.Include(wop => wop.Project).SingleOrDefault(wop => wop.ESSN == worksOnProject.ESSN);
                    db.workOns.Add(worksOnProject);
                    db.SaveChanges();
                }

            }

            ViewBag.emps = Employees;
            ViewBag.mgrSSN = (int)HttpContext.Session.GetInt32("SSN");

            return View(worksOnProject1);
        }

        public IActionResult EditEmployeeHour()
        {
            List<employee> employees = db.employees.ToList();
            ViewBag.employees = new SelectList(employees, "SSN", "FirstName");
            return View();
        }

        public IActionResult EditEmployeeHour_emp(int id)
        {
            List<project>? projects = db.workOns.Include(wop => wop.Project).Where(wop => wop.ESSN == id).Select(wop => wop.Project).ToList();
            ViewBag.projects = new SelectList(projects, "Number", "Name");
            if (projects.Count > 0)
            {
                workOn worksOnProject = new workOn()
                {
                    Hours = db.workOns.SingleOrDefault(wop => (wop.ESSN == id) && (wop.projectNum == projects[0].Number)).Hours
                };
                return PartialView("_ProjectsList", worksOnProject);
            }
            return PartialView("_ProjectsList");
        }

        public IActionResult EditEmployeeHour_emp_proj(int id, int projNum)
        {
            workOn? worksOnProject = db.workOns.SingleOrDefault(wop => wop.ESSN == id && wop.projectNum == projNum);
         
            return PartialView("_hour", worksOnProject);
        }

        public IActionResult EditEmployeeHourDb(workOn worksOnProject)
        {
            db.workOns.Update(worksOnProject);
            db.SaveChanges();
            return View();
        }


    }

}

