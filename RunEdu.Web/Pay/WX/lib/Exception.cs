using System;
using System.Collections.Generic;
using System.Web;

namespace RunEdu.Web.Pay
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}