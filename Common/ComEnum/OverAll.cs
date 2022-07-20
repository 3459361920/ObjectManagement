using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wathet.Common
{
    public class ComEnum
    {

        #region fenggao

        public enum ActiveChannels
        {
            [Description("线下POS")]
            线下POS = 1,
        }

        public enum DeductionType
        {
            [Description("积分")]
            积分 = 1,
            [Description("卡券")]
            卡券 = 2,
        }

        public enum OrderLimit
        {
            [Description("无")]
            无 = 1,
            [Description("满足金额")]
            满足金额 = 2,
        }

        public enum SMSTemplete
        {
            [Description("SMS_183410857")]
            登录 = 1,
            [Description("")]
            亲友团 = 2,
            [Description("")]
            亲友团积分 = 3,
            [Description("")]
            亲友团电商券 = 4,
        }
        /// <summary>
        ///抽奖次数 行为类型
        /// </summary>

        public enum ActionType
        {
            [Description("初始化")]
            初始化 = 1,
            [Description("抽奖消耗")]
            抽奖消耗 = 2,
            [Description("分享")]
            分享 = 3,
            [Description("购买")]
            购买 = 4,
            [Description("每日赠送")]
            每日赠送 = 5,
            [Description("参与活动赠送")]
            参与活动赠送 = 6,
        }
        /// <summary>
        /// 同步状态
        /// </summary>
        public enum SyncStatus
        {
            [Description("未同步")]
            未同步 = 1,
            [Description("已同步")]
            已同步 = 2,
            [Description("修改待同步")]
            修改待同步 = 3,
        }

        /// <summary>
        /// 分享领取类型
        /// </summary>
        public enum ShareType
        {
            [Description("每天")]
            每天 = 1,
            [Description("最多")]
            最多 = 2,
        }


        /// <summary>
        /// 适用渠道
        /// </summary>
        public enum ChannelsRange
        {
            [Description("全场可用")]
            全场可用 = 1,
            [Description("指定可用")]
            指定可用 = 2
        }

        /// <summary>
        /// 新零售券适用范围
        /// </summary>
        public enum ResaleApplyCoupon
        {
            [Description("全场适用")]
            全场可用 = 1,
            [Description("部分商户适用")]
            部分商户适用 = 2,
            [Description("部分商户不适用")]
            部分商户不适用 = 7,
            [Description("部分商品适用")]
            部分商品适用 = 3
        }
        /// <summary>
        /// 渠道
        /// </summary>
        public enum Channels
        {
            [Description("H5")]
            H5 = 1,
            [Description("小程序")]
            小程序 = 2,
            [Description("APP")]
            APP = 3,
            [Description("商城")]
            商城 = 4,
            [Description("POS")]
            POS = 5,
            [Description("上传小票")]
            上传小票 = 6,
            [Description("支付宝支付")]
            支付宝支付 = 7,
            [Description("微信支付")]
            微信支付 = 8,
            [Description("其他")]
            其他 = 9,
        }
        /// <summary>
        /// 奖励类型
        /// </summary>
        public enum RewardType
        {
            [Description("无")]
            无 = 0,
            [Description("积分")]
            积分 = 1,
            [Description("卡券")]
            卡券 = 2,
            [Description("电商活动")]
            电商活动 = 3,
            [Description("抽奖")]
            抽奖 = 4,
            [Description("线下礼品")]
            线下礼品 = 5,
        }
        /// <summary>
        /// 默认图片
        /// </summary>
        public enum DefaultImage
        {
            logo小图,
            列表小图,
            内页大图
        }
        /// <summary>
        /// 导出状态
        /// </summary>
        public enum ExportStatus
        {
            [Description("待处理")]
            待处理 = 0,
            [Description("导出成功")]
            导出成功 = 1,
            [Description("导出失败")]
            导出失败 = 2,
        }
        /// <summary>
        /// 小票
        /// </summary>
        public enum smallticket
        {
            [Description("上传小票")]
            上传小票 = 1,
            [Description("小票审核通过")]
            小票审核通过 = 2
        }
        /// <summary>
        /// 适用商户范围
        /// </summary>
        public enum shopRange
        {
            [Description("全场商户")]
            全场商户 = 1,
            [Description("特定商户")]
            特定商户 = 2
        }
        /// <summary>
        /// 适用商场范围
        /// </summary>
        public enum mallRange
        {
            [Description("所有商场")]
            所有商场 = 1,
            [Description("特定商场")]
            特定商场 = 2
        }
        /// <summary>
        /// 适用业态范围
        /// </summary>
        public enum businessRange
        {
            [Description("特定业态")]
            特定业态 = 1,
            [Description("特定商户")]
            特定商户 = 2
        }
        /// <summary>
        /// 核销地点
        /// </summary>
        public enum VerifyPlace
        {
            [Description("服务台")]
            服务台 = 1,
            [Description("租户")]
            租户 = 2,
            [Description("SPU")]
            SPU = 3,
            [Description("SKU")]
            SKU = 4
        }
        /// <summary>
        /// 导出数据类型
        /// </summary>
        public enum ExportType
        {
            [Description("卡券列表")]
            卡券列表 = 1,
            [Description("领券量列表")]
            领券量列表 = 2,
            [Description("核销量列表")]
            核销量列表 = 3,
            [Description("销售月报表")]
            销售月报表 = 4,
            [Description("卡券核销的统计")]
            卡券核销的统计 = 5,
            [Description("免费领券活动统计")]
            免费领券活动统计 = 6,
            [Description("亲友团活动统计")]
            亲友团活动统计 = 7,
            [Description("报名活动统计")]
            报名活动统计 = 8,
            [Description("注册送券活动统计")]
            注册送券活动统计 = 9,
            [Description("兑换码活动统计")]
            兑换码活动统计 = 10,
            [Description("发券活动统计")]
            发券活动统计 = 11,
            [Description("上传小票活动统计")]
            上传小票活动统计 = 12,
            [Description("商户扫码活动统计")]
            商户扫码活动统计 = 13,
            [Description("抽奖活动统计")]
            抽奖活动统计 = 14,
            [Description("店铺列表")]
            店铺列表 = 15,
            [Description("发券活动")]
            发券活动 = 16,
            [Description("报名信息")]
            报名信息 = 17,
            [Description("亲友团开团列表")]
            亲友团开团列表 = 18,
            [Description("兑换码券码")]
            兑换码券码 = 19,
            [Description("活动审核列表")]
            活动审核列表 = 20,
            [Description("停车支付成功订单")]
            停车支付成功订单 = 21,
            [Description("停车支付错误记录")]
            停车支付错误记录 = 22,
            [Description("停车支付抵扣记录")]
            停车支付抵扣记录 = 23,
            [Description("积分商品列表")]
            积分商品列表 = 24,
            [Description("积分订单")]
            积分订单 = 25,

        }

        /// <summary>
        /// POS来源
        /// </summary>
        public enum SourceType
        {
            [Description("登录")]
            登录 = 1,
            [Description("注册")]
            注册 = 2,
            [Description("直接")]
            直接 = 3,
            [Description("抵扣")]
            抵扣 = 4
        }


        /// <summary>
        /// 满减消费类型
        /// </summary>
        public enum FullSubtractConsumptionType
        {
            [Description("单笔累计消费")]
            单笔累计消费 = 1,
            [Description("当天累计消费")]
            当天累计消费 = 2
        }

        #endregion


        #region //积分更新方式

        /// <summary>
        /// 积分限制
        /// </summary>
        public enum ruletype
        {
            [Description("每日每位顾客限兑换礼品份数")]
            每日每位顾客限兑换礼品份数 = 1,

            [Description("每个礼品每位顾客限兑换份数")]
            每个礼品每位顾客限兑换份数 = 2,

            [Description("无兑换限制")]
            无兑换限制 = 3,
        }
        #endregion

        #region //积分订单状态

        /// <summary>
        /// 积分订单交易状态
        /// </summary>
        public enum TransStatus
        {
            [Description("已完成")]
            已完成 = 1,
            [Description("已取消")]
            已取消 = 2,
            [Description("部分取消")]
            部分取消 = 3,
            [Description("已支付")]
            已支付 = 4,
            [Description("已失败")]
            已失败 = 5,
        }

        #endregion

        #region //字段值比较
        /// <summary>
        /// 字段值比较
        /// </summary>
        public enum CompareOp
        {
            [Description("不操作")]
            不操作 = 1,
            [Description("等于")]
            等于 = 2,
            [Description("不等于")]
            不等于 = 3,
            [Description("大于")]
            大于 = 4,
            [Description("大于等于")]
            大于等于 = 5,
            [Description("小于")]
            小于 = 6,
            [Description("小于等于")]
            小于等于 = 7,
            /// <summary>
            /// 表中数据 使用like
            /// </summary>
            [Description("包含")]
            包含 = 8,
            [Description("不包含")]
            不包含 = 9,
            /// <summary>
            /// 表中数据包含于程序里的列表, sql查询时用 column in (list), 使用包含于的时候..数据类型要求使用 string, 如果int会被屏蔽
            /// </summary>
            [Description("包含于")]
            包含于 = 10,
            /// <summary>
            /// 相当于 like '***%'
            /// </summary>
            [Description("后段包含")]
            后段包含 = 11
        }

        #endregion



        #region //日志等级
        /// <summary>
        /// 日志等级
        /// </summary>
        public enum LogLevel
        {
            [Description("信息")]
            Info = 1,
            [Description("调试")]
            Debug = 2,
            [Description("警告")]
            Warn = 3,
            [Description("异常")]
            Error = 4,
            [Description("毁灭")]
            Fatal = 5,
        }
        /// <summary>
        /// 队列类型 根据此枚举获取队列名
        /// </summary>
        public enum RabbitQueue
        {
            [Description("Wathet.Log")]
            日志_常规 = 0,
            [Description("Wathet.SmsSend.Log")]
            日志_短信发送 = 1,
            [Description("Wathet.MemberActionLog")]
            会员使用记录 = 2,
            [Description("Wathet.Crm.Api.Visit")]
            日志_CRM主接口_访问 = 3,
            [Description("Wathet.Crm.Api.Modifiy")]
            日志_CRM主接口_操作修改 = 4,
            [Description("Wathet.Crm.Wechat.Visit")]
            日志_微信端_访问 = 5,
            [Description("Wathet.Crm.Wechat.Modifiy")]
            日志_微信端_操作日志 = 6,
            [Description("Wathet.JS.Log")]
            日志_前端JS日志信息 = 7,
            [Description("Wathet.Crm.Merchant.Visit")]
            日志_商户端_访问 = 8,
            [Description("Wathet.Crm.Merchant.Modifiy")]
            日志_商户端_操作日志 = 9,
            [Description("Wathet.Wechat.PV")]
            日志_前端PV记录 = 10,
            [Description("Wathet.CRM.PV")]
            日志_后端PV记录 = 11,
            [Description("Wathet.OpenService.Visit")]
            日志_OpenService_接口日志 = 12,

            [Description("Wathet.Merchants")]
            日志_商户后台 = 13,
            [Description("Wathet.Api")]
            日志_Api = 14,
            [Description("Wathet.MallShop")]
            日志_商场商户 = 15,
            [Description("Wathet.Wx.Error")]
            日志_微信错误日志 = 16,
            [Description("Wathet.Wifi.Mac.Api")]
            日志_WifiMacApi = 17,
            [Description("Wathet.Login.Phone.Api")]
            日志_LoginPhoneApi = 18,
            [Description("Wathet.Malls")]
            日志_商场后台 = 19,
            [Description("Wathet.Sms")]
            日志_Sms = 20,
            [Description("Wathet.Merchant.Scan.Log")]
            日志_商户扫码发券 = 21,

            [Description("Wathet.Merchant.Coupon.Code")]
            商户后台生成兑换码券码 = 22,

            [Description("Wathet.ExternalApi.Visit")]
            日志_对外API_访问 = 23,
            [Description("Wathet.ExternalApi.Modifiy")]
            日志_对外API_操作日志 = 24,
            [Description("Wathet.ExportInfo")]
            日志_数据导出 = 25,

            [Description("Wathet.CheckCoupon.Api.Visit")]
            日志_PC核销_访问 = 26,
            [Description("Wathet.CheckCoupon.Api.Modifiy")]
            日志_PC核销_操作日志 = 27,


            [Description("Wathet.CRM.Visit")]
            日志_访问CRM记录 = 28,
            [Description("Wathet.CRM.Warn")]
            日志_CRM警报记录 = 29,

            [Description("Wathet.Coupon.Visit")]
            日志_卡券_访问 = 30,
            [Description("Wathet.Coupon.Modifiy")]
            日志_卡券_操作日志 = 31,

            [Description("Wathet.Activity.Visit")]
            日志_活动_访问 = 32,
            [Description("Wathet.Activity.Modifiy")]
            日志_活动_操作日志 = 33,
            [Description("Wathet.Qianlan.Modifiy")]
            日志_浅蓝操作日志 = 34,

            [Description("Wathet.OpenCoupon.Visit")]
            日志_对外卡券_访问 = 35,
            [Description("Wathet.OpenCoupon.Modifiy")]
            日志_对外卡券_操作日志 = 36,

            [Description("Wathet.Quartz.Visit")]
            日志_服务_访问 = 37,
            [Description("Wathet.Quartz.Modifiy")]
            日志_服务_操作日志 = 38,
            [Description("Wathet.Park")]
            日志_停车 = 39,
            [Description("Wathet.Park.server")]
            日志_停车_服务 = 40,

            [Description("Wathet.Park.Visit")]
            日志_停车_访问 = 41,
            [Description("Wathet.Park.Modifiy")]
            日志_停车_操作日志 = 42,
            [Description("Wathet.FosunAlliance.Log")]
            日志_星选权益接口调用 = 43,

            [Description("Sql.PV.Park_KeTuo_PV")]
            日志_停车_科拓 = 44,

            [Description("Sql.PV.Park_PiaoTong_PV")]
            日志_开票_票通 = 45,
        }

        #endregion

        #region //SUM汇总相关



        #region //字段的数据类型..对应到数据库中的数据类型
        /// <summary>
        /// 字段的数据类型..对应到数据库中的数据类型
        /// </summary>
        public enum ExcDataType
        {
            [Description("int")]
            整数 = 1,
            [Description("decimal")]
            小数 = 2,
            [Description("nvarchar")]
            字符串 = 3,
            [Description("bit")]
            是否 = 4,
            [Description("datetime")]
            时间 = 5,
            [Description("nvarchar")]
            列表 = 6,
            [Description("nvarchar")]
            文章 = 7,
            [Description("nvarchar")]
            大文本 = 8,
        }
        #endregion


        #endregion

        #region //SQL索引类型

        public enum SQLIndexType
        {
            [Description("普通")]
            普通 = 1,
            [Description("唯一索引")]
            唯一索引 = 2,
            [Description("聚集聚集")]
            聚集索引 = 3
        }
        #endregion

        #region //支付方式
        /// <summary>
        /// 支付方式
        /// </summary>
        public enum PayType
        {
            [Description("微信支付")]
            微信支付 = 1,
            [Description("支付宝支付")]
            支付宝支付 = 2,
            [Description("银联支付")]
            银联支付 = 3,
            [Description("第三方支付")]
            第三方支付 = 4
        }
        #endregion

        #region //汇付支付方式
        /// <summary>
        /// 支付方式
        /// </summary>
        public enum HPayType
        {
            [Description("未知")]
            未知 = -1,
            [Description("微信小程序支付")]
            微信小程序支付 = 1,
            [Description("网银支付")]
            网银支付 = 2,
            [Description("聚合钱包")]
            聚合钱包 = 3,
            [Description("聚合钱包_支付宝支付")]
            聚合钱包_支付宝支付 = 4,
            [Description("聚合钱包_公众号支付")]
            聚合钱包_公众号支付 = 5,
            [Description("网银支付_企业网银")]
            网银支付_企业网银 = 6,
            [Description("网银支付_个人网银")]
            网银支付_个人网银 = 7,
            [Description("支付宝小程序支付")]
            支付宝小程序支付 = 8,
            [Description("微信公众号")]
            微信公众号 = 9,
            [Description("支付宝生活号")]
            支付宝生活号 = 10
        }
        #endregion

        #region 汇付回调返回
        /// <summary>
        /// 回调返回状态
        /// </summary>
        public enum CallbackResponseenum
        {
            /// <summary>
            /// 请求成功
            /// </summary>
            [Description("请求成功")]
            请求成功 = 10000,
            /// <summary>
            /// 请求处理中
            /// </summary>
            [Description("请求处理中")]
            请求处理中 = 10001,
            /// <summary>
            /// 请求已受理
            /// </summary>
            [Description("请求已受理")]
            请求已受理 = 10002,
            /// <summary>
            /// 请求失败
            /// </summary>
            [Description("请求失败")]
            请求失败 = 10003,
        }
        #endregion

        #region 汇付支付状态
        public enum TransSate
        {
            [Description("初始")]
            初始 = 1,
            [Description("处理中")]
            处理中 = 2,
            [Description("成功")]
            成功 = 3,
            [Description("失败")]
            失败 = 4
        }
        #endregion


        #region //客户端类型
        /// <summary>
        /// 客户端类型
        /// </summary>
        public enum ClientChannel
        {
            [Description("微信")]
            微信公众号 = 1,
            [Description("APP")]
            APP = 2,
            [Description("后台")]
            后台添加 = 3,
            [Description("网页")]
            PC端网页 = 4,
            [Description("微信小程序")]
            微信小程序 = 5,
        }
        #endregion




        #region //卡券的使用条件
        /// <summary>
        /// 卡券的使用条件
        /// </summary>
        public enum ParkCouponLimitType
        {
            [Description("您已在规定时间内使用过卡券")]
            已在规定时间内使用过卡券 = 1,
            [Description("卡券未到开始使用时间")]
            卡券未到开始使用时间 = 2,
            [Description("停车时长不足")]
            停车时长不足 = 3,
            [Description("停车金额不足")]
            停车金额不足 = 4
        }

        #endregion


        #region //发布状态

        /// <summary>
        /// 数据状态 用于数据筛选条件
        /// </summary>
        public enum PublishStatus
        {
            [Description("已发布")]
            已发布 = 1,
            [Description("未发布")]
            未发布 = 2
        }
        #endregion

        #region //对象类型
        /// <summary>
        /// 数据库对象类型, 主要用于修改和启用禁用时的日志存储和后期处理
        /// </summary>
        public enum EntityType
        {
            [Description("商场信息")]
            Mall = 1,

            [Description("店铺")]
            Shop = 2,
            [Description("用户")]
            User = 3,

            [Description("会员信息")]
            Member = 4,
            [Description("会员注册渠道")]
            Member_RegChannel = 5,
            [Description("品牌信息")]
            Info_Brand = 6,
            [Description("卡券详情")]
            Coupon = 7,
            [Description("营销报名")]
            Sale_Enroll = 8,
            [Description("营销促销")]
            Sale_Promotion = 9,
            [Description("营销公告")]
            Sale_Notice = 10,
            [Description("营销注册送券")]
            Sale_RegisterCoupon = 11,
            [Description("营销免费领券")]
            Sale_RewardCoupon = 12,
            [Description("营销抽奖")]
            Sale_LuckDraw = 13,
            [Description("营销抽奖奖品")]
            Sale_LuckDrawPrize = 14,
            [Description("微信端信息")]
            WX_Ele = 15,
            [Description("商场微信端UI配置信息")]
            WX_MallConfig = 16,
            [Description("会员活动记录")]
            Member_ActivityHistory = 17,
            [Description("报名场次")]
            Sale_EnrollField = 18,
            [Description("抽奖场次")]
            Sale_LuckDrawField = 19,
            [Description("合作方系统")]
            Partner = 20,

            [Description("用户端设置")]
            UI_Portal = 21,
            [Description("粉丝")]
            Member_Fans = 22,
            [Description("认证会员")]
            MemberCrm = 23,
            [Description("卡券适用门店")]
            Coupon_ApplyShop = 24,
            [Description("卡券领取记录")]
            Member_Coupon = 25,

            [Description("订单满减满赠")]
            Sale_OrderActivity = 26,
            [Description("订单满赠规则")]
            Sale_OrderActivityGiftRule = 27,
            [Description("电商促销活动")]
            Sale_Goods = 28,
            [Description("电商促销活动商品")]
            Sale_GoodsInfo = 29,


            [Description("营销上传小票")]
            Sale_Receipt = 30,
            [Description("营销商户扫码发券")]
            Sale_scan = 31,
            [Description("营销商户扫码发券库存管理")]
            Sale_scan_amount = 32,


            [Description("营销免费领积分")]
            Sale_Free_bonus_points = 33,

            [Description("营销亲友团")]
            Sale_Tuan = 34,
            [Description("营销商场投票")]
            Sale_Mall_Vote = 35,
            [Description("营销大转盘活动")]
            Sale_Turnplate = 36,
            [Description("营销大转盘活动奖品")]
            Sale_Turnplate_Prize = 37,
            [Description("营销Pos促销活动")]
            Sale_Pos_Promotion = 38,
            [Description("营销兑换码")]
            Sale_RedeemCode = 39,
            [Description("营销商场投票")]
            Sale_Vote = 40,
            [Description("营销商场投票管理")]
            Sale_Vote_Option = 41,
            [Description("营销签到活动")]
            Sale_Sign_Award = 42,
            [Description("营销签到规则")]
            Sale_Sign_Rule = 43,



            [Description("停车场设置")]
            Park_Pay_Setting = 44,
            [Description("停车场抵扣规则设置")]
            Park_Mall_Change = 45,
            [Description("缴费抵扣规则设置审核")]
            Park_Mall_Change_Audit = 46,
            [Description("停车场闸机设置")]
            Park_Gate = 180,

            [Description("销售月报表")]
            Sale_Monreport = 47,
            [Description("兑换码换积分")]
            Code_Exchange_Integral = 48,
            [Description("停车折扣设置")]
            Mall_Discount = 49,
            [Description("活动卡券")]
            Activity_Coupon = 50,
            [Description("兑换码换卡券")]
            Code_Exchange_Coupon = 51,
            [Description("停车场开票设置")]
            ParkElectricityTicketMall = 52,

            [Description("消费福利活动")]
            Sale_ConsumerWelfare = 54,
            [Description("营销消费福利活动奖品")]
            Sale_ConsumerWelfare_Prize = 55,
            [Description("活动类型")]
            Activity_Type = 56,
            [Description("营销注册送券活动奖品")]
            Sale_Register_Prize = 57,
            [Description("推广方式")]
            Promotion_Type = 58,
            [Description("定向发券")]
            Sale_SendCoupon = 61,
            [Description("分配卡券核销数量")]
            Assign_CouponCheck = 62,
            [Description("活动")]
            Sale_DonateStep = 63,
            [Description("活动奖品")]
            Sale_DonateStep_Prize = 64,
            [Description("活动分组")]
            ActiviyGroup = 65,
            [Description("卡券分组")]
            CouponGroup = 66,
            [Description("活动包")]
            ActiviyPackage = 67,
            [Description("卡券包")]
            CouponPackage = 68,
            [Description("领电商券")]
            Sale_RewardCOICoupon = 69,
            [Description("卡券活动关联")]
            Activity_Coupons = 70,
            [Description("积分商品")]
            PointGoods = 71,
            [Description("积分订单")]
            Member_OrderPointGoods = 72,
            [Description("积分商品优惠时间")]
            PointGoods_Time_Extend = 73,
            [Description("订单")]
            Orders = 74,
            [Description("领取CDP券")]
            Sale_RewardCDPCoupon = 75,
            [Description("领取产业券券")]
            Sale_RewardThirdCoupon = 76,
            [Description("用户创建申请")]
            User_Apply = 77,

            [Description("API定义")]
            Apis_Type = 149,
            [Description("API操作")]
            ApiOperation_Type = 150,
            [Description("API分组管理")]
            ApiGroup_Type = 151,
            [Description("API历史版本")]
            Apis_History = 152,
            [Description("User联系人")]
            User_Contact = 153,
            [Description("API申请")]
            Apis_Apply = 154,
            [Description("Wiki分类")]
            Wiki_Class = 155,
            [Description("Wiki内容")]
            Wiki_Content = 156,
            [Description("所属系统")]
            FromSystem = 157,

            [Description("活动主题")]
            ActivityTopic = 164,
            [Description("邀请有礼")]
            Sale_InviteRegister = 165,
            [Description("邀请有礼奖品")]
            Sale_InviteRegisterPrize = 166,
            [Description("被邀请有礼")]
            Sale_CoverInviteRegister = 167,
            [Description("自定义字段")]
            CustomColumn = 168,
            [Description("场景触发活动")]
            Sale_Trigger_Activity = 169,
            [Description("营销场景触发活动奖品")]
            Sale_Trigger_Prize = 170,
            [Description("用户权限")]
            User_Auth = 171,

            [Description("开放平台用户关联所属系统")]
            User_FromSystem_Platform = 178,

            [Description("补贴活动")]
            Sale_Subsidy = 179,

        }
        #endregion

        #region //操作类型
        /// <summary>
        /// 操作类型
        /// </summary>
        public enum EntityMethod
        {
            [Description("添加")]
            添加 = 1,
            [Description("删除")]
            删除 = 2,
            [Description("修改信息")]
            修改信息 = 3,
            [Description("启用")]
            启用 = 4,
            [Description("禁用")]
            禁用 = 5,
            [Description("修改中奖几率")]
            修改中奖几率 = 6,
            [Description("发布")]
            发布 = 7,
            [Description("未发布")]
            未发布 = 8,
            [Description("修改排序编号")]
            修改排序编号 = 9,
            [Description("登入系统")]
            登入系统 = 10,
            [Description("登出系统")]
            登出系统 = 11,
            [Description("审核")]
            审核 = 12,
            [Description("修改场次奖品发放限额")]
            修改场次奖品发放限额 = 13,
            [Description("取消订单")]
            取消订单 = 14,

        }

        #endregion

        #region //卡券

        #region //卡券类型
        /// <summary>
        /// 卡券类型 
        /// </summary>
        public enum CouponType
        {

            [Description("代金券")]
            代金券 = 2,
            [Description("礼品券")]
            礼品券 = 3,
            [Description("停车券")]
            停车券 = 6,
            [Description("报名券")]
            报名券 = 7,
            [Description("折扣券")]
            折扣券 = 9,
            [Description("体验券")]
            体验券 = 10,
            [Description("星选券")]
            星选券 = 11
        }
        #endregion

        #region //卡券使用类型
        /// <summary>
        /// 卡券使用类型
        /// </summary>
        public enum CouponStockType
        {
            [Description("共享")]
            共享 = 1,
            [Description("独自使用")]
            独自使用 = 2,
        }
        #endregion

        #region //卡券有效期
        /// <summary>
        /// 卡券有效期
        /// </summary>
        public enum CouponValidity
        {
            [Description("固定日期")]
            固定日期 = 1,
            [Description("领取后")]
            领取后天数 = 2
        }
        #endregion

        #region //卡券可用时段
        /// <summary>
        /// 卡券可用时段
        /// </summary>
        public enum CouponUseableRange
        {
            [Description("全部时段")]
            全部时段 = 1,
            [Description("部分时段")]
            部分时段 = 2
        }
        #endregion

        #region //扫码核销形式
        /// <summary>
        /// 扫码核销形式
        /// </summary>
        public enum CouponSpendQrCodeType
        {
            [Description("二维码")]
            二维码 = 1,
            [Description("条码")]
            条码 = 2,
            [Description("仅卡券号")]
            仅卡券号 = 3
        }
        #endregion

        #region //卡券价值类型
        /// <summary>
        /// 卡券价值类型
        /// </summary>
        public enum CouponAmountType
        {
            [Description("抵扣金额")]
            金额 = 1,
            [Description("抵扣时长")]
            时长 = 2,
            [Description("折扣比例")]
            折扣 = 3,
        }
        #endregion

        #region //卡券的使用条件
        /// <summary>
        /// 卡券的使用条件
        /// </summary>
        public enum CouponSpendLimitType
        {
            [Description("无条件")]
            无条件 = 1,
            [Description("最低消费")]
            最低消费 = 2,
            [Description("重复满减")]
            重复满减 = 3,
            [Description("购买指定商品")]
            购买指定商品 = 4,
            [Description("停车满时长")]
            停车满时长 = 5,
            [Description("停车满金额")]
            停车满金额 = 6,
            [Description("购买商品满几件可用")]
            购买商品满几件可用 = 7,
            [Description("购买商品第几件可用")]
            购买商品第几件可用 = 8,
            [Description("单笔消费")]
            单笔消费 = 9,
        }

        #endregion

        #region //卡券核销形式
        /// <summary>
        /// 卡券核销形式
        /// </summary>
        public enum CouponSpendType
        {
            [Description("消费使用")]
            消费使用 = 1,
            [Description("停车使用")]
            停车使用 = 2,
        }
        #endregion

        #region //卡券核销状态
        /// <summary>
        /// 卡券核销状态
        /// </summary>
        public enum CouponSpendStep
        {
            [Description("未使用")]
            未使用 = 1,
            [Description("已使用")]
            已使用 = 2,
            [Description("已过期")]
            已过期 = 3,
            [Description("未经审核")]
            未经审核 = 4,
            [Description("审核拒绝")]
            审核拒绝 = 5,
            [Description("已退还")]
            已退还 = 6,
            [Description("未生效")]
            未生效 = 7,
            [Description("已冻结")]
            已冻结 = 8
        }

        #endregion

        #region //卡券核券方
        /// <summary>
        /// 卡券核券渠道
        /// </summary>
        public enum CouponSpendChannel
        {
            [Description("线上商城")]
            线上商城 = 1,
            [Description("线下商场")]
            线下商场 = 2,
            [Description("第三方卡券")]
            第三方卡券 = 3
        }

        /// <summary>
        /// 卡券核券子渠道
        /// </summary>
        public enum CouponUseChannel
        {
            [Description("POS")]
            POS = 1,
            [Description("PC端核销")]
            PC端核销 = 2,
        }

        /// <summary>
        /// 卡券核券方
        /// </summary>
        public enum CouponSpendFeature
        {
            [Description("服务台")]
            服务台 = 1,
            [Description("商场")]
            商场 = 2,
            [Description("停车场")]
            停车场 = 3,
            [Description("店铺")]
            店铺 = 4,
            [Description("其他")]
            其他 = 5,
            [Description("POS")]
            POS = 6,
            [Description("C端线上")]
            C端线上 = 7,
            [Description("星选兑换券")]
            星选兑换券 = 8
        }

        /// <summary>
        /// 卡券核銷端
        /// </summary>
        public enum CouponSpendClient
        {
            [Description("商户手机端")]
            商户手机端 = 1,
            [Description("POS端")]
            POS端 = 2,
            [Description("会员C端")]
            会员C端 = 3,
            [Description("PC端核销")]
            PC端核销 = 4,
            [Description("停车核销")]
            停车核销 = 5,
            [Description("星选兑换券核销")]
            星选兑换券核销 = 6
        }

        #endregion

        #endregion


        #region //促销是否启用倒计时
        /// <summary>
        /// 促销是否启用倒计时
        /// </summary>
        public enum SaleDownTimeType
        {
            [Description("不启用倒计时")]
            不启用倒计时 = 1,
            [Description("启用开始倒计时")]
            启用开始倒计时 = 2,
            [Description("启用结束倒计时")]
            启用结束倒计时 = 3
        }
        #endregion

        #region //验证积分形式
        /// <summary>
        /// 验证积分形式
        /// </summary>
        public enum SalePointCheckType
        {
            [Description("免费")]
            免费 = 1,
            [Description("积分兑换")]
            积分兑换 = 2,
            [Description("验证积分")]
            验证积分 = 3,
            [Description("验证金币")]
            验证金币 = 4,
            [Description("金币兑换")]
            消耗金币 = 5,
        }
        #endregion

        #region //奖品类型
        /// <summary>
        /// 奖品类型
        /// </summary>
        public enum SalePrizeType
        {
            [Description("不中奖")]
            不中奖 = 1,
            [Description("卡券")]
            卡券 = 2,
            [Description("积分")]
            积分 = 3,
            [Description("抽奖机会")]
            抽奖机会 = 4,
        }
        #endregion

        #region //卡券类型
        /// <summary>
        /// 卡券类型
        /// </summary>
        public enum StoreCouponType
        {
            [Description("非商城卡券")]
            否 = 0,
            [Description("商城卡券")]
            是 = 1
        }
        #endregion

        #region //是否卡券包类型
        /// <summary>
        /// 是否卡券包类型
        /// </summary>
        public enum CouponPackType
        {
            [Description("非卡券包")]
            否 = 0,
            [Description("卡券包")]
            是 = 1
        }
        #endregion

        #region 触发活动类型）
        /// <summary>
        /// 触发活动类型
        /// </summary>
        public enum TriggerType
        {
            [Description("完善资料")]
            完善资料 = 1
        }
        #endregion


        #region //是否可以抽奖类型（奖池为空时）
        /// <summary>
        /// 是否卡券包类型
        /// </summary>
        public enum CanDrawType
        {
            [Description("不能继续抽奖")]
            否 = 0,
            [Description("可以继续抽奖")]
            是 = 1
        }
        #endregion

        #region //积分奖品类型
        /// <summary>
        /// 积分奖品类型
        /// </summary>
        public enum IntegralPrizeType
        {
            [Description("固定积分")]
            固定积分 = 1,
            [Description("随机积分")]
            随机积分 = 2
        }
        #endregion

        #region //停车场景类型
        /// <summary>
        /// 停车场景类型
        /// </summary>
        public enum ParkingSceneType
        {
            [Description("会员开车进场")]
            会员开车进场 = 1,
            [Description("会员开车出场")]
            会员开车出场 = 2
        }
        #endregion

        #region //活动类型
        /// <summary>
        /// 活动类型
        /// </summary>
        public enum SaleActivityType
        {
            [Description("摇一摇")]
            摇一摇 = 1,
            [Description("大转盘抽奖")]
            大转盘抽奖 = 2,
            [Description("跑马灯抽奖")]
            跑马灯抽奖 = 3,
            [Description("老虎机抽奖")]
            老虎机抽奖 = 4,
            [Description("砸金蛋抽奖")]
            砸金蛋抽奖 = 5,
            [Description("摇一摇抽奖")]
            摇一摇抽奖 = 6,
            [Description("报名")]
            报名 = 7,
            [Description("卡券兑换")]
            卡券兑换 = 8,
            [Description("新会员福利")]
            新会员福利 = 9,
            [Description("公告")]
            公告 = 10,
            [Description("活动公告")]
            活动公告 = 11,

            [Description("扫码发券")]
            扫码发券 = 12,
            [Description("上传小票")]
            上传小票 = 13,
            [Description("上传小票大转盘")]
            上传小票大转盘 = 14,
            [Description("Pos交易后发券")]
            Pos交易后发券 = 15,
            [Description("兑换码活动")]
            兑换码活动 = 16,
            [Description("好友助力")]
            好友助力 = 17,
            [Description("签到")]
            签到 = 18,
            [Description("免费领积分")]
            免费领积分 = 19,


            [Description("定向发券")]
            定向发券 = 20,
            [Description("定向发券大批量")]
            定向发券大批量 = 21,

            [Description("投票")]
            投票 = 22,
            [Description("兑换码领积分")]
            兑换码领积分 = 23,

            [Description("抽奖活动")]
            抽奖活动 = 24,


            [Description("卡券核销")]
            卡券核销 = 25,
            [Description("卡券核销奖项")]
            卡券核销奖项 = 26,
            [Description("API发券")]
            API发券 = 27,
            [Description("活动")]
            活动 = 28,

            [Description("电商发券")]
            电商发券 = 29,

            [Description("消费有礼")]
            消费福利 = 30,

            [Description("积分商品")]
            积分商品 = 999,


            [Description("邀请有礼")]
            邀请有礼 = 31,
            [Description("被邀请有礼")]
            被邀请有礼 = 32,
            [Description("场景触发活动")]
            场景触发活动 = 33,

            [Description("停车缴费")]
            停车缴费 = 34,

            [Description("CDP发券")]
            CDP发券 = 35,
            [Description("产业发券")]
            产业发券 = 36,
            [Description("补贴活动")]
            补贴活动 = 37,
        }
        #endregion


        #region 老活动枚举
        public enum OtherActivityType
        {
            [Description("公告促销")]
            公告促销 = 0,
            [Description("免费领券")]
            免费领券 = 2,
            [Description("报名")]
            报名 = 4,
            [Description("亲友团")]
            亲友团 = 6,
            [Description("摇一摇")]
            摇一摇 = 7
        }


        #region //活动参与状态

        /// <summary>
        /// 活动参与状态
        /// </summary>
        public enum SignUpStatus
        {
            [Description("审核中")]
            审核中 = 1,
            [Description("已审核")]
            已审核 = 2,
            [Description("已成功参与")]
            已成功参与 = 3,
            [Description("已拒绝")]
            已拒绝 = 4,
            [Description("参与失败")]
            参与失败 = 5,
            [Description("已过期")]
            已过期 = 6,
        }

        #endregion




        #endregion

        #region //星期
        /// <summary>
        /// 星期
        /// </summary>
        public enum WeekDays
        {
            [Description("星期一")]
            星期一 = 1,
            [Description("星期二")]
            星期二 = 2,
            [Description("星期三")]
            星期三 = 3,
            [Description("星期四")]
            星期四 = 4,
            [Description("星期五")]
            星期五 = 5,
            [Description("星期六")]
            星期六 = 6,
            [Description("星期日")]
            星期日 = 7,
        }

        #endregion


        #region //积分来源
        /// <summary>
        /// 积分来源
        /// </summary>
        public enum PointFrom
        {

            [Description("参与活动消耗")]
            参与活动消耗 = 1,
            [Description("活动抽奖奖励")]
            活动抽奖奖励 = 2,
        }
        #endregion




        #region //积分更新方式

        /// <summary>
        /// 只要遇到Reward就是加积分,遇到Redemption就是减积分 后边跟ReFound 指这个积分是从以前的一个积分记录中来
        /// </summary>
        public enum PointMath
        {
            [Description("获取积分")]
            Reward = 1,

            [Description("消耗积分")]
            Redemption = 2,

            [Description("积分退还")]  //消耗积分Redemption对应
            Reward_Back = 3,

            [Description("积分补扣")]  //获取积分Reward对应
            Redemption_Back = 4,
        }


        #endregion



        #region //微信端页面元素
        /// <summary>
        /// 微信端页面元素
        /// </summary>
        public enum UI_Ele_WX
        {
            [Description("Banner图")]
            Banner图 = 1,
            [Description("首页滚动公告")]
            首页滚动公告 = 2,
            [Description("首页店铺推荐")]
            首页店铺推荐 = 3,
            [Description("首页活动推荐")]
            首页活动推荐 = 4,
            [Description("首页卡券推荐")]
            首页卡券推荐 = 5,
            [Description("活动列表")]
            活动列表 = 6,
            [Description("店铺活动列表")]
            店铺活动列表 = 7,

            [Description("首页广告位")]
            首页广告位 = 13,
            [Description("顶部Logo")]
            顶部Logo = 14,
            [Description("店铺列表")]
            店铺列表 = 15,
            [Description("积分换购列表")]
            积分换购列表 = 16,
            [Description("首页推送")]
            首页推送 = 17,
            [Description("投票活动")]
            投票活动 = 18,

        }
        #endregion

        #region //会员性质
        /// <summary>
        /// 会员性质
        /// </summary>
        public enum Feature
        {
            [Description("平台")]
            平台 = 1,
            [Description("商业")]
            商业 = 2,
            [Description("店铺")]
            商户 = 3,
            [Description("调用方")]
            调用方 = 4,
            [Description("接入方")]
            接入方 = 5,
            [Description("调用方接入方")]
            调用方接入方 = 6,
            [Description("中台管理组")]
            中台管理组 = 7,
            [Description("业务系统拥有者")]
            业务系统拥有者 = 8
        }

        /// <summary>
        /// 用户性质
        /// </summary>
        public enum UserFeature
        {
            [Description("平台")]
            平台 = 1,
            [Description("商业")]
            商业 = 2,
            [Description("商户")]
            商户 = 3
        }
        #endregion



        #region //抽奖渠道

        /// <summary>
        /// 抽奖渠道
        /// </summary>
        public enum LuckDrawChannel
        {
            [Description("站内信")]
            站内信 = 1,

            [Description("抽奖活动")]
            抽奖活动 = 2
        }

        #endregion

        #region 发放卡券类型
        public enum SendCouponType
        {
            [Description("扫码发券")]
            扫码发券 = 1,
            [Description("动态码领券")]
            动态码领券 = 2,
        }
        #endregion




        #region //状态码
        /// <summary>
        /// 项目状态码
        /// </summary>
        public enum Code
        {
            [Description("服务器繁忙，请刷新重试")]
            E_程序异常 = 500,

            #region 普通操作
            //--------------------------------------------
            //------------------用户普通操作返回--------------------
            //--------------------------------------------
            [Description("操作成功")]
            A_操作成功 = 0,
            [Description("操作失败")]
            A_操作失败 = 1,
            [Description("参数异常")]
            A_参数异常 = 2,
            [Description("未找到对象")]
            A_未找到对象 = 3,
            [Description("必填字段为空")]
            A_必填字段为空 = 4,
            [Description("输入Json与模型要求不一致")]
            A_输入Json与模型要求不一致 = 5,
            [Description("已有同名数据,请避免数据重复")]
            A_已有同名参数 = 6,
            [Description("条件判断未通过，刷新重试")]
            A_条件判断未通过 = 7,
            [Description("当前对象为失效或者禁用状态")]
            A_当前对象失效 = 8,
            [Description("数据异常")]
            A_数据错误_跳转 = 9,
            [Description("Email格式不正确")]
            A_Email格式不正确 = 10,
            [Description("需要删除理由")]
            A_需要删除理由 = 11,
            [Description("请先分配权限")]
            A_分配权限 = 12,
            [Description("邮箱已存在")]
            A_邮箱已存在 = 13,
            [Description("YAPI登录名已存在")]
            A_YAPI登录名已存在 = 14,
            [Description("请输入正确的手机号")]
            A_请输入正确的手机号 = 15,
            #endregion

            #region 用户
            //--------------------------------------------
            //------------------用户登录状态判断--------------------
            //--------------------------------------------
            [Description("用户名不可为空")]
            用户_用户名不可为空 = 98,
            [Description("RefreshToken失效")]
            用户_RefreshToken失效 = 99,
            [Description("未登录")]
            用户_未登录 = 100,
            [Description("会话超时")]
            用户_会话超时 = 101,
            [Description("Token失效")]
            用户_Token失效 = 102,
            [Description("用户名和密码均不可为空")]
            用户_用户名和密码均不可为空 = 103,
            [Description("用户名或者密码错误,请重新输入")]
            用户_用户名或密码错误 = 104,
            [Description("用户名错误")]
            用户_用户名错误 = 105,
            [Description("账户被禁用,或已删除")]
            用户_账户被禁用或已删除 = 106,
            [Description("当前会员身份未验证")]
            用户_会员身份未验证 = 107,
            [Description("认证会员等级异常")]
            用户_会员等级异常 = 108,
            [Description("鉴权失败")]
            用户_鉴权失败 = 109,


            #endregion

            #region 权限
            //--------------------------------------------
            //----------------用户操作权限判断---------------
            //--------------------------------------------
            [Description("未找到对应权限,访问路径异常")]
            权限_未找到对应权限 = 110,
            [Description("没有权限进行该模块操作")]
            权限_没有权限进行该模块操作 = 111,
            [Description("没有该操作需要的权限")]
            权限_没有该操作需要的权限 = 112,
            [Description("商场权限不足以执行此操作")]
            权限_商场权限不足以执行此操作 = 113,
            [Description("登录账号性质不允许进行此操作")]
            权限_登录账号性质不允许进行此操作 = 114,
            [Description("加载用户权限集失败")]
            权限_加载用户权限集失败 = 115,
            #endregion

            #region 活动准入
            //--------------------------------------------
            //----------------活动准入---------------
            //--------------------------------------------
            [Description("当前活动未发布")]
            活动准入_当前活动未发布 = 120,
            [Description("活动还未开始哦!请稍后再试")]
            活动准入_当前时间不能参与该活动 = 121,
            [Description("当前活动已无参与名额")]
            活动准入_当前活动已无参与名额 = 122,
            [Description("参与人数超过活动限制")]
            活动准入_参与人数超过活动限制 = 123,
            [Description("会员等级验证不通过")]
            活动准入_会员等级验证不通过 = 124,
            [Description("活动不适用于当前商场")]
            活动准入_活动不适用于当前商场 = 125,
            [Description("店铺不属于该商场")]
            活动准入_店铺不属于该商场 = 126,
            [Description("获取会员历史参与情况失败")]
            活动准入_获取会员历史参与情况失败 = 127,
            [Description("您已参加过此活动,请勿重复操作!")]
            活动准入_本活动不允许多次参与 = 128,
            [Description("本活动参与次数已用完")]
            活动准入_本活动参与次数已用完 = 129,
            [Description("本场次参与次数已用完")]
            活动准入_本场次参与次数已用完 = 130,
            [Description("您的积分余额不足,暂无法参与此活动!")]
            活动准入_积分余额不满足参与条件 = 131,
            [Description("活动积分验证参数异常")]
            活动准入_活动积分验证参数异常 = 132,
            [Description("活动参与积分设置异常")]
            活动准入_活动参与积分设置异常 = 133,
            [Description("不支持的活动类型")]
            活动准入_不支持的活动类型 = 134,
            [Description("未找到该活动或活动已失效")]
            活动准入_未找到该活动或活动已失效 = 135,
            [Description("未找到该抽奖场次的奖品设置")]
            活动准入_未找到该抽奖场次的奖品设置 = 136,
            [Description("未找到该场次或场次已失效")]
            活动准入_未找到该场次或场次已失效 = 137,
            [Description("要求的表单填写不完整")]
            活动准入_要求的表单填写不完整 = 138,
            [Description("您已中过奖了，把机会留给别人吧")]
            活动准入_不允许多次中奖 = 139,
            #endregion

            #region 卡券准入
            [Description("卡券已经过期,不能领取")]
            卡券准入_卡券已经过期 = 140,
            [Description("未能获取用户历史参与记录")]
            卡券准入_未能获取用户历史领卡信息 = 141,
            [Description("卡券已领完")]
            卡券准入_卡券已领完 = 142,
            [Description("剩余卡券不足购买数量")]
            卡券准入_剩余卡券不足购买数量 = 143,
            [Description("卡券当天发放量已领完")]
            卡券准入_当天发放量已发完 = 144,
            [Description("当天剩余发放量不足购买数量")]
            卡券准入_当天剩余发放量不足购买数量 = 145,
            [Description("已经到达个人领取上限")]
            卡券准入_已经到达个人领取上限 = 146,
            [Description("个人剩余可领取量不足购买数量")]
            卡券准入_个人剩余可领取量不足购买数量 = 147,
            [Description("已经到达个人当天领取上限")]
            卡券准入_已经到达个人当天领取上限 = 148,
            [Description("个人当天剩余可领取量不足购买数量")]
            卡券准入_个人当天剩余可领取量不足购买数量 = 149,
            [Description("卡券审核未通过")]
            卡券准入_卡券审核未通过 = 150,
            #endregion

            #region 积分商品购买

            [Description("未找到对应的价格列表")]
            积分商品购买_获取积分商品价格失败 = 160,
            [Description("当前时间不允许兑换")]
            积分商品购买_当前时间内不允许兑换 = 162,
            [Description("账户积分余额不足支付")]
            积分商品购买_账户积分余额不足支付 = 166,
            [Description("会员历史购买记录获取失败")]
            积分商品购买_会员历史购买记录获取失败 = 167,
            [Description("会员历史购买数量超限")]
            积分商品购买_会员历史购买数量超限 = 168,
            [Description("会员今日购买数量超限")]
            积分商品购买_会员今日购买数量超限 = 169,
            [Description("剩余可购买数量超限")]
            积分商品购买_剩余可购买数量超限 = 170,
            [Description("今日剩余可购买数量超限")]
            积分商品购买_今日剩余可购买数量超限 = 171,


            #endregion


            #region 自定义字段
            [Description("要求的字段未找到")]
            自定义字段_字段缺失 = 180,
            [Description("所选值不在给定范围")]
            自定义字段_所选值不在给定范围 = 181,
            [Description("卡券已全部退还")]
            自定义字段_卡券已全部退还 = 182,
            #endregion

            #region 卡券核销模块
            [Description("当前卡券活动主体已不存在")]
            卡券核销_当前卡券活动主体已不存在 = 200,
            [Description("当前卡券主体已不存在")]
            卡券核销_当前卡券主体已不存在 = 201,
            [Description("当前卡券无效")]
            卡券核销_当前卡券无效 = 202,
            [Description("当前卡券未生效")]
            卡券核销_当前卡券未生效 = 203,
            [Description("当前卡券已过期")]
            卡券核销_当前卡券已过期 = 204,
            [Description("当前卡券已核销")]
            卡券核销_当前卡券已核销 = 205,
            [Description("当前卡券不在此商场核销")]
            卡券核销_当前卡券不在此商场核销 = 206,
            [Description("当前卡券不在服务台核销")]
            卡券核销_当前卡券不在服务台核销 = 207,
            [Description("当前卡券不在此商户核销")]
            卡券核销_当前卡券不在此商户核销 = 208,
            [Description("当前卡券不在可用的日期范围内")]
            卡券核销_当前卡券不在可用的日期范围内 = 209,
            [Description("当前卡券不在可用的时段范围内")]
            卡券核销_当前卡券不在可用的时段范围内 = 210,
            [Description("当前报名券还未审核")]
            卡券核销_当前报名券还未审核 = 211,
            [Description("当前报名券审核拒绝")]
            卡券核销_当前报名券审核拒绝 = 212,
            [Description("不支持核销停车券")]
            卡券核销_不支持核销停车券 = 213,
            [Description("停车券不允许商户核销")]
            卡券核销_停车券不允许商户核销 = 214,
            [Description("停车券核销必传车牌号")]
            卡券核销_停车券核销必传车牌号 = 215,
            [Description("五分钟内不允许在两家商户核销")]
            卡券核销_五分钟内不允许在两家商户核销 = 216,
            [Description("卡券核销_POS核销为代金券")]
            卡券核销_POS核销为代金券 = 217,
            [Description("当前卡券不支持此核销渠道")]
            卡券核销_当前卡券不支持此核销渠道 = 218,
            [Description("当前商户卡券核销量不能超过卡券分配核销量")]
            卡券核销_当前商户卡券核销量不能超过卡券分配核销量 = 219,
            [Description("当前卡券已冻结")]
            卡券核销_当前卡券已冻结 = 220,
            #endregion



            #region 活动模块
            [Description("活动已过期")]
            活动_已过期 = 400,
            [Description("活动已失效")]
            活动_已失效 = 401,
            [Description("活动已结束")]
            活动_已结束 = 402,
            [Description("活动已参加")]
            活动_已参加 = 403,
            [Description("活动参团已满")]
            活动_参团已满 = 404,
            [Description("活动未发布")]
            活动_未发布 = 405,
            [Description("活动未开始")]
            活动_未开始 = 406,

            [Description("不在签到活动周期内，无法参与")]
            不在签到活动周期内 = 406,
            #endregion

            #region 中台模块
            [Description("Sign失效")]
            中台_Sign失效 = 60001,
            [Description("缺失sign参数")]
            中台_Headers_缺失sign参数 = 60002,
            [Description("缺失thirdCode参数")]
            中台_Headers_缺失thirdCode参数 = 60003,
            [Description("缺失timestamp参数")]
            中台_Headers_缺失timestamp参数 = 60004,
            [Description("thirdCode无效")]
            中台_Headers_thirdCode无效 = 60005,
            [Description("timestamp无效")]
            中台_Headers_timestamp无效 = 60006,
            [Description("timestamp超时")]
            中台_Headers_timestamp超时 = 60007,
            #endregion

            #region 商户核销助手
            [Description("商户助手_账户未绑定")]
            商户助手_账户未绑定 = 701,
            [Description("商户助手_用户名不存在或已禁用")]
            商户助手_用户名不存在或已禁用 = 702,
            [Description("当前卡券不在充电桩核销")]
            当前卡券不在充电桩核销 = 703,
            #endregion

            #region 对外接口新的验签方式
            [Description("接口调用账户已被禁用或不存在")]
            接口调用账户已被禁用或不存在 = 1202,
            [Description("调用方验签异常")]
            调用方验签异常 = 1203,
            [Description("调用时间戳超时")]
            调用时间戳超时 = 1204,
            [Description("调用方无调用此接口权限")]
            调用方无调用此接口权限 = 1205,
            #endregion

        }
        #endregion

        #region //商业类型
        /// <summary>
        /// 商场的商业类型
        /// </summary>
        public enum BusType
        {
            [Description("购物中心")]
            购物中心 = 1,
        }
        #endregion

        #region //门店地址性质

        public enum AreaType
        {
            [Description("楼内地址")]
            楼内地址 = 1
        }

        #endregion




        #region //自定义字段

        #region //用途
        /// <summary>
        /// 用途
        /// </summary>
        public enum Column_UseFor
        {
            [Description("报名活动")]
            报名活动 = 1
        }

        #endregion

        #region //输入字段类型
        /// <summary>
        /// 输入字段类型
        /// </summary>
        public enum Column_InputDataType
        {
            [Description("填空")]
            填空 = 1,
            [Description("是否")]
            是否 = 2,
            [Description("单选")]
            单选 = 3,
            [Description("多选")]
            多选 = 4
        }
        #endregion

        #region //填空内容的类型
        /// <summary>
        /// 填空内容的类型
        /// </summary>
        public enum Column_ContentType
        {
            [Description("文字")]
            文字 = 1,
            [Description("数字")]
            数字 = 2,
            [Description("日期")]
            日期 = 3,
            [Description("时间")]
            时间 = 4,
            [Description("电话号码")]
            电话号码 = 5,
            [Description("邮箱")]
            邮箱 = 6,
            [Description("大段文字")]
            大段文字 = 7
        }

        #endregion
        #endregion

        #region //抽奖场次状态

        /// <summary>
        /// 抽奖场次状态
        /// </summary>
        public enum LuckDrawFieldStep
        {
            [Description("未开始")]
            未开始 = 1,

            [Description("进行中")]
            进行中 = 2,

            [Description("已结束")]
            已结束 = 3
        }

        #endregion

        #region 停车
        /// <summary>
        /// 停车场抵扣类型
        /// </summary>
        public enum ParkDType
        {
            [Description("抵扣金额")]
            抵扣金额 = 0,
            [Description("抵扣时长")]
            抵扣时长 = 1
        }
        #endregion

        #region 停车支付类型
        public enum ParkPaymentType
        {
            [Description("微信")]
            微信 = 0,
            [Description("积分")]
            积分 = 1,
            [Description("卡券")]
            卡券 = 2,
            [Description("积分卡券")]
            积分卡券 = 3,
        }
        #endregion

        #region 停车支付方式
        public enum ParkpayType
        {
            [Description("零元支付")]
            零元支付 = 0,
            [Description("支付宝")]
            支付宝 = 1,
            [Description("银联 ")]
            银联 = 2,
            [Description("微信")]
            微信 = 3,
        }
        #endregion

        #region //审核

        public enum CheckStatus
        {
            [Description("未审核")]
            未审核 = 1,
            [Description("审核通过")]
            审核通过 = 2,
            [Description("审核拒绝")]
            审核拒绝 = 3,
            [Description("申请失败")]
            申请失败 = 4,
        }

        #endregion



        #region //卡券筛选判断条件
        /// <summary>
        /// 卡券筛选判断条件
        /// </summary>
        public enum CouponSearchCondition
        {
            [Description("全部卡券")]
            全部卡券 = 1,
            [Description("可用卡券")]
            可用卡券 = 2,
            [Description("不可用卡券")]
            不可用卡券 = 3,
            [Description("过期卡券")]
            过期卡券 = 4,
            [Description("已使用")]
            已使用 = 5
        }
        /// <summary>
        /// 卡券类型
        /// </summary>
        public enum CouponStatus
        {
            [Description("领券量")]
            领券量 = 1,
            [Description("核销量")]
            核销量 = 2,
            [Description("剩余量")]
            剩余量 = 3
        }

        #endregion

        #region //微信相关

        /// <summary>
        /// 微信模板消息的跳转方式
        /// </summary>
        public enum WechatTemplateJumpMode
        {
            [Description("不跳转")]
            不跳转 = 0,
            [Description("H5链接")]
            H5链接 = 1,
            [Description("小程序")]
            小程序 = 2,
            [Description("公众号图文消息链接")]
            公众号图文消息链接 = 3
        }



        #endregion

        #region //推送模板消息

        #region //模板消息模板类型

        /// <summary>
        /// 模板消息模板类型
        /// </summary>
        public enum PushTemplateMsgAction
        {
            [Description("积分扣减通知")]
            积分扣减通知 = 1,
            [Description("积分新增通知")]
            积分新增通知 = 2,
            [Description("用户获取卡券")]
            获取卡券 = 3,
            [Description("卡券即将过期")]
            卡券即将过期 = 4,
            [Description("停车入场通知")]
            停车入场通知 = 5,
            [Description("停车出场通知")]
            停车出场通知 = 6,

        }
        #endregion
        #endregion

        #region //注册来源类型

        /// <summary>
        /// 注册来源类型
        /// </summary>
        public enum RegisterFrom
        {
            [Description("微信小程序")]
            微信小程序 = 1
        }
        #endregion



        #region //系统运行模式
        /// <summary>
        /// 系统运行模式
        /// </summary>
        public enum ProgramRunMode
        {
            [Description("集团模式")]
            集团模式 = 1,
            [Description("SaaS模式")]
            SaaS模式 = 2
        }

        #endregion



        #region //用户User登录口
        /// <summary>
        /// 用户User登录口
        /// </summary>
        public enum UserLoginClient
        {
            [Description("PC后台")]
            PC后台 = 1,
            [Description("小程序核销")]
            小程序核销 = 2,
            [Description("小程序核销后台")]
            小程序核销后台 = 3,
            [Description("PC核销后台")]
            PC核销后台 = 4,
            [Description("PC后台管理")]
            PC后台管理 = 5,
            [Description("PC中台开放平台")]
            PC中台开放平台 = 6
        }

        #endregion


        #region 活动等级
        /// <summary>
        /// ActivityLevel
        /// </summary>
        public enum ActivityLevel
        {
            [Description("特一级")]
            特一级 = 1,
            [Description("一级")]
            一级 = 2,
            [Description("二级")]
            二级 = 3,
            [Description("三级")]
            三级 = 4,
            [Description("四级")]
            四级 = 5
        }
        #endregion


        #region 警报规则相关
        public enum AlertRuleRange
        {
            [Description("Average")]
            平均值 = 1,
            [Description("Last")]
            最后值 = 2,
            [Description("Maximum")]
            最大值 = 3,
            [Description("Minimum")]
            最小值 = 4,
            [Description("Total")]
            总数 = 5,
        }


        public enum Operators
        {
            [Description("GreaterThan")]
            大于 = 1,
            [Description("GreaterThanOrEqual")]
            大于等于 = 2,
            [Description("LessThan")]
            小于 = 3,
            [Description("LessThanOrEqual")]
            小于等于 = 4
        }

        public enum WindowSize
        {
            [Description("PT5M")]
            在最近5分钟 = 1,
            [Description("PT10M")]
            在最近10分钟 = 2,
            [Description("PT15M")]
            在最近15分钟 = 3,
            [Description("PT30M")]
            在最近30分钟 = 4,
            [Description("PT45M")]
            在最近45分钟 = 5,
            [Description("PT1H")]
            在最近1小时 = 6,
            [Description("PT2H")]
            在最近2小时 = 7,
            [Description("PT3H")]
            在最近3小时 = 8,
            [Description("PT4H")]
            在最近4小时 = 9,
            [Description("PT5H")]
            在最近5小时 = 10,
            [Description("PT6H")]
            在最近6小时 = 11,
        }

        public enum AlertLevel
        {
            高危 = 1,
            紧急 = 2,
            一般 = 3,
        }
        #endregion

        #region MetricAlert
        public enum MetricAlertType
        {
            动态警报 = 1,
            静态警报 = 2
        }
        public enum MetricAlertWindowsSize
        {
            [Description("5分钟")]
            PT5M = 1,
            [Description("15分钟")]
            PT15M = 2,
            [Description("30分钟")]
            PT30M = 3,
            [Description("1小时")]
            PT1H = 4
        }
        public enum AlertSensitivity
        {
            [Description("低")]
            Low = 1,
            [Description("中等")]
            Medium = 2,
            [Description("高")]
            High = 3
        }

        public enum MetricAlertTimeAggregation
        {
            [Description("平均值")]
            Average = 1,
            [Description("最后值")]
            Last = 2,
            [Description("最大值")]
            Maximum = 3,
            [Description("最小值")]
            Minimum = 4,
            [Description("总数")]
            Total = 5,
        }

        public enum MetricAlertSeverityLevel
        {
            通知 = 4,
            注意 = 3,
            低危 = 2,
            警告 = 1,
            高危 = 0
        }
        public enum MetricAlertOperators
        {
            [Description("大于")]
            GreaterThan = 1,
            [Description("大于等于")]
            GreaterThanOrEqual = 2,
            [Description("小于")]
            LessThan = 3,
            [Description("小于等于")]
            LessThanOrEqual = 4,
            [Description("大于或小于")]
            GreaterOrLessThan = 5
        }
        #endregion



        #region Request Method
        /// <summary>
        /// Web请求方法
        /// </summary>
        public enum RequestMethod
        {
            [Description("GET")]
            GET = 1,
            [Description("POST")]
            POST = 2,
            [Description("PUT")]
            PUT = 3,
            [Description("DELETE")]
            DELETE = 4,
            [Description("OPTIONS")]
            OPTIONS = 5,
            [Description("PATCH")]
            PATCH = 6
        }
        #endregion

        #region Reports
        public enum ReportClass
        {
            Total = 99,
            Success = 1,
            Failed = 2,
            Blocked = 3
        }

        public enum RuntimeReportTimeRange
        {
            FifteenMins = 1,
            ThirtyMins = 2,
            OneHours = 3,
            OneDay = 4
        }


        public enum BandWidthSize
        {
            B = 1,
            KB = 2,
            MB = 3,
            GB = 4
        }
        #endregion

        #region Query&Headers 参数类型
        /// <summary>
        /// Query&Headers 参数类型
        /// </summary>
        public enum QueryParameterType
        {
            [Description("string")]
            STRING = 1,
            [Description("boolean")]
            BOOLEAN = 2,
            [Description("number")]
            NUMBER = 3
        }
        #endregion

        #region ApiVersion
        /// <summary>
        /// ApiVersion
        /// </summary>
        public enum VersionStatus
        {
            [Description("Stable")]
            Stable = 1,
            [Description("Alpha")]
            Alpha = 2,
            [Description("Beta")]
            Beta = 3,
            [Description("RC")]
            RC = 4,
            [Description("LTS")]
            LTS = 5
        }
        #endregion

        #region OperationType
        /// <summary>
        /// OperationType
        /// </summary>
        public enum OperationType
        {
            [Description("Add")]
            Add = 1,
            [Description("Update")]
            Update = 2,
            [Description("Reject")]
            Reject = 3
        }
        #endregion







        #region 报警异常类型
        /// <summary>
        /// 报警异常类型
        /// </summary>
        public enum AlarmMailChannel
        {
            [Description("CRM异常")]
            CRM异常 = 1,
            [Description("停车异常")]
            停车异常 = 2,
            [Description("Windows服务异常")]
            Windows服务异常 = 3,
            [Description("卡券领取/核销异常")]
            卡券领取核销异常 = 4,
        }
        #endregion




        #region 公告促销类型
        /// <summary>
        /// 公告促销类型
        /// </summary>
        public enum PromotionType
        {
            [Description("公告")]
            公告 = 0,
            [Description("外链")]
            外链 = 1,
        }
        #endregion

        #region 公告促销外链链接类型
        public enum LinkType
        {
            [Description("微刊")]
            微刊 = 1,
            [Description("官网新闻")]
            官网新闻 = 2,
        }
        #endregion

        #region 协议类型
        public enum ProtocolType
        {
            [Description("用户隐私协议")]
            用户隐私协议 = 1,
            [Description("无感支付协议")]
            无感支付协议 = 2
        }
        #endregion

        #region //审核状态
        /// <summary>
        /// 审核状态
        /// </summary>
        public enum AuditStatus
        {
            [Description("已保存")]
            已保存 = 0,
            [Description("待审核")]
            待审核 = 1,
            [Description("中台管理组审核通过")]
            中台管理组审核通过 = 2,
            [Description("中台管理组审核不通过")]
            中台管理组审核不通过 = 3,
            [Description("业务系统拥有者审核通过")]
            业务系统拥有者审核通过 = 4,
            [Description("业务系统拥有者审核不通过")]
            业务系统拥有者审核不通过 = 5,
            [Description("中台运营组审核通过")]
            中台运营组审核通过 = 6,
            [Description("已撤回")]
            已撤回 = 7,
        }
        #endregion

        #region //待接入会员性质
        /// <summary>
        /// 会员性质
        /// </summary>
        public enum BeforeAccessFeature
        {
            [Description("调用方/接入方待接入")]
            调用方接入方待接入 = 1,
            [Description("调用方已接入")]
            调用方已接入 = 2,
            [Description("接入方已接入")]
            接入方已接入 = 3,
            [Description("调用方")]
            调用方 = 4,
            [Description("接入方")]
            接入方 = 5
        }
        #endregion

        #region 审核目标
        public enum AuditTarget
        {
            [Description("接入API审核")]
            接入API审核 = 1,
            [Description("接入方申请信息审核")]
            接入方申请信息审核 = 2,
            [Description("调用方申请信息审核")]
            调用方申请信息审核 = 3,
            [Description("接入API提交审核")]
            接入API提交审核 = 4,
            [Description("调用方申API审核")]
            调用方申API审核 = 5,
            [Description("所属系统关联")]
            所属系统关联 = 6,
            [Description("接入API")]
            接入API = 7,
            [Description("调用API")]
            调用API = 8,
            [Description("接入")]
            接入 = 9
        }
        #endregion

        #region AuditLogType
        /// <summary>
        /// OperationType
        /// </summary>
        public enum AuditLogType
        {
            [Description("申请")]
            Apply = 1,
            [Description("审核")]
            Audit = 2
        }
        #endregion

        #region //调用方相关枚举
        /// <summary>
        /// 调用方位置
        /// </summary>
        public enum CallerLocation
        {
            [Description("Azure")]
            Azure = 1,
            [Description("阿里云")]
            阿里云 = 2,
            [Description("北京DC")]
            北京DC = 3,
            [Description("其它")]
            其它 = 4
        }

        /// <summary>
        /// 调用方技术栈
        /// </summary>
        public enum CallerTechType
        {
            [Description(".NET")]
            NET = 1,
            [Description("JAVA")]
            JAVA = 2,
            [Description("PHP")]
            PHP = 3,
            [Description("Perl")]
            Perl = 4,
            [Description("C++")]
            CPlusPlus = 5,
            [Description("GO")]
            Go = 6,
            [Description("MATALAB")]
            MATALAB = 7,
            [Description("Node.JS")]
            NodeJs = 8,
            [Description("Python")]
            Python = 9
        }
        #endregion

        #region //所属系统审核状态
        /// <summary>
        /// 审核状态
        /// </summary>
        public enum FromSystemAuditStatus
        {
            [Description("待提交")]
            待提交 = 0,
            [Description("待审核")]
            待审核 = 1,
            [Description("已通过")]
            已通过 = 2,
            [Description("已驳回")]
            已驳回 = 3,
            [Description("已撤回")]
            已撤回 = 4
        }
        #endregion

        public enum Adminstatus
        {
            [Description("待审核")]
            待审核 = 1,
            [Description("账号信息已审核")]
            申请信息已审核 = 2,
            [Description("API已审核")]
            API已审核 = 3
        }

        public enum ApplyType
        {
            [Description("接入")]
            接入 = 1,
            [Description("调用")]
            调用 = 2
        }
        #region 实例配置表type
        public enum InstanceConfigType
        {
            [Description("共享性")]
            共享性 = 1,
            [Description("专享型")]
            专享型 = 2
        }
        #endregion




        #region 阿里网关 ALiGateWay

        /// <summary>
        /// 域名合法状态
        /// </summary>
        public enum DomainLegalStatus
        {
            [Description("NORMAL")]
            正常 = 1,
            [Description("ABNORMAL")]
            异常 = 2
        }



        /// <summary>
        /// 域名解析状态
        /// </summary>
        public enum DomainCNAMEStatus
        {
            [Description("RESOLVED")]
            已解析 = 1,
            [Description("UNRESOLVED")]
            未解析 = 2

        }


        /// <summary>
        /// 绑定证书状态
        /// </summary>
        public enum BindSslStatus
        {
            [Description("未绑定")]
            未绑定 = 1,
            [Description("已绑定")]
            已绑定 = 2

        }



        /// <summary>
        /// 域名绑定状态
        /// </summary>
        public enum DomainBindingStatus
        {
            [Description("BINDING")]
            正常 = 1,
            [Description("BOUND")]
            未生效 = 2
        }

        #endregion

        #region 开票结果状态
        public enum Invoicestatus
        {
            [Description("开票成功")]
            开票成功 = 1,
            [Description("开票中")]
            开票中 = 2,
            [Description("开票失败")]
            开票失败 = 3
        }
        #endregion

        /// <summary>
        /// 购买循环时间类型
        /// </summary>
        public enum purchaseTimeType
        {
            [Description("当月")]
            当月 = 1,
        }

        public enum ActCouponType
        {
            [Description("线下卡券")]//bme
            线下卡券 = 0,
            [Description("线上卡券")]//电商
            线上卡券 = 1,
            [Description("星选卡券")]//星选
            星选卡券 = 2
        }

        ///// <summary>
        ///// ActivityCoupons类型
        ///// </summary>
        //public enum ActivityCouponsSource
        //{
        //    [Description("电商")]
        //    电商 = 0,
        //    [Description("星选")]
        //    星选 = 1
        //}
    }
}
