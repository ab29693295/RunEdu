﻿using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunEdu.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult Right()
        {
            return View();
        }
        public ActionResult GetLeft()
        {

        
                return PartialView("_Left", null);
            
        }
    }
}