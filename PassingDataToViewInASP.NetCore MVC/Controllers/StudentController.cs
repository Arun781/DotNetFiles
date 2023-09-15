using Microsoft.AspNetCore.Mvc;
using PassingDataToViewInASP.NetCore_MVC.Models;

namespace PassingDataToViewInASP.NetCore_MVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List() { return View(); }


        IStudentRepository _studentRepository;
        public ViewResult Details()
        {
            Students model = _studentRepository.GetStudentById(1);

            // Pass PageTitle and Employee model to the View using ViewData
            ViewData["PageTitle"] = "Employee Details";
            ViewData["student"] = model;

            return View();
        }
        public IActionResult Edit() { return View(); }
    }
}
