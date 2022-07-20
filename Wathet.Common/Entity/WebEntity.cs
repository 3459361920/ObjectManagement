using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using static Wathet.Common.ComEnum;

namespace Wathet.Common.Entity
{

    #region //JsonR 接口返回的Json对象
    [Serializable]
    public class JsonR
    {
        public JsonR()
        {
            code = -1;
            message = string.Empty;
            body = null;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据体 可为空
        /// </summary>
        public object body { get; set; }
    }
    #endregion





    #region JsonR 接口返回的Json对象
    [Serializable]
    public class JsonR<T>
    {
        public JsonR()
        {
            code = -1;
            message = string.Empty;
            body = default(T);
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据体 可为空
        /// </summary>
        public T body { get; set; }
    }
    #endregion

    #region //JsonREntityList 接口返回的列表对象

    /// <summary>
    /// 用于给前端返回列表数据时使用的对象 用于给 ResultJson 的 Body 赋值
    /// </summary>
    [Serializable]
    public class JsonREntityList
    {

        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// 数据对象
        /// </summary>
        public IEnumerable<object> list { get; set; }
    }
    #endregion

    #region //JsonRPageConditionBase  列表分页请求的父类
    /// <summary>
    /// 用于存储分页查询时的条件,控制器中使用的是继承类
    /// </summary>
    [Serializable]
    public abstract class JsonRPageConditionBase
    {
        public int Page { set { if (value <= 0) { pageIndex = 1; } else { pageIndex = value; } } get { return pageIndex; } }
        public int PageSize { set { if (value <= 0) { pageSize = Wathet.Common.Config.DefaultPageSize; } else { pageSize = value; } } get { return pageSize; } }
        public string KeyWord;


        private int pageIndex;
        private int pageSize;
        public abstract JsonREntityList GetList(bool IsPage = true);
    }
    #endregion

    #region //JsonRSimple
    /// <summary>
    /// 页面数据传输过程中,用于存储外键对象名称
    /// </summary>
    [Serializable]
    public class JsonRSimple
    {
        public JsonRSimple() { id = 0; name = string.Empty; }
        public JsonRSimple(int i, string n)
        {
            id = i;
            name = n;
        }
        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
    }

    #endregion


    #region //JsonRShopShare
    /// <summary>
    /// 页面数据传输过程中,用于存储外键对象名称
    /// </summary>
    [Serializable]
    public class JsonRShopShare
    {
        public JsonRShopShare() { id = 0; name = string.Empty;amount = 0; }
        public JsonRShopShare(int i, string n,decimal a)
        {
            id = i;;
            name = n;
            amount = amount;
        }
        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分摊金额
        /// </summary>
        public decimal amount { get; set; }
    }

    #endregion

    #region //JsonRSimple  string
    /// <summary>
    /// 页面数据传输过程中,用于存储外键对象名称
    /// </summary>
    [Serializable]
    public class JsonRStrSimple
    {
        public JsonRStrSimple() { id = string.Empty; name = string.Empty; }
        public JsonRStrSimple(string i, string n)
        {
            id = i;
            name = n;
        }
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
    }

    #endregion
    #region //JsonRRules
    /// <summary>
    /// 抽奖机会规则实体,用于存储外键对象名称
    /// </summary>
    [Serializable]
    public class JsonRRules : JsonRSimple
    {
        public JsonRRules() { count = 0; daycount = 0; }
        public JsonRRules(int i, int n)
        {
            count = i;
            daycount = n;
        }
        /// <summary>
        /// 初始次数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 每天次数
        /// </summary>
        public int daycount { get; set; }
    }

    #endregion


    public class RateLimit
    {
        public string calls { get; set; }
        public string renewalPeriod { get; set; }
    }

    /// <summary>
    /// 页面数据传输过程中,用于存储外键对象名称
    /// </summary>
    [Serializable]
    public class JsonRSimpleVirtual : JsonRSimple
    {
        public JsonRSimpleVirtual() { id = 0; name = string.Empty; }
        public JsonRSimpleVirtual(int i, string n, int v)
        {
            id = i;
            name = n;
            isVirtual = v;
        }
        /// <summary>
        /// 是否虚拟
        /// </summary>
        public int isVirtual { get; set; }
    }
    public class JsonRMiniData
    {

        public JsonRMiniData() { id = 0; nick_name = string.Empty; appId = string.Empty; }
        public JsonRMiniData(int i, string n, string cn)
        {
            id = i;
            nick_name = n;
            appId = cn;
        }
        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }
        public string name { get; set; }
        public string nick_name { get; set; }
        /// <summary>
        /// appid
        /// </summary>
        public string appId { get; set; }
    }

    #region //JsonRStringSimple
    /// <summary>
    /// 页面数据传输过程中,用于存储外键对象名称
    /// </summary>
    [Serializable]
    public class JsonRStringSimple
    {
        public JsonRStringSimple() { id = string.Empty; name = string.Empty; }
        public JsonRStringSimple(string i, string n)
        {
            id = i;
            name = n;
        }
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
    }

    #endregion

    public class JsonRReultData
    {
        public JsonRReultData() { ErrorCode = 0; Message = string.Empty; }
        //public JsonRReultData(int i, string n)
        //{
        //    ErrorCode = i;
        //    Message = n;
        //}
        public JsonRReultData(int i, string n)
        {
            switch (i)
            {
                case 1:
                case 3:
                case 6:
                    ErrorCode = 0x2329;
                    Message = n;
                    break;
                case 2:
                case 4:
                case 5:
                    ErrorCode = 7;
                    Message = n;
                    break;
                case 7:
                case 100:
                case 102:
                    ErrorCode = 9;
                    Message = "Invalid Profile Credential";
                    break;
                case 99:
                case 1001:
                case 1002:
                    ErrorCode = 2;
                    Message = "Invalid User Credential";
                    break;
                case 103:
                case 104:
                case 105:
                    ErrorCode = 0x3e9;
                    Message = n;
                    break;
                case 106:
                    ErrorCode = 0x3ea;
                    Message = "The account is currently locked.";
                    break;
                case 110:
                case 111:
                case 112:
                case 113:
                case 114:
                    ErrorCode = 3;
                    Message = n;
                    break;
                case 109:
                    ErrorCode = 0xbb9;
                    Message = "The points is currently locked.";
                    break;
                case 300:
                    ErrorCode = 0xfa7;
                    Message = n;
                    break;
                case 500:
                    ErrorCode = 0x2328;
                    Message = n;
                    break;
                default:
                    ErrorCode = i;
                    Message = n;
                    break;
            };
        }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }

    [Serializable]
    public class JsonRSimpleCode : JsonRSimple
    {
        public JsonRSimpleCode() { }
        public JsonRSimpleCode(int i, string n, string cn)
        {
            id = i;
            name = n;
            codeNo = cn;
        }
        public string codeNo { get; set; }
    }

    #region JsonRSimpleTime
    public class JsonRSimpleTime
    {
        public JsonRSimpleTime() { id = 0; eventTime = new JsonRTime(); }
        public JsonRSimpleTime(int i, JsonRTime n)
        {
            id = i;
            eventTime = n;
        }
        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public JsonRTime eventTime { get; set; }
    }
    #endregion

    #region //JsonRSimpleValue : JsonRSimple
    [Serializable]
    public class JsonRSimpleValue : JsonRSimple
    {
        public JsonRSimpleValue()
        {
            categoryNo = 0;
        }
        public List<JsonRSimple> value { get; set; }
        public int categoryNo { get; set; }
    }
    #endregion

    #region //JsonRBody : JsonRSimple
    /// <summary>
    /// 用于扩展JsonRSimple对象,多出body用于存储多的值
    /// </summary>
    [Serializable]
    public class JsonRBody : JsonRSimple
    {
        /// <summary>
        /// 对象的值,为object类型,具体使用具体转换
        /// </summary>
        public object body { get; set; }
    }
    #endregion


    #region //WxArticle

    /// <summary>
    /// 微信文章媒体对象
    /// </summary>
    [Serializable]
    public class WxArticle
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region //JsonRTime
    /// <summary>
    /// 页面数据传输过程中,用于存储时间范围
    /// </summary>
    [Serializable]
    public class JsonRTime
    {
        public JsonRTime() { start = string.Empty; end = string.Empty; }
        public JsonRTime(string s, string e)
        {
            start = s;
            end = e;
        }

        public string start { get; set; }
        public string end { get; set; }
    }
    #endregion


    #region JsonRGoodsInfo
    public class JsonRGoodsInfo
    {
        public int goodsId { get; set; }

        public int skuId { get; set; }

        public string name { get; set; }

        public int stock { get; set; }

        public decimal salePrice { get; set; }
    }
    #endregion

    #region //JsonRHTML
    [Serializable]
    public class JsonRHTML
    {
        public string resource { get; set; }
        public string html { get; set; }
    }
    #endregion


    /// <summary>
    /// 活动发券信息
    /// </summary>

    #region //JsonRShop : JsonRSimple
    [Serializable]
    public class JsonRShop : JsonRSimple
    {
        public string codeNo { get; set; }
        public string logo { get; set; }
        public JsonRSimple mall { get; set; }
    }
    #endregion
    /// <summary>
    /// 活动发券信息
    /// </summary>

    #region //JsonRMerchant : JsonRSimple
    [Serializable]
    public class JsonRMerchant : JsonRSimple
    {
        public string logo { get; set; }
        public JsonRSimple mall { get; set; }
        public string merchantId { get; set; }
    }
    #endregion

    public class ScanNoTotal
    {
        public int num { get; set; }
        public int SelfTotalToday { get; set; }
    }

    public class SimpleShop
    {
        public int shopID { get; set; }
        public string shopName { get; set; }
        public string typeName { get; set; }
        public int couponID { get; set; }
        public int id { get; set; }
    }

    #region //JsonRMall : JsonRSimple
    [Serializable]
    public class JsonRMall : JsonRSimpleCode
    {
        public int isVirtual { get; set; }
        public string logo { get; set; }
        public JsonRSimple mall { get; set; }
    }
    #endregion

    #region //MMObj
    [Serializable]
    public class MMObj : JsonRSimple
    {
        public MMObj type { get; set; }

        public string codeNo { get; set; }
    }
    #endregion

    #region //查询条件
    [Serializable]
    public class ListCondition
    {
        public ListCondition()
        {
            Column = string.Empty;
            Declare = string.Empty;
            CompareOp = CompareOp.等于;
            DataType = ExcDataType.整数;
        }

        /// <summary>
        /// 数据库表字段名
        /// </summary>
        public string Column;
        /// <summary>
        /// @参数名称
        /// </summary>
        public string Declare;
        /// <summary>
        /// 参数值
        /// </summary>
        public object value;
        /// <summary>
        /// 条件类型
        /// </summary>
        public CompareOp CompareOp;

        /// <summary>
        /// 字段数据类型
        /// </summary>
        public ExcDataType DataType;
    }

    #endregion


    /// <summary>
    /// sql导出参数
    /// </summary>
    public class sqlOutputParam
    {
        public string name { get; set; }
        public string value { get; set; }
        //public DbType tp { get; set; }
        //public string sqlOperator { get; set; }
    }

    /// <summary>
    /// 商城券扩展信息
    /// </summary>
    public class JsonRCommonCoupon
    {
        /// <summary>
        /// 总发券数
        /// </summary>
        public int totalNum { get; set; }
        /// <summary>
        /// 每天发券数
        /// </summary>
        public int dayNum { get; set; }
        /// <summary>
        /// 限领数量
        /// </summary>
        public int userCount { get; set; }
        /// <summary>
        /// 每日限领数量
        /// </summary>
        public int userDayCount { get; set; }
        /// <summary>
        /// 商城券
        /// </summary>
        public CommonCoupon coupon { get; set; }
    }

    /// <summary>
    /// 卡券
    /// </summary>
    [Serializable]
    public class CommonCoupon
    {
        public int id { get; set; }
        public string name { get; set; }

        public string activityName { get; set; }



        public int sortNumber { get; set; }
        public bool valid { get; set; }
        public string createTime { get; set; }
        public object couponGroup { get; set; }
        public JsonRSimple type { get; set; }
        public JsonRSimple stockType { get; set; }
        public object shopLimit { get; set; }
        public List<JsonRSimple> shopList { get; set; }
        public List<JsonRSimple> mallList { get; set; }
        public object shop { get; set; }
        public JsonRSimple publisher { get; set; }
        public JsonRSimple publisher_shop { get; set; }
        public JsonRSimple publisher_mall { get; set; }
        public JsonRSimple effectType { get; set; }
        public string effectDate { get; set; }
        public string afterGetDayTime { get; set; }
        public string effectDuration { get; set; }
        /// <summary>
        /// 卡券持续最后天数的具体时间
        /// </summary>
        public string afterValidDayTime { get; set; }
        public object duration { get; set; }
        public bool expired { get; set; }
        /// <summary>
        /// 总库存
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// 剩余可用库存
        /// </summary>
        public int stockCount { get; set; }
        public string distributeCount { get; set; }
        public int totalSpend { get; set; }
        public int totalReward { get; set; }
        public bool isMemberTotalLimit { get; set; }
        public string memberTotalLimit { get; set; }
        public bool isMemberDailyLimit { get; set; }
        public string memberDailyLimit { get; set; }
        public List<JsonRSimple> couponList { get; set; }
        public int couponCount { get; set; }
        public JsonRSimple spendChannel { get; set; }
        public bool isPay { get; set; }
    }

    /// <summary>
    /// 设置活动周期
    /// </summary>
    public class ActivityWeek
    {
        /// <summary>
        /// 活动星期列表（枚举）
        /// </summary>
        public virtual List<JsonRSimple> limitWeeks { get; set; }
        /// <summary>
        /// 活动当天时段列表，格式12:05-13:30|14:00-16:00
        /// </summary>
        public virtual List<ActivityPeriod> limitTimes { get; set; }
    }

    /// <summary>
    /// 活动时间范围
    /// </summary>
    public class ActivityPeriod
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
    }

    public class ManyCard : Json_Coupon
    {
        public string activityId { get; set; }
        public string[] GetNecessary() { return new string[] { "totalNum", "dayNum", "userCount", "userDayCount", "coupon" }; }
    }

    public class Json_ActivityCoupon
    {
        public bool valid { get; set; }
        public string activityId { get; set; }
        public int type { get; set; }

        /// <summary>
        /// 传入卡券数据
        /// </summary>
        public Json_Coupon coupon { get; set; }
    }
    /// <summary>
    /// 请求卡券参数
    /// </summary>
    /// 
    [Serializable]
    public class Json_Coupon
    {
        /// <summary>
        /// 卡券类型 0 线下卡券 1 线上卡券 2星选卡券
        /// </summary>
        public JsonRSimple StoreCouponType { get; set; }
        /// <summary>
        /// 卡券活动关联表id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 总发券数
        /// </summary>
        public int totalNum { get; set; }

        /// <summary>
        /// 总领取数
        /// </summary>
        public int totalGet { get; set; }
        /// <summary>
        /// 每天发券数
        /// </summary>
        public int dayNum { get; set; }
        /// <summary>
        /// 限领数量
        /// </summary>
        public int userCount { get; set; }
        /// <summary>
        /// 每日限领数量
        /// </summary>
        public int userDayCount { get; set; }
        /// <summary>
        /// 固定日期 1、固定 2 、领取后
        /// </summary>
        public JsonRSimple effectType { get; set; }
        /// <summary>
        /// 领取后多少天生效
        /// </summary>
        public string effectDate { get; set; }
        /// <summary>
        /// 领取后多少天生效的具体时间
        /// </summary>
        public string afterGetDayTime { get; set; }
        /// <summary>
        /// 持续天数
        /// </summary>
        public string effectDuration { get; set; }
        /// <summary>
        /// 卡券持续最后天数的具体时间
        /// </summary>
        public string afterValidDayTime { get; set; }
        /// <summary>
        /// 固定日期选择 (卡券有效期)
        /// </summary>
        public JsonRTime duration { get; set; }
        /// <summary>
        /// 全部时段（1、全部时段 2、部分时段）
        /// </summary>
        public JsonRSimple availableDuration { get; set; }
        /// <summary>
        /// 部分时段的可用日期
        /// </summary>
        public List<JsonRSimple> availableDay { get; set; }
        /// <summary>
        /// 部分时段的可用时段
        /// </summary>
        public List<JsonRTime> availableTime { get; set; }
        /// <summary>
        /// 核销商场（1、所有商场 2、特定商场）
        /// </summary>
        public JsonRSimple verifyMall { get; set; }
        /// <summary>
        /// 核销商场-指定商场列表
        /// </summary>
        public List<JsonRSimpleCode> verifyMallList { get; set; }
        /// <summary>
        /// 核销地点（1、服务台 2、商场租户 3、SPU 4、SKU）
        /// </summary>
        public List<JsonRSimple> verifyChannel { get; set; }
        public List<string> spuIds { get; set; }
        public List<string> skuIds { get; set; }
        /// <summary>
        /// 商场租户（1、全部租户 2、指定租户）
        /// </summary>
        public JsonRSimple mallShopType { get; set; }
        /// <summary>
        /// 指定租户列表
        /// </summary>
        public List<JsonRShop> shopList { get; set; }
        /// <summary>
        /// 卡券信息
        /// </summary>
        public CommonCoupon coupon { get; set; }
        /// <summary>
        /// 电商卡券信息
        /// </summary>
        public CommonCoupon isECStoreCoupon { get; set; }
        /// <summary>
        /// 星选兑换卡券信息
        /// </summary>
        public RedeemBenefitsModel redeemCoupon { get; set; }
        /// <summary>
        /// 核销渠道 1pos 2 商户助手&PC核销
        /// </summary>
        public JsonRSimple spendChannel { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool status { get; set; }
        /// <summary>
        /// 小程序appId
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 小程序路径
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 是否分摊金额
        /// </summary>
        public bool isSubLedger { get; set; }
        /// <summary>
        /// 商场分摊金额
        /// </summary>
        public decimal mallSharePrice { get; set; }

        /// <summary>
        /// 分摊商户
        /// </summary>
        public List<JsonRShopShare> shopShareList { get; set; }
    }

    #region 星选兑换券model
    public class RedeemBenefitsModel
    {
        public int id { get; set; }
        public string activityName { get; set; }
        public int stockNum { get; set; }
        public RedeemRightsInfo rightsInfo { get; set; }
    }

    public class RedeemRightsInfo
    {
        public int id { get; set; }
        public string title { get; set; }
        public int limitTimes { get; set; }
        public RedeemCoupon coupon { get; set; }
    }

    public class RedeemCoupon
    {
        public int id { get; set; }
        public string title { get; set; }
        public JsonRSimple validityType { get; set; }
        public JsonRTime duration { get; set; }
        public int validityAfterGet { get; set; }
        public int validityAfterUsableDays { get; set; }
    }
    #endregion

    public class ShopModel
    {
        /// <summary>
        /// 店铺编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public List<JsonRSimple> type { get; set; }
        /// <summary>
        /// 商场
        /// </summary>
        public JsonRSimple mall { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public JsonRSimple floor { get; set; }
        public string shopCode { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 门牌号
        /// </summary>
        public string storeNumber { get; set; }
        /// <summary>
        /// 店铺合同有效期
        /// </summary>
        public JsonRTime validityDate { get; set; }

    }

    /// <summary>
    /// 卡券固定日期选择
    /// </summary>
    public class CommonDuration
    {
        public string validityBeginTime { get; set; }
        public string validityEndTime { get; set; }
    }
    /// <summary>
    /// 活动发券信息
    /// </summary>
    [Serializable]
    public class ActivityCoupon
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int activityId { get; set; }
        /// 卡券数量
        /// </summary>
        public int num { get; set; }
    }
    /// <summary>
    /// 活动关联的卡券
    /// </summary>
    /// 
    [Serializable]
    public class CouponList
    {
        /// <summary>
        /// 卡券类型
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 卡券名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        public int activityID { get; set; }

        /// <summary>
        /// 活动相关领券量
        /// </summary>
        public int num { get; set; }

        /// <summary>
        /// 每天领券量
        /// </summary>
        public int daynum { get; set; }

        /// <summary>
        /// 会员限领数量
        /// </summary>
        public int usercount { get; set; }

        /// <summary>
        /// 会员每天限领数量
        /// </summary>
        public int userdaycount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool status { get; set; }
        /// <summary>
        /// 卡券编号
        /// </summary>
        public int couponId { get; set; }

        // public List<Json_Coupon> coupon { get; set; }
    }
    public class Api_Json_Result
    {
        public int result { get; set; }
        public string msg { get; set; }
    }

    public class Api_Json_Data_Result<T> : Api_Json_Result
    {
        public T data { get; set; }
    }

    public class Api_JsonFeel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class Api_Data_JsonFeel : Api_JsonFeel
    {
        public object Data { get; set; }
    }

    public class Api_Page_Json_Result
    {
        public int result { get; set; }
        public string msg { get; set; }
        public int pageCount { get; set; }
    }

    public class Api_Page_Json_Data_Result<T> : Api_Page_Json_Result
    {
        public T data { get; set; }
    }

    public class HttpPostResult
    {
        public HttpStatusCode StatusCode;
        public bool Result;
        public string Data;
        public string TimeLog;
    }

    /// <summary>
    /// api请求参数
    /// </summary>
    public class ApiParameter
    {
        /// <summary>
        /// 方法名
        /// </summary>
        public string tp { get; set; }
        /// <summary>
        /// 发起请求的unix时间戳
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sn { get; set; }
    }

    #region //JsonR 停车对外接口返回的Json对象
    [Serializable]
    public class CarJsonR
    {
        public CarJsonR()
        {
            Code = -1;
            Message = string.Empty;
            Data = null;
        }
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据体 可为空
        /// </summary>
        public object Data { get; set; }
    }
    #endregion
}
