﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingProjekt.Controllers
{
    public class MeddelandeController : Controller
    {
        // GET: Meddelande
        public ActionResult Index()
        {
            return View();
        }
    }
}