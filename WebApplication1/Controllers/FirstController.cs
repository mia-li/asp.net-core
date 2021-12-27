using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            #region Session:服务器内存的一段内容，在httpcontext
            if(string.IsNullOrWhiteSpace(this.HttpContext.Session.GetString("CurrentUserSession")))
            {
                //session本身的方法只有几个基础的，setstring getstring 是session的扩展方法
                //用扩展方法能在抽象设计时，最小化设计类，后续的便捷功能可以通过扩展方法来提供
                //直接用session会报错，要在startup里添加中间件和服务实例 
                //可以理解成.net core 用什么服务都得给他进行配置
                base.HttpContext.Session.SetString("CurrentUserSession",
                    Newtonsoft.Json.JsonConvert.SerializeObject(new CurrentUser()
                    {
                        Id = 6,
                        Name = "lb",
                        Account = "lblmlp",
                        Email = "1007473330@qq.com",
                        Password = "123456",
                        LoginTime = DateTime.Now
                    }));
            }
            #endregion

            #region Model
            return View(new CurrentUser()
            {
                Id=7,
                Name="mlp",
                Account="yyyy",
                Email="1007473330@qq.com",
                Password="123456",
                LoginTime=DateTime.Now
            });
            #endregion
        }
    }
}
