using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;
namespace WebApplication1.Controllers
{
    public class ThirdController : Controller
    {
        //asp.net core 内置的ioc
        //控制反转--把对象的依赖转为对抽象的依赖

        //why ioc?
        //1、可以去掉对细节的依赖，方便扩展--减小影响范围，甚至转移到配置文件依赖，只需要改配置文件
        //假如没有Ioc 需要E-先构造C--先构造B--先构造A 上端需要知道全部的细节
        //2、可以做到屏蔽细节，对象依赖注入DI
        private readonly ITestServiceA _testServiceA;
        public ThirdController(ITestServiceA testServiceA)
        {
            _testServiceA = testServiceA;
            //ioc 使用步骤：
            //写接口-实现-在startup中的ConfigureServices中注册-使用
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
