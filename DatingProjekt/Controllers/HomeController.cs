using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLager.Repositories;
using System.Web.Routing;
using DatingProjekt.Models;
using System.Web.Security;

namespace DatingProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;

        public HomeController()
        {
            _userRepository = new UserRepository();
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.Message = "Dina inställningar.";

            return View();
        }
        public ActionResult Registrera()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
             //Om felaktig input, returnera view
            model.ErrorMessage = null;
            if (!ModelState.IsValid) return View();
            var Användarnamn = model.Användarnamn;
            var Lösenord = model.Lösenord;
            
            var userexists = _userRepository.UserExists(Användarnamn);
            var lösenexists = _userRepository.PassWordExists(Lösenord);
            if (userexists && lösenexists)
            {
                //FormsAuthentication.SetAuthCookie(Användarnamn, false);
                //Vid utloggning: FormsAuthentication.SignOut()
                return RedirectToAction("listaAlla", "User");
            }
            else
            {
                model.ErrorMessage = "Felaktigt användarnamn eller lösenord";
                return View(model);
            }

        }
    }
}