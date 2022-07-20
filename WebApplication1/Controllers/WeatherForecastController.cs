using ClassLibrary1;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Common;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{

    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly ActionCommon actioncommon;
        private readonly Https https;

        public WeatherForecastController(ILogger<WeatherForecastController> _logger,ActionCommon _actioncommon, Https _https)
        {
            logger = _logger;
            actioncommon = _actioncommon;
            https = _https;
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> post([FromBody]object1 obj,string parameter)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// sql获取会员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetMember()
        {
            var sql = "Select top 10 * from t_membercrm";
            var data = DBhelper.crm_member().Db().ExecuteDT(sql);
            //return new JsonResult(data);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 添加内存缓存值
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [HttpGet]
        public bool SetCache(string keyName,string value,int seconds)
        {
            var set = Cache.SetCacheValue(keyName, value, seconds);
            return set;
        }

        /// <summary>
        /// 获取内存缓存值
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetCache(string keyName)
        {
            var set = Cache.GetCacheValue(keyName);
            return set;
        }

        /// <summary>
        /// 邮件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic SendDirect()
        {
            return actioncommon.SendDirect();
        }

        /// <summary>
        /// 调用获取会员接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Action1()
        {
            var timestamp = actioncommon.TimeStamp();
            var md5 = actioncommon.MD5(timestamp);
            #region getAPI
            var dic = new Dictionary<string, string>();
            dic.Add("Token", "ad9d11b0-56b6-4e18-87b6-4c1fefc8a263");
            dic.Add("sign", md5);
            dic.Add("timestamp", timestamp);
            dic.Add("appKey", "O2O");
            var url = "https://sitcrmexternal.xfenggao.com/api/Profile/GetMemberDetail?memberInfo=" + "990000000000015";
            var resp = https.GetResponse("memberDetail", url,dic);
            #endregion

            #region 访问接口
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
            http.Method = "GET";
            http.Headers.Add("Token", "ad9d11b0-56b6-4e18-87b6-4c1fefc8a263");
            http.Headers.Add("sign", md5);
            http.Headers.Add("timestamp", timestamp);
            http.Headers.Add("appKey", "O2O");
            HttpWebResponse response = (HttpWebResponse)http.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
            string result = reader.ReadToEnd();
            HttpContext.Request.Headers[""].FirstOrDefault();
            return "get方法，action1";
            #endregion
            HttpClient client = new HttpClient();
            //client.httpClient.SetHeaders(heads);
            client.BaseAddress=new Uri("");


            //HttpClient httpClient;
            //httpClient = _httpClientFactory.CreateClient();
            ////拼接地址
            //var apiUrl = "";
            //HttpContent httpContents = new StringContent("", Encoding.UTF8, "application/json");
            //httpClient.DefaultRequestHeaders.Add("Token", "ad9d11b0-56b6-4e18-87b6-4c1fefc8a263");


            //WebClient webclient = new WebClient();
            //webclient.Headers.Add("","");
            //webclient.UploadDataTaskAsync("url","post",bytes);

        }

        /// <summary>
        /// redis简单使用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string RedisUse()
        {
            var con = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            var db = con.GetDatabase();
            //var keyValue = db.StringGetSet("key","value");
            //var keyValue1 = db.StringGetSet("a","a");
            //var keyValue2 = db.StringGetSet("b","b");
            var name1 = db.StringGet("a");
            var keys = db.Execute("keys","*");
            var key = ((RedisKey[])keys).Select(a=>a.ToString()).ToList();
            var value = ((RedisValue[])keys).Select(a => a.ToString()).ToList();
            //var db1 = con.GetDatabase(1);
            //db1.StringGetSet("KEY", "VALUE");
            //db1.StringGetSet("A", "A");
            //db1.StringGetSet("B", "B");
            var dic = new Dictionary<string, string>();
            for (int i = 0; i < key.Count; i++)
            {
                dic.Add(key[i],value[i]);
            }
            con.Close();
            return actioncommon.Json(dic);
            //MemcachedClientConfiguration
        }
        /// <summary>
        /// 导出
        /// </summary>
        [HttpPost]
        public void FileInfoUse(bool? aa)
        {
            DataTable table = new DataTable() {};
            table.Columns.Add("name");
            table.Columns.Add("age");
            table.Columns.Add("gender");
            table.Columns.Add("address");
            //table.Rows.Add(new string[] {"name","age","gender","address" });
            table.Rows.Add(new string[] {"李","18","男","上海" });
            table.Rows.Add(new string[] {"凌","19","男","湖南" });
            table.Rows.Add(new string[] {"君","20","男","四川" });
            //文件对象
            FileInfo file = new FileInfo("D:\\Project_Management\\.Core2\\downloag\\excel.xls");
            //工作簿对象
            HSSFWorkbook book=new NPOI.HSSF.UserModel.HSSFWorkbook();
            //Excel对象
            ISheet sheet = book.CreateSheet();
            //表格行
            IRow columnName = sheet.CreateRow(0);
            //添列名
            for (int i = 0; i < table.Columns.Count; i++)
            {
                columnName.CreateCell(i).SetCellValue(table.Columns[i].ToString());
            }
            //添值
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //表格行
                IRow row = sheet.CreateRow(i);
                for (int b = 0; b < table.Columns.Count; b++)
                {
                    row.CreateCell(b).SetCellValue((string)table.Rows[i][b]);
                }
            }
            using (MemoryStream ms=new MemoryStream())
            {
                book.Write(ms);
                ms.Seek(0,SeekOrigin.Begin);
                using (FileStream fileStream = new FileStream(file.FullName,FileMode.Create,FileAccess.Write))
                {
                    byte[] bytes = new byte[ms.Length];
                    ms.Read(bytes,0, (int)ms.Length);
                    fileStream.Write(bytes,0,bytes.Length);
                    fileStream.Close();
                    ms.Close();
                }
            }

        }

        /// <summary>
        /// 分段读取文件
        /// 默认每次读取 1M 数据
        /// </summary>
        /// <param name="sourceFile">文件全路径</param>
        /// <param name="readStart">读取的开始位置</param>
        /// <param name="contentLeave">是否还有剩下部分</param>
        /// <param name="splitFileSize">每次读取的片段长度</param>
        /// <param name="separate">分隔符号的ASCII码值</param>
        /// <returns></returns>
        [HttpGet]
        public string FileDownload(string sourceFile, ref long readStart, ref bool contentLeave, long splitFileSize = 1024 * 1024 * 1, char separate = '\n')
        {
            string resultContent = string.Empty;

            try
            {
                using (FileStream stream = new FileStream(@"C:\Users\EDY\Documents\WXWork\1688854799295419\Cache\File\2022-07\work(2).txt", FileMode.Open))
                {
                    long FileTotalLength = stream.Length;
                    if (readStart < FileTotalLength)
                    {
                        //创建二进制读取
                        using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8))
                        {
                            //直接将开始读取的位置设定到基础大小的字节上
                            //下面要做的是往后找到这一行的结束
                            reader.BaseStream.Position = splitFileSize + readStart - 1;
                            //判断当前位置不超过文件总大小
                            if (reader.BaseStream.Position <= FileTotalLength)
                            {
                                //往后挨个儿字符找换行
                                //这里要说明的是  reader.ReadByte() 方法执行时会自动将 reader.BaseStream.Position 的值向后+1
                                //网上有些例子执行了 ReadByte 另外还做 Position++  明显是有字符隔掉的
                                while (reader.BaseStream.Position < FileTotalLength && reader.ReadByte() != separate) { }

                                //这里获得现在找到换行的那个字节上的位置到这次遍历开始的位置中间的字节数量
                                //+1 是为了把找到的那个换行符也带上
                                int readWrodCountNow = (int)(reader.BaseStream.Position - readStart);
                                //把读取的起始位置重置到这次查询的开始位置
                                reader.BaseStream.Position = readStart;
                                //把这次读取的内容写入到新文件
                                resultContent = Encoding.UTF8.GetString(reader.ReadBytes(readWrodCountNow));
                            }
                            else
                            {
                                reader.BaseStream.Position = readStart;
                                resultContent = Encoding.UTF8.GetString(reader.ReadBytes(BaseExtensions.ToInt((FileTotalLength - readStart + 1), 0)));
                            }
                            //将这次读取到的位置作为下次的起始位置
                            readStart = reader.BaseStream.Position;
                            contentLeave = readStart < FileTotalLength;
                            //去除隐藏字符 byte值为65279  unicode的文件第一个字符会出现
                            resultContent = resultContent.Replace(((char)65279).ToString(), "");
                            return resultContent;
                        }
                    }
                    else
                    {
                        contentLeave = false;
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                contentLeave = false;
                return "";
            }
        }
        [HttpPost]
        public string Action2()
        {
            return "post方法，action2";
        }
        //public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        //{
        //    var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
        //    if (property != null)
        //    {
        //        var collection = property.GetValue(header, null) as NameValueCollection;
        //        collection[name] = value;
        //    }
        //}

        //public void Index()
        //{
        //    HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("Url");
        //    rq.Method = "GET";
        //    SetHeaderValue(rq.Headers, "Host", "127.0.0.1");
        //    SetHeaderValue(rq.Headers, "Connection", "keep-alive");
        //    SetHeaderValue(rq.Headers, "Accept", "*/*");
        //    SetHeaderValue(rq.Headers, "X-Requested-With", "XMLHttpRequest");
        //    SetHeaderValue(rq.Headers, "User-Agent", "...");
        //    SetHeaderValue(rq.Headers, "Referer", "http://127.0.0.1/index.php?m=Index&a=indexs");
        //    SetHeaderValue(rq.Headers, "Accept-Encoding", "gzip, deflate");
        //    SetHeaderValue(rq.Headers, "Accept-Language", "1.5");
        //    SetHeaderValue(rq.Headers, "Cookie", "This is Cookie");

        //    HttpWebResponse resp = (HttpWebResponse)rq.GetResponse();

        //    using (Stream stream = resp.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(stream, Encoding.Default);
        //        string responseString = reader.ReadToEnd();
        //    }
        //}


        #region Class
        public class object1{
            public int id { get; set; }
            public string name { get; set; }
        }
        #endregion
    }
}
