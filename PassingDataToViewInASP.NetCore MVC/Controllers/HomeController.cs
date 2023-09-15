using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PassingDataToViewInASP.NetCore_MVC.Models;
using System.Diagnostics;

namespace PassingDataToViewInASP.NetCore_MVC.Controllers
{
    public class HomeController : Controller
    {
        private IStudentRepository _studentRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = new MockStudentRepository();
        }

        // Retrieve employee name and return
        public IActionResult Index()
        {
            Students stu = new Students() { Id = 1, Name = "Scott", Address = "HYD" };
            ViewBag.stud = stu;
            return View(stu);
        }
        public ViewResult Details()
        {
            Students stumodel = _studentRepository.GetStudentById(1);

            // Pass PageTitle and Employee model to the View using ViewData
            ViewBag["PageTitle"] = "Students Details";
            // ViewData["student"] = model;

            return View(stumodel);
        }
        //JSONResult 
        public JsonResult Details1()
        {
            Students model = _studentRepository.GetStudentById(1);
            return Json(model);
        }
        //Controller returns objectresult
        public ObjectResult Details2()
        {
            Students model = _studentRepository.GetStudentById(1);
            return new ObjectResult(model);
        }
        //controller returns View
        public ViewResult Details3()
        {
            Students model = _studentRepository.GetStudentById(1);
            return View(model);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}