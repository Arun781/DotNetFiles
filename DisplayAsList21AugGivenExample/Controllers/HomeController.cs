using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DisplayAsList21AugGivenExample.Models;
using DisplayAsList21AugGivenExample.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DisplayAsList21AugGivenExample.Controllers
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
			//var students = _studentRepository.GetAllStudents();
			//return View(students);
			List<Students> stuList = _studentRepository.GetAllStudents().ToList();
			return View(stuList);
		}
		public ViewResult Details()
		{
			// Instantiate HomeDetailsViewModel and store Employee details and PageTitle
			StudentViewModel studentViewModel = new StudentViewModel()
			{
				students = _studentRepository.GetStudentById(1),
				pageTitle = "Student Details"
			};

			// Pass the ViewModel object to the View() helper method
			return View(studentViewModel);
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