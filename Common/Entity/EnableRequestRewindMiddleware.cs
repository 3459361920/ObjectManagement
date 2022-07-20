using System;
using System.Collections.Generic;
using System.Text;

#if NETSTANDARD2_0 || NETCOREAPP2_0 || NETCOREAPP2_1
using System.Threading.Tasks;
using global::Microsoft.AspNetCore.Http;
using global::Microsoft.AspNetCore.Http.Internal;
using global::Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Http
{
    /// <summary>
    /// <para>EnableRequestRewind中间件，开启.net core 2 中的RequestRewind模式，Request.Body可以二次读取，</para>
    /// <para>以解决某些特殊情况下netcore默认机制导致的Request.Body为空而引发的WeixinSDK错误的问题。</para>
    /// <para>https://github.com/JeffreySu/WeiXinMPSDK/issues/1090</para>
    /// </summary>
    public class EnableRequestRewindMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// EnableRequestRewindMiddleware
        /// </summary>
        /// <param name="next"></param>
        public EnableRequestRewindMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableRewind();
            await _next(context);
        }
    }

    /// <summary>
    /// EnableRequestRewindExtension
    /// </summary>
    public static class EnableRequestRewindExtension
    {
        /// <summary>
        /// UseEnableRequestRewind
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseEnableRequestRewind(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnableRequestRewindMiddleware>();
        }
    }
}
#endif
