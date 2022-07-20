using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wathet.Common.Entity
{

    #region //js日志记录

    public class LogJS
    {
        public int UserID;
        public string UserCodeNo;
        public string UserName;
        public string PageURL;
        public int typeId;
        public string typeName;
        public string Content;
        public int PortalID;
        public int AppChannelID;
        public string OpenID;

    }

    #endregion

    #region //PV记录

    public class VisitPV
    {

        public string PageURL;
        public string ParamsGet;
        public string ParamsPost;
        public string ParamsFile;
        public string RefferURL;
        public string Method;
        public string IP;

        public int ResultCode;
        public string ResultMessage;
        public string ResultBody;

        public int HttpCodeStatus;
        public string Exception;

    }
    public class CrmVisit : VisitPV
    {
        public DateTime BeginTime;
        public DateTime EndTime;
        public string TokenAuth;
        public string SvcAuth;
    }


    public class WathetPV : VisitPV
    {

        public int UserID;
        public string UserCodeNo;
        public string UserName;
    }


    #region //接口访问记录

    public class LogVisitPV : VisitPV
    {
        public int UserID;
        public string UserCodeNo;
        public string UserName;
        public string Token;

        public DateTime BeginTime;
        public DateTime EndTime;

        public string ConnID;

        public int PortalID;
        public int AppChannelID;
        public string OpenID;

        public Dictionary<string, object> RunLog;
    }

    public class ZhongTaiLogVisitPV : VisitPV
    {
        public string ThirdCode;
        public string Name;
        public string Sign;

        public DateTime BeginTime;
        public DateTime EndTime;

        public string ConnID;

        public int PortalID;
        public int AppChannelID;
        public string OpenID;

        public Dictionary<string, object> RunLog;
    }
    #endregion

    #endregion

    #region //日志
    [Serializable]
    public class LogEntity
    {
        public string Program { get; set; }
        public string ThreadName { get; set; }
        public Wathet.Common.ComEnum.LogLevel Level { get; set; }
        public object Body { get; set; }
        public DateTime Time { get; set; }
        public DateTime HandleTime { get; set; } //处理时间
    }

    #endregion

    #region //短信发送记录

    public class LogSMSEntity
    {
        public string Program { get; set; }
        public string ThreadName { get; set; }
        public Wathet.Common.ComEnum.LogLevel Level { get; set; }
        public LogSMSDetail Body { get; set; }
        public DateTime Time { get; set; }
    }



    public class LogSMSDetail
    {
        public string Reason { get; set; }
        public string API { get; set; }
        public string Encode { get; set; }
        public string Result { get; set; }
        public bool Success { get; set; }
        public string Phone { get; set; }
        public string SMSBody { get; set; }
        public DateTime CreateTime { get; set; }
    }
    #endregion

    #region //对象修改

    public class LogEntityModifiy
    {
        public LogEntityModifiy() { UpdateTime = DateTime.Now; Remark = string.Empty; }
        public int ID { get; set; }
        public object User { get; set; }
        public Wathet.Common.ComEnum.EntityType Entity { get; set; }
        public object OldEntity { get; set; }
        public object NewEntity { get; set; }
        public ComEnum.EntityMethod Method { get; set; }
        public string Remark { get; set; }
        public DateTime UpdateTime { get; set; }
    }
    #endregion

    #region //停车日志

    public class ParkLogEntity
    {
        public int ID { get; set; }
        public int Member_id { get; set; }
        public int Mall_id { get; set; }
        public string carNo { get; set; }
        public int action_type { get; set; } 
        public string order_no { get; set; }
        public string order_id { get; set; }
        public string content { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }

    }
    #endregion
    #region //停车服务日志

    public class ParkLogServerEntity
    {
        public string content { get; set; }
        public int LevelID { get; set; }
        public string LevelName { get; set; }

    }
    #endregion

    #region //积分记录增减启用删除操作 数据服务

    /*
     1. 操作的数据

    2. 操作的类型  添加  启用  禁用 删除

    3. 所属的合作方系统    
     
     */
    #endregion

    #region //用户参加活动后 消耗积分 与获得奖品
    public class LogSignActivity_Prize
    {
        public LogSignActivity_Prize()
        {
            EventTag = string.Empty;
            Member = null;
            MemberCrm = null;
            ActivityHistory = null;
            CostPointPartnerID = 0;
            CostPointID = 0;
            Prize_Point = null;
            Prize_Coupon = null;
            aCoupon = null;
            Coupon = null;
            IsFirstJoin = false;
            ResidueTotal = 0;
            prizeId = 0;
            basePrizeId = 0;
            COICouponUrl = string.Empty;
        }
        public string EventTag;
        public object Member;
        public object MemberCrm;
        public object ActivityHistory;
        public int CostPointPartnerID;
        public int CostPointID;
        public object Prize_Point;
        public object Prize_Coupon;
        public object aCoupon;
        public object Coupon;
        public bool IsFirstJoin;
        public int ResidueTotal;
        public int prizeId;
        public int basePrizeId;
        public string COICouponUrl;
        public object StockCode;
    }
    #endregion

    #region //用户购买积分商品 消耗积分 与获得卡券
    public class LogBuyPointGoods
    {
        public LogBuyPointGoods()
        {
            EventTag = string.Empty;
            Member = null;
            MemberCrm = null;
            MemberCrmScore = null;
            CostPointPartnerID = 0;
            CostPointID = 0;
            PointGoods = null;
            PointGoods_Coupon = null;
            BuyCount = 0;
            Price = 0;
            mall = null;
            portalId = 0;
            appChannelId = 0;
        }
        public string EventTag;
        public object Member;
        public object MemberCrm;
        public object MemberCrmScore;
        public int CostPointPartnerID;
        public int CostPointID;
        public object PointGoods;
        public object PointGoods_Coupon;
        public int BuyCount;
        public int Price;
        public object mall;
        public int portalId;
        public int appChannelId;
    }
    #endregion

    #region //埋点数据采集
    /// <summary>
    /// 埋点行为数据采集对象
    /// </summary>
    public class EmbedDataEntity
    {
        /// <summary>
        /// 埋点行为数据采集对象
        /// </summary>
        public EmbedDataEntity()
        {
            this.DateKey = DateTime.Now.Date;
            this.CreateTime = DateTime.Now;
            this.Title = string.Empty;
            this.Description = string.Empty;
        }

        #region 会员信息
        /// <summary>
        /// 会员id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberNo { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 会员头像
        /// </summary>
        public string MemberLogo { get; set; }

        #endregion

        #region 应用

        /// <summary>
        /// 应用类型
        /// </summary>
        public int AppChannelType { get; set; }

        /// <summary>
        /// 应用类型
        /// </summary>
        public string AppChannelTypeName { get; set; }

        /// <summary>
        ///  应用
        /// </summary>
        public string AppChannelId { get; set; }
        /// <summary>
        ///  应用名称
        /// </summary>
        public string AppChannelName { get; set; }


        #endregion

        #region 平台、商场、商户
        /// <summary>
        /// 是否平台
        /// </summary>
        public bool IsPlatform { get; set; }

        /// <summary>
        /// 商场编号
        /// </summary>
        public int MallId { get; set; }
        /// <summary>
        /// 商场名称
        /// </summary>
        public string MallName { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        #endregion

        #region Portal、渠道

        /// <summary>
        /// portal端编号
        /// </summary>
        public int PortalId { get; set; }
        /// <summary>
        /// portal名称
        /// </summary>
        public string PortalName { get; set; }

        /// <summary>
        /// 渠道Id
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        public string ChannelName { get; set; }
        #endregion

        #region 分享、导购

        /// <summary>
        /// 分享者会员ID
        /// </summary>
        public int SharerId { get; set; }
        /// <summary>
        /// 分享者会员名称
        /// </summary>
        public string SharerName { get; set; }

        /// <summary>
        /// 导购员ID
        /// </summary>
        public int ShopperId { get; set; }
        /// <summary>
        /// 导购员名称
        /// </summary>
        public string ShopperName { get; set; }
        #endregion



        #region 公众号来源
        /// <summary>
        /// 来源公众号ID
        /// </summary>
        public int FromWechatId { get; set; }
        /// <summary>
        /// 来源公众号名称
        /// </summary>
        public string FromWechatName { get; set; }
        #endregion

        #region 事件及内容类型
        /// <summary>
        /// 事件
        /// </summary>
        public int Event { get; set; }
        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; }


        /// <summary>
        /// 事件性质
        /// </summary>
        public int EventType { get; set; }



        /// <summary>
        /// 内容类型
        /// </summary>
        public int ContentType { get; set; }
        /// <summary>
        /// 内容类型名称
        /// </summary>
        public string ContentTypeName { get; set; }

        /// <summary>
        /// 内容类型2
        /// </summary>
        public int ContentType2 { get; set; }
        /// <summary>
        /// 内容类型名称2
        /// </summary>
        public string ContentTypeName2 { get; set; }
        #endregion


        /// <summary>
        /// 年月日日期部分
        /// </summary> 
        public DateTime DateKey { get; set; }

        /// <summary>
        /// 创建的时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 详情ID
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public int ActivityType { get; set; }

        /// <summary>
        ///  80进制码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 客户端ip
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 小程序场景值,小程序里自带的，其它没有
        /// </summary>
        public string Scene { get; set; }

        /// <summary>
        /// tagId列表
        /// </summary>
        public List<string> TagList { get; set; }


        #region 内容详细通用字段
        /// <summary>
        /// 是否成功，（用于：领取卡券、参与报名、参与抽奖、抽奖结果、接收消息）
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 是否采用积分支付（用于：领取卡券、参与报名、参与抽奖 ）
        /// </summary>
        public bool IsPointPay { get; set; }

        /// <summary>
        /// 是否采用现金支付（用于：领取卡券、参与报名、参与抽奖 ）
        /// </summary>
        public bool IsCashPay { get; set; }

        /// <summary>
        /// 是否获得券（用于：：领取卡券、参与报名、抽奖结果）
        /// </summary>
        public bool IsGetCoupon { get; set; }


        /// <summary>
        /// 实付积分（用于：订单提交、订单支付、领取卡券、参与报名、参与抽奖、卡券核销  ）
        /// </summary>
        public int ActualPoint { get; set; }

        /// <summary>
        /// 实付现金（用于：订单提交、订单支付、领取卡券、参与报名、参与抽奖、卡券核销 ）
        /// </summary>
        public decimal ActualAmount { get; set; }

        #endregion

        #region 订单相关

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 原始积分
        /// </summary>
        public int OriginalPoint { get; set; }

        /// <summary>
        /// 原始现金
        /// </summary>
        public decimal OriginalAmount { get; set; }



        /// <summary>
        /// 是否使用优惠券
        /// </summary>
        public bool IsUseCoupon { get; set; }

        /// <summary>
        /// 使用优惠券数量
        /// </summary>
        public int UseCouponCount { get; set; }

        /// <summary>
        /// 使用优惠券抵扣的金额
        /// </summary>
        public decimal UseCouponAmount { get; set; }

        /// <summary>
        /// 使用的券的类型,多个用逗号分割
        /// </summary>
        public string UseCouponTypes { get; set; }

        /// <summary>
        /// 使用的券的ID,多个用逗号分割
        /// </summary>
        public string UseCouponIds { get; set; }


        /// <summary>
        /// 商品数(1个口罩+2个眼镜，商品数是2)
        /// </summary>
        public int GoodsCount { get; set; }

        /// <summary>
        /// 商品类别1,多个用逗号分割
        /// </summary>
        public string GoodsTypes1 { get; set; }

        /// <summary>
        /// 商品类别2,多个用逗号分割
        /// </summary>
        public string GoodsTypes2 { get; set; }

        /// <summary>
        /// 商品编号,多个用逗号分割
        /// </summary>
        public string GoodsNos { get; set; }

        /// <summary>
        /// 购买数量（1个口罩+2个眼镜，购买数是3）
        /// </summary>
        public int GoodsQty { get; set; }

        /// <summary>
        /// 购买商品标题,多个用逗号分割
        /// </summary>
        public string GoodsTitles { set; get; }

        /// <summary>
        /// 是否支持积分购买
        /// </summary>
        public bool IsCanPointBuy { set; get; }
        /// <summary>
        /// 是否支持现金购买
        /// </summary>
        public bool IsCanCashBuy { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 订单付款状态
        /// </summary>
        public int OrderPayStatus { get; set; }

        /// <summary>
        /// 订单支付方式
        /// </summary>
        public int OrderPayment { get; set; }

        /// <summary>
        /// 订单支付流水号
        /// </summary>
        public string OrderPaymentNo { get; set; }

        /// <summary>
        /// 合作方Id 
        /// </summary>
        public int PartnerId { get; set; }

        #endregion

        #region 卡券

        /// <summary>
        ///购买的卡券数量
        /// </summary>
        public int CouponQty { get; set; }
        /// <summary>
        /// 卡券类型
        /// </summary>
        public int CouponType { get; set; }

        /// <summary>
        /// 卡券编号
        /// </summary>
        public string CouponCode { get; set; }


        #endregion

        #region 报名
        /// <summary>
        /// 报名人姓名
        /// </summary>
        public string EnrollName { get; set; }


        /// <summary>
        /// 报名人联系电话
        /// </summary>
        public string EnrollPhone { get; set; }

        /// <summary>
        /// 报名同行人数
        /// </summary>
        public int EnrollPersonCount { get; set; }

        /// <summary>
        /// 场次Id
        /// </summary>
        public int EnrollSessionId { get; set; }

        /// <summary>
        /// 报名场次名称
        /// </summary>
        public string EnrollSession { get; set; }

        /// <summary>
        /// 场次开始时间
        /// </summary>
        public DateTime? EnrollSessionStartTime { get; set; }

        /// <summary>
        /// 场次结束时间
        /// </summary>
        public DateTime? EnrollSessionEndTime { get; set; }
        #endregion

        #region 抽奖

        /// <summary>
        /// 是否中奖
        /// </summary>
        public bool IsWinning { get; set; }
        /// <summary>
        /// 奖品性质(卡券、积分)
        /// </summary>
        public int PrizeType { get; set; }

        /// <summary>
        /// 获得积分数
        /// </summary>
        public int GetPoint { get; set; }

        /// <summary>
        /// 获得卡券数
        /// </summary>
        public int GetCouponCount { get; set; }
        #endregion

        #region 微信菜单
        /// <summary>
        /// 微信公众号菜单类型
        /// </summary>
        public int WechatMenuType { get; set; }

        /// <summary>
        /// 微信公众号菜单编号
        /// </summary>
        public string WechatMenuNo { get; set; }

        /// <summary>
        /// 微信公众号菜单Url
        /// </summary>
        public string WechatMenuUrl { get; set; }
        #endregion

        #region 推送消息

        /// <summary>
        /// 消息类型,见枚举
        /// </summary>
        public int MessageType { get; set; }


        /// <summary>
        /// 模板名称或图文名称等
        /// </summary>
        public string MessageTitle { get; set; }

        /// <summary>
        /// 推送内容的ID,如图文的media_id、模板id等
        /// </summary>
        public string MessageContentId { get; set; }

        /// <summary>
        /// 消息推送原因,见枚举
        /// </summary>
        public int MessagePushReason { get; set; }


        /// <summary>
        /// 消息触发方式,见枚举
        /// </summary>
        public int MessageSendType { get; set; }
        #endregion

        #region 卡券核销

        /// <summary>
        /// 卡券核销端
        /// <summary>
        public int CouponSpendClient { get; set; }

        /// <summary>
        /// 卡券核销端名称
        /// <summary>
        public string CouponSpendClientName { get; set; }

        /// <summary>
        /// 卡券核销端编号，如POS机编号等
        /// </summary>
        public string CouponSpendClientNo { get; set; }

        /// <summary>
        /// 核销人
        /// </summary>
        public string CouponSpendUser { get; set; }
        /// <summary>
        /// 核销订单编号,如：pos产生的订单编号
        /// </summary>
        public string CouponSpendOrderNo { get; set; }

        /// <summary>
        /// 核销订单金额
        /// </summary>
        public decimal CouponSpendOrderAmount { get; set; }

        /// <summary>
        /// 核销订单优惠金额
        /// </summary>
        public decimal CouponSpendOrderDiscountAmount { get; set; }
        #endregion

        #region 地理位置
        /// <summary>
        /// 微信地理位置的维度
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 微信地理位置的经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 微信地理位置
        /// </summary>
        public string Address { get; set; }
        #endregion

        #region //名片访问
        /// <summary>
        /// 行为次数
        /// </summary>
        public int times { get; set; }
        /// <summary>
        /// 名片ID
        /// </summary>
        public int visitCardId { get; set; }
        /// <summary>
        /// 名片所属会员ID
        /// </summary>
        public int visitCardMemberId { get; set; }
        /// <summary>
        /// 名片所属会员名称
        /// </summary>
        public string visitCardMemberName { get; set; }
        /// <summary>
        /// 名片所属会员Logo
        /// </summary>
        public string visitCardMemberLogo { get; set; }

        #endregion
    }


    /// <summary>
    /// 渠道打开率
    /// </summary>
    public class ChannelOpenRate
    {
        /// <summary>
        /// 渠道Id
        /// </summary>
        public int ChannelId { get; set; }


        /// <summary>
        /// 事件
        /// </summary>
        public int Event { get; set; }


        /// <summary>
        /// 内容类型
        /// </summary>
        public int ContentType { get; set; }

        /// <summary>
        /// 会员id
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 详情ID
        /// </summary>
        public int DetailId { get; set; }
    }
    #endregion

    #region //用户计算合并
    /// <summary>
    /// 用户合并的对象,MergeMemberIDs里的会员按逗号分隔,会在Hadoop计算的时候将这些会员合并到TargetMemberId的会员是身上
    /// </summary>
    public class MemberMergeEntity
    {
        public int MemberID { get; set; }
        public string CodeNo { get; set; }
        public string NickName { get; set; }
        public string logo { get; set; }
        public string MergeIDs { get; set; }
        public bool IsMathAction { get; set; }
        public DateTime CreateTime { get; set; }
    }
    #endregion

  

    #region //企业微信组架构 

    /// <summary>
    /// 企业微信组架构
    /// </summary>
    public class WorkWxDepartmentEntity
    {

        /// <summary>
        /// 所属商业
        /// </summary>
        public int mall { get; set; }
        /// <summary>
        /// 企业号Id
        /// </summary>
        public string corpId { get; set; }

    }
    #endregion

    #region //商品素材推送

    public class GoodsValidEntity
    {

        /// <summary>
        /// 商品id
        /// </summary>
        public int goodsId { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public bool valid { get; set; }


        /// <summary>
        /// sku id
        /// </summary>
        public int skuId { get; set; }
    }

    /// <summary>
    /// 商品素材推送
    /// </summary>
    public class GoodsPushEntity
    {

        public GoodsPushEntity()
        {
            goodsId = 0;
            skuId = 0;
            activityId = 0;
        }

        /// <summary>
        /// 操作类型 1添加 2删除
        /// </summary>
        public int operationType { get; set; }

        /// <summary>
        /// 对象类型（1商品 2促销活动 3促销商品）
        /// </summary>
        public int entityType { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        public int goodsId { get; set; }

        /// <summary>
        /// 促销商品id
        /// </summary>
        public int saleId { get; set; }

        /// <summary>
        /// 活动id
        /// </summary>
        public int activityId { get; set; }


        /// <summary>
        /// sku id
        /// </summary>
        public int skuId { get; set; }
    }
    #endregion
}
