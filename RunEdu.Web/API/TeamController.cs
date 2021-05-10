using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edu.Web.API
{

    public class TeamController : BaseAPIController
    {
        /// <summary>
        /// 获取所有的团队
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllTeam()
        {
            try {

                var teamList = unitOfWork.DTeam.GetAll();


                return Json(new { R = true, Data=teamList });
            }
            catch (Exception ex)
            {
                return Json(new { R = false, Data = "" });
            }
        }
    }
}
