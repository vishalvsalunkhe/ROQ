using ROQ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROQ.Admin.Controllers
{
    public class HomeController : Controller
    {
        IUserService _IUserService;

        public HomeController(IUserService iUserService)
        {
            _IUserService = iUserService;
        }
        public ActionResult Index()
        {
            var users = _IUserService.GetUserByID(1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}