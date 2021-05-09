﻿using Edu.Service;
using Edu.Tools;
using RunEdu.Web.Pay;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunEdu.Web.Controllers
{
    public class CommonController : BaseControl
    {
        #region 微信支付回调

        // GET: PayCommon
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Notify()
        {

            Edu.Tools.LogHelper.Info("开始执行微信回调");
            Response.ContentType = "text/plain";
            Response.Write("Hello World");


            string xmlData = getPostStr();//获取请求数据

            Edu.Tools.LogHelper.Info("微信回调数据" + xmlData);

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(xmlData);
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                WxPayData ress = new WxPayData();
                ress.SetValue("return_code", "FAIL");
                ress.SetValue("return_msg", ex.Message);
             

            }

            Edu.Tools.LogHelper.Info("result_code:"+ data.IsSet("result_code").ToString());
            //只有return_code为SUCCESS时才返回result_code
            if (data.IsSet("result_code"))
            {
                string transaction_id = data.GetValue("transaction_id").ToString();
                string out_trade_no = data.GetValue("out_trade_no").ToString();
                string result_code = data.GetValue("result_code").ToString();


                Edu.Tools.LogHelper.Info("out_trade_no:" + data.GetValue("out_trade_no").ToString());

                
                OperationResult result= unitOfWork.Save();

                if (result.ResultType == OperationResultType.Success)
                {
                  
                }
                else
                {
                  
                }



            }

            //微信要求的回复格式
            WxPayData res = new WxPayData();
            res.SetValue("return_code", "SUCCESS");
            res.SetValue("return_msg", "OK");

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string getPostStr()
        {
            Int32 intLen = Convert.ToInt32(System.Web.HttpContext.Current.Request.InputStream.Length);
            byte[] b = new byte[intLen];
            System.Web.HttpContext.Current.Request.InputStream.Read(b, 0, intLen);
            return System.Text.Encoding.UTF8.GetString(b);
        }
        #endregion
    }
}