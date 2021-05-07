﻿using Edu.Data;
using Edu.Tools;
using System.Web.Mvc;

namespace Edu.Service
{
    /// <summary>
    /// 所有Control基类
    /// </summary>
    public class BaseControl : Controller
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
    }
    /// <summary>
    /// 实现admin类权限控制的控制器
    /// </summary>
    [MyAuth(isAdmin = "1")]
    public class AdminBaseController : BaseControl
    {

    }
    /// <summary>
    /// 实现Teacher类权限控制的控制器
    /// </summary>
    //[MyAuth(Roles = "2")]
    public class TBaseController : BaseControl
    {

    }
    /// <summary>
    /// 实现学生类权限控制的控制器
    /// </summary>
    //[MyAuth(Roles = "3")]
    public class SBaseController : BaseControl
    {

    }
    /// <summary>
    /// 实现非admin类权限控制的控制器
    /// </summary>
    [MyAuth]
    public class UserBaseController : BaseControl
    {

    }
}
