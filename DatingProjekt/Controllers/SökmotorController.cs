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
            //Hämtar användaren. 
            try {
                var model = new SökmotorModel();

                using (var sökmotorRepository = new SökmotorRepository())
                {
                    model.HittadAnd = sökmotorRepository.sökMedAndNamn(sökText);
                }
                model.SökText = "";

                return View(model);
            }
            catch(Exception e)
            {
                return View(e);
            }
            }

        [HttpPost]
        public ActionResult Sökmotor(SökmotorModel model)
        {
            //Visar användaren.
            try
            {
                var söktext = model.SökText;
                var sökResultatModel = new SökmotorModel();

                using (var sökmotorRepository = new SökmotorRepository())
                {
                    sökResultatModel.HittadAnd = sökmotorRepository.sökMedAndNamn(söktext);
                }

                return View(sökResultatModel);
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}