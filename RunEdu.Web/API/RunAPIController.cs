using Edu.Entity;
using Edu.Model;
using Edu.Model.WeiXin;
using Edu.Service;
using Edu.Service.Service;
using Edu.Tools;
using Newtonsoft.Json;
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
        [HttpGet]
        public IHttpActionResult GetHuoYue(int DayCount)
        {
            emphasis em = new emphasis();
            backgroundStyle bd = new backgroundStyle();

         
           HuoYueModel huating = new HuoYueModel();
            huating.name = "华庭队";
            huating.type = "bar";
            huating.label = "labelOption";
            huating.barGap = 0;
            em.focus = "series";
            huating.emphasis = em;
            bd.color = "#3BCEDEFF";
            huating.backgroundStyle = bd;



            HuoYueModel lanting = new HuoYueModel();
            lanting.name = "兰庭队";
            lanting.type = "bar";
            lanting.label = "labelOption";
          
            lanting.emphasis = em;
         

            HuoYueModel fengge = new HuoYueModel();
            fengge.name = "兰庭队";
            fengge.type = "bar";
            fengge.label = "labelOption";

            fengge.emphasis = em;

            HuoYueModel mingjun = new HuoYueModel();
            mingjun.name = "兰庭队";
            mingjun.type = "bar";
            mingjun.label = "labelOption";
         
            mingjun.emphasis = em;

            HuoDate huodate = new HuoDate();
            huodate.type = "category";
            axisTick ast= new axisTick();
            ast.show = "false";


            string sql = @"SELECT DATE_FORMAT(CreateDate,'%m.%d') as m,(SELECT COUNT(*) FROM running WHERE TeamID=1 AND DATE_SUB(CURDATE(), INTERVAL  " + DayCount.ToString() + "  DAY) <= date(CreateDate)) as T1Count,(SELECT COUNT(*) FROM running WHERE TeamID=2 AND DATE_SUB(CURDATE(), INTERVAL  "+ DayCount.ToString()+ "  DAY) <= date(CreateDate)) as T2Count,(SELECT COUNT(*) FROM running WHERE TeamID=3 AND DATE_SUB(CURDATE(), INTERVAL   " + DayCount.ToString() + "  DAY) <= date(CreateDate)) as T3Count,(SELECT COUNT(*) FROM running WHERE TeamID=4  AND DATE_SUB(CURDATE(), INTERVAL   " + DayCount.ToString() + "  DAY) <= date(CreateDate)) as T4Count from running  WHERE DATE_SUB(CURDATE(), INTERVAL    " + DayCount.ToString() + "  DAY) <= date(CreateDate) GROUP BY m";

            var data = this.unitOfWork.context.Database.SqlQuery<HuoSqlModel>(sql, new object[0]).ToList();
            if (data != null && data.Count() > 0)
            {
                huating.data = data.Select(p => p.T1Count).ToList();
                lanting.data = data.Select(p => p.T2Count).ToList();
                fengge.data = data.Select(p => p.T3Count).ToList();
                mingjun.data = data.Select(p => p.T4Count).ToList();
                huodate.data = data.Select(p => p.m).ToList();
            }

          

            return Json(new { R = true, HT=huating,LT=lanting,FG=fengge,MJ=mingjun,DateList= huodate });
        }

        [HttpPost]
        public IHttpActionResult CountPoint(int IsOver=0)
        {
            try
            {
                Stream postData = HttpContext.Current.Request.InputStream;
                StreamReader sRead = new StreamReader(postData);
                string postContent = sRead.ReadToEnd();
                sRead.Close();

                int PlayScore = 0;

                List<Points> runModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Points>>(postContent);
                double Dis = 0;

                if (runModel != null && runModel.Count() > 1)
                {
                    for (int i = 0; i < runModel.Count() - 1; i++)
                    {

           
                        double d = RunHelper.GetDistance(runModel[i].latitude, runModel[i].longitude, runModel[i + 1].latitude, runModel[i + 1].longitude);

                        if (IsOver == 1)
                        {
                            List<CardPoints> cardPoints = CardPointHelper.GetPoints();

                            foreach (var item in cardPoints)
                            {
                                double d1= RunHelper.GetDistance(runModel[i].latitude, runModel[i].longitude, item.latitude, item.longitude)*1000;

                                if (d1 < 10)
                                {
                                    PlayScore = PlayScore + 150;
                                }
                            }
                        }


                        long FTime = runModel[i].pointTimestamp;
                        long STime = runModel[i+1].pointTimestamp;

                        double cha = (STime - FTime) / 1000;

                        double speed = (d  / cha);

                     

                        if (speed < 0.5 || speed > 7)
                        {

                        }
                        else
                        {
                            Dis = Dis + d;
                        }


                    }
                    return Json(new { R = true, Data = (Dis/1000).ToString("0.000"), PointScore = PlayScore });
                }
                else
                {
                    return Json(new { R = true, Data = 0 , PointScore = 0});
                }

            }
            catch (Exception ex)
            {
                Edu.Tools.LogHelper.Info(ex.ToString());

                return Json(new { R = true, Data = 0 });
            }




        }



        [HttpGet]
        public IHttpActionResult GetRank(int DayCount, string WXUserID = "")
        {
            IHttpActionResult result;
            try
            {
                string sql = "SELECT @rownum:= @rownum + 1 as RankID,SUM(Totalkm) as Totalkm,B.NickName,b.HeadPhoto,C.TeamName from(select @rownum:= 0) d,running as A ,userinfo as B,team as C  WHERE  DATE_SUB(CURDATE(), INTERVAL " + DayCount.ToString() + " DAY) <= date(A.CreateDate) and A.WXUserID=B.WxID and A.TeamID = C.ID GROUP BY WXUserID ";
                string sql2 = string.Concat(new string[]
                {
                    "SELECT @rownum:= @rownum + 1 as RankID,SUM(Totalkm) as Totalkm,B.NickName,b.HeadPhoto,C.TeamName from(select @rownum:= 0) d,running as A ,userinfo as B,team as C  WHERE A.WXUserID='",
                    WXUserID,
                    "' AND  DATE_SUB(CURDATE(), INTERVAL ",
                    DayCount.ToString(),
                    " DAY) <= date(A.CreateDate) and A.WXUserID=B.WxID and A.TeamID = C.ID GROUP BY WXUserID "
                });
               var data = this.unitOfWork.context.Database.SqlQuery<RankModel>(sql, new object[0]);
               var personData = this.unitOfWork.context.Database.SqlQuery<RankModel>(sql2, new object[0]);
                result = base.Json(new
                {
                    R = true,
                    Data = data,
                    PersonData = personData
                });
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());
                result = base.Json(new
                {
                    R = false,
                    Data = ""
                });
            }
            return result;
        }
        [HttpGet]
        public IHttpActionResult GetTeamRank(int DayCount, int TeamID, string WXUserID = "oDyWN5BMhVuLjJqjkd9eBxRDILQA")
        {
            IHttpActionResult result;
            try
            {
                string sql = string.Concat(new string[]
                {
                    "SELECT @rownum:= @rownum + 1 as RankID,  SUM(Totalkm) as Totalkm,B.NickName,B.HeadPhoto,B.Sex,C.TeamName from  (select @rownum:= 0) d, running as A ,userinfo as B,team as C  WHERE A.WXUserID=B.WxID  AND A.TeamID=",
                    TeamID.ToString(),
                    " AND  DATE_SUB(CURDATE(), INTERVAL ",
                    DayCount.ToString(),
                    "   DAY) <= date(A.CreateDate)  GROUP BY A.WXUserID  ORDER BY Totalkm DESC"
                });
                string sql2 = string.Concat(new string[]
                {
                    "SELECT @rownum:= @rownum + 1 as RankID,  SUM(Totalkm) as Totalkm,B.NickName,B.HeadPhoto,B.Sex,C.TeamName from  (select @rownum:= 0) d, running as A ,userinfo as B,team as C  WHERE A.WXUserID=B.WxID AND A.WXUserID='",
                    WXUserID,
                    "' AND A.TeamID=",
                    TeamID.ToString(),
                    " AND  DATE_SUB(CURDATE(), INTERVAL ",
                    DayCount.ToString(),
                    "   DAY) <= date(A.CreateDate)  GROUP BY A.WXUserID  ORDER BY Totalkm DESC"
                });
                List<TeamRunModel> data = this.unitOfWork.context.Database.SqlQuery<TeamRunModel>(sql, new object[0]).ToList<TeamRunModel>();
                List<TeamRunModel> personData = this.unitOfWork.context.Database.SqlQuery<TeamRunModel>(sql2, new object[0]).ToList<TeamRunModel>();
                result = base.Json(new
                {
                    R = true,
                    Data = data,
                    PersonData = personData
                });
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());
                result = base.Json(new
                {
                    R = false,
                    Data = "",
                    PersonData = ""
                });
            }
            return result;
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
            TodayRunModel tM = new TodayRunModel();

            decimal TotalKm = 0;

            int totalSeconds = 0;

            double totalHeat = 0;

            int totalPointscore = 0;

            int totalRunscore = 0;
            if (runList != null && runList.Count() > 0)
            {
              

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
                    minSpeedB = Math.Round(minSpeedB, 1);

                    totalPointscore = totalPointscore + Convert.ToInt32(item.PointScore);
                    totalRunscore = totalRunscore + Convert.ToInt32(item.RunScore);
                }

            
            }
            if (minSpeedB == 100)
            {
                tM.MinSpeed = "0";
            }
            else
            {
                tM.MinSpeed = minSpeedB.ToString();
            }
         
            tM.TotalKM = TotalKm;
            tM.TotalHeat = Math.Round(totalHeat, 1);
            tM.RunDate = DateTime.Now.ToString("yyyy.MM.dd");
            tM.TotalTime = TimeHelper.TransTimeSecondIntToString(totalSeconds);
            tM.PointScore = totalPointscore;
            tM.RunScore = totalRunscore;
            return Json(new { R = true, Data = tM });


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
        /// 提交跑步数据
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IHttpActionResult ModyRun()
        {
            IHttpActionResult result;
            try
            {
                Stream inputStream = HttpContext.Current.Request.InputStream;
                StreamReader streamReader = new StreamReader(inputStream);
                string value = streamReader.ReadToEnd();
                streamReader.Close();
                Running runModel = JsonConvert.DeserializeObject<Running>(value);
                UserInfo userInfo = this.unitOfWork.DUserInfo.Get((UserInfo p) => p.WxID == runModel.WXUserID, null, "").FirstOrDefault<UserInfo>();
                bool flag = userInfo != null && userInfo.Weight != null;
                if (flag)
                {
                    string sql = @"SELECT SUM(PointScore) FROM running WHERE WXUserID='" + runModel.WXUserID + "'  year(CreateDate)=year(now()) and month(CreateDate) = month(now()) and day(CreateDate) = day(now())";

                    int TodayPointCount = Convert.ToInt32(this.unitOfWork.context.Database.SqlQuery<int>(sql, new object[0]));
                    if (TodayPointCount > 600)
                    {
                        runModel.PointScore = 0;
                    }

                    double num = Convert.ToDouble(userInfo.Weight);
                    double num2 = Convert.ToDouble(runModel.Totalkm);
                    runModel.RunScore = new int?(Convert.ToInt32(100.0 * num2));                   
                    runModel.TotalScore = runModel.RunScore + runModel.PointScore;
                    int hour = Convert.ToDateTime(runModel.TotalTime).Hour;
                    int minute = Convert.ToDateTime(runModel.TotalTime).Minute;
                    int num3 = Convert.ToInt32(hour * 60 + minute);
                    runModel.Speed = new double?(Convert.ToDouble((double)num3 / num2));

                    
                }
                runModel.CreateDate = new DateTime?(DateTime.Now);
                this.unitOfWork.DRunning.Insert(runModel);
                this.unitOfWork.Save();
                result = base.Json(new
                {
                    R = true,
                    M = "跑步信息添加成功！"
                });
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());
                result = base.Json(new
                {
                    R = false,
                    M = "跑步信息添加失败！"
                });
            }
            return result;
        }
    }
}
