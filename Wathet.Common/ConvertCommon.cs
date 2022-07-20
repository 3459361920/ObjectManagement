using AngleSharp.Html;
using Microsoft.Extensions.ObjectPool;
using NPOI.OpenXmlFormats.Dml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;


namespace Wathet.Common
{
    public static class ConvertCommon
    {

        /// <summary>
        /// 获取时间范围，通过xxxx-xx-xx ~ xxxx-xx-xx的格式
        /// </summary>
        /// <param name="time">传入时间字符串</param>
        /// <param name="start">返回的开始时间</param>
        /// <param name="end">返回的结束时间</param>
        /// <returns></returns>
        public static bool GetDatetimeRange(this string time,out DateTime start,out DateTime end)
        {
            try
            {
                string[] timeRange = time.Split('~');

                start = DateTime.Parse(timeRange[0] );
                end = DateTime.Parse(timeRange[1]);
                return true;
            }
            catch
            {
                start = default(DateTime);
                end = default(DateTime);
                return false;
            }
        }

        /// <summary>
        /// 获得AzureId字符串，获得字符串最后一个/后面的字符串
        /// </summary>
        /// <param name="idStr">Azure 字符串</param>
        /// <returns></returns>
        public static string GetAzureIdString(this string idStr)
        {
            int lastBlockCharStartIndex = idStr.LastIndexOf('/') + 1;
            return idStr.Substring(lastBlockCharStartIndex, idStr.Length - lastBlockCharStartIndex);
        }

        /// <summary>
        /// Number of calls.Get CallResult by numbers. 
        /// </summary>
        /// <param name="code">call number</param>
        /// <returns></returns>
        public static string GetCallResult(this int code)
        {

            //https://docs.microsoft.com/en-us/rest/api/apimanagement/2019-12-01/reports/listbyapi 参考文档转换

            /* Number of successful calls.
             * This includes calls returning HttpStatusCode <= 301 and HttpStatusCode.NotModified and HttpStatusCode.TemporaryRedirect */
            if (code < 301 || code == (int)HttpStatusCode.NotModified || code == (int)HttpStatusCode.TemporaryRedirect)
            {
                return "Success";
            }
            /* Number of calls failed due to proxy or backend errors. 
             * This includes calls returning HttpStatusCode.BadRequest(400) and any Code between HttpStatusCode.InternalServerError(500) and 600 */
            else if (code == (400) || (code >= 500 && code <= 600))
            {
                return "Failed";
            }
            /* Number of calls blocked due to invalid credentials. 
             * This includes calls returning HttpStatusCode.Unauthorized and HttpStatusCode.Forbidden and HttpStatusCode.TooManyRequests */
            else if (code == (int)HttpStatusCode.Unauthorized || code == (int)HttpStatusCode.Forbidden || code == (int)HttpStatusCode.TooManyRequests)
            {
                return "Blocked";
            }
            else if (code == 404)
            {
                return "404";
            }
            /* Number of other calls. */
            else
            {
                return "Other";
            }
        }

        public static string ToDescription(this Enum value)
        {
            if (value == null)
                return "";

            System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return value.ToString();
            else
                return (attribArray[0] as DescriptionAttribute).Description;
        }

        public static string ToRoundString(this double value,int roundNum = 2)
        {
            return Math.Round(value, roundNum).ToString($"F{ roundNum }");
        }

        public static DateTime ToGWTime(this DateTime value)
        {
            TimeZoneInfo localTimeZone = System.TimeZoneInfo.Local;
            TimeSpan timeSpan = localTimeZone.GetUtcOffset(value);
            DateTime greenwishTime = value - timeSpan;
            return greenwishTime;
        }

        public static (DateTime startTime,DateTime endTime) GetTimeRange(this ComEnum.RuntimeReportTimeRange timeRange,DateTime startTime)
        {
            switch (timeRange)
            {
                case ComEnum.RuntimeReportTimeRange.FifteenMins:
                    return (startTime:startTime.AddMinutes(-15), endTime:startTime);
                case ComEnum.RuntimeReportTimeRange.ThirtyMins:
                    return (startTime:startTime.AddMinutes(-30), endTime:startTime);
                case ComEnum.RuntimeReportTimeRange.OneHours:
                    return (startTime: startTime.AddHours(-1), endTime: startTime);
                case ComEnum.RuntimeReportTimeRange.OneDay:
                    return (startTime: startTime.AddDays(-1), endTime: startTime);
                default:
                    return (startTime: startTime.AddMinutes(-15), endTime: startTime);
            }
        }

        public static int GetSeconds(this ComEnum.RuntimeReportTimeRange timeRange)
        {
            switch (timeRange)
            {
                case ComEnum.RuntimeReportTimeRange.FifteenMins:
                    return 900;
                case ComEnum.RuntimeReportTimeRange.ThirtyMins:
                    return 1800;
                case ComEnum.RuntimeReportTimeRange.OneHours:
                    return 3600;
                case ComEnum.RuntimeReportTimeRange.OneDay:
                    return 86400;
                default:
                    return 0;
            }
        }


        public static string GetBandWidthString(this long value)
        {
            double bandWidthValue = value;
            int unitNum = 1;
            while (bandWidthValue > 1024)
            {
                bandWidthValue = bandWidthValue / 1024;
                unitNum++;
            }

            return bandWidthValue.ToRoundString(2)+" "+((ComEnum.BandWidthSize)unitNum).ToString();
        }


        public static string GetCriteriaODataTypeString(this ComEnum.MetricAlertType value)
        {
            switch (value)
            {
                case ComEnum.MetricAlertType.动态警报:
                    return "Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria";
                case ComEnum.MetricAlertType.静态警报:
                    return "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria";
                default:
                    return "Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria";
            }
        }
        public static string GetCriterionTypeString(this ComEnum.MetricAlertType value)
        {
            switch (value)
            {
                case ComEnum.MetricAlertType.静态警报:
                    return "StaticThresholdCriterion";
                case ComEnum.MetricAlertType.动态警报:
                    return "DynamicThresholdCriterion";
                default:
                    return "StaticThresholdCriterion";
            }
        }

        public static object ConvertSimpleType(object value, Type destinationType)
        {
            object returnValue;
            if ((value == null) || destinationType.IsInstanceOfType(value))
            {
                return value;
            }
            string str = value as string;
            if ((str != null) && (str.Length == 0))
            {
                return null;
            }
            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            bool flag = converter.CanConvertFrom(value.GetType());
            if (!flag)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }
            if (!flag && !converter.CanConvertTo(destinationType))
            {
                throw new InvalidOperationException("无法转换成类型：" + value.ToString() + "==>" + destinationType);
            }
            try
            {
                returnValue = flag ? converter.ConvertFrom(null, null, value) : converter.ConvertTo(null, null, value, destinationType);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("类型转换出错：" + value.ToString() + "==>" + destinationType, e);
            }
            return returnValue;
        }
    }
}
