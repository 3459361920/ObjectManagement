using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Wathet.Common
{
    /// <summary>
    /// 项目配置节
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 程序集名称
        /// </summary>
        public const string AssemblyFileName = "Wathet.";

        /// <summary>
        /// 项目编号
        /// </summary>
        public const int ProjectID = 1;

        /// <summary>
        /// 小程序获取Portal参数的方式
        /// 1写固定值  2从登录态获取
        /// </summary>
        public const int GetPortalMode = 2;

        /// <summary>
        /// 登录token保存再 saas2=52 号库。
        /// </summary>
        public const int User_Redis_DBNo = 52;




        public const int StaticCacheMins = 129600;


        public static Dictionary<string, Entity.vvv> DicValue = new Dictionary<string, Entity.vvv>();

        public static Dictionary<string, Entity.vvv> dicViewCache = new Dictionary<string, Entity.vvv>();


        /// <summary>
        /// 程序运行模式,本机Vs调试为true,config.json中添加local:true, 服务器上不加此配置
        /// </summary>
        public static string IsLocalRun => (Wathet.Common.ConfigurationManager.AppSettings["LocalRun"] ?? "").ToString();
        /// <summary>
        /// 服务器的内网IP, 另外会固定替换 127.0.0.1
        /// </summary>
        public static string LocalIp = (Wathet.Common.ConfigurationManager.AppSettings["LocalIp"] ?? "0.0.0.0").ToString();
        /// <summary>
        /// 服务器的远程IP
        ///218.97.15.103
        ///106.14.150.184
        ///139.224.118.153
        /// </summary>
        public static string RemoteIp = (Wathet.Common.ConfigurationManager.AppSettings["RemoteIp"] ?? "106.14.150.184").ToString();

        #region //系统运行模式
        /// <summary>
        /// 系统运行模式
        /// </summary>
        public const Wathet.Common.ComEnum.ProgramRunMode ProgramRunMode = Wathet.Common.ComEnum.ProgramRunMode.集团模式;
        #endregion

        #region //SCrm会话相关
        /// <summary>
        /// Scrm系统Token名称(PC登录)
        /// </summary>
        public const string Scrm_TokenName_PC = "Crm_Token.";
        /// <summary>
        /// Scrm系统RefreshToken名称(PC登录)
        /// </summary>
        public const string Scrm_TokenName_Refresh_PC = "Crm_Token_Refresh.";


        /// <summary>
        /// Scrm系统Token名称(商户核销助手)
        /// </summary>
        public const string Scrm_TokenName_Merchant = "MerchantApp_Token.";
        /// <summary>
        /// Scrm系统RefreshToken名称(商户核销助手)
        /// </summary>
        public const string Scrm_TokenName_Refresh_Merchant = "MerchantApp_Token_Refresh.";

        /// <summary>
        /// PC核销管理Token名称(商户PC核销)
        /// </summary>
        public const string PC_TokenName_Merchant = "PC_MerchantApp_Token.";
        /// <summary>
        /// PC核销管理RefreshToken名称(商户PC核销)
        /// </summary>
        public const string PC_TokenName_Refresh_Merchant = "PC_MerchantApp_Token_Refresh.";


        /// <summary>
        /// Scrm系统Token名称(商户核销助手_后台管理)
        /// </summary>
        public const string Scrm_TokenName_MerchantManage = "Crm_Token_Mobile.";
        /// <summary>
        /// Scrm系统RefreshToken名称(商户核销助手_后台管理)
        /// </summary>
        public const string Scrm_TokenName_Refresh_MerchantManage = "Crm_Token_Mobile_Refresh.";


        /// <summary>
        /// User用户权限缓存名
        /// </summary>
        public const string Scrm_AuthName = "CrmSessionAuth.";

        /// <summary>
        /// Signature权限缓存名
        /// </summary>
        public const string Signature_AuthName = "SignatureSessionAuth.";

        /// <summary>
        /// 用户会话时长(分钟)
        /// </summary>
        public const int Token_Duration_Mins = 120;
        /// <summary>
        /// 用户会话RefreshToken时长(小时)
        /// </summary>
        public const int RefreshToken_Duration_Hour = 48;
        #endregion

        #region //默认值设定

        /// <summary>
        /// 默认时间(最小时间)
        /// </summary>
        public static DateTime DefaultDateTime = new DateTime(1900, 1, 1);
        /// <summary>
        /// 默认编码方式 UTF-8
        /// </summary>
        public static string DefaultEncoding = "UTF-8";
        /// <summary>
        /// 默认列表页显示条数
        /// </summary>
        public const int DefaultPageSize = 10;

        #endregion

        #region //系统默认的超级Root的Feature
        /// <summary>
        /// 系统默认的超级Root的Feature
        /// </summary>
        public static Entity.JsonRSimple DefaultRootFeature = new Entity.JsonRSimple(900, "超级Root");
        #endregion
    }
}





