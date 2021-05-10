using Edu.Entity;
using Edu.Service;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Edu.Web.API
{
    public class RunAPIController : BaseAPIController
    {
        [HttpPost]
        public IHttpActionResult ModyRun()
        {
            try
            {
                Stream postData = HttpContext.Current.Request.InputStream;
                StreamReader sRead = new StreamReader(postData);
                string postContent = sRead.ReadToEnd();
                sRead.Close();
                //JSONHelper.ObjectToJson(postContent);
                //AddLive aLive= JSONHelper.Deserialize<AddLive>(postContent);
                Running runModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Running>(postContent);


                runModel.CreateDate = DateTime.Now;


                unitOfWork.DRunning.Insert(runModel);

                unitOfWork.Save();


                return Json(new { R = true, M = "用户信息完善成功！" });
            }
            catch (Exception ex)
            {

                LogHelper.Info(ex.ToString());
                return Json(new { R = false, M = "用户信息完善失败！" });
            }
        }
    }
}
