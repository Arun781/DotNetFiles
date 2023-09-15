using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;

namespace CaptchMvcTstPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string empty)
        {
            // Code for validating the CAPTCHA  
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                return RedirectToAction("ThankYouPage");
            }
            ViewBag.ErrMessage = "Error: captcha is not valid.";
            return View();
        }

        public ActionResult ThankYouPage()
        {return View();}
    }
}
