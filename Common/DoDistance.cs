using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common
{
    public static class DoDistance
    {
        /// <summary>
        /// 获取距离最近的点的经纬度
        /// </summary>
        /// <param name="from">起点坐标以英文逗号分隔,纬度在前,经度在后(纬度,经度;例:39.071510,117.190091)</param>
        /// <param name="to">终点坐标单个坐标以英文逗号分隔,坐标之间以英文分号分隔(例:39.071510,117.190091;40.007632,116.389160;39.840177,116.463318)</param>
        /// <param name="mode">计算方式：driving（驾车）、walking（步行）默认：walking</param>
        /// <param name="mapUrl">腾讯地图计算距离接口地址,https://apis.map.qq.com/ws/distance/v1/</param>
        /// <param name="mapKey">腾讯地图计算秘钥, GFGBZ-7HR3O-QHHWH-SXHON-KFJPK-LTFIX</param>
        /// <param name="mapSign">腾讯地图计算验签, SYdjcETBAfwxGY1WKdmpmEAQv5aYTCHV</param>
        /// <returns></returns>
        public static Distance GetShortestDistance(string from = "", string to = "", string mode = "walking", string mapUrl = "", string mapKey = "", string mapSign = "")
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                return null;
            }
            var url = mapUrl;
            var Data = new SortedDictionary<string, string>();
            Data.Add("mode", mode);
            Data.Add("from", from);
            Data.Add("to", to);
            Data.Add("key", mapKey);//腾讯开发平台分配的key
            var dataStr = string.Empty;
            foreach (var item in Data)
            {
                dataStr += item.Key + "=" + item.Value + "&";
            }
            var postData = dataStr.Substring(0, dataStr.Length - 1);
            var signData = postData + mapSign;//腾讯开放平台分配的验签值,,
            var sign = DoEncrypt.MD5("/ws/distance/v1/?" + signData);//md5加密
            postData += "&sig=" + sign;
            var result = DoWebRequest.SendRequest_Get(url, postData);
            var postResult = DoWebRequest.SendRequest_Get(url, postData);
            if (!string.IsNullOrEmpty(postResult))
            {
                return postResult.ToObjectFromJson<Distance>();
            }
            return null;
        }

        public class Distance
        {
            public int status { get; set; }//返回状态码
            public string message { get; set; }//状态码说明
            public object result { get; set; }//返回内容
        }
    }
}
