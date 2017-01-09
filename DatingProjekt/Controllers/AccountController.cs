using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using DatingProjekt.Models;
using DataLager.Repositories;
using DataLager;
using System.Web.Security;

namespace DatingProjekt.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccountController()
        {
            _userRepository = new UserRepository();
        }

        public ActionResult Index()
        {
            var model = new HomeModel();
            {
                model.RandomProfiler = _userRepository.RandomProfiler(); //Den här genererar några exempelanvändare.
            }
            return View(model);
        }
        
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistrationModel model)
        {
            
            if (!ModelState.IsValid) return View(); //Om felaktig input, returnera view
            try
            {
                var and = new Änder()
                {
                    Förnamn = model.Förnamn,
                    Efternamn = model.Efternamn,
                    Kön = model.Kön,
                    Ålder = model.Ålder,
                    Lösenord = model.Lösenord,
                    Användarnamn = model.Användarnamn,
                    Profilbild = "default.jpg",
                    Beskrivning = model.Beskrivning,
                    IntresseradAvHane = model.IntresseradAvHane,
                    IntresseradAvHona = model.IntresseradAvHona,
                    Aktiv = true,
                    Allmän = true,

                };
                if (!_userRepository.kollaOmUnikt(and.Användarnamn))
                {
                    model.ErrorMessage = "Användarnamnet måste vara unikt!";
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(model.Användarnamn, false);
                _userRepository.läggTillAnvändare(and);
                return RedirectToAction("Login", "Account");
            }
            catch(Exception e)
            {
                return View(e);
            }
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
            model.ErrorMessage = null;
            if (!ModelState.IsValid) return View(); //Om felaktig input, returnera view
                var Användarnamn = model.Användarnamn;
                var Lösenord = model.Lösenord;
                var ErrorMessage = model.ErrorMessage;

                var inloggande = _userRepository.loggaIn(Användarnamn, Lösenord);

                var userexists = _userRepository.användareFinns(Användarnamn);
                var lösenexists = _userRepository.finnsLösen(Lösenord);
            try
            {
                if (!userexists || !lösenexists)
                {
                    model.ErrorMessage = "Felaktigt användarnamn eller lösenord.";
                    return View(model);
                }

                else
                {
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
            }
            catch(Exception e)
            {
                return View(e);
            }
        }

        [HttpPost]
        public JsonResult uniktNamn(Änder and)
        {
            if (!_userRepository.kollaOmUnikt(and.Användarnamn))
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        public ActionResult LoggaUt()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie"); //Loggar ut från cookien, så att användaren inte är inloggad där med heller.
            return RedirectToAction("Login", "Account");
        }
    }
}