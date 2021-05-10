using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Model.WeiXin
{
   public class UserModel
    {
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        /// 
        public int ID { get; set; }
        /// <summary>
        /// 微信用户ID
        /// </summary>
        public string WxID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        public string TrueName { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public string High { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Sex { get; set; }


        public string Password { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPhoto { get; set; }

        /// <summary>
        /// 团队ID
        /// </summary>
        public int TeamID { get; set; }

        /// <summary>
        /// 团队名称
        /// </summary>
        public string TeamName { get; set; }




    }
}
