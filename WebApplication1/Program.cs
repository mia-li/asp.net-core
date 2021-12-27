using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            host.Run();
            //׼��һ��web������Ȼ������
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)//����Ĭ��builder--����ɸ�������
                //.ConfigureLogging((context,loggingBuilder)=>
                //{
                //    loggingBuilder.AddFilter("System", LogLevel.Warning);
                //    loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                //    loggingBuilder.AddLog4Net();
                //})
                .ConfigureWebHostDefaults(//ָ��һ��web������-kestrel
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
