using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class employeeController : Controller
    {
        private MVC_DemoDbContext dbContext;
        public employeeController()
        {
            dbContext = new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<employee> employees = dbContext.employees.ToList();
            return View(employees);
        }

        public IActionResult GetById(int id)
        {
            employee? employee= dbContext.employees.SingleOrDefault(e => e.SSN == id);
            if (employee == null)
            {
                return View("Error"); // view : Error , model = null
            }
            return View(employee);  // view : GetById , model = course


            //return View();    // view : GetById , model = null
            //return View("GetOne", course);  // view : GetOne , model = Course
        }

        public IActionResult Add()
        {
            List<employee> employees = dbContext.employees.ToList();
            return View(employees);
        }

        public IActionResult AddemployeeDb(employee employee)
        {
            dbContext.employees.Add(employee);
            dbContext.SaveChanges();

            List<employee> employees = dbContext.employees.ToList();
            return View("index", employees);
        }

        public IActionResult Edit(int id)
        {
            employee employee = dbContext.employees.SingleOrDefault(e => e.SSN == id);
            List<employee> employees= dbContext.employees.ToList();
            ViewBag.ins = employees;
            return View(employee);
        }

        public IActionResult EditempoloyeeDb(employee employee)
        {
            employee employeee= dbContext.employees.SingleOrDefault(e =>e.SSN == employee.SSN);
            employeee.FirstName = employee.FirstName;
            employeee.MiddleName = employee.MiddleName;
            employeee.LastName = employee.LastName;
            employeee.Salary = employee.Salary;
           
          //  employee1.BirthDate = employee1.BirthDate;
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            employee employee = dbContext.employees.SingleOrDefault(e => e.SSN == id);
            dbContext.employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View("Login");

        }
        public IActionResult Check(employee emp)
        {
            employee e = dbContext.employees.Where(e => e.SSN == emp.SSN && e.FirstName == emp.FirstName).Single();
            if (e != null)
            {
                HttpContext.Session.SetInt32("SSN", e.SSN);
            }

            return RedirectToAction("Profile");
        }
        public IActionResult Profile()
        {
            employee emp = dbContext.employees.Where(e => e.SSN == HttpContext.Session.GetInt32("SSN")).Single();
            return View("Profile", emp);

        }


    }
}
