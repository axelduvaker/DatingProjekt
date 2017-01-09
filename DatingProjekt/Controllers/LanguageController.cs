using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
namespace DatingProjekt.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }
        //Den här metoden ändrar språket genom att lagra det i en cookie.
        public ActionResult Change(String LanguageAbbrevation)
        {
            try
            {
                if (LanguageAbbrevation != null)
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
                }
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = LanguageAbbrevation;
                Response.Cookies.Add(cookie);
                return View("Index");
            }
            catch(Exception e)
            {
                return View(e);
            }
        }
    }
}