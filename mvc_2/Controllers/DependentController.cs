using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class DependentController : Controller
    {
        private MVC_DemoDbContext dbContext;
        public DependentController()
        {
            dbContext = new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<Dependent> dependents = dbContext.dependents.ToList();
            return View(dependents);
        }

        public IActionResult GetById(int id)

        {
           // List<Dependent> dependents = dbContext.dependents.Where(e => e.ESSN == HttpContext.Session.GetInt32("SSN")).ToList();
              //  return View("GetById", dependents);
            //{
            Dependent? dependent = dbContext.dependents.SingleOrDefault(e => e.ESSN == HttpContext.Session.GetInt32("SSN"));
            if (dependent == null)
            {
                return View("Error");
            }
            return View(dependent);



        }

            public IActionResult Add()
        {
             List<Dependent> dependents = dbContext.dependents.ToList();
           
            return View(dependents);
        }

        public IActionResult AddemployeeDb(Dependent dependent)
        {
            dbContext.dependents.Add(dependent);
            dbContext.SaveChanges();

            List<Dependent> dependents = dbContext.dependents.ToList();
            return View("index", dependents);
        }

        public IActionResult Edit(int id)
        {
            Dependent dependent = dbContext.dependents.SingleOrDefault(e => e.id == id);
            List<Dependent> dependents = dbContext.dependents.ToList();
            ViewBag.ins = dependents;
            return View(dependent);
        }

        public IActionResult EditempoloyeeDb(Dependent dependent)
        {
           Dependent dependent1 = dbContext.dependents.SingleOrDefault(e => e.id == dependent.id);
            dependent1.Name = dependent.Name;
            dependent1.Sex = dependent.Sex;
            dependent1.BirthDate = dependent.BirthDate;
            dependent1.Relationship = dependent.Relationship;

            //  employee1.BirthDate = employee1.BirthDate;
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Dependent dependent = dbContext.dependents.SingleOrDefault(e => e.id == id);
            dbContext.dependents.Remove(dependent);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
