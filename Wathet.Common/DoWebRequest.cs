using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using static Wathet.Common.ComEnum;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Wathet.Common.Entity;
using Microsoft.Extensions.Azure;

namespace Wathet.Common
{
    public static class DoWebRequest
    {
        #region //是否是PC浏览器

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
            string curBrowser = http.GetUserAgent();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region //是否是手机浏览器
        /// <summary>
        /// 是否是手机浏览器
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsMobileBrowser(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            //regex from http://detectmobilebrowsers.com/
            Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            var userAgent = http.GetUserAgent();
            if ((b.IsMatch(userAgent) || v.IsMatch(userAgent.Substring(0, 4))))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region //获取请求信息

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetHeaders(this Microsoft.AspNetCore.Http.HttpContext http, string strName)
        {
            return http.Request.Headers[strName].FirstOrDefault();
        }


        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            try
            {
                var IP = http.GetHeaders("X-Forwarded-For");
                if (string.IsNullOrEmpty(IP))
                {
                    IP = http.Connection.RemoteIpAddress.ToString();
                }
                return IP;
            }
            catch { }
            return "";
        }


        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetServerIP(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            try
            {
                var IP = http.Connection.LocalIpAddress.MapToIPv4().ToString();

                return IP;
            }
            catch { }
            return "";
        }



        /// <summary>
        /// 获取请求的协议 是Http / Https 或者其他
        /// </summary>
        /// <returns></returns>
        public static string GetProtocol(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            var Protocol = http.GetHeaders("X-Original-Proto");
            if (string.IsNullOrEmpty(Protocol))
            {
                Protocol = http.Request.Protocol;
            }
            return Protocol;
        }

        /// <summary>
        /// 获取请求的内容方式
        /// </summary>
        public static string GetContentType(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            if (http.Request != null && http.Request.Method != null)
            {
                return (http.Request.ContentType ?? "").ToLower();
            }
            return string.Empty;

        }

        /// <summary>
        /// 获取请求的方式
        /// </summary>
        /// <returns></returns>
        public static string GetMethod(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            if (http.Request != null && http.Request.Method != null)
            {
                return http.Request.Method.ToUpper();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取用户代理(浏览器名)
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static string GetUserAgent(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            return http.GetHeaders("User-Agent");
        }
        /// <summary>
        /// 获取请求的完整路径
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static string GetRequestURL(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            try
            {
                return http.GetProtocol() + "://" + http.Request.Host.Value + http.Request.Path.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToSimple("获取当前请求地址出错"));
                return string.Empty;
            }
        }

        #endregion

        #region //获取版本

        private static FileVersionInfo AssemblyFileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        /// <summary>
        /// 获得Assembly版本号
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyVersion()
        {
            return string.Format("{0}.{1}.{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);
        }

        /// <summary>
        /// 获得Assembly产品名称
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyProductName()
        {
            return AssemblyFileVersion.ProductName;
        }

        /// <summary>
        /// 获得Assembly产品版权
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyCopyright()
        {
            return AssemblyFileVersion.LegalCopyright;
        }
        #endregion

        #region //编码和解码URL

        /// <summary>
        /// 对Url地址进行 编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// 对URL地址进行 解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }
        #endregion

        #region //GetQueryString
        /// <summary>
        /// 根据参数名获取值
        /// </summary>
        /// <param name="http"></param>
        /// <param name="ParamName"></param>
        /// <returns></returns>
        public static string GetQueryStringValueByName(this Microsoft.AspNetCore.Http.HttpContext http, string ParamName)
        {
            var dic = http.GetQueryStringToDic();
            if (dic.ContainsKey(ParamName.ToLower()))
            {
                return dic[ParamName.ToLower()];
            }
            return string.Empty;
        }

        /// <summary>
        /// 将QueryString值转换为键值对Dic<string,string>
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStringToDic(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            var result = new Dictionary<string, string>();
            var query = http.GetQueryString();
            if (!string.IsNullOrEmpty(query))
            {
                var temp = query.Split(new char[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                temp.ForEach(tt =>
                {
                    var temp2 = tt.ToLower().Split('=');
                    if (temp2.Length == 2)
                    {
                        if (!result.ContainsKey(temp2[0]))
                        {
                            result.Add(temp2[0], temp2[1]);
                        }
                    }
                });
            }
            return result;
        }

        /// <summary>
        /// 将QueryString值转换为键值对Dic(键转化小写，值不处理)
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetQueryStringToKeyLowerDic(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            var result = new Dictionary<string, string>();
            var query = http.GetQueryString();
            if (!string.IsNullOrEmpty(query))
            {
                var temp = query.Split(new char[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                temp.ForEach(tt =>
                {
                    var temp2 = tt.Split('=');
                    if (temp2.Length == 2)
                    {
                        if (!result.ContainsKey(temp2[0].ToLower()))
                        {
                            result.Add(temp2[0].ToLower(), temp2[1]);
                        }
                    }
                });
            }
            return result;
        }

        /// <summary>
        /// 获取URL参数值列表
        /// </summary>
        /// <returns></returns>
        public static string GetQueryString(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            var Reque = http.Request;
            if (Reque != null && Reque.QueryString.HasValue)
            {
                return Reque.QueryString.Value;
            }
            return string.Empty;
        }


        #endregion

        #region //GetBodyForm

        /// <summary>
        /// 获取Body里的参数
        /// </summary>
        public static async Task<string> GetBodyForm(this Microsoft.AspNetCore.Http.HttpContext http)
        {
            var content = string.Empty;
            var request = http.Request;
            if (request.ContentLength != null && request.ContentLength > 0)
            {
                try
                {
                    request.Body.Position = 0;//表示设定从Body流起始位置开始，读取整个Htttp请求的Body数据。
                    StreamReader streamReader = new StreamReader(http.Request.Body, Encoding.UTF8);
                    content = await streamReader.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(content))
                        content = content.Replace("\n", "").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
                    request.Body.Position = 0;//表示在读取到Body后，重新设置Stream到起始位置，方便后面的Filter或Middleware使用Body的数据。
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return string.Empty;
                }
            }
            return content;
        }

        #endregion

        #region //工具 拆分参数字符串到键值对

        public static Dictionary<string, string> GetDicFromStr(string strParam)
        {
            if (strParam.StartsWith('{')) return strParam.ToObjectFromJson<Dictionary<string, string>>();
            var dic = new Dictionary<string, string>();
            var value = UrlDecode(strParam).ToLower().Split(new char[] { '?', '&' }, StringSplitOptions.RemoveEmptyEntries);
            value.ToList().ForEach(str =>
            {
                var kv = str.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (kv.Length == 2)
                {
                    if (dic.ContainsKey(kv[0])) { dic[kv[0]] = kv[1]; } else { dic.Add(kv[0], kv[1]); }
                }
            });
            return dic;
        }
        #endregion


        /// <summary>
        /// 根据Dictionary参数获取form-data参数类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetFormParmsByDictionary(Dictionary<string, string> data)
        {
            if (data == null || data.Count == 0) return string.Empty;
            var first = true;
            string str = string.Empty;
            foreach (var item in data)
            {
                if (first)
                {
                    str = $"{item.Key}={item.Value}";
                    first = false;
                }
                else
                {
                    str = str + $"&{item.Key}={item.Value}";
                }
            }
            return str;
        }

        #region //模拟发送请求 用于接口调用
        /// <summary>
        /// Post提交Url，并获取返回值
        /// </summary>
        /// <param name="posturl">提交到的页面</param>
        /// <param name="postData">post参数 要拼接在Body中的参数</param>
        /// <param name="getData">url参数(例：name=jim&age=1&height=177)</param>
        /// <param name="encodeStr">编码方式(例："gb2312","utf-8")</param>
        /// <param name="TimeOut">超时时间(单位:毫秒) 可以设置,默认100秒 </param>
        /// <returns>请求返回的数据</returns>
        public static string SendRequest_Post(string posturl, string postData, string getData = "", string ContentType = "application/json", string encodeStr = "UTF-8", int TimeOut = 100 * 1000, string httpMethod = "POST", Dictionary<string, string> head = null)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = System.Text.Encoding.GetEncoding(encodeStr);
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                getData = string.IsNullOrEmpty(getData) ? string.Empty : (getData.StartsWith("?") ? getData : "?" + getData);
                // 设置参数
                request = WebRequest.Create(posturl + getData) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = httpMethod;
                request.ContentType = ContentType;// "application/x-www-form-urlencoded ; charset=UTF-8";
                request.ContentLength = data.Length;
                request.Timeout = TimeOut;
                request.Proxy = null;
                if (head != null)
                {
                    foreach (var key in head.Keys)
                    {
                        request.Headers.Add(key, head[key]);
                    }
                }
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                if (ex is WebException)
                {
                    using (WebResponse eResponse = (ex as WebException).Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)eResponse;
                        using (Stream eData = eResponse.GetResponseStream())
                        {
                            using (var reader = new StreamReader(eData))
                            {
                                string text = reader.ReadToEnd();
                                Console.WriteLine(text);
                            }
                        }
                    }
                }
                return string.Empty;
            }
        }


        /// <summary>
        /// Post提交Url，并获取返回值
        /// </summary>
        /// <param name="posturl">提交到的页面</param>
        /// <param name="postData">post参数 要拼接在Body中的参数</param>
        /// <param name="getData">url参数(例：name=jim&age=1&height=177)</param>
        /// <param name="encodeStr">编码方式(例："gb2312","utf-8")</param>
        /// <param name="TimeOut">超时时间(单位:毫秒) 可以设置,默认100秒 </param>
        /// <returns>请求返回的数据</returns>
        public static string SendRequestWithHeader_Post(string posturl, string postData, string Token, string SvcAuth, string ProfileToken, string getData = "", string ContentType = "application/json", string encodeStr = "UTF-8", int TimeOut = 100 * 1000, string httpMethod = "POST")
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = System.Text.Encoding.GetEncoding(encodeStr);
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                getData = string.IsNullOrEmpty(getData) ? string.Empty : (getData.StartsWith("?") ? getData : "?" + getData);
                // 设置参数
                request = WebRequest.Create(posturl + getData) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = httpMethod;
                request.ContentType = ContentType;// "application/x-www-form-urlencoded ; charset=UTF-8";
                request.ContentLength = data.Length;
                request.Timeout = TimeOut;
                request.Proxy = null;
                if (!string.IsNullOrWhiteSpace(Token))
                {
                    request.Headers.Add("Token", Token);
                }
                if (!string.IsNullOrWhiteSpace(SvcAuth))
                {
                    request.Headers.Add("SvcAuth", SvcAuth);
                }
                if (!string.IsNullOrWhiteSpace(ProfileToken))
                {
                    request.Headers.Add("ProfileToken", ProfileToken);
                }

                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                if (ex is WebException)
                {
                    using (WebResponse eResponse = (ex as WebException).Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)eResponse;
                        using (Stream eData = eResponse.GetResponseStream())
                        {
                            using (var reader = new StreamReader(eData))
                            {
                                string text = reader.ReadToEnd();
                                Console.WriteLine(text);
                            }
                        }
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Get提交Url，并获取返回值
        /// </summary>
        /// <param name="url">提交到的页面</param>
        /// <param name="paramData">url参数(例：name=jim&age=1&height=177)</param>
        /// <param name="encodeStr">编码方式(例："gb2312","utf-8")</param>
        /// <returns>请求返回的数据</returns>
        public static string SendRequestWithHeader_Get(string url, string Token, string SvcAuth, string ProfileToken, string paramData = "", string encodeStr = "UTF-8", string ContentType = "application/json")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (paramData.Length > 0 ? "?" + paramData : ""));
            request.Method = "GET";
            request.Proxy = null;
            request.ContentType = ContentType;
            if (!string.IsNullOrWhiteSpace(Token))
            {
                request.Headers.Add("Token", Token);
            }
            if (!string.IsNullOrWhiteSpace(SvcAuth))
            {
                request.Headers.Add("SvcAuth", SvcAuth);
            }
            if (!string.IsNullOrWhiteSpace(ProfileToken))
            {
                request.Headers.Add("ProfileToken", ProfileToken);
            }
            ServicePointManager.Expect100Continue = false;

            HttpWebResponse response = null;
            try
            {

                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                    {
                        string retString = myStreamReader.ReadToEnd();
                        return retString;
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    var stream = e.Response.GetResponseStream();
                    var streamReader = new StreamReader(stream);
                    if (stream.CanRead)
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response.Dispose();
                }
                if (request != null)
                    request.Abort();
            }
        }




        /// <summary>
        /// Get提交Url，并获取返回值
        /// </summary>
        /// <param name="url">远程访问的地址</param>
        /// <param name="data">参数</param>
        /// <param name="head">head</param>
        /// <returns>远程页面调用结果</returns>
        public static string SendRequest_Get(string url, string data, Dictionary<string, string> head)
        {
            HttpWebRequest request = null;
            url = url + (data.Length > 0 ? "?" + data : "");
            request = WebRequest.Create(url) as HttpWebRequest;
            if (head != null)
            {
                foreach (var key in head.Keys)
                {
                    request.Headers[key] = head[key];

                }
            }

            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamIn = response.GetResponseStream();

            StreamReader reader = new StreamReader(streamIn);
            string result = reader.ReadToEnd();
            reader.Close();
            streamIn.Close();
            response.Close();

            return result;
        }

        /// <summary>
        /// Get提交Url，并获取返回值
        /// </summary>
        /// <param name="url">提交到的页面</param>
        /// <param name="paramData">url参数(例：name=jim&age=1&height=177)</param>
        /// <param name="encodeStr">编码方式(例："gb2312","utf-8")</param>
        /// <returns>请求返回的数据</returns>
        public static string SendRequest_Get(string url, string paramData = "", string encodeStr = "UTF-8", string ContentType = "application/json", string subscriptionKey = "")
        {
            #region MyRegion
            //try
            //{
            //    var request = new HttpRequestMessage(HttpMethod.Get, url);


            //    using (var httpClient = new HttpClient())
            //    {


            //        httpClient.DefaultRequestHeaders.Add("Accept", ContentType);
            //        httpClient.DefaultRequestHeaders.Add("AcceptCharset", encodeStr);
            //        // response
            //        var response = httpClient.GetAsync(url + (paramData.Length > 0 ? "?" + paramData : "")).Result;
            //        var data = response.Content.ReadAsStringAsync().Result;
            //        return data;//接口调用成功获取的数据
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return string.Empty;
            //}
            #endregion

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (paramData.Length > 0 ? "?" + paramData : ""));
            request.Method = "GET";
            request.Proxy = null;
            request.ContentType = ContentType;
            if (!string.IsNullOrWhiteSpace(subscriptionKey))
            {
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            }
            ServicePointManager.Expect100Continue = false;

            HttpWebResponse response = null;
            try
            {

                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                    {
                        string retString = myStreamReader.ReadToEnd();
                        return retString;
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    var stream = e.Response.GetResponseStream();
                    var streamReader = new StreamReader(stream);
                    if (stream.CanRead)
                    {
                        return streamReader.ReadToEnd();
                    }
                }
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response.Dispose();
                }
                if (request != null)
                    request.Abort();
            }
        }


        /// <summary>
        /// post请求数据（注意，此方法只支持json传参）
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="requestJson">json参数</param>
        /// <returns>返回json格式的字符串</returns>
        public static string PostAsync(string url, string requestJson, Dictionary<string, string> head = null)
        {
            #region 这种模式好像会有等待
            //string result = "";
            //try
            //{
            //    Uri postUrl = new Uri(url);

            //    using (HttpContent httpContent = new StringContent(requestJson))
            //    {
            //        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //        if (head != null)
            //        {
            //            foreach (var key in head.Keys)
            //            {
            //                httpContent.Headers.Add(key, head[key]);
            //            }
            //        }
            //        using (var httpClient = new HttpClient())
            //        {
            //            httpClient.Timeout = new TimeSpan(0, 0, 60);
            //            result = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    result = $"Error:接口调用出错,{ex.Message}";
            //}
            //return result;
            #endregion

            var byts = Encoding.UTF8.GetBytes(requestJson);
            var postStream = new System.IO.MemoryStream(byts);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = postStream != null ? postStream.Length : 0;
            if (head != null)
            {
                foreach (var key in head.Keys)
                {
                    request.Headers.Add(key, head[key]);
                }
            }
            // request.ServicePoint.Expect100Continue = false;
            ServicePointManager.Expect100Continue = false;
            if (postStream != null)
            {
                //postStream.Position = 0;
                //上传文件流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                postStream.Close();//关闭文件访问
            }
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response != null && e.Response.ContentLength > 0)
                {
                    var stream = e.Response.GetResponseStream();
                    var streamReader = new StreamReader(stream);
                    if (stream.CanRead)
                    {
                        var s = streamReader.ReadToEnd();
                        return s;
                    }
                }
                return "";
            }

            using (Stream responseStream = response.GetResponseStream())
            {

                using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                {
                    return myStreamReader.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// post请求数据（注意，此方法只支持json传参）
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="requestJson">json参数</param>
        /// <returns>返回json格式的字符串</returns>
        public static string WebRequestAsync(string url, string requestJson, Dictionary<string, string> head = null, string Method = "POST")
        {
            #region 这种模式好像会有等待
            //string result = "";
            //try
            //{
            //    Uri postUrl = new Uri(url);

            //    using (HttpContent httpContent = new StringContent(requestJson))
            //    {
            //        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //        if (head != null)
            //        {
            //            foreach (var key in head.Keys)
            //            {
            //                httpContent.Headers.Add(key, head[key]);
            //            }
            //        }
            //        using (var httpClient = new HttpClient())
            //        {
            //            httpClient.Timeout = new TimeSpan(0, 0, 60);
            //            result = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            //        }

            //    }

            //}
            //catch (Exception ex)
            //{
            //    result = $"Error:接口调用出错,{ex.Message}";
            //}
            //return result;
            #endregion

            var byts = Encoding.UTF8.GetBytes(requestJson);
            var postStream = new System.IO.MemoryStream(byts);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            request.Method = Method;
            request.ContentType = "application/json";
            request.ContentLength = postStream != null ? postStream.Length : 0;
            if (head != null)
            {
                foreach (var key in head.Keys)
                {
                    request.Headers.Add(key, head[key]);
                }
            }
            // request.ServicePoint.Expect100Continue = false;
            ServicePointManager.Expect100Continue = false;
            if (postStream != null)
            {
                //postStream.Position = 0;
                //上传文件流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                postStream.Close();//关闭文件访问
            }
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response != null && e.Response.ContentLength > 0)
                {
                    var stream = e.Response.GetResponseStream();
                    var streamReader = new StreamReader(stream);
                    if (stream.CanRead)
                    {
                        var s = streamReader.ReadToEnd();
                        return s;
                    }
                }
                return "";
            }

            using (Stream responseStream = response.GetResponseStream())
            {

                using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")))
                {
                    return myStreamReader.ReadToEnd();
                }
            }
        }
        #endregion


        /// <summary>
        /// 模拟请求数据（注意，此方法只支持json传参）
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="requestJson">json参数</param>
        /// <param name="headers">headers参数</param>
        /// <param name="httpMethod">请求方式</param>
        /// <returns>返回json格式的字符串</returns>
        public static (HttpStatusCode statusCode, string content) HttpRequestReturnValueTuple(string url, string requestJson, Dictionary<string, string> headers = null, string httpMethod = "post")
        {
            #region MyRegion
            HttpStatusCode statusCode;
            string content;
            try
            {
                using (HttpContent httpContent = new StringContent(requestJson))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpClientHandler handler = new HttpClientHandler()
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    };
                    using (var httpClient = new HttpClient(handler))
                    {
                        if (headers != null)
                        {
                            foreach (var item in headers)
                            {
                                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                            }
                        }
                        httpClient.Timeout = TimeSpan.FromMinutes(30);
                        HttpResponseMessage httpResult;
                        httpMethod = httpMethod.ToLower();
                        switch (httpMethod)
                        {
                            case "put":
                                httpResult = httpClient.PutAsync(url, httpContent).Result;
                                break;
                            case "get":
                                httpResult = httpClient.GetAsync(url).Result;
                                break;
                            case "patch":
                                httpResult = httpClient
                                    .SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url)
                                    {
                                        Content = httpContent
                                    }).Result;
                                break;
                            case "delete":
                                httpResult = httpClient.DeleteAsync(url).Result;
                                break;
                            case "head":
                                httpResult = httpClient
                                    .SendAsync(new HttpRequestMessage(new HttpMethod("HEAD"), url)
                                    {
                                        Content = httpContent
                                    }).Result;
                                break;
                            default:
                                httpResult = httpClient.PostAsync(url, httpContent).Result;
                                break;
                        }
                        statusCode = httpResult.StatusCode;
                        content = httpResult.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception e)
            {
                return (0, e.Message);
            }
            return (statusCode, content);
            #endregion



        }
        /// <summary>
        /// 模拟请求数据（注意，此方法只支持json传参）
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="requestJson">json参数</param>
        /// <param name="headers">headers参数</param>
        /// <param name="httpMethod">请求方式</param>
        /// <returns>返回json格式的字符串</returns>
        public static async Task<HttpResponseMessage> HttpRequestAsync(string url, string requestJson, Dictionary<string, string> headers = null, string httpMethod = "get")
        {
            HttpResponseMessage httpResult;
            try
            {
                using HttpContent httpContent = new StringContent(requestJson);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                using var httpClient = new HttpClient(handler);
                if (headers != null)
                {
                    foreach (var (key, value) in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(key, value);
                    }
                }
                httpClient.Timeout = TimeSpan.FromMinutes(30);
                httpMethod = httpMethod.ToLower();
                httpResult = httpMethod switch
                {
                    "put" => await httpClient.PutAsync(url, httpContent),
                    "get" => await httpClient.PostAsync(url, httpContent),
                    "patch" => await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = httpContent }),
                    "delete" => await httpClient.DeleteAsync(url),
                    "head" => await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("HEAD"), url) { Content = httpContent }),
                    _ => await httpClient.GetAsync(url)
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(e.Message)
                };
            }
            return httpResult;
        }


        /// <summary>
        /// 模拟请求数据（注意，此方法只支持json传参）
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="requestJson">json参数</param>
        /// <param name="headers">headers参数</param>
        /// <param name="httpMethod">请求方式</param>
        /// <returns>返回json格式的字符串</returns>
        public static (HttpStatusCode statusCode, string content) HttpRequestByForm(string url, string requestJson, Dictionary<string, string> headers = null)
        {
            #region MyRegion
            HttpStatusCode statusCode;
            string content;
            try
            {
                using HttpContent httpContent = new StringContent(requestJson);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                using var httpClient = new HttpClient();
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                httpClient.Timeout = new TimeSpan(0, 0, 100);
                HttpResponseMessage httpResult = httpClient.PostAsync(url, httpContent).Result;
                statusCode = httpResult.StatusCode;
                content = httpResult.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return (0, e.Message);
            }
            return (statusCode, content);
            #endregion



        }

        public static (HttpStatusCode statusCode, string content, HttpResponseHeaders responseHeaders) HttpRequest(string url, string requestJson, Dictionary<string, string> headers = null, string httpMethod = "post")
        {
            #region MyRegion
            HttpStatusCode statusCode;
            string content;
            HttpResponseHeaders responseHeaders;
            try
            {
                using (HttpContent httpContent = new StringContent(requestJson))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (var httpClient = new HttpClient())
                    {
                        if (headers != null)
                        {
                            foreach (var item in headers)
                            {
                                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                            }
                        }
                        httpClient.Timeout = new TimeSpan(0, 0, 100);
                        HttpResponseMessage httpResult;
                        httpMethod = httpMethod.ToLower();
                        switch (httpMethod)
                        {
                            case "put":
                                httpResult = httpClient.PutAsync(url, httpContent).Result;
                                break;
                            case "get":
                                httpResult = httpClient.GetAsync(url).Result;
                                break;
                            case "patch":
                                httpResult = httpClient
                                    .SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url)
                                    {
                                        Content = httpContent
                                    }).Result;
                                break;
                            case "delete":
                                httpResult = httpClient.DeleteAsync(url).Result;
                                break;
                            case "head":
                                httpResult = httpClient
                                    .SendAsync(new HttpRequestMessage(new HttpMethod("HEAD"), url)
                                    {
                                        Content = httpContent
                                    }).Result;
                                break;
                            default:
                                httpResult = httpClient.PostAsync(url, httpContent).Result;
                                break;
                        }
                        statusCode = httpResult.StatusCode;
                        content = httpResult.Content.ReadAsStringAsync().Result;
                        responseHeaders = httpResult.Headers;

                    }
                }
            }
            catch (Exception e)
            {
                return (0, e.Message, null);
            }
            return (statusCode, content, responseHeaders);
            #endregion
        }

        public static (HttpStatusCode statusCode, Stream content) HttpRequestReturnStream(string url, string requestJson, Dictionary<string, string> headers = null)
        {
            HttpStatusCode statusCode;
            Stream content;
            try
            {
                using HttpContent httpContent = new StringContent(requestJson);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using var httpClient = new HttpClient();
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                httpClient.Timeout = new TimeSpan(0, 0, 100);
                HttpResponseMessage httpResult = httpClient.GetAsync(url).Result;
                statusCode = httpResult.StatusCode;
                content = httpResult.Content.ReadAsStreamAsync().Result;
            }
            catch (Exception e)
            {
                return (0, null);
            }
            return (statusCode, content);
        }


        #region 兼容层调用
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }
        /// <summary>
        /// 使用Get方法获取字符串结果（加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static HttpPostResult HttpGet(string url, string token, string svcAuth, string profileToken, CookieContainer cookieContainer = null, Encoding encoding = null)
        {
            var timeLog = "开始时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //request.Timeout = 10000;
            request.Proxy = null;
            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;
            }
            if (!string.IsNullOrWhiteSpace(svcAuth))
            {
                request.Headers.Add("SvcAuth", svcAuth);
            }
            ServicePointManager.DefaultConnectionLimit = 200;
            ServicePointManager.Expect100Continue = false;
            if (url.StartsWith("https://"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //request.ServicePoint.Expect100Continue = false;
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("Token", token);
            }
            if (!string.IsNullOrWhiteSpace(profileToken))
            {
                request.Headers.Add("ProfileToken", profileToken);
            }
            HttpWebResponse response = null;
            try
            {
                timeLog += ",开始请求时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                response = (HttpWebResponse)request.GetResponse();
                timeLog += ",请求结束时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();

                if (cookieContainer != null)
                {
                    response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.GetEncoding("utf-8")))
                    {
                        string retString = myStreamReader.ReadToEnd();
                        timeLog += ",Response输出时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                        return new HttpPostResult { StatusCode = response.StatusCode, Result = true, Data = retString, TimeLog = timeLog };
                    }
                }
            }
            catch (WebException e)
            {
                timeLog += ",请求异常时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                var stream = e.Response.GetResponseStream();
                var streamReader = new StreamReader(stream);
                var errstr = streamReader.ReadToEnd();
                timeLog += ",请求异常结束时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                if (stream.CanRead)
                {
                    return new HttpPostResult { StatusCode = response.StatusCode, Result = false, Data = errstr, TimeLog = timeLog };
                }
                return new HttpPostResult { StatusCode = response.StatusCode, Result = false, Data = e.Message, TimeLog = timeLog };
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }

                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }


        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="isFile">postStreams是否是文件流</param>
        /// <returns></returns>
        public static HttpPostResult HttpPostWithHeader(string url, string token, string svcAuth = "", CookieContainer cookieContainer = null, Stream postStream = null, bool isFile = false, Encoding encoding = null, string profileToken = "", string httpMethod = "POST", string ApimSubscriptionKey = "")
        {
            var timeLog = "开始时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpMethod;
            request.ContentType = "application/json";
            request.ContentLength = postStream != null ? postStream.Length : 0;
            //request.Timeout = 10000;
            request.Proxy = null;
            if (!string.IsNullOrWhiteSpace(svcAuth))
            {
                request.Headers.Add("SvcAuth", svcAuth);
            }
            ServicePointManager.DefaultConnectionLimit = 200;
            ServicePointManager.Expect100Continue = false;
            if (url.StartsWith("https://"))
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // request.ServicePoint.Expect100Continue = false;
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Add("Token", token);
            }
            if (!string.IsNullOrWhiteSpace(profileToken))
            {
                request.Headers.Add("ProfileToken", profileToken);
            }
            if (!string.IsNullOrWhiteSpace(ApimSubscriptionKey))
            {
                request.Headers.Add("Ocp-Apim-Subscription-Key", ApimSubscriptionKey);
            }
            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;
            }

            if (postStream != null && postStream.Length > 0)
            {
                timeLog += ",写入流请求时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                //postStream.Position = 0;

                //上传文件流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                postStream.Close();//关闭文件访问
                postStream = null;
                timeLog += ",写入流结束时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
            }

            HttpWebResponse response = null;
            try
            {
                timeLog += ",开始请求时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                response = (HttpWebResponse)request.GetResponse();
                timeLog += ",请求结束时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();

                if (cookieContainer != null)
                {
                    response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.GetEncoding("utf-8")))
                    {
                        var retString = myStreamReader.ReadToEnd();
                        timeLog += ",Response输出时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                        return new HttpPostResult { StatusCode = response.StatusCode, Result = true, Data = retString, TimeLog = timeLog };
                    }
                }
            }
            catch (WebException e)
            {
                timeLog += ",请求异常时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                if (e.Response != null && e.Response.ContentLength > 0)
                {
                    var stream = e.Response.GetResponseStream();
                    var streamReader = new StreamReader(stream);
                    timeLog += ",请求异常结束时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                    if (stream.CanRead)
                    {
                        return new HttpPostResult { StatusCode = response.StatusCode, Result = false, Data = streamReader.ReadToEnd(), TimeLog = timeLog };
                    }
                }
                return new HttpPostResult { StatusCode = response.StatusCode, Result = false, Data = e.Message, TimeLog = timeLog };
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                    request = null;
                }

                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }


        /// <summary>
        /// 异步获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="svcAuth"></param>
        /// <param name="postStream"></param>
        /// <param name="profileToken"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        public static HttpPostResult HttpRequestWithHeader(string url, string token, string svcAuth = "", string profileToken = "", string postStream = "", string httpMethod = "POST")
        {
            var timeLog = "开始时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证
                ServicePointManager.DefaultConnectionLimit = 1000;
                if (url.StartsWith("https://"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (HttpContent httpContent = new StringContent(postStream))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpClientHandler handler = new HttpClientHandler()
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    };
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                    using (var httpClient = new HttpClient(handler))
                    {
                        if (!string.IsNullOrWhiteSpace(svcAuth))
                        {
                            httpClient.DefaultRequestHeaders.Add("SvcAuth", svcAuth);
                        }
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            httpClient.DefaultRequestHeaders.Add("Token", token);
                        }
                        if (!string.IsNullOrWhiteSpace(profileToken))
                        {
                            httpClient.DefaultRequestHeaders.Add("ProfileToken", profileToken);
                        }
                        httpClient.Timeout = TimeSpan.FromMinutes(30);
                        HttpResponseMessage httpResult;
                        httpMethod = httpMethod.ToLower();
                        timeLog += ",开始请求时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                        switch (httpMethod)
                        {
                            case "put":
                                httpResult = httpClient.PutAsync(url, httpContent).Result;
                                break;
                            case "get":
                                httpResult = httpClient.GetAsync(url).Result;
                                break;
                            case "patch":
                                httpResult = httpClient
                                    .SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url)
                                    {
                                        Content = httpContent
                                    }).Result;
                                break;
                            case "delete":
                                httpResult = httpClient.DeleteAsync(url).Result;
                                break;
                            case "head":
                                httpResult = httpClient
                                    .SendAsync(new HttpRequestMessage(new HttpMethod("HEAD"), url)
                                    {
                                        Content = httpContent
                                    }).Result;
                                break;
                            default:
                                httpResult = httpClient.PostAsync(url, httpContent).Result;
                                break;
                        }
                        timeLog += ",请求结束时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                        switch (httpResult.StatusCode)
                        {
                            case HttpStatusCode.Created:
                            case HttpStatusCode.OK:
                            case HttpStatusCode.NoContent:
                                return new HttpPostResult { StatusCode = httpResult.StatusCode, Result = true, Data = httpResult.Content.ReadAsStringAsync().Result, TimeLog = timeLog };
                            case HttpStatusCode.NotFound:
                                return new HttpPostResult { StatusCode = httpResult.StatusCode, Result = false, Data = httpResult.Content.ReadAsStringAsync().Result, TimeLog = timeLog };
                            default:
                                return new HttpPostResult { StatusCode = httpResult.StatusCode, Result = false, Data = httpResult.Content.ReadAsStringAsync().Result, TimeLog = timeLog };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                timeLog += ",请求异常时间：" + DateTime.Now.Format_yyyyMMddHHmmssfff();
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += ex.InnerException.InnerException;

                return new HttpPostResult { Result = false, Data = msg, TimeLog = timeLog };
            }
        }
        #endregion
    }
}