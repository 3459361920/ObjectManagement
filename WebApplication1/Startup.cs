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
            //Http���Զ�����ӵ�
            services.AddHttpClient();
            //services.AddLogging();
            //services.AddSuperHttpService();
            services.AddScoped<ActionCommon>();
            services.AddScoped<Https>();
            services.AddControllers();
            #region MyRegion

            #endregion
            #region Swagger
            //����swagger
            //ע��Swagger������������һ��swagger�ĵ�
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Web App",
                    Description = "RESTful API"
                });
                option.OperationFilter<HttpHeaderOperation>();//Swagger�����ĵ�Ҳ�����Զ������
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
            });
            #endregion
            #region //�м�� ָ��Ȩ����֤�ķ�ʽ 
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { });
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(Common.MyAuthorizeFilter)); //������Զ��������
                option.RespectBrowserAcceptHeader = true;
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Core3.1�����ԣ� ʹ��EnableBuffering����������֤�����õ�HttpPost��Body����
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
            //ע��ʹ��Ȩ����֤������
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //�����м������������Swagger
            app.UseSwagger();
            //�����м����������SwaggerUI��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App v1");
                option.RoutePrefix = string.Empty;//���ø��ڵ����
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
                Name = "token",  //���Authorizationͷ������
                In = ParameterLocation.Header,
                Required = false,
                Description = "Tokenֵ"
            });

        }
    }
}
