using Edu.Model.WeiXin;
using Edu.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Edu.Web.API
{
    public class WeiXinController : BaseAPIController
    {

        [HttpGet]
        /// <summary>
        /// 注册微信用户
        /// </summary>
        /// <param name="EqCode"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string appid, string secret, string js_code)
        {
            try
            {
                string Url = "https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + js_code + "&grant_type=authorization_code";

              
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Proxy = null;
                request.KeepAlive = false;
                request.Method = "GET";
                request.ContentType = "application/json; charset=UTF-8";
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();


                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                WeiXinAPIUser obj = serializer.Deserialize<WeiXinAPIUser>(retString);

                return Json(new { R = true, user = obj });

            }
            catch (Exception ex)
            {
                return Json(new { R = false, ID = 0, m = ex.ToString() });
            }
        }
    }
}
