﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.Controllers
{
    [TypeAuthorization("Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }
    }
}