using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingProjekt.Controllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        [HttpPost]
        public ActionResult UserPicture(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                    Server.MapPath("~content/images"), pic);

                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}