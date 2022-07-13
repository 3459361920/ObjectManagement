using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Http，自定义添加的
            services.AddHttpClient();
            //services.AddLogging();
            //services.AddSuperHttpService();
            services.AddScoped<ActionCommon>();
            services.AddScoped<Https>();
            services.AddControllers();
            #region MyRegion

            #endregion
            #region Swagger
            //配置swagger
            //注册Swagger生成器，定义一个swagger文档
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Web App",
                    Description = "RESTful API"
                });
                option.OperationFilter<HttpHeaderOperation>();//Swagger生成文档也生成自定义参数
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
            });
            #endregion
            #region //中间件 指定权限验证的方式 
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { });
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(Common.MyAuthorizeFilter)); //并添加自定义过滤器
                option.RespectBrowserAcceptHeader = true;
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Core3.1新特性， 使用EnableBuffering方法，来保证可以拿到HttpPost中Body内容
            app.Use(next => context => { context.Request.EnableBuffering(); return next(context); });
            //app.Use(next => new RequestDelegate(
            //    async context => {
            //        context.Request.EnableBuffering();
            //        await next(context);
            //    }
            //));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //注册使用权限验证过滤器
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //启用中间件服务生成器Swagger
            app.UseSwagger();
            //启用中间键服务生成SwaggerUI，指定Swagger JSON终结点
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App v1");
                option.RoutePrefix = string.Empty;//设置根节点访问
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        //areaName: "default",
            //        template: "api/[controller]/[action]"
            //    );
            //});

        }
    }
    public class HttpHeaderOperation : Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter
    {

        public void Apply(OpenApiOperation operation, Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "token",  //添加Authorization头部参数
                In = ParameterLocation.Header,
                Required = false,
                Description = "Token值"
            });

        }
    }
}
