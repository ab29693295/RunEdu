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
            //[{"latitude":40.04769515991211,"longitude":116.35626983642578,"pointTimestamp":1621754514000},{"latitude":40.04769515991211,"longitude":116.35626983642578,"pointTimestamp":1621754516000},{"latitude":40.04769515991211,"longitude":116.3563003540039,"pointTimestamp":1621754518000},{"latitude":40.047691345214844,"longitude":116.35630798339844,"pointTimestamp":1621754520000},{"latitude":40.04768371582031,"longitude":116.35631561279297,"pointTimestamp":1621754522000},{"latitude":40.04768371582031,"longitude":116.35631561279297,"pointTimestamp":1621754524000},{"latitude":40.04768371582031,"longitude":116.35631561279297,"pointTimestamp":1621754526000},{"latitude":40.04768371582031,"longitude":116.35631561279297,"pointTimestamp":1621754528000},{"latitude":40.04768371582031,"longitude":116.35631561279297,"pointTimestamp":1621754530000},{"latitude":40.04768371582031,"longitude":116.35631561279297,"pointTimestamp":1621754532000}] 
            double d = RunHelper.GetDistance(40.04769515991211, 116.35626983642578, 40.04769515991211, 116.3563003540039);

            long FTime = 1621754516000;
            long STime = 1621754518000;

            double cha = (STime - FTime) / 1000;

            double speed = (d  / cha);

           

            if (speed < 0.5 || speed > 7)
            {

            }

            var user = unitOfWork.DUserInfo.GetAll();
            string a = user.FirstOrDefault().UserName;
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