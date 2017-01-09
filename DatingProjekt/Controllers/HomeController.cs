using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLager.Repositories;
using System.Web.Routing;
using DatingProjekt.Models;
using System.Web.Security;
using System.Security.Claims;

namespace DatingProjekt.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;

        public HomeController()
        {
            _userRepository = new UserRepository();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = new HomeModel();
            {
                model.RandomProfiler = _userRepository.RandomProfiler();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult UppdateraAnd()
        {
            ViewBag.Message = "Dina inställningar.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Registrera()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}