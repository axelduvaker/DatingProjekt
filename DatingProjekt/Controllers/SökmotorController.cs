using DatingProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLager.Repositories;

namespace DatingProjekt.Controllers
{
    public class SökmotorController : Controller
    {
        [HttpGet]
        public ActionResult Sökmotor(string sökText)
        {
            var model = new SökmotorModel();

            using (var sökmotorRepository = new SökmotorRepository())
            {
                model.HittadAnd = sökmotorRepository.sökMedAndNamn(sökText);
            }
            model.SökText = "";

            return View(model);
        }

        [HttpPost]
        public ActionResult Sökmotor(SökmotorModel model)
        {
            var söktext = model.SökText;
            var sökResultatModel = new SökmotorModel();

            using (var sökmotorRepository = new SökmotorRepository())
            {
                sökResultatModel.HittadAnd = sökmotorRepository.sökMedAndNamn(söktext);
            }

            return View(sökResultatModel);
        }
    }
}