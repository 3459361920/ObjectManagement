using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public JsonResult Action2()
        {
            return new JsonResult("post方法，action2");
        }



        public static void Post()
        {
            //====================================参数准备
            string httpMethod = "POST";                           //请求方法
            string domain = "";                                   //请求域名
            string path = "/api/Profile/Register";                //请求地址,网关注册接口 
            string stage = "TEST";                                //请求环境 
            string gateWayAppKey = "";                            //网关Appkey
            string gateWayAppSercert = "";                        //网关AppSercert
            string fengGaoAppKey = "";                            //蜂高AppKey
            string fengGaoAppSercert = "";                        //蜂高AppSercert 
            var timestamp = (long)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;//时间戳    

            //请求参数 
            //请注意参数大小写，某些接口会大小写敏感
            var postData = new
            {
                MobileNumber = "15922433136",
                BirthDay = "1997-01-01 00:00:00",
                Name = "XX",
                Gender = 0,
                MallCode = "110",
            };



            //=====================================headers准备
            //请求header准备
            Dictionary<string, string> headers = new Dictionary<string, string>();
            //网关验签头
            headers.Add("Content-Type", "application/json; charset=utf-8");
            headers.Add("Accept", "application/json; charset=utf-8");
            headers.Add("Content-MD5", MessageDigestUtil.Base64AndMD5(Encoding.UTF8.GetBytes(ConvertJson(postData))));
            headers.Add("X-Ca-Stage", stage);
            headers.Add("X-Ca-Timestamp", timestamp.ToString());
            headers.Add("X-Ca-Nonce", Guid.NewGuid().ToString());
            headers.Add("X-Ca-Key", gateWayAppKey);
            headers.Add("X-Ca-Signature-Headers", "X-Ca-Key,X-Ca-Nonce,X-Ca-Stage,X-Ca-Timestamp");
            //峰高验签头
            headers.Add("appkey", fengGaoAppKey);
            headers.Add("timestamp", timestamp.ToString());



            //======================================签名准备 
            //网关签名
            StringBuilder singstr = new StringBuilder();
            singstr.Append(httpMethod); singstr.Append("\n");
            singstr.Append(headers["Accept"]); singstr.Append("\n");
            if (headers.ContainsKey("Content-MD5")) singstr.Append(headers["Content-MD5"]);
            singstr.Append("\n");
            singstr.Append(headers["Content-Type"]); singstr.Append("\n");
            if (headers.ContainsKey("Date")) singstr.Append(headers["Date"]);
            singstr.Append("\n");
            //headers拼接
            StringBuilder headerstr = new StringBuilder();
            headerstr.Append("X-Ca-Key:"); headerstr.Append(headers["X-Ca-Key"]); headerstr.Append("\n");
            headerstr.Append("X-Ca-Nonce:"); headerstr.Append(headers["X-Ca-Nonce"]); headerstr.Append("\n");
            headerstr.Append("X-Ca-Stage:"); headerstr.Append(headers["X-Ca-Stage"]); headerstr.Append("\n");
            headerstr.Append("X-Ca-Timestamp:"); headerstr.Append(headers["X-Ca-Timestamp"]);
            singstr.Append(headerstr.ToString()); singstr.Append("\n");
            //如果有query参数 或者 form参数，添加path?param=param,具体见文档
            singstr.Append(path);
            headers.Add("X-Ca-Signature", CreateGateWaySign(gateWayAppSercert, singstr.ToString()));
            //蜂高签名
            headers.Add("sign", MD5(fengGaoAppKey + timestamp + fengGaoAppSercert));


            //========================================请求
            var httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(domain + path));
            httpRequest.Method = httpMethod;
            foreach (var header in headers)
            {
                if (header.Key == "Accept") httpRequest.Accept = header.Value;
                else if (header.Key == "Content-Type") httpRequest.ContentType = header.Value;
                else if (header.Key == "Date") httpRequest.Date = Convert.ToDateTime(header.Value);
                else httpRequest.Headers.Add(header.Key, header.Value);
            }
            byte[] data = Encoding.UTF8.GetBytes(ConvertJson(postData));
            Stream stream = httpRequest.GetRequestStream();
            stream.Write(data, 0, data.Length);
            using (var response = GetResponse(httpRequest))
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Method);
                Console.WriteLine(response.Headers);
                Stream st = response.GetResponseStream();
                StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
                Console.WriteLine(reader.ReadToEnd());
                Console.WriteLine(Constants.LF);
            }

        }





        public static string CreateGateWaySign(string appSercert, string signStr)
        {

            using (var algorithm = KeyedHashAlgorithm.Create("HMACSHA256"))
            {
                algorithm.Key = Encoding.UTF8.GetBytes(appSercert.ToCharArray());
                return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(signStr.ToCharArray())));
            }
        }




        public static string MD5(string Str, bool isUpper = false)
        {
            var bytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(Str));
            string ret = "";
            foreach (byte bb in bytes) { ret += Convert.ToString(bb, 16).PadLeft(2, '0'); }
            var result = ret.PadLeft(32, '0');
            return isUpper ? result.ToUpper() : result.ToLower();
        }




        public static string ConvertJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }



        private static HttpWebResponse GetResponse(HttpWebRequest httpRequest)
        {
            HttpWebResponse httpResponse = null;
            try
            {
                WebResponse response = httpRequest.GetResponse();
                httpResponse = (HttpWebResponse)response;

            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }
            return httpResponse;
        }



    }
}
