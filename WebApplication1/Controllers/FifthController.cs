using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Utility.Filter;

namespace WebApplication1.Controllers
{
    public class FifthController : Controller
    {
        /// <summary>
        /// 利用filter加缓存
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        [CustomCacheResourceFilterAttribute]
        public IActionResult Info()
        {
            base.ViewBag.Now = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss fff");
            return View();
        }

    }
}
