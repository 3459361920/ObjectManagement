using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Common
{
    public class MyAuthorizeFilter: AuthorizeFilter
    {
        private static AuthorizationPolicy _policy_ = new AuthorizationPolicy(new[] { new DenyAnonymousAuthorizationRequirement() }, new string[] { });
        /// <summary>
        /// 拦截器 过滤权限
        /// </summary>
        public MyAuthorizeFilter() : base(_policy_) { }
        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //context.Result =new ObjectResult("验证不通过！");
            return;
        }
    }
    public class ResultExecuted : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var http = context.HttpContext;
            var body = http.Request.Body;
        }
    }
    public class ExecutedFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 业务程序处理完成之后
        /// </summary>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Request.EnableBuffering();
            context.HttpContext.Request.Body.Seek(0,SeekOrigin.Begin);
            StreamReader stream = new StreamReader(context.HttpContext.Request.Body);
            string bodycontent = stream.ReadToEndAsync().Result;
            var query = context.HttpContext.Request.QueryString;
            context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            var http = ((FilterContext)context).HttpContext;
            var Reque = http.Request;
            var ms = new MemoryStream();
            try
            {
                Reque.EnableBuffering();
                Reque.Body.Position = 0;
                Reque.Body.CopyTo(ms);
                var postStr = Encoding.UTF8.GetString(ms.ToArray());
                ms.Position = 0;
                Reque.Body = ms;
                var result = postStr.Replace("\n", "");
                var i = 0; do { result = result.Replace("  ", " ").Replace("  ", " ").Replace("  ", " "); i++; } while (i < 5);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
