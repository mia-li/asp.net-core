using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interface;
using WebApplication1.Service;
using WebApplication1.Utility.Filter;

namespace WebApplication1
{
    public class Startup
    {
        //startup 是kestrel跟mvc的关联
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();//该怎么使用session
            //services.AddTransient<CustomExceptionFilterAttribute>(); //ServiceFilter需要先注册

            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute)); //全局注册--全局生效
                }
                );

            //Ioc还可以控制对象生命周期
            services.AddTransient<ITestServiceA, TestServiceA>();//瞬时生命周期
            //services.AddSingleton<ITestServiceA, TestServiceA>();//单例-进程唯一实例
            //services.AddScoped<ITestServiceA, TestServiceA>();//作用域单例一一个请求一个实例

        }
        //http request pipeline: http请求处理的过程
        //新型管道：套娃式
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();//表示请求需要使用session
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
