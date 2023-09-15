using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayAsList21AugGivenExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisplayAsList21AugGivenExample.Controllers
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
