using Edu.Model;
using Edu.Model.WeiXin;
using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunEdu.Web.Controllers
{
    public class HomeController : BaseControl
    {
        public ActionResult Index()
        {

           
           

            var user = unitOfWork.DUserInfo.GetAll();
          
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

        public ActionResult Test()
        {
            return View();
        }
    }
}