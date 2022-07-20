using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Wathet.Common.Entity
{
    #region //数据库异常对象
    /// <summary>
    /// 数据库异常对象
    /// </summary>
    public class DBError
    {
        public string ConnectionStr { get; set; }
        public bool IsTrans { get; set; }
        public string Sql { get; set; }
        public string SafeSql { get; set; }
        public object Params { get; set; }
        public Exception Error { get; set; }
    }
    #endregion

    #region //静态缓存超时对象    
    public class vvv
    {
        public string value { get; set; }
        public DateTime time { get; set; }
    }
    #endregion


    public class ECcouponRollBackModel
    {
        public string memberNo { get; set; }

        public string codeNo { get; set; }
    }

    #region //会员参与活动后的结果通知 用于 Member_EventNotice 的NoticeBody
    public class MemNotice_SignActivity
    {
        public MemNotice_SignActivity()
        {
            SignIn = false;
            IsRewardPrize = false;
            PrizeType = ComEnum.SalePrizeType.不中奖.GetHashCode();
            CouponID = 0;
            CouponName = string.Empty;
            CouponType = 0;
            CouponEndTime = string.Empty;
            CouponCodeNo = null;
            PointAmount = 0;
            ResidueTotal = 0;
            IsFirstJoin = false;
            ActivityName = string.Empty;
            prizeId = 0;
            PrizeName = string.Empty;
            TransNo = string.Empty;
            ECCouponUrl = string.Empty;
            memberNo = string.Empty;
        }
        public bool SignIn { get; set; }
        public bool IsRewardPrize { get; set; }
        public int PrizeType { get; set; }
        public int CouponID { get; set; }
        public string CouponName { get; set; }
        public int CouponType { get; set; }
        public string CouponEndTime { get; set; }
        public string[] CouponCodeNo { get; set; }
        public int PointAmount { get; set; }
        /// <summary>
        /// 剩余参与次数(为0表示参与次数用完)
        /// </summary>
        public int ResidueTotal { get; set; }
        /// <summary>
        /// 是否第一次参与
        /// </summary>
        public bool IsFirstJoin { get; set; }
        public string ActivityName { get; set; }
        public int prizeId { get; set; }
        public string PrizeName { get; set; }
        public string TransNo { get; set; }
        /// <summary>
        /// 电商券地址
        /// </summary>
        public string ECCouponUrl { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string memberNo { get; set; }

        public List<MemNotice_SignActivityList> memNotice_SignActivities { get; set; }
    }

    #endregion

    #region //会员参与活动后的结果通知 用于 Member_EventNotice 的NoticeBodyList
    public class MemNotice_SignActivityList
    {
        public MemNotice_SignActivityList()
        {
            SignIn = false;
            IsRewardPrize = false;
            PrizeType = ComEnum.SalePrizeType.不中奖.GetHashCode();
            CouponID = 0;
            CouponName = string.Empty;
            CouponType = 0;
            CouponEndTime = string.Empty;
            CouponCodeNo = null;
            PointAmount = 0;
            ResidueTotal = 0;
            IsFirstJoin = false;
            ActivityName = string.Empty;
            prizeId = 0;
            PrizeName = string.Empty;
            TransNo = string.Empty;
            ECCouponUrl = string.Empty;
            memberNo = string.Empty;
        }
        public bool SignIn { get; set; }
        public bool IsRewardPrize { get; set; }
        public int PrizeType { get; set; }
        public int CouponID { get; set; }
        public string CouponName { get; set; }
        public int CouponType { get; set; }
        public string CouponEndTime { get; set; }
        public string[] CouponCodeNo { get; set; }
        public int PointAmount { get; set; }
        /// <summary>
        /// 剩余参与次数(为0表示参与次数用完)
        /// </summary>
        public int ResidueTotal { get; set; }
        /// <summary>
        /// 是否第一次参与
        /// </summary>
        public bool IsFirstJoin { get; set; }
        public string ActivityName { get; set; }
        public int prizeId { get; set; }
        public string PrizeName { get; set; }
        public string TransNo { get; set; }
        /// <summary>
        /// 电商券地址
        /// </summary>
        public string ECCouponUrl { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string memberNo { get; set; }
    }

    #endregion
    #region 卡券相关
    /// <summary>
    /// 发券输入对象
    /// </summary>
    public class requestCoupon
    {
        public string memberCard { get; set; }
        public int activityId { get; set; }
        public int activityType { get; set; }
        public int fieldId { get; set; }
        public int portalId { get; set; }
        public int channelId { get; set; }
        public int mallId { get; set; }
        public int shopId { get; set; }
        public int couponId { get; set; }
        public int acId { get; set; }
        public bool coiGoods = false;
        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderNo { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal salePrice { get; set; }
        /// <summary>
        /// 补贴金额
        /// </summary>
        public decimal subsidyAmount { get; set; }
    }

    public class CouponExternalModel
    {
        /// <summary>
        /// 卡券标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 卡券面额
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 是否补贴券
        /// </summary>
        public bool isSubsidy { get; set; }
        /// <summary>
        /// 补贴金额
        /// </summary>
        public decimal subsidyAmount { get; set; }
        /// <summary>
        /// 卡券使用限制类型
        /// </summary>
        public int limitType { get; set; }
        /// <summary>
        /// 卡券使用限制金额
        /// </summary>
        public string limitAmount { get; set; }
    }


    public class RecevieModel
    {
        public int SelfTotal { get; set; }
        public int SelfTotalToday { get; set; }
        public int Total { get; set; }
        public int TotalToday { get; set; }
    }
    /// <summary>
    /// 核销输入对象
    /// </summary>
    public class ConsumeParam
    {
        /// <summary>
        /// 券号
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 商场id，针对商场账号，有多商场的情况
        /// </summary>
        public int mallId { get; set; }

        /// <summary>
        /// 店铺编号
        /// </summary>
        public int shopId { get; set; }
        public List<int> mallIds { get; set; }
        public List<int> shopIds { get; set; }
        public string SPUID { get; set; }
        public string SKUID { get; set; }

        /// <summary>
        /// 店铺编码
        /// </summary>
        public string shopCode { get; set; }
        /// <summary>
        /// 车牌号 停车券使用
        /// </summary>
        public string carNo { get; set; }
        /// <summary>
        /// 卡券核销方式
        /// </summary>

        public int useType { get; set; }
        /// <summary>
        /// 卡券核销端
        /// </summary>
        public int spendClient { get; set; }
        /// <summary>
        /// 核销人id
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 核销人名称
        /// </summary>
        public string userName { get; set; }
    }

    /// <summary>
    /// 卡券用户相关对象 
    /// </summary>
    public class CouponUserBody
    {
        /// <summary>
        /// 会员id
        /// </summary>
        public int memberId { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string memberCardNo { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        public string memberLevel { get; set; }


        /// <summary>
        ///卡券号
        /// </summary>
        public string codeNo { get; set; }

        /// <summary>
        /// 卡券生效时间
        /// </summary>
        public string beginTime { get; set; }

        /// <summary>
        /// 卡券失效时间
        /// </summary>
        public string endTime { get; set; }

        /// <summary>
        /// 卡券状态 
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 卡券状态名称
        /// </summary>
        public string statusName { get; set; }


        /// <summary>
        /// 卡券核销商场
        /// </summary>
        public string consumeMall { get; set; }

        /// <summary>
        /// 卡券核销商户
        /// </summary>
        public string consumeShop { get; set; }

        /// <summary>
        /// 卡券人
        /// </summary>
        public string consumeUser { get; set; }

        /// <summary>
        /// 卡券核销时间
        /// </summary>
        public string consumeTime { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int errorCode { get; set; }
        /// <summary>
        /// 核销商户id
        /// </summary>
        public int storeId { get; set; }
        /// <summary>
        /// 是否是虚拟商场
        /// </summary>
        public bool isVirtualMall { get; set; }

    }



    /// <summary>
    /// 卡券核销记录列表
    /// </summary>
    public class CouponListBody
    {


        /// <summary>
        /// 会员卡号
        /// </summary>
        public string memberCardNo { get; set; }

        /// <summary>
        /// 卡券编号
        /// </summary>
        public string codeNo { get; set; }

        /// <summary>
        /// 卡券名称
        /// </summary>
        public string couponTitle { get; set; }

        /// <summary>
        /// 卡券领取时间
        /// </summary>
        public string getTime { get; set; }

        /// <summary>
        /// 卡券核销时间
        /// </summary>
        public string consumeTime { get; set; }

        /// <summary>
        /// 核销人
        /// </summary>
        public string consumeUserName { get; set; }

        /// <summary>
        /// 卡券核销商场
        /// </summary>
        public string consumeMall { get; set; }

        /// <summary>
        /// 卡券核销商户
        /// </summary>
        public string consumeShop { get; set; }

    }

    #endregion

    #region //会员购买积分商品后的通知类 用于 Member_EventNotice 的NoticeBody
    public class MemNotice_BuyPointGoods
    {
        public MemNotice_BuyPointGoods()
        {
            SignIn = false;
            IsRewardPrize = false;
            CouponID = string.Empty;
            CouponName = string.Empty;
            FaildReason = string.Empty;
            CouponCodeNo = new string[] { };
            TransNo = string.Empty;
        }
        public bool SignIn { get; set; }
        public string FaildReason { get; set; }
        public bool IsRewardPrize { get; set; }
        public string CouponID { get; set; }
        public string CouponName { get; set; }
        public string[] CouponCodeNo { get; set; }
        public string TransNo { get; set; }
    }
    #endregion


    /// <summary>
    /// 会员卡券信息
    /// </summary>
    [Serializable]
    public class MemberCoupon
    {
        /// <summary>
        /// 卡券来源
        /// </summary>
        public int acId { get; set; }
        /// <summary>
        /// 卡券来源
        /// </summary>
        public int fromSourceId { get; set; }
        /// <summary>
        /// 卡券类型
        /// </summary>
        public int couponType { get; set; }
        /// <summary>
        /// 卡券数量
        /// </summary>
        public int num { get; set; }
    }

    public class MemberCouponRequest
    {
        //ids
        public string ids { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string beginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 卡券类型
        /// </summary>
        public bool getCouponType { get; set; }
        /// <summary>
        /// 卡券分组
        /// </summary>
        public int excludeCouponType { get; set; }
    }

    public class ActivityCouponsRequest
    {
        public List<int> ids { get; set; }
        public int activityCouponType { get; set; }
    }

    public class WxStockCode
    {
        public string stock_id { get; set; }
        public string codeNo { get; set; }
    }

    #region 对接星选model
    public class FoSunModel
    {
        public SyncRightsModel model { get; set; }
    }

    /// <summary>
    /// 产业创建卡券输入对象
    /// </summary>
    public class SyncRightsModel
    {
        public string industryRightsCode { get; set; }
        public string title { get; set; }
        public string subTitle { get; set; }
        public int isOnline { get; set; }
        public string industryCode { get; set; }
        /// <summary>
        /// 渠道code
        /// </summary>
        public string channelCode { get; set; }
        public string imgUrl { get; set; }
        public decimal salePrice { get; set; }
        public decimal costPrice { get; set; }
        public int rightsType { get; set; }
        public int useType { get; set; }
        public decimal reduceMoney { get; set; }
        public DateTime starTime { get; set; }
        public DateTime endTime { get; set; }
        public int num { get; set; }
        public int userCount { get; set; } = -1;
        public int userDayCount { get; set; } = -1;
        public string contents { get; set; }
        public List<jumplist> jumpList { get; set; }

        public decimal amount { get; set; }
        public decimal discount { get; set; }
        public string experienceContent { get; set; }

        public string couponInstructions { get; set; }
    }

    public class jumplist
    {
        public int id { get; set; }
        public string path { get; set; }
        public string appId { get; set; }
    }
    #endregion

    public class MemberInfoRequest
    {
        public string mobile { get; set; }

        public string memberNo { get; set; }

    }

}
