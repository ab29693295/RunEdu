using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunEdu.Web.Controllers
{
    public class TestController : BaseControl
    {
        // GET: Test
        public ActionResult Index()
        {
           int a= Convert.ToInt32(100 * 0.035);
            Edu.Tools.LogHelper.Info("我想看看有没有日志！");
            return View();
        }
    }
}