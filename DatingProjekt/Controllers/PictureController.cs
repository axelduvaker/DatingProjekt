using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLager.Repositories;

namespace DatingProjekt.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        [HttpPost]
        public ActionResult UserPicture(HttpPostedFileBase file)
        {
            try {
                if (file != null && file.ContentLength > 0)
                {
                    var filename = Path.GetFileName(file.FileName); //Använder Path för att hitta filen.
                    var pathname = Path.Combine(Server.MapPath("~/Content/Images"), filename); //Sparar filen i mappen Images.
                    file.SaveAs(pathname);


                    PictureRepository.UploadPicture(User.Identity.Name, filename);


                }
                return RedirectToAction("Profile", "Profile");
            }
            catch(Exception e)
            {
                return View(e);
            }
            }
    }
}