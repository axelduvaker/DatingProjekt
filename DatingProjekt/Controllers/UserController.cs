using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLager.Repositories;
using DatingProjekt.Models;

namespace DatingProjekt.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public IEnumerable<And> Get()
        {
            var users = _userRepository.GetAll();
            return users.Select(x => new And
            {
                AndId = x.id,
                Förnamn = x.Förnamn
            });
        }

        [AllowAnonymous]
        public ActionResult listaAlla()
        {
            var hamtadeAnder = _userRepository.GetAll();
            var model = new AndViewModel
            {
                Ands = _userRepository.GetAll()
            };
            return View(model);
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}