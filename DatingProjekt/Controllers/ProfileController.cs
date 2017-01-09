using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatingProjekt.Models;
using DataLager.Repositories;

namespace DatingProjekt.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserRepository _userRepository;
        public ProfileController()
        {
            _userRepository = new UserRepository();
        }

        //GET: Profile
        public ActionResult Profile(LoginModel model)
        {
            try
            {
                var namn = User.Identity.Name;
                var user = _userRepository.HamtaAnd(namn);
                if (user == null) return View();
                var and = new And
                {
                    Användarnamn = user.Användarnamn,
                    AndId = user.id,
                    Förnamn = user.Förnamn,
                    Efternamn = user.Efternamn,
                    Kön = user.Kön,
                    Ålder = user.Ålder,
                    Profilbild = user.Profilbild,
                    Beskrivning = user.Beskrivning,
                    IntresseradAvHane = user.IntresseradAvHane,
                    IntresseradAvHona = user.IntresseradAvHona,
                };
                return View(and);
            }
            catch(Exception e)
            {
                return View(e);
            }
        }
    }
}