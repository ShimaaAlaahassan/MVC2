using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;

using MVC2.View_Model;

namespace MVC2.Controllers
{
    public class DepartmentController : Controller
    {

        MVC_DemoDbContext db;
        public DepartmentController()
        {
            db = new MVC_DemoDbContext() ;
        }
        //to display all department
        public IActionResult Index()
        {
            List<Department> departments = db.departments.Include(s => s.DepartmentLocations).ToList();

            return View(departments);
        }
        public IActionResult Details(int id)
        {
            Department department = db.departments.Include(s => s.EmpManage).SingleOrDefault(t => t.Number == id);
            MangerNameVM vM = new MangerNameVM();
            vM.Name = department.Name;
            vM.mngrSSN = department.emp_m;
            return View(vM);
        }
        public IActionResult Add()
        {
            List<employee> empmanager = db.employees.Include(s => s.deptManage).ToList();
            ViewBag.empMan = new SelectList(empmanager, "SSN", "FirstName");
            return View();
        }
        public IActionResult AddToDb(Department department)
        {
            db.departments.Add(department);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {

            List<employee> employees = db.employees.ToList();
            ViewBag.manager = employees;
            Department dept = db.departments.SingleOrDefault(s => s.Number == id);
            return View(dept);

        }
        public IActionResult SaveEdit(Department department)
        {
            Department olddept = db.departments.FirstOrDefault(s => s.Number == department.Number);
            olddept.Name = department.Name;
            olddept.DepartmentLocations = department.DepartmentLocations;
            olddept.emp_m = department.emp_m;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult GetDepartmentByMgrId(int id)
        {
            Department department = db.departments.Include(d => d.DepartmentLocations).Include(d => d.Projects).SingleOrDefault(d => d.emp_m == id);
            if (department == null)
                return View("Error");
            else
                return View("GetDepartmentByMgrId", department);

        }
    }
}

