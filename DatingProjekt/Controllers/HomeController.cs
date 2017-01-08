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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
             //Om felaktig input, returnera view
            model.ErrorMessage = null;
            if (!ModelState.IsValid) return View();
            var Användarnamn = model.Användarnamn;
            var Lösenord = model.Lösenord;

            var userexists = _userRepository.UserExists(Användarnamn);
            var lösenexists = _userRepository.PassWordExists(Lösenord);
            if (!userexists || !lösenexists)
            {
                model.ErrorMessage = "Fel Användarnamn eller lösenord.";
                return View(model);
            }

            else {
                var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, model.Användarnamn)
            },
                "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);
                

                    FormsAuthentication.SetAuthCookie(model.Användarnamn, false);
                return RedirectToAction("Profile", "Profile");
            }
            //var inloggande = _userRepository.LoginUser(Användarnamn, Lösenord);
            //if (inloggande == null)
            //{
            //    model.ErrorMessage = "Fel Användarnamn eller lösenord."; 
            //    return View(model);
            //}
            //FormsAuthentication.SetAuthCookie(inloggande.Användarnamn, false);
            //return RedirectToAction("listaAlla", "User");

        }
        public ActionResult LoggaUt()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }
    }
}