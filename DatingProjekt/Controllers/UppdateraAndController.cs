using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProjekt.Models;
using DataLager.Repositories;
using System.Web.Security;
using System.IO;

namespace DatingProjekt.Controllers
{
    [Authorize]
    public class UppdateraAndController : System.Web.Mvc.Controller
    {
        private readonly UserRepository _userRepository;

        public UppdateraAndController()
        {
            _userRepository = new UserRepository();
        }
        [HttpGet]
        public ActionResult UppdateraAnd()
        {
            if (!ModelState.IsValid) return View();

            var user = new DataLager.Änder();
            user = _userRepository.GetUser(User.Identity.Name);


            var model = new UppdateraAndModel()
            {
                Förnamn = user.Förnamn,
                Efternamn = user.Efternamn,
                Ålder = user.Ålder,
                Beskrivning = user.Beskrivning,
                Aktiv = true,
                Allmän = true,
                IntresseradAvHane = user.IntresseradAvHane,
                IntresseradAvHona = user.IntresseradAvHona
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UppdateraAnd(UppdateraAndModel model)
        {
            if (!ModelState.IsValid) return View(); //Om felaktig input, returnera view


            var aktivAnd = new DataLager.Änder();

            aktivAnd.Förnamn = model.Förnamn;
            aktivAnd.Efternamn = model.Efternamn;
            aktivAnd.Användarnamn = User.Identity.Name; 
            aktivAnd.Lösenord = model.Lösenord;
            aktivAnd.Beskrivning = model.Beskrivning;
            aktivAnd.Ålder = model.Ålder;
            aktivAnd.Kön = model.Kön;
            aktivAnd.IntresseradAvHane = model.IntresseradAvHane;
            aktivAnd.IntresseradAvHona = model.IntresseradAvHona;
            aktivAnd.Aktiv = model.Aktiv;
            aktivAnd.Allmän = model.Allmän;

            var currentUser = User.Identity.Name;
            
            var uppdateraAndRepository = new UppdateraAndRepository();
            uppdateraAndRepository.UpdateAnd(currentUser, aktivAnd);
            _userRepository.Save();

            return RedirectToAction("Profile", "Profile");
        }


    }
}
