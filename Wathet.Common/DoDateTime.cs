using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Wathet.Common.Entity;

namespace Wathet.Common
{
    public static class DoDateTime
    {

        #region //月份

        #region //月份第一天

        public static DateTime FirstDay_Of_Month(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, 1);
        }
        #endregion

        #region //月份最后一天

        public static DateTime LastDay_Of_Month(this DateTime time)
        {
            return time.AddMonths(1).FirstDay_Of_Month().AddDays(-1);
        }
        #endregion
        #endregion

        #region //季度

        #region //获取指定日期是当年的第几季度

        /// <summary>
        /// 获取指定日期是当年的第几季度
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int QuarterOfYear(this DateTime time)
        {
            return time.Month % 3 == 0 ? time.Month / 3 : time.Month / 3 + 1;
        }
        #endregion

        #region //季度第一天

        public static DateTime FirstDay_Of_Quarter(this DateTime time)
        {
            var quarter = time.QuarterOfYear();
            return new DateTime(time.Year, quarter * 3 - 2, 1);
        }
        #endregion

        #region //季度最后一天

        public static DateTime LastDay_Of_Quarter(this DateTime time)
        {
            return time.FirstDay_Of_Quarter().AddMonths(3).AddDays(-1);
        }
        #endregion 
        #endregion

        #region //星期

        #region //当年的第几周

        /// <summary>
        /// 获取指定日期是当年的第几周
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime time)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }
        #endregion

        #region //星期第一天

        public static DateTime FirstDay_Of_Week(this DateTime time)
        {
            //修改礼拜日值是7  默认为0
            //以礼拜一为第一天
            var weekNumber = time.DayOfWeek == DayOfWeek.Sunday ? 7 : time.DayOfWeek.GetHashCode();
            return time.AddDays(-(weekNumber - 1));
        }
        #endregion

        #region //星期最后一天

        public static DateTime LastDay_Of_Week(this DateTime time)
        {
            return time.FirstDay_Of_Week().AddDays(6);
        }
        #endregion

        #region //获取星期几
        /// <summary>
        /// 获取星期几(中文)
        /// </summary>
        public static string GetChinaWeek(DateTime now)
        {
            return new string[] { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" }[(int)now.DayOfWeek];
        }
        #endregion

        #endregion

        #region //年份

        #region //年份第一天
        public static DateTime FirstDay_Of_Year(this DateTime time)
        {
            return new DateTime(time.Year, 1, 1);
        }
        #endregion

        #region //年份最后一天

        public static DateTime LastDay_Of_Year(this DateTime time)
        {
            return new DateTime(time.Year, 12, 31);
        }
        #endregion

        #endregion

        #region //格式化
        /// <summary>
        /// 格式化: yyyy-MM
        /// </summary>
        /// <param name="time"></param>
        /// <param name="IsSymbol">是否带符号,false时纯数字</param>
        /// <returns></returns>
        public static string Format_yyyyMM(this DateTime time, bool IsSymbol = true)
        {
            return time.ToString(IsSymbol ? "yyyy-MM" : "yyyyMM");
        }
        /// <summary>
        /// 格式化: yyyy-MM-dd
        /// </summary>
        /// <param name="time"></param>
        /// <param name="IsSymbol">是否带符号,false时纯数字</param>
        /// <returns></returns>
        public static string Format_yyyyMMdd(this DateTime time, bool IsSymbol = true)
        {
            if (IsSymbol == true)
                return time.ToString("yyyy-MM-dd");
            else
                return time.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 格式化: yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="time"></param>
        /// <param name="IsSymbol">是否带符号,false时纯数字</param>
        /// <returns></returns>
        public static string Format_yyyyMMddHHmmss(this DateTime time, bool IsSymbol = true)
        {
            if (IsSymbol == true)
                return time.ToString("yyyy-MM-dd HH:mm:ss");
            else
                return time.ToString("yyyyMMddHHmmss");
        }
        /// <summary>
        /// 格式化: yyyy-MM-dd HH:mm:ss.fff
        /// </summary>
        /// <param name="time"></param>
        /// <param name="IsSymbol">是否带符号,false时纯数字</param>
        /// <returns></returns>
        public static string Format_yyyyMMddHHmmssfff(this DateTime time, bool IsSymbol = true)
        {
            if (IsSymbol == true)
                return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            else
                return time.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// 格式化: yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="time"></param>
        /// <param name="IsSymbol">是否带符号,false时纯数字</param>
        /// <returns></returns>
        public static string Format_yyyyMMddHHmm(this DateTime time, bool IsSymbol = true)
        {
            if (IsSymbol == true)
                return time.ToString("yyyy-MM-dd HH:mm");
            else
                return time.ToString("yyyyMMddHHmm");
        }

        /// <summary>
        /// 格式化: HH:mm:ss
        /// </summary>
        /// <param name="time"></param>
        /// <param name="IsSymbol">是否带符号,false时纯数字</param>
        /// <returns></returns>
        public static string Format_HHmmss(this DateTime time, bool IsSymbol = true)
        {
            if (IsSymbol == true)
                return time.ToString("HH:mm:ss");
            else
                return time.ToString("HHmmss");
        }
        #endregion

        #region 字符转时间
        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str, DateTime defValue)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime dateTime;
                if (DateTime.TryParse(str, out dateTime))
                    return dateTime;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str)
        {
            return StrToDateTime(str, DateTime.Now);
        }
        #endregion

        #region 时间戳转时间
        /// <summary>
        /// 时间戳转换成时间
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime IntToDateTime(long timestamp)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timestamp);
        }
        #endregion


        #region //将没有间隔符的时间重置为时间对象
        /// <summary>
        /// 将没有间隔符的时间重置为时间对象
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime GetDateFromStr(string time)
        {
            int step = 2;
            var list = new List<string>() { "19", "00", "01", "01", "00", "00", "00" };
            for (int i = 0; i < time.Length / 2; i++)
            {
                list[i] = time.Substring(i * step, step);
            }
            string str = string.Format("{0}{1}-{2}-{3} {4}:{5}:{6}", list[0], list[1], list[2], list[3], list[4], list[5], list[6]);

            return str.ToDateTime();
        }
        #endregion

        #region //时间差文字转换

        public static string GetTimeSpanStr(this DateTime Time1, DateTime Time2)
        {
            return (Time1 - Time2).GetTimeSpanStr();
        }

        public static string GetTimeSpanStr(this TimeSpan span)
        {
            string result = string.Empty;
            if (Math.Abs(span.Days) > 0) result += $" {Math.Abs(span.Days)}天";
            if (Math.Abs(span.Hours) > 0) result += $" {Math.Abs(span.Hours)}小时";
            if (Math.Abs(span.Minutes) > 0) result += $" {Math.Abs(span.Minutes)}分钟";
            if (Math.Abs(span.Seconds) > 0) result += $" {Math.Abs(span.Seconds)}秒";
            if (Math.Abs(span.Milliseconds) > 0) result += $" {Math.Abs(span.Milliseconds)}毫秒";
            return result;
        }

        #endregion

        #region  //获取年龄
        /// <summary>
        ///  根据出生年月日获取年龄
        /// </summary>
        public static int GetAge(this DateTime dt)
        {
            return dt.Date <= DateTime.Now.Date ? (DateTime.Now.Date - dt.Date).Days / 365 : 0;
        }
        #endregion

        #region //获取农历
        // 十二天干
        static string[] tg = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        // 十二地支
        static string[] dz = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        // 十二生肖
        static string[] sx = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        // 农历月
        static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)" };
        // 农历日
        private static string[] days1 = { "初", "十", "廿", "三" };
        // 农历日
        private static string[] days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

        #region //返回农历 年 月 日 生肖

        ///<summary>
        /// 根据DateTime 获取农历完整字符串  例:戊辰[龙]年闰三月初二
        ///</summary>
        public static string GetNongLi(this DateTime datetime, bool IsYear = true, bool IsMonth = true, bool IsDay = true)
        {
            //获取闰月， 0 则表示没有闰月
            int leapMonth = new ChineseLunisolarCalendar().GetLeapMonth(datetime.Year);

            bool isleap = datetime.Month == leapMonth;
            bool IsJianMonth = leapMonth > 0 && datetime.Month > leapMonth;

            return string.Concat(
                (IsYear ? GetNongLiYear(datetime) : string.Empty),
                (IsMonth ? (isleap ? "闰" : string.Empty) : string.Empty),
                (IsMonth ? GetNongLiMonth(datetime.AddMonths(-(IsJianMonth ? 1 : 0))) : string.Empty),
                (IsDay ? GetNongLiDay(datetime) : string.Empty)
            );
        }

        ///<summary>
        /// 返回农历年
        ///</summary>
        public static string GetNongLiYear(this DateTime time)
        {
            int tgIndex = (time.Year - 4) % 10;
            int dzIndex = (time.Year - 4) % 12;
            return string.Concat(tg[tgIndex], dz[dzIndex], "[", sx[dzIndex], "]") + "年";
        }
        ///<summary>
        /// 返回农历月
        ///</summary>
        public static string GetNongLiMonth(this DateTime time)
        {
            return months[time.Month - 1] + "月";
        }
        ///<summary>
        /// 返回农历日
        ///</summary>
        public static string GetNongLiDay(this DateTime time)
        {
            var day = time.Day;
            return day != 20 && day != 30
                ? string.Concat(days1[(day - 1) / 10], days[(day - 1) % 10])
                : string.Concat(days[(day - 1) / 10], days1[1]);
        }
        /// <summary>
        /// 获取年份生肖
        /// </summary>
        public static string GetNongLiShengXiao(this DateTime time)
        {
            return sx[(time.Year - 4) % 12];
        }
        #endregion


        #endregion

        #region //当天的开始 和结束

        public static DateTime DayBegin(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd 00:00:00").ToDateTime();
        }

        public static DateTime DayEnd(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd 23:59:59").ToDateTime();
        }
        #endregion

        #region 根据时间获取语义话述
        /// <summary>
        /// 根据时间获取语义话述 返回: 近一天 近一周
        /// </summary>
        public static string GetCloseTimeStr(this DateTime time)
        {
            int Realcha = (DateTime.Now - time).Days;
            var fixedStr = Realcha < 0 ? "未来" : "近";
            var cha = Math.Abs(Realcha);
            if (cha == 0) { return "当天"; }
            if (cha >= 0 && cha <= 1) { return fixedStr + "一天"; }
            if (cha > 1 && cha <= 2) { return fixedStr + "两天"; }
            if (cha > 2 && cha <= 3) { return fixedStr + "三天"; }
            if (cha > 3 && cha <= 7) { return fixedStr + "一周"; }
            if (cha > 7 && cha <= 14) { return fixedStr + "半个月"; }
            if (cha > 14 && cha <= 30) { return fixedStr + "一个月"; }
            if (cha > 30 && cha <= 60) { return fixedStr + "二个月"; }
            if (cha > 60 && cha <= 91) { return fixedStr + "三个月"; }
            if (cha > 90 && cha <= 182) { return fixedStr + "半年"; }
            if (cha > 182 && cha <= 365) { return fixedStr + "一年"; }
            return Realcha < 0 ? time.Format_yyyyMMdd() + "至今" : "到" + time.Format_yyyyMMdd();
        }
        #endregion

        #region //判断时间轴是否交叉
        /// <summary>
        /// 判断时间轴是否交叉
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="timeList"></param>
        /// <returns></returns>
        public static bool CheckTimeBetween(DateTime start, DateTime end, List<DateTime[]> timeList)
        {
            foreach (var t in timeList)
            {
                if (IsBetween2(start, t[0], t[1]) || IsBetween2(end, t[0], t[1]) || IsBetween2(t[0], start, end) || IsBetween2(t[1], start, end))
                {
                    return false;
                }
            }
            return true;
        }
        static bool IsBetween2(DateTime source, DateTime lower, DateTime upper)
        {
            return source >= lower && source <= upper;
        }
        #endregion

        #region // 获取当前时间戳
        public static long Timestamp(this DateTime dateTime)
        {
            System.DateTime startTime = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            return (int)(dateTime - startTime).TotalSeconds;
        }
        #endregion


        public static decimal GetTotalMilliSecond(this DateTime datetime)
        {
            return Math.Round(datetime.Ticks / 100000M);
        }

        #region // 获取当前时间戳（DateTime.UtcNow获取的是世界标准时区的当前时间）
        /// <summary>
        /// 获取当前时间戳（DateTime.UtcNow获取的是世界标准时区的当前时间）
        /// </summary>
        /// <returns></returns>
        public static string Timestamp()
        {
            System.DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string timestamp = ((long)(DateTime.UtcNow - startTime).TotalSeconds).ToString();
            return timestamp;
        }
        #endregion

        /// <summary>
        /// 获取时间戳 ,精确到毫秒
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }


        #region 生成时间戳
        /// <summary>
        /// 日期转换成unix时间戳
        /// </summary>
        public static long DateTimeToUnixTimestamp(DateTime data)
        {
            long x = Convert.ToInt64((data.ToUniversalTime().Ticks - 621355968000000000) / 10000000);

            if (x < 0)
            {
                x = Convert.ToInt64(new DateTime(2000, 1, 1).ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            }
            return x;
        }
        #endregion

        /// <summary>
        /// 时间戳转换为时间
        /// </summary>
        /// <param name="dateTimeFromXml">时间戳</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(long dateTimeFromXml)
        {
            System.DateTime startTime =  TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(dateTimeFromXml);
            return dt;
        }

        #region 微信时间处理

        public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromUnixStramp(long dateTimeFromXml)
        {
            return BaseTime.AddTicks((dateTimeFromXml + 8 * 60 * 60) * 10000000);
        }
        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromUnixStramp(string dateTimeFromXml)
        {
            return GetDateTimeFromUnixStramp(long.Parse(dateTimeFromXml));
        }

        /// <summary>
        /// 获取微信DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetUnixDateTime(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }
        public static DateTime GetWeChatDate(double time)
        {
            return DateTime.Parse("1970-1-1").AddSeconds(time);
        }
        public static DateTime GetWeChatDate(string time)
        {
            double tim = DoString.StrToDouble(time, 0);
            if (tim != 0)
                return DateTime.Parse("1970-1-1").AddSeconds(tim);
            return DateTime.Now;
        }
        public static double GetLinuxTime(DateTime time)
        {
            return (int)((time - DateTime.Parse("1970-1-1")).TotalSeconds);
        }

        #endregion

        /// <summary>
        /// 判断日期的全部格式是否有时分秒（yyyy-MM-dd HH:mm:dd）
        /// </summary>
        /// <param name="dateStr">输入日期的字符串</param>
        /// <returns></returns>
        public static bool isDateTimeShort(string dateStr)
        {
            DateTime dt;
            bool flag = DateTime.TryParse(dateStr, out dt);
            if (flag)
            {
                if (dt.Hour > 0 || dt.Minute > 0 || dt.Second > 0)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 获取指定时间内的指定星期的全部日期
        /// </summary>
        /// <param name="startDT"></param>
        /// <param name="endDT"></param>
        /// <param name="limitWeeks"></param>
        /// <returns></returns>
        public static List<DateTime> getDate(DateTime startDT, DateTime endDT, string limitWeeks)
        {
            var Weeks = (limitWeeks ?? "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(o => o.ToInt()).ToList();
            var Monday = new List<DateTime>();

            if (Weeks.Count > 0)
            {
                TimeSpan dt = endDT - startDT;
                int dayCount = dt.Days;  //总天数

                for (int i = 0; i < dayCount; i++)
                {
                    var WeekDays = (int)ComEnum.WeekDays.星期一;
                    switch (startDT.AddDays(i).DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            WeekDays = (int)ComEnum.WeekDays.星期一;
                            break;
                        case DayOfWeek.Tuesday:
                            WeekDays = (int)ComEnum.WeekDays.星期二;
                            break;
                        case DayOfWeek.Wednesday:
                            WeekDays = (int)ComEnum.WeekDays.星期三;
                            break;
                        case DayOfWeek.Thursday:
                            WeekDays = (int)ComEnum.WeekDays.星期四;
                            break;
                        case DayOfWeek.Friday:
                            WeekDays = (int)ComEnum.WeekDays.星期五;
                            break;
                        case DayOfWeek.Saturday:
                            WeekDays = (int)ComEnum.WeekDays.星期六;
                            break;
                        case DayOfWeek.Sunday:
                            WeekDays = (int)ComEnum.WeekDays.星期日;
                            break;
                    }
                    if (Weeks.Contains(WeekDays))
                    {
                        Monday.Add(startDT.AddDays(i));
                    }
                }
            }
            return Monday;
        }

        //获取指定时间内的指定星期的全部日期
        public static  bool getlimitWeeks(DateTime startDT, DateTime endDT, string limitWeeks)
        {
            bool IsDate=true;

            //获取当前日期
            DateTime NowDate = DateTime.Now;

            //获取当前可参加时间段内的时间周
            var WeekList = (limitWeeks ?? "").Split(',').Select(c => Convert.ToString(c)).ToList();

            //判断是否在此范围内
            if (NowDate <= endDT && NowDate >= startDT)
            {
                //获取当前周
                string NowWeek = CaculateWeekDay(NowDate).ToString();

                if (WeekList.Where(c => c == NowWeek).Count() >= 1)
                {
                    IsDate = false;
                }

            }
            return IsDate;
        }

        private static  int CaculateWeekDay(DateTime rq)
        {
            int y = rq.Year;
            int m = rq.Month;
            int d = rq.Day;
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400 + 1) % 7;
            //基姆拉尔森计算公式里周日代表0，如果是0赋值为7 代码周日
            if (week == 0)
            {
                week = 7;
            }
            return week;
        }
    }
}
