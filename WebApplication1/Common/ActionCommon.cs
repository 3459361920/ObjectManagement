using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Common
{
    public class ActionCommon
    {

        #region Json
        public string Json(object parameter)
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(parameter);
            return result;
        }
        #endregion

        #region Json Convert T
        public object JsonObject<T>(T o,string parameter)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(parameter);
            return result;
        }
        #endregion

        #region 时间戳
        public string TimeStamp()
        {
            System.DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string timestamp = ((long)(DateTime.UtcNow - startTime).TotalSeconds).ToString() + "000";
            return timestamp;
        }
        #endregion

        #region MD5
        public string MD5(string parameter)
        {
            var bytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes($"O2O{parameter}Y6SxbQY1Z6VS3A9M7oOnvc3iKU7LjDCG"));
            string ret = "";
            foreach (byte bb in bytes) { ret += Convert.ToString(bb, 16).PadLeft(2, '0'); }
            var md5 = ret.PadLeft(32, '0').ToLower();
            return md5;
        }
        #endregion

        #region Email
        /// <summary>
        /// Smtp发送邮件
        /// </summary>
        /// <returns></returns>
        public bool SendDirect()
        {
            var mail = new MailMessage()
            {
                From = new MailAddress("saas@inexten.com", "SendDirect邮件发送"),//发件人，命名
                Subject="主题"
            };
            mail.To.Add("3459361920@qq.com");//收件人
            mail.Priority = MailPriority.High;//邮件优先级
            AlternateView alternate = AlternateView.CreateAlternateViewFromString("<h5>星期五，上海的温度打破98年的最高温度。</h5>",Encoding.UTF8, MediaTypeNames.Text.Html);
            mail.AlternateViews.Add(alternate);
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();

            try
            {
                SmtpClient client = null;

                client = new SmtpClient("smtp.exmail.qq.com");//邮件服务名（QQ邮箱：smtp.qq.com，QQ企业邮箱：smtp.exmail.qq.com）
                client.EnableSsl = true;
                //client.Port =465;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("saas@inexten.com", "Happy@2022");//发件人邮箱，smtp授权码
                client.Send(mail);

                client.Dispose();
                //SendResult = "发送成功!!";
                return true;
            }
            catch (Exception ex)
            {
                //SendResult = ex.ToString();
                return false;
            }
            return true;
        }
        #endregion

    }

    public static class BaseExtensions
    {
        public static int ToInt(this object obj, int defValue)
        {
            obj = obj ?? defValue; int def; if (int.TryParse(obj.ToString(), out def)) { return def; }
            try { var dou = ToDouble(obj, 0); return Convert.ToInt32(dou >= 0 ? Math.Floor(dou) : Math.Ceiling(dou)); } catch { return defValue; }
        }
        public static double ToDouble(this object obj, double defValue) { obj = obj ?? defValue; double def; double.TryParse(obj.ToString(), out def); return def == 0 ? defValue : def; } 
        public static void CW(string parameter)
        {
            Console.WriteLine("调用方法CW，输出："+parameter);
        }
    }

    public class Https
    {
        /// <summary>
        /// HTTP客户端工厂,更好的管理，会方到池子中（HttpClient的Dispose不会立即释放，）
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        public Https(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;    
        }

        public async Task<IResponse> GetResponse(string clientname,string url,Dictionary<string,string> dic)
        {
            var client = string.IsNullOrWhiteSpace(clientname)?httpClientFactory.CreateClient("Name"):httpClientFactory.CreateClient(clientname);
            if(dic.Count>0)
                foreach (var item in dic)
                {
                    client.DefaultRequestHeaders.Add(item.Key,item.Value);
                }
            var result =await client.GetAsync(url);
            var json = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IResponse>(json);
        }
    }
    #region Http扩展
    public static class HttpExtensions
    {
        public static IServiceCollection AddSuperHttpService(this IServiceCollection services)
        {
            services.AddScoped<Https>();
            return services;
        }
    }
    #endregion
}
