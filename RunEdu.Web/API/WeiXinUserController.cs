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
    public class WeiXinUserController : BaseAPIController
    {
        [HttpPost]
        public IHttpActionResult Post()
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
                if (!string.IsNullOrEmpty(oModel.WxID))
                {
                    var user = unitOfWork.DUserInfo.Get(p => p.WxID == oModel.WxID).FirstOrDefault();
                    if (user != null)
                    {

                        user.Sex = oModel.Sex;
                        user.Address = oModel.Address;
                        user.NickName = oModel.NickName;
                        user.HeadPhoto = oModel.HeadPhoto;

                        unitOfWork.DUserInfo.Update(user);
                    }
                    else
                    {
                        us.Sex = oModel.Sex;
                        us.Address = oModel.Address;
                        us.IsCheck = oModel.IsCheck;
                        us.NickName = oModel.NickName;
                        us.HeadPhoto = oModel.HeadPhoto;
                        us.WxID = oModel.WxID;
                        us.CreatDate = DateTime.Now;

                        unitOfWork.DUserInfo.Insert(us);


                    }

                    unitOfWork.Save();



                    return Json(new { R = true, M = "用户信息完善成功！" });

                }

                else
                {
                    return Json(new { R = true, M = "用户信息完善失败！" });
                }


            }
            catch (Exception ex)
            {
                return Json(new { R = true, M = "用户信息完善失败！" });
            }
        }

    }
}
