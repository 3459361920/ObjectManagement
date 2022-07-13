using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class WxMerchantController1 : BaseController
    {
        private readonly ActionCommon actioncommon;
        private readonly Https https;

        public WxMerchantController1( ActionCommon _actioncommon, Https _https)
        {
            actioncommon = _actioncommon;
            https = _https;
        }
        [HttpPost]
        public string CreateMerChant()
        {
            try
            {
                var url = "https://api.weixin.qq.com/cgi‐bin/business/register?access_token=" + "58_Dn7pFbocc-JQ0O5Azlq2kv7LvGURE3tEWKTfoJwiCMGunApNYN7rM7iRaj-c_mVpOLNkzkp7qCP8yW4eNzZNu3IWxCsC9EGJi4HkxmQCmkmZeNeBJ1ZXCNCfjdSdfiwVdXAUayLU6rvJTH3ZSWUjAIDYCA";
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
                http.Method = "Post";

                CookieContainer cookieContainer = new CookieContainer();
                http.CookieContainer = cookieContainer;
                http.AllowAutoRedirect = true;
                http.ContentType = "application/json"; // "application/x-www-form-urlencoded ; charset=UTF-8";
                http.Timeout = 100 * 1000;
                http.Proxy = null;
                var merchant = new MerChant()
                {
                    account_name = "apple",
                    nickname = "苹果",
                    icon_media_id = "media_id"
                };
                //Stream str = http.GetRequestStream();

                Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
                byte[] contentbytes = Encoding.GetEncoding("UTF-8").GetBytes(actioncommon.Json(merchant));
                http.ContentLength = contentbytes.Length;
                //http.GetRequestStream().Write(contentbytes,0,contentbytes.Length);
                var response = http.GetResponse();
                var resstream = response.GetResponseStream();
                StreamReader read = new StreamReader(resstream, Encoding.GetEncoding("UTF-8"));
                var result = read.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            return "";
        }
        #region Class
        public class MerChant
        {
            public string account_name { get; set; }
            public string nickname { get; set; }
            public string icon_media_id { get; set; }
        }
        #endregion
    }
}
