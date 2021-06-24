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
        public IHttpActionResult GetTotalSocre(string WXUserID)
        {
            var run = unitOfWork.DScore.Get(p => p.WXUserID == WXUserID).FirstOrDefault();


            return Json(new { R = true, Data = run });
        }
        [HttpGet]
        public IHttpActionResult GetSocreRank(string WXUserID)
        {
            var run = unitOfWork.DScoreRank.Get(p => p.WXUserID == WXUserID);


            return Json(new { R = true, Data = run });
        }


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
            axisTick ast = new axisTick();
            ast.show = "false";


            string sql = @"SELECT  DATE_FORMAT(Tb1.date,'%m.%d') as m,IFNULL(Tb2.m,'0') as T1Count,IFNULL(Tb3.m,'0') as T2Count,IFNULL(Tb4.m,'0') as T3Count,IFNULL(Tb5.m,'0') as T4Count
FROM 
(SELECT  date_sub(CURDATE(),interval @i:=@i+1 day) as date 
from ( select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1  ) as tmp,(select @i:= -1) t) as Tb1
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af2.CreateDate,'%m.%d') as gptime from running as af2 where af2.TeamID=1 and DATE_SUB(CURDATE(), INTERVAL 7   DAY) <= date(af2.CreateDate)  GROUP BY gptime)  as Tb2  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb2.gptime
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af3.CreateDate,'%m.%d') as gptime from running as af3 where af3.TeamID=2 and DATE_SUB(CURDATE(), INTERVAL 7   DAY) <= date(af3.CreateDate)  GROUP BY gptime)  as Tb3  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb3.gptime   
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af4.CreateDate,'%m.%d') as gptime from running as af4 where af4.TeamID=3 and DATE_SUB(CURDATE(), INTERVAL 7   DAY) <= date(af4.CreateDate)  GROUP BY gptime)  as Tb4  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb4.gptime  
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af5.CreateDate,'%m.%d') as gptime from running as af5 where af5.TeamID=4 and DATE_SUB(CURDATE(), INTERVAL 7   DAY) <= date(af5.CreateDate)  GROUP BY gptime)  as Tb5  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb5.gptime ORDER BY m   desc";

            if (DayCount == 30)
            {
                sql = @"SELECT  DATE_FORMAT(Tb1.date,'%m.%d') as m,IFNULL(Tb2.m,'0') as T1Count,IFNULL(Tb3.m,'0') as T2Count,IFNULL(Tb4.m,'0') as T3Count,IFNULL(Tb5.m,'0') as T4Count
FROM 
(SELECT  date_sub(CURDATE(),interval @i:=@i+1 day) as date 
from ( select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1  union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1 union all select 1  ) as tmp,(select @i:= -1) t) as Tb1
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af2.CreateDate,'%m.%d') as gptime from running as af2 where af2.TeamID=1 and DATE_SUB(CURDATE(), INTERVAL 30   DAY) <= date(af2.CreateDate)  GROUP BY gptime)  as Tb2  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb2.gptime
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af3.CreateDate,'%m.%d') as gptime from running as af3 where af3.TeamID=2 and DATE_SUB(CURDATE(), INTERVAL 30   DAY) <= date(af3.CreateDate)  GROUP BY gptime)  as Tb3  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb3.gptime   
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af4.CreateDate,'%m.%d') as gptime from running as af4 where af4.TeamID=3 and DATE_SUB(CURDATE(), INTERVAL 30   DAY) <= date(af4.CreateDate)  GROUP BY gptime)  as Tb4  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb4.gptime  
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af5.CreateDate,'%m.%d') as gptime from running as af5 where af5.TeamID=4 and DATE_SUB(CURDATE(), INTERVAL 30   DAY) <= date(af5.CreateDate)  GROUP BY gptime)  as Tb5  ON DATE_FORMAT(Tb1.date,'%m.%d')=Tb5.gptime ORDER BY m   desc";
            }
            else if (DayCount == 90)
            {
                sql = @"SELECT  DATE_FORMAT(Tb1.date,'%m') as m,IFNULL(Tb2.m,'0') as T1Count,IFNULL(Tb3.m,'0') as T2Count,IFNULL(Tb4.m,'0') as T3Count,IFNULL(Tb5.m,'0') as T4Count
FROM 
(SELECT  date_sub(CURDATE(),interval @i:=@i+1 month) as date 
from ( select 1 union all select 1 union all select 1  ) as tmp,(select @i:= -1) t) as Tb1
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af2.CreateDate,'%m') as gptime from running as af2 where af2.TeamID=1 and DATE_SUB(CURDATE(), INTERVAL 3   MONTH) <= date(af2.CreateDate)  GROUP BY gptime)  as Tb2  ON DATE_FORMAT(Tb1.date,'%m')=Tb2.gptime
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af3.CreateDate,'%m') as gptime from running as af3 where af3.TeamID=2 and DATE_SUB(CURDATE(), INTERVAL 3   MONTH) <= date(af3.CreateDate)  GROUP BY gptime)  as Tb3  ON DATE_FORMAT(Tb1.date,'%m')=Tb3.gptime   
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af4.CreateDate,'%m') as gptime from running as af4 where af4.TeamID=3 and DATE_SUB(CURDATE(), INTERVAL 3   MONTH) <= date(af4.CreateDate)  GROUP BY gptime)  as Tb4  ON DATE_FORMAT(Tb1.date,'%m')=Tb4.gptime  
LEFT JOIN (SELECT COUNT(*) as m,DATE_FORMAT(af5.CreateDate,'%m') as gptime from running as af5 where af5.TeamID=4 and DATE_SUB(CURDATE(), INTERVAL 3   MONTH) <= date(af5.CreateDate)  GROUP BY gptime)  as Tb5  ON DATE_FORMAT(Tb1.date,'%m')=Tb5.gptime ORDER BY m   desc

";
            }

            var data = this.unitOfWork.context.Database.SqlQuery<HuoSqlModel>(sql, new object[0]).ToList();
            if (data != null && data.Count() > 0)
            {
                huating.data = data.Select(p => p.T1Count).ToList();
                lanting.data = data.Select(p => p.T2Count).ToList();
                fengge.data = data.Select(p => p.T3Count).ToList();
                mingjun.data = data.Select(p => p.T4Count).ToList();
                huodate.data = data.Select(p => p.m).ToList();
            }



            return Json(new { R = true, HT = huating, LT = lanting, FG = fengge, MJ = mingjun, DateList = huodate });
        }


        [HttpPost]
        public IHttpActionResult CountCardPoint()
        {
            try
            {
                Stream postData = HttpContext.Current.Request.InputStream;
                StreamReader sRead = new StreamReader(postData);
                string postContent = sRead.ReadToEnd();
                sRead.Close();

                int PlayScore = 0;

                List<Points> runModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Points>>(postContent);

                Edu.Tools.LogHelper.Info("跑步数据列表：" + postContent);
                double Dis = 0;

                List<CardPoints> cardPoints = CardPointHelper.GetPoints();

                if (runModel != null && runModel.Count() > 1)
                {
                    for (int i = 0; i < runModel.Count() - 1; i++)
                    {


                        double d = RunHelper.GetDistance(runModel[i].latitude, runModel[i].longitude, runModel[i + 1].latitude, runModel[i + 1].longitude);




                        foreach (var item in cardPoints)
                        {
                            double d1 = RunHelper.GetDistance(runModel[i].latitude, runModel[i].longitude, item.latitude, item.longitude);

                            if (d1 < 60)
                            {



                                PlayScore = PlayScore + 10;

                                cardPoints.Remove(item);
                            }

                        }



                        long FTime = runModel[i].pointTimestamp;
                        long STime = runModel[i + 1].pointTimestamp;

                        double cha = (STime - FTime) / 1000;

                        double speed = (d / cha);



                        if (speed < 0.5 || speed > 7)
                        {

                        }
                        else
                        {
                            Dis = Dis + d;
                        }


                    }

                    if (PlayScore > 40)
                    {
                        PlayScore = 40;
                    }

                    return Json(new { R = true, Data = (Dis / 1000).ToString("0.000"), PointScore = PlayScore });
                }
                else
                {
                    return Json(new { R = true, Data = 0, PointScore = 0 });
                }

            }
            catch (Exception ex)
            {
                Edu.Tools.LogHelper.Info(ex.ToString());

                return Json(new { R = true, Data = 0 });
            }




        }

        [HttpPost]
        public IHttpActionResult CountPoint()
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


                        long FTime = runModel[i].pointTimestamp;
                        long STime = runModel[i + 1].pointTimestamp;

                        double cha = (STime - FTime) / 1000;

                        double speed = (d / cha);



                        if (speed < 0.5 || speed > 7)
                        {

                        }
                        else
                        {
                            Dis = Dis + d;
                        }


                    }
                    return Json(new { R = true, Data = (Dis / 1000).ToString("0.000") });
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



        [HttpGet]
        public IHttpActionResult GetRank(int DayCount, string WXUserID = "")
        {
            IHttpActionResult result;
            try
            {
                string sql = @"SELECT @rownum:= @rownum + 1 as RankID,SUM(Totalkm) as Totalkm,A.WXUserID,B.NickName,b.HeadPhoto,B.Sex,C.TeamName,B.TeamID from(select @rownum:= 0) d,running as A ,userinfo as B,team as C WHERE  DATE_SUB(CURDATE(), INTERVAL "+DayCount.ToString()+" DAY) <= date(A.CreateDate) AND  A.WXUserID=B.WxID AND A.TeamID=C.ID  GROUP BY WXUserID ";

                var data = this.unitOfWork.context.Database.SqlQuery<RankModel>(sql, new object[0]);
                var personData = data.Where(p => p.WXUserID == WXUserID);
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
                    "SELECT @rownum:= @rownum + 1 as RankID,  E.Totalkm,E.WXUserID,E.NickName,E.HeadPhoto,E.Sex,E.TeamName,E.TeamID from (SELECT  SUM(Totalkm) as Totalkm,A.WXUserID,B.NickName,B.HeadPhoto,B.Sex,C.TeamName,C.ID  as TeamID from running as A ,userinfo as B,team as C  WHERE A.TeamID=B.TeamID AND A.WXUserID=B.WxID AND A.TeamID = C.ID  AND A.TeamID="+TeamID.ToString()+"  AND A.TeamID=c.ID  AND  DATE_SUB(CURDATE(), INTERVAL "+DayCount.ToString()+" DAY) <= date(A.CreateDate)  GROUP BY A.WXUserID  ORDER BY Totalkm DESC) E, (select @rownum:= 0) d"
                });

                List<TeamRunModel> data = this.unitOfWork.context.Database.SqlQuery<TeamRunModel>(sql, new object[0]).ToList<TeamRunModel>();
                List<TeamRunModel> personData = data.Where(p => p.WXUserID == WXUserID).ToList();
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

            var runList = unitOfWork.DRunning.Get(p => p.WXUserID == WxUserID).OrderByDescending(p => p.ID).Take(30);


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




            var runList = unitOfWork.DRunning.Get(p => p.WXUserID == WxUserID);

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

                    if (minSpeedB > minSpeedA && minSpeedA != 0)
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

                // 查询当天数据
                string time = DateTime.Now.ToShortDateString();


                DateTime time1 = Convert.ToDateTime(time + " 0:00:00");  // 数字前 记得 加空格


                DateTime time2 = Convert.ToDateTime(time + " 23:59:59");


                Stream inputStream = HttpContext.Current.Request.InputStream;
                StreamReader streamReader = new StreamReader(inputStream);
                string value = streamReader.ReadToEnd();
                streamReader.Close();
                Edu.Tools.LogHelper.Info("value:" + value.ToString());

                Running runModel = JsonConvert.DeserializeObject<Running>(value);


                UserInfo userInfo = this.unitOfWork.DUserInfo.Get((UserInfo p) => p.WxID == runModel.WXUserID, null, "").FirstOrDefault<UserInfo>();
                bool flag = userInfo != null && userInfo.Weight != null;
                if (flag)
                {


                    int pointScore = Convert.ToInt32(runModel.PointScore);

                    int TodayPointCount = Convert.ToInt32(unitOfWork.DRunning.Get(p => p.CreateDate > time1 && p.CreateDate < time2 && p.WXUserID == runModel.WXUserID).Sum(p => p.PointScore));
                    if (TodayPointCount > 0)
                    {


                        if (TodayPointCount >= 40)
                        {
                            pointScore = 0;
                        }

                        if (pointScore + TodayPointCount > 100 && TodayPointCount < 40)
                        {
                            pointScore = 40 - TodayPointCount;
                        }


                    }



                    double num = Convert.ToDouble(userInfo.Weight);
                    double num2 = Convert.ToDouble(runModel.Totalkm);
                    int RunScore = 0 + Convert.ToInt32(10 * num2);


                    int TodayRunCount = Convert.ToInt32(unitOfWork.DRunning.Get(p => p.CreateDate > time1 && p.CreateDate < time2 && p.WXUserID == runModel.WXUserID).Sum(p => p.RunScore));


                    if (TodayRunCount > 0)
                    {


                        if (TodayRunCount >= 100)
                        {
                            RunScore = 0;
                        }
                        if (RunScore + TodayRunCount > 100 && TodayRunCount < 100)
                        {
                            RunScore = 100 - TodayRunCount;
                        }

                    }


                    runModel.RunScore = RunScore;
                    runModel.PointScore = pointScore;

                    runModel.TotalScore = RunScore + pointScore;
                    int hour = Convert.ToDateTime(runModel.TotalTime).Hour;
                    int minute = Convert.ToDateTime(runModel.TotalTime).Minute;
                    int num3 = Convert.ToInt32(hour * 60 + minute);
                    runModel.Speed = Convert.ToDouble((double)num3 / num2);


                    if (RunScore > 0)
                    {
                        ScoreRank scoreRank = new ScoreRank();
                        scoreRank.WXUserID = runModel.WXUserID;
                        scoreRank.RunTypeID = 1;
                        scoreRank.RunTypeName = "跑步获取";
                        scoreRank.Score = RunScore;
                        scoreRank.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        this.unitOfWork.DScoreRank.Insert(scoreRank);
                        this.unitOfWork.Save();
                    }


                    if (pointScore > 0)
                    {
                        ScoreRank scoreRank = new ScoreRank();
                        scoreRank.WXUserID = runModel.WXUserID;
                        scoreRank.RunTypeID = 1;
                        scoreRank.RunTypeName = "节点打卡";
                        scoreRank.Score = pointScore;
                        scoreRank.CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        this.unitOfWork.DScoreRank.Insert(scoreRank);
                        this.unitOfWork.Save();
                    }

                    int totalScore = pointScore + RunScore;
                    if (totalScore > 0)
                    {
                        var score = unitOfWork.DScore.Get(p => p.WXUserID == runModel.WXUserID).FirstOrDefault();
                        if (score != null)
                        {
                            score.TotalScore = score.TotalScore + totalScore;

                            this.unitOfWork.DScore.Update(score);
                            this.unitOfWork.Save();
                        }
                        else
                        {
                            Score _score = new Score();
                            _score.WXUserID = runModel.WXUserID;

                            _score.TotalScore = pointScore;
                            _score.CreatDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            this.unitOfWork.DScore.Insert(_score);
                            this.unitOfWork.Save();
                        }

                    }




                }
                runModel.CreateDate = new DateTime?(DateTime.Now);
                this.unitOfWork.DRunning.Insert(runModel);
                this.unitOfWork.Save();





                result = base.Json(new
                {
                    R = true,
                    M = "跑步信息添加成功！",
                    Data = runModel
                });
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());
                result = base.Json(new
                {
                    R = false,
                    M = "跑步信息添加失败！",
                    Data = ""
                });
            }
            return result;
        }
    }
}
