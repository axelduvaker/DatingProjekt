using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLager.Repositories;
using DatingProjekt.Models;
using DataLager;

namespace DatingProjekt.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly VänRepository _vänRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
            _vänRepository = new VänRepository();
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

        public ActionResult VisaProfil(string visitUser)
        {
            var userRepository = new UserRepository();
            var visitingUser = userRepository.GetUser(visitUser);

            var ärVänner = VänRepository.kollaOmVänner(User.Identity.Name, visitUser);

            var visitModel = new VisitModel()
            {
                Förnamn = visitingUser.Förnamn,
                Efternamn = visitingUser.Efternamn,
                Användarnamn = visitingUser.Användarnamn,
                Ålder = visitingUser.Ålder,
                Kön = visitingUser.Kön,
                Beskrivning = visitingUser.Beskrivning,
                IntresseradAvHane = visitingUser.IntresseradAvHane,
                IntresseradAvHona = visitingUser.IntresseradAvHona,
                Profilbild = visitingUser.Profilbild,
                NuvarandeVän = ärVänner
            };

            return View(visitModel);
        }

        public ActionResult allaVänner()
        {
            var användarnamn = User.Identity.Name;

            var model = new VänModel()
            {
                ListaVänner = new List<Änder>()
            };

            var allavänner = VänRepository.AllaVänner(_userRepository.GetUser(användarnamn));

            foreach (var vänner in allavänner)
            {
                model.ListaVänner.Add(vänner);
            }
            return View(model);
        }
        public ActionResult VänFörfrågan()
        {
            var model = new VänförfråganModel();

            model.Förfrågningar =
                _vänRepository.AktivaFörfrågningar(_userRepository.HamtaAnd(User.Identity.Name));
            return View(model);
        }

        public ActionResult SkickaFörfrågan(string skickande, string mottagande)
        {
            var skickandeAnd = new Änder();
            var mottagandeAnd = new Änder();
            skickandeAnd = _userRepository.HamtaAnd(skickande);
            mottagandeAnd = _userRepository.HamtaAnd(mottagande);

            _vänRepository.VänFörfrågan(skickandeAnd, mottagandeAnd);

            return RedirectToAction("VänFörfrågan");

        }
        public ActionResult AccepteraFörfrågan(int skickande, int mottagande)
        {
                _vänRepository.SvaraFörfrågan(skickande, mottagande, true);
            
            return RedirectToAction("VänFörfrågan");
        }

        public ActionResult NekaFörfrågan(int skickande, int mottagande)
        {
                _vänRepository.SvaraFörfrågan(skickande, mottagande, false);
         
            return RedirectToAction("VänFörfrågan");
        }
        public PartialViewResult antalVänFörfrågningar()
        {
            var model = new AntalFörfrågningarModel();
            var friendReqRepository = new VänRepository();
            var user = new Änder();

            using (var userRepo = new UserRepository())
            {
                user = userRepo.HamtaAnd(User.Identity.Name);
            }
            model.antalFörfrågningar = friendReqRepository.AktivaFörfrågningar(user).Count;
            return PartialView(model);
        }
    }
}