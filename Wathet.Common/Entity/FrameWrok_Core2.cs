using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Wathet.Common
{
    #region //HttpContext

    /// <summary>
    /// 上下文对象,程序里都可以使用
    /// </summary>
    public static class HttpContext
    {
        private static IHttpContextAccessor _accessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                if (_accessor == null)
                    return null;
                return _accessor.HttpContext;
            }
        }

        public static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


    }

    /// <summary>
    /// IServiceCollection 扩展方法, 用于注册HttpContext
    /// </summary>
    public static class StaticHttpContextExtensions
    {
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        //注册使用HttpContext
        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpContext.Configure(httpContextAccessor);
            return app;
        }
    }

    #endregion

    #region //ConfigurationManager

    public static class ConfigurationManager
    {
        public static ConfigurationManager_Temp AppSettings
        {
            get
            {
                return new ConfigurationManager_Temp();
            }
        }

        public class ConfigurationManager_Temp
        {
            public IConfiguration get() {

                var appVersion = Environment.GetEnvironmentVariable("BME-environment-version") ?? "";
                var configuration = new ConfigurationBuilder();
                switch (appVersion)
                {
                    case "dev":
                    case "uat":
                    case "prd":
                    case "fosunsit":
                    case "fosunuat":
                    case "fosunprod":
                    default:
                        configuration.AddJsonFile($"Config.{appVersion}.json");
                        break;
                    case "":
                        configuration.AddJsonFile("Config.json");
                        break;
                }


                IConfiguration config = configuration.Build();
                return config;
            }
            public string this[string name]
            {
                get
                {
                    try
                    {
                        //danny 增加了 SetBasePath(Directory.GetCurrentDirectory())，解决获找不到配置文件的问题                        
                        var appVersion = Environment.GetEnvironmentVariable("BME-environment-version") ?? "";
                        var configuration = new ConfigurationBuilder();
                        switch (appVersion)
                        {
                            case "dev":
                            case "uat":
                            case "prd":
                            case "fosunsit":
                            case "fosunuat":
                            case "fosunprod":
                            default:
                                configuration.AddJsonFile($"Config.{appVersion}.json");
                                break;
                            case "":
                                configuration.AddJsonFile("Config.json");
                                break;
                        }

                        IConfiguration config = configuration.Build();
                        return config[name];
                    }
                    catch (Exception ex) { Console.WriteLine("目标: " + name); Console.WriteLine(ex); return null; }
                }
            }
        }
        public static T GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(AppSettings.get().GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }
    }

    #endregion
 

    #region //Path 获取项目的绝对路径 使用DoPath下的方法
    public static class Extensions
    {
        public static IServiceCollection AddWkMvcDI(this IServiceCollection services)
        {
            return services;
        }

        public static IApplicationBuilder UseWkMvcDI(this IApplicationBuilder builder)
        {
            DI.ServiceProvider = builder.ApplicationServices;
            return builder;
        }
    }

    public static class DI
    {
        public static IServiceProvider ServiceProvider
        {
            get; set;
        }
    }

    #endregion



}
