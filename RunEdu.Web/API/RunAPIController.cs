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
        /// <summary>
        /// 获取当日数据
        /// </summary>
        /// <param name="WxUserID"></param>
        /// <returns></returns>
        [HttpGet]

        
        public IHttpActionResult GetTodayRUn(int WxUserID)
        {
            string time = DateTime.Now.ToShortDateString();


            DateTime time1 = Convert.ToDateTime(time + " 0:00:00");  // 数字前 记得 加空格


            DateTime time2 = Convert.ToDateTime(time + " 23:59:59");

            var runList = unitOfWork.DRunning.Get(p => p.CreateDate > time1 && p.CreateDate < time2);

            int minSpeedA = 100;
            int minSpeedB = 100;

            if (runList != null && runList.Count() > 0)
            {
                foreach (var item in runList)
                {
                   
                }

            }

            return Json(new { R = true });
        }


        /// <summary>
        /// 添加跑步信息
        /// </summary>
        /// <returns></returns>
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

                var user = unitOfWork.DUserInfo.Get(p => p.WxID == runModel.WXUserID).FirstOrDefault();
                if (user != null && user.Weight != null)
                {
                    double weight = Convert.ToDouble(user.Weight);
                    double Km = Convert.ToDouble(runModel.Totalkm);

                    //runModel.BurnHeat = (weight * Km).ToString()+"K";

                    runModel.RunScore =Convert.ToInt32( 100 * Km);

                    runModel.TotalScore = runModel.RunScore+runModel.PointScore;

                    int h = Convert.ToDateTime(runModel.TotalTime).Hour;

                    int m = Convert.ToDateTime(runModel.TotalTime).Minute;

                    double time = Convert.ToDouble(h + "." + m);

                    runModel.Speed = Convert.ToDouble(Km/time);
                }

                runModel.CreateDate = DateTime.Now;


                unitOfWork.DRunning.Insert(runModel);

                unitOfWork.Save();


                return Json(new { R = true, M = "跑步信息添加成功！" });
            }
            catch (Exception ex)
            {

                LogHelper.Info(ex.ToString());
                return Json(new { R = false, M = "跑步信息添加失败！" });
            }
        }
    }
}
