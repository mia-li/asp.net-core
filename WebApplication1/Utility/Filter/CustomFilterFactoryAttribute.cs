using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utility.Filter
{
    public class CustomFilterFactoryAttribute:Attribute,IFilterFactory
    {
        private Type _FilterType = null;
        public CustomFilterFactoryAttribute(Type type)
        {
            this._FilterType = type;
        }
        public bool IsReusable => true;

        /// <summary>
        /// 容器的实例--构造对象--就可以实现依赖注入
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>返回的是一个filter</returns>
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(this._FilterType);
        }
    }
}
