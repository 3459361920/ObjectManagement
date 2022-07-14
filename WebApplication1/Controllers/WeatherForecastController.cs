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
        /// 获取会员
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
        [HttpGet]
        public string Action1()
        {
            var send= actioncommon.SendDirect();
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
        [HttpPost]
        public string RedisUse()
        {
            var con = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            var db = con.GetDatabase();
            var keyValue = db.StringGetSet("key","value");
            var keyValue1 = db.StringGetSet("a","a");
            var keyValue2 = db.StringGetSet("b","b");
            var name1 = db.StringGet("a");
            var keys = db.Execute("keys","*");
            var key = ((RedisKey[])keys).Select(a=>a.ToString());
            var value = ((RedisValue[])keys).Select(a => a.ToString()) as List<string>;
            var zz = value[0];
            var db1 = con.GetDatabase(1);
            db1.StringGetSet("KEY", "VALUE");
            db1.StringGetSet("A", "A");
            db1.StringGetSet("B", "B");
            var dic = new Dictionary<string, string>();
            con.Close();
            return actioncommon.Json(keys);
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
