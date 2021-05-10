using Edu.Entity;
using Edu.Model.WeiXin;
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
    public class UserController : BaseAPIController
    {
        /// <summary>
        /// 根据微信ID获取用户信息
        /// </summary>
        /// <param name="WxID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult ExistUser(string WxID)
        {
            try
            {
                var user = unitOfWork.DUserInfo.Get(p=>p.WxID==WxID);

                if (user != null&&user.Count()>0)
                {
                    return Json(new { R = true, user = user });
                }
                else
                {
                    return Json(new { R = false, user = user });
                }

               
            }
            catch (Exception ex)
            {
                return Json(new { R = false, user = "" });
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        
        public IHttpActionResult GetUser(int ID)
        {
            try
            {
                var user = unitOfWork.DUserInfo.GetByID(ID);
                return Json(new { R = false, user = user });
            }
            catch (Exception ex)
            {
                return Json(new { R = false, user = "" });
            }
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ModyUser()
        {
            try
            {
                Stream postData = HttpContext.Current.Request.InputStream;
                StreamReader sRead = new StreamReader(postData);
                string postContent = sRead.ReadToEnd();
                sRead.Close();
                //JSONHelper.ObjectToJson(postContent);
                //AddLive aLive= JSONHelper.Deserialize<AddLive>(postContent);
                UserModel oModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(postContent);




                string OrderID = Edu.Tools.CombHelper.GenerateLong().ToString();
                UserInfo us = new UserInfo();
                int userID = 0;
                if (!string.IsNullOrEmpty(oModel.WxID))
                {
                    var user = unitOfWork.DUserInfo.Get(p => p.WxID == oModel.WxID).FirstOrDefault();
                    if (user != null)
                    {

                        us.Height = oModel.High;
                        us.Weight = oModel.Weight;
                        us.Age = oModel.Age;
                        user.TeamName = oModel.TeamName;
                        unitOfWork.DUserInfo.Update(user);
                        unitOfWork.Save();

                        userID = user.ID;
                    }
                    else
                    {
                        us.Height = oModel.High;
                        us.Weight = oModel.Weight;
                        us.Age = oModel.Age;
                    
                        user.TeamName = oModel.TeamName;
                        unitOfWork.DUserInfo.Insert(us);

                        unitOfWork.Save();
                        userID = us.ID;
                    }
                    var tUser = unitOfWork.DTeamUser.Get(p => p.WXUserID == oModel.WxID && p.TeamID == oModel.TeamID).FirstOrDefault();
                    if (tUser != null)
                    {
                        tUser.Status = 1;
                        unitOfWork.DTeamUser.Update(tUser);
                        unitOfWork.Save();
                    }
                    else
                    {
                        TeamUser tmUser = new TeamUser();
                        tmUser.Status = 1;
                        tmUser.CreatDate = DateTime.Now;
                        tmUser.TeamID = oModel.TeamID;
                        tmUser.TeamName = oModel.TeamName;
                        tmUser.WXUserID = oModel.WxID;
                        tmUser.UserName = oModel.UserName;
                        unitOfWork.DTeamUser.Insert(tUser);
                        unitOfWork.Save();
                    }

                    var tuserList = unitOfWork.DTeamUser.Get(p => p.WXUserID == oModel.WxID && p.TeamID!= oModel.TeamID);
                    if (tuserList != null && tuserList.Count() > 0)
                    {
                        foreach (var item in tuserList)
                        {
                            item.Status = 0;
                            unitOfWork.DTeamUser.Update(item);
                            unitOfWork.Save();
                        }
                    }
                }
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
