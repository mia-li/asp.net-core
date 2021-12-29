using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Utility.Filter;

namespace WebApplication1.Controllers
{
    //[CustomExceptionFilterAttribute]//controller注册
    //[ServiceFilter(typeof(CustomExceptionFilterAttribute))] 
    //[TypeFilter(typeof(CustomExceptionFilterAttribute))]
    public class FourthController : Controller
    {
        /// <summary>
        /// 以前的方法 在index/info里都要写try catch 
        /// 现在：不写try catch 且不修改方法，也完成异常处理
        /// AOP：聚焦业务逻辑，轻松扩展功能；实现代码复用，集中管理
        /// </summary>
        /// <returns></returns>
        /// 
       // [CustomExceptionFilterAttribute]//action注册
       //还可以在startup 全局中注册 
        public IActionResult Index()
        {
            //try catch
            //假设底下代码为业务逻辑
            int a = 1;
            int b = 2;
            int m = a + b;
            int k = m - m;
            int j = m / k; //为了抛出异常
            return View();
        }
        public IActionResult Info()
        {
            //try catch
            //假设底下代码为业务逻辑
            int a = 1;
            int b = 2;
            int m = a + b;
            int k = m - m;
            int j = m / k; //为了抛出异常
            return View();
        }
    }
}
