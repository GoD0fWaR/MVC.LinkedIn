﻿using Microsoft.AspNet.Identity.Owin;
using ITI.LinkedIn.Core;
using ITI.LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.LinkedIn.Web.Controllers
{
    public class HomeController : Controller
    {
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}