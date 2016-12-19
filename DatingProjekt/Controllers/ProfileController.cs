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

        // GET: Profile
        public ActionResult Index(string förnamn)
        {
            var user = _userRepository.Get(förnamn);
            var and = new And
            {
                AndId = user.id,
                Förnamn = user.Förnamn
            };
            return View(and);
        }
        
    }
}