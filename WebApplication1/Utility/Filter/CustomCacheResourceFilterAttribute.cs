using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utility.Filter
{
    /// <summary>
    /// OnResourceExecuted / OnResourceExecuting 都是IResourceFilter的接口
    /// OnResourceExecuted：缓存结果
    /// OnResourceExecuting：使用缓存
    /// 基于都是IResourceFilter 完成缓存，可以避免控制器多次实例化和action执行，但是视图还是会执行，只能缓存context.Result 
    /// 不能缓存context.Response,将result转为response就会执行视图
    /// 
    /// 怎样可以不执行视图，或者重用视图的结果，重用html？ 
    /// 使用responseCache,直接进行客户端缓存，请求在指定时间内不再抵达服务器；
    /// 
    /// 
    /// 这样的缓存方式是以action为单位的，缺点是会直接跳过业务逻辑，不能深入，若想在业务逻辑里加缓存，怎么做？
    /// 
    /// 业务逻辑里有多个步骤，但只有某个步骤需要缓存结果，其他都要求实时更新，filter是不适合的，可以基于autofac的aop缓存
    /// 在某个具体的执行步骤里做缓存，缓存就是第一次到达字典里没有，执行完以后存进字典，后面再查有对应key就直接返回结果
    /// 
    ///
    /// </summary>
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {
        private static Dictionary<string, IActionResult> _CustomCacheResourceFilterAttributeDictionary = new Dictionary<string, IActionResult>();
        public int Order => 0;

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string key = context.HttpContext.Request.Path;
            if(_CustomCacheResourceFilterAttributeDictionary.ContainsKey(key))
            {
                context.Result = _CustomCacheResourceFilterAttributeDictionary[key];
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string key = context.HttpContext.Request.Path;
            _CustomCacheResourceFilterAttributeDictionary.Add(key, context.Result);
        }
    }
}
