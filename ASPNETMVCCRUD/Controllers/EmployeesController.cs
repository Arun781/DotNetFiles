using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using ASPNETMVCCRUD.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcDemoDbContext _Context;
        public EmployeesController(MvcDemoDbContext demo)
        {
            _Context = demo;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel req)
        {
            var emp = new Employee()
            {
                Name = req.Name,
                Email = req.Email,
                DateOfBirth = req.DateOfBirth,
                Salary = req.Salary,
                Department = req.Department
            };
            await _Context.employees.AddAsync(emp);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid sid)
        {
            var emp = await _Context.employees.FirstOrDefaultAsync(x => x.Id == sid);

            if (emp != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Name = emp.Name,
                    Salary = emp.Salary,
                    Email = emp.Email,
                    DateOfBirth = emp.DateOfBirth,
                    Department = emp.Department
                };

                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> emps = _Context.employees.ToList();
            return View(emps);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var emp = await _Context.employees.FindAsync(model.id);
            if (emp != null)
            {
                _Context.employees.Remove(emp);
                await _Context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


    }
}
