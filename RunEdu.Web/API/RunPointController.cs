using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edu.Web.API
{
    public class RunPointController : BaseAPIController
    {
        [HttpGet]
        public IHttpActionResult GetTeamPoint(int TeamID)
        {
            try
            {
                var pointList = unitOfWork.DRunPoint.Get(p => p.TeamID == TeamID);
                return Json(new { R = true, Data = pointList });
            }
            catch (Exception ex)
            {
                return Json(new { R = false, Data = "" });
            }
           
        }
    }
}
