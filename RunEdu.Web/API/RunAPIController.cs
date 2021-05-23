using Edu.Entity;
using Edu.Model;
using Edu.Model.WeiXin;
using Edu.Service;
using Edu.Service.Service;
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
        public IHttpActionResult CountPoint()
        {
            try
            {
                Stream postData = HttpContext.Current.Request.InputStream;
                StreamReader sRead = new StreamReader(postData);
                string postContent = sRead.ReadToEnd();
                sRead.Close();

                Edu.Tools.LogHelper.Info(postContent);

                List<Points> runModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Points>>(postContent);
                double Dis = 0;

                if (runModel != null && runModel.Count() > 1)
                {
                    for (int i = 0; i < runModel.Count() - 1; i++)
                    {

                        Edu.Tools.LogHelper.Info("开始计算");
                        double d = RunHelper.GetDistance(runModel[i].latitude, runModel[i].longitude, runModel[i + 1].latitude, runModel[i + 1].longitude);

                        Edu.Tools.LogHelper.Info("距离:"+d.ToString());

                        long FTime = runModel[i].pointTimestamp;
                        long STime = runModel[i+1].pointTimestamp;

                        double cha = (STime - FTime) / 1000;

                        double speed = (d  / cha);

                        Edu.Tools.LogHelper.Info("速度:" + speed.ToString());

                        if (speed < 0.5 || speed > 7)
                        {

                        }
                        else
                        {
                            Dis = Dis + d;
                        }


                    }
                    return Json(new { R = true, Data = (Dis/1000).ToString("0.000") });
                }
                else
                {
                    return Json(new { R = true, Data = 0 });
                }

            }
            catch (Exception ex)
            {
                Edu.Tools.LogHelper.Info(ex.ToString());

                return Json(new { R = true, Data = 0 });
            }




        }

      

        /// <summary>
        /// 按照个人查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetRank(int DayCount)
        {
            try {
                string sql = @"SELECT @rownum:= @rownum + 1 as RankID,SUM(Totalkm) as Totalkm,B.NickName,b.HeadPhoto,C.TeamName from(select @rownum:= 0) d,running as A ,userinfo as B,team as C  WHERE  DATE_SUB(CURDATE(), INTERVAL " + DayCount.ToString() + " DAY) <= date(A.CreateDate) and A.TeamID = C.ID GROUP BY WXUserID ";

                var Data = unitOfWork.context.Database.SqlQuery<RankModel>(sql);

                return Json(new { R = true, Data = Data });
                
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());


                return Json(new { R = false, Data = "" });
            }
        }

        /// <summary>
        /// 按团队排行
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetTeamRank(int DayCount,int TeamID)
        {
            try
            {
                string Sql = "SELECT SUM(Totalkm) as Totalkm,B.NickName,B.HeadPhoto,B.Sex,C.TeamName from running as A ,userinfo as B,team as C  WHERE A.WXUserID=B.WxID AND A.TeamID=C.ID AND C.ID="+TeamID.ToString()+" AND  DATE_SUB(CURDATE(), INTERVAL "+DayCount.ToString()+" DAY) <= date(A.CreateDate)  GROUP BY A.WXUserID  ORDER BY Totalkm DESC";

                var Data = unitOfWork.context.Database.SqlQuery<TeamRunModel>(Sql);

                return Json(new { R = true, Data = Data });
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());


                return Json(new { R = false, Data = "" });
            }
          
        }
        /// <summary>
        /// 获取跑步详情
        /// </summary>
        /// <param name="WxUserID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetRunDetail(int ID)
        {
            var run = unitOfWork.DRunning.GetByID(ID);


            return Json(new { R = true, Data = run });
        }

        /// <summary>
        /// 获取当日数据列表
        /// </summary>
        /// <param name="WxUserID"></param>
        /// <returns></returns>
        [HttpGet]

        public IHttpActionResult GetTodayRunList(string WxUserID)
        {
            
           var runList = unitOfWork.DRunning.Get(p => p.WXUserID == WxUserID).OrderByDescending(p=>p.ID).Take(30);

          
           return Json(new { R = true, Data = runList });

        }

        [HttpGet]
        public IHttpActionResult GetHistoryRun()
        {
            return Json(new { R = true, Data = "" });
        }

        /// <summary>
        /// 获取个人总数据
        /// </summary>
        /// <param name="WxUserID"></param>
        /// <returns></returns>
        [HttpGet]


        public IHttpActionResult GetPersonTotalRUn(string WxUserID)
        {
           


      
            var runList = unitOfWork.DRunning.Get(p =>p.WXUserID == WxUserID);

            double minSpeedA = 100;
            double minSpeedB = 100;

            if (runList != null && runList.Count() > 0)
            {
                TodayRunModel tM = new TodayRunModel();

                decimal TotalKm = 0;

                int totalSeconds = 0;

                double totalHeat = 0;

                int totalPointscore = 0;

                int totalRunscore = 0;

                foreach (var item in runList)
                {
                    TotalKm = TotalKm + Convert.ToDecimal(item.Totalkm);

                    totalSeconds = totalSeconds + Convert.ToDateTime(item.TotalTime).Hour * 3600 + Convert.ToDateTime(item.TotalTime).Minute * 60;

                    totalHeat = totalHeat + Convert.ToDouble(item.BurnHeat);

                    minSpeedA = Convert.ToDouble(item.Speed);

                    if (minSpeedB > minSpeedA)
                    {
                        minSpeedB = minSpeedA;
                    }

                    totalPointscore = totalPointscore + Convert.ToInt32(item.PointScore);
                    totalRunscore = totalRunscore + Convert.ToInt32(item.RunScore);
                }

                tM.MinSpeed = minSpeedB.ToString();
                tM.TotalKM = TotalKm;
                tM.TotalHeat = Math.Round(totalHeat, 1); 
                tM.RunDate = DateTime.Now.ToString("yyyy.MM.dd");
                tM.TotalTime = TimeHelper.TransTimeSecondIntToString(totalSeconds);
                tM.PointScore = totalPointscore;
                tM.RunScore = totalRunscore;
                return Json(new { R = true, Data = tM });
            }
            else
            {
                return Json(new { R = false, Data = "" });
            }


        }


        /// <summary>
        /// 获取当日数据
        /// </summary>
        /// <param name="WxUserID"></param>
        /// <returns></returns>
        [HttpGet]


        public IHttpActionResult GetTodayRUn(string WxUserID)
        {
            string time = DateTime.Now.ToShortDateString();


            DateTime time1 = Convert.ToDateTime(time + " 0:00:00");  // 数字前 记得 加空格


            DateTime time2 = Convert.ToDateTime(time + " 23:59:59");

            var runList = unitOfWork.DRunning.Get(p => p.CreateDate > time1 && p.CreateDate < time2 && p.WXUserID == WxUserID);

            double minSpeedA = 100;
            double minSpeedB = 100;

            if (runList != null && runList.Count() > 0)
            {
                TodayRunModel tM = new TodayRunModel();

                decimal TotalKm = 0;

                int totalSeconds = 0;

                double totalHeat = 0;

                int totalPointscore = 0;

                int totalRunscore = 0;

                foreach (var item in runList)
                {
                    TotalKm = TotalKm + Convert.ToDecimal(item.Totalkm);

                    totalSeconds = totalSeconds + Convert.ToDateTime(item.TotalTime).Hour * 3600 + Convert.ToDateTime(item.TotalTime).Minute * 60;

                    totalHeat = totalHeat + Convert.ToDouble(item.BurnHeat);

                    minSpeedA = Convert.ToDouble(item.Speed);

                    if (minSpeedB > minSpeedA)
                    {
                        minSpeedB = minSpeedA;
                    }

                    totalPointscore = totalPointscore + Convert.ToInt32(item.PointScore);
                    totalRunscore = totalRunscore + Convert.ToInt32(item.RunScore);
                }

                tM.MinSpeed = minSpeedB.ToString();
                tM.TotalKM = TotalKm;
                tM.TotalHeat = Math.Round(totalHeat, 1); ;
                tM.RunDate = DateTime.Now.ToString("yyyy.MM.dd");
                tM.TotalTime = TimeHelper.TransTimeSecondIntToString(totalSeconds);
                tM.PointScore = totalPointscore;
                tM.RunScore = totalRunscore;
                return Json(new { R = true, Data = tM });
            }
            else
            {
                return Json(new { R = false, Data = "" });
            }


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

                    int time = Convert.ToInt32(h*60 + m);

                    runModel.Speed = Convert.ToDouble(time / Km);
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
