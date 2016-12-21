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
        //public ActionResult Index(LoginViewModel model)
        //{
        //    var user = _userRepository.Get(förnamn);
        //    var and = new And
        //    {
        //        AndId = model.id,
        //        Förnamn = model.Förnamn
        //    };
        //    return View(and);
        //}
        
    }
}