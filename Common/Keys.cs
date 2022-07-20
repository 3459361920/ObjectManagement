using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common
{
    public class Keys
    {
        //Cache======================================================
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "dt_cache_site_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_USER_CONFIG = "dt_cache_user_config";
        /// <summary>
        /// 订单配置
        /// </summary>
        public const string CACHE_ORDER_CONFIG = "dt_cache_order_config";
        /// <summary>
        /// HttpModule映射类
        /// </summary>
        public const string CACHE_SITE_HTTP_MODULE = "dt_cache_http_module";
        /// <summary>
        /// 绑定域名
        /// </summary>
        public const string CACHE_SITE_HTTP_DOMAIN = "dt_cache_http_domain";
        /// <summary>
        /// 站点一级目录名
        /// </summary>
        public const string CACHE_SITE_DIRECTORY = "dt_cache_site_directory";
        /// <summary>
        /// 站点ASPX目录名
        /// </summary>
        public const string CACHE_SITE_ASPX_DIRECTORY = "dt_cache_site_aspx_directory";
        /// <summary>
        /// URL重写映射表
        /// </summary>
        public const string CACHE_SITE_URLS = "dt_cache_site_urls";
        /// <summary>
        /// URL重写LIST列表
        /// </summary>
        public const string CACHE_SITE_URLS_LIST = "dt_cache_site_urls_list";


        /// <summary>
        /// 当前商场的缓存
        /// </summary>
        public const string CACHE_CURRENT_MALL = "CACHE_CURRENT_MALL";


        //Session=====================================================
        /// <summary>
        /// 网页验证码
        /// </summary>
        public static string SESSION_CODE
        {
            get { return "dt_session_code"; }
        }
        /// <summary>
        /// 图形验证码
        /// </summary>
        public static string SESSION_CODE_NEW
        {
            get { return "dt_session_code_new"; }
        }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public const string SESSION_SMS_CODE = "dt_session_sms_code";
        /// <summary>
        /// 后台管理员
        /// </summary>
        public const string SESSION_ADMIN_INFO = "dt_session_admin_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "dt_session_user_info";

        //Cookies=====================================================
        /// <summary>
        /// 防重复顶踩KEY
        /// </summary>
        public const string COOKIE_DIGG_KEY = "dt_cookie_digg_key";
        /// <summary>
        /// 防重复评论KEY
        /// </summary>
        public const string COOKIE_COMMENT_KEY = "dt_cookie_comment_key";

        #region 百度cookie
        /// <summary>
        /// 百度直达号的登录state
        /// </summary>
        public static string COOKIE_BAIDU_LOGIN_STATE { get { return "baidu_login_state_COOKIE"; } }

        /// <summary>
        /// 百度的手机号
        /// </summary>
        public static string COOKIE_BAIDU_PHONE { get { return "baidu_phone_COOKIE"; } }


        /// <summary>
        /// 百度用户ID
        /// </summary>
        public static string COOKIE_BAIDU_UID { get { return "baidu_id_COOKIE"; } }

        /// <summary>
        /// 百度用户名
        /// </summary>
        public static string COOKIE_BAIDU_NAME { get { return "baidu_name_COOKIE"; } }

        /// <summary>
        /// 百度用户头像
        /// </summary>
        public static string COOKIE_BAIDU_HEAD_IMAGE { get { return "baidu_img_COOKIE"; } }

        /// <summary>
        /// 智慧图活动链接
        /// </summary>
        public static string COOKIE_WISDOM_ACTIVITY { get { return "COOKIE_WISDOM_ACTIVITY"; } }

        /// <summary>
        /// 商场名称
        /// </summary>
        public static string COOKIE_MALL_NAME { get { return "COOKIE_MALL_NAME"; } }

        #endregion

        #region 支付宝cookie

        /// <summary>
        /// 支付宝的手机号
        /// </summary>
        public static string COOKIE_ALIPAY_PHONE { get { return "ALIPAY_phone_COOKIE"; } }


        /// <summary>
        /// 支付宝用户ID
        /// </summary>
        public static string COOKIE_ALIPAY_UID { get { return "ALIPAY_id_COOKIE"; } }

        /// <summary>
        /// 支付宝用户名
        /// </summary>
        public static string COOKIE_ALIPAY_NAME { get { return "ALIPAY_name_COOKIE"; } }

        /// <summary>
        /// 支付宝用户头像
        /// </summary>
        public static string COOKIE_ALIPAY_HEAD_IMAGE { get { return "ALIPAY_img_COOKIE"; } }
        #endregion
    }
}
