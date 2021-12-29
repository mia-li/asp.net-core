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
        //startup ��kestrel��mvc�Ĺ���
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();//����ôʹ��session
            //services.AddTransient<CustomExceptionFilterAttribute>(); //ServiceFilter��Ҫ��ע��

            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute)); //ȫ��ע��--ȫ����Ч
                }
                );

            //Ioc�����Կ��ƶ�����������
            services.AddTransient<ITestServiceA, TestServiceA>();//˲ʱ��������
            //services.AddSingleton<ITestServiceA, TestServiceA>();//����-����Ψһʵ��
            //services.AddScoped<ITestServiceA, TestServiceA>();//��������һһ������һ��ʵ��

        }
        //http request pipeline: http������Ĺ���
        //���͹ܵ�������ʽ
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();//��ʾ������Ҫʹ��session
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
