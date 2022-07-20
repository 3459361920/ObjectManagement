using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wathet.Common
{
    public class DoVadio
    {
        /// <summary>
        /// 视频播放
        /// </summary>
        /// <param name="strUrl">链接</param>
        /// <param name="strWidth">宽</param>
        /// <param name="StrHeight">长</param>
        /// <returns></returns>
        public static string SelPlay(string strUrl, int strWidth, int StrHeight)
        {
            StringBuilder sb = new StringBuilder();
            string isExt;
            if (strUrl != "")
            {
                int i = strUrl.LastIndexOf(".");
                isExt = strUrl.Substring(i + 1, strUrl.Length - i - 1);

            }
            else
            {
                return "";   //文件格式不正确
            }
            isExt = isExt.ToLower();
            switch (isExt)
            {
                case "avi":
                case "wmv":
                case "asf":
                case "mov":
                    sb.Append("<EMBED id=MediaPlayer src='" + strUrl + "' width='" + strWidth + "' height='" + StrHeight + "' loop='false' autostart='true'></EMBED>");
                    break;
                case "rm":
                case "ra":
                case "rmvb":
                case "ram":
                    sb.Append("<OBJECT height='" + StrHeight + "' width='" + strWidth + "' classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA>");
                    sb.Append("<PARAM NAME='_ExtentX' VALUE='12700'>");
                    sb.Append("<PARAM NAME='_ExtentY' VALUE='9525'>");
                    sb.Append("<PARAM NAME='AUTOSTART' VALUE='-1'>");
                    sb.Append("<PARAM NAME='SHUFFLE' VALUE='0'>");
                    sb.Append("<PARAM NAME='PREFETCH' VALUE='0'>");
                    sb.Append("<PARAM NAME='NOLABELS' VALUE='0'>");
                    sb.Append("<PARAM NAME='SRC' VALUE='" + strUrl + "'>");
                    sb.Append("<PARAM NAME='CONTROLS' VALUE='ImageWindow'>");
                    sb.Append("<PARAM NAME='CONSOLE' VALUE='Clip'>");
                    sb.Append("<PARAM NAME='LOOP' VALUE='0'>");
                    sb.Append("<PARAM NAME='NUMLOOP' VALUE='0'>");
                    sb.Append("<PARAM NAME='CENTER' VALUE='0'>");
                    sb.Append("<PARAM NAME='MAINTAINASPECT' VALUE='0'>");
                    sb.Append("<PARAM NAME='BACKGROUNDCOLOR' VALUE='#000000'>");
                    sb.Append("</OBJECT>");
                    sb.Append("<BR>");
                    sb.Append("<OBJECT height=32 width='" + strWidth + "' classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA>");
                    sb.Append("<PARAM NAME='_ExtentX' VALUE='12700'>");
                    sb.Append("<PARAM NAME='_ExtentY' VALUE='847'>");
                    sb.Append("<PARAM NAME='AUTOSTART' VALUE='0'>");
                    sb.Append("<PARAM NAME='SHUFFLE' VALUE='0'>");
                    sb.Append("<PARAM NAME='PREFETCH' VALUE='0'>");
                    sb.Append("<PARAM NAME='NOLABELS' VALUE='0'>");
                    sb.Append("<PARAM NAME='CONTROLS' VALUE='ControlPanel,StatusBar'>");
                    sb.Append("<PARAM NAME='CONSOLE' VALUE='Clip'>");
                    sb.Append("<PARAM NAME='LOOP' VALUE='0'>");
                    sb.Append("<PARAM NAME='NUMLOOP' VALUE='0'>");
                    sb.Append("<PARAM NAME='CENTER' VALUE='0'>");
                    sb.Append("<PARAM NAME='MAINTAINASPECT' VALUE='0'>");
                    sb.Append("<PARAM NAME='BACKGROUNDCOLOR' VALUE='#000000'>");
                    sb.Append("</OBJECT>");
                    break;
                case "swf":
                case "flv":
                    sb.Append("<OBJECT codeBase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=4,0,2,0' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' width='" + strWidth + "' height='" + StrHeight + "'> ");
                    sb.Append("<PARAM NAME='movie' VALUE='" + strUrl + "'> ");
                    sb.Append("<PARAM NAME='play' VALUE='false'> ");
                    sb.Append("<PARAM NAME='quality' VALUE='high'> ");
                    sb.Append("<embed src='" + strUrl + "' quality='high' pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width='" + strWidth + "' height='" + StrHeight + "'></embed> ");
                    sb.Append("</OBJECT> ");
                    break;
                case "mpg":
                    sb.Append("<object classid='clsid:05589FA1-C356-11CE-BF01-00AA0055595A' id='ActiveMovie1' width='" + strWidth + "' height='" + StrHeight + "'>");
                    sb.Append("<param name='Appearance' value='0'>");
                    sb.Append("<param name='AutoStart' value='-1'>");
                    sb.Append("<param name='AllowChangeDisplayMode' value='-1'>");
                    sb.Append("<param name='AllowHideDisplay' value='0'>");
                    sb.Append("<param name='AllowHideControls' value='-1'>");
                    sb.Append("<param name='AutoRewind' value='-1'>");
                    sb.Append("<param name='Balance' value='0'>");
                    sb.Append("<param name='CurrentPosition' value='0'>");
                    sb.Append("<param name='DisplayBackColor' value='0'>");
                    sb.Append("<param name='DisplayForeColor' value='16777215'>");
                    sb.Append("<param name='DisplayMode' value='0'>");
                    sb.Append("<param name='Enabled' value='-1'>");
                    sb.Append("<param name='EnableContextMenu' value='-1'>");
                    sb.Append("<param name='EnablePositionControls' value='-1'>");
                    sb.Append("<param name='EnableSelectionControls' value='0'>");
                    sb.Append("<param name='EnableTracker' value='-1'>");
                    sb.Append("<param name='Filename' value='" + strUrl + "' valuetype='ref'>");
                    sb.Append("<param name='FullScreenMode' value='0'>");
                    sb.Append("<param name='MovieWindowSize' value='0'>");
                    sb.Append("<param name='PlayCount' value='1'>");
                    sb.Append("<param name='Rate' value='1'>");
                    sb.Append("<param name='SelectionStart' value='-1'>");
                    sb.Append("<param name='SelectionEnd' value='-1'>");
                    sb.Append("<param name='ShowControls' value='-1'>");
                    sb.Append("<param name='ShowDisplay' value='-1'>");
                    sb.Append("<param name='ShowPositionControls' value='0'>");
                    sb.Append("<param name='ShowTracker' value='-1'>");
                    sb.Append("<param name='Volume' value='-480'>");
                    sb.Append("</object>");
                    break;
                case "smi":
                    sb.Append("<OBJECT id=RVOCX classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA width='" + strWidth + "' height='" + StrHeight + "'>");
                    sb.Append("<param name='_ExtentX' value='6350'>");
                    sb.Append("<param name='_ExtentY' value='4763'>");
                    sb.Append("<param name='AUTOSTART' value='-1'>");
                    sb.Append("<param name='SHUFFLE' value='0'>");
                    sb.Append("<param name='PREFETCH' value='0'>");
                    sb.Append("<param name='NOLABELS' value='-1'>");
                    sb.Append("<param name='SRC' value='" + strUrl + "'>");
                    sb.Append("<param name='CONTROLS' value='ImageWindow'>");
                    sb.Append("<param name='CONSOLE' value='console1'>");
                    sb.Append("<param name='LOOP' value='0'>");
                    sb.Append("<param name='NUMLOOP' value='0'>");
                    sb.Append("<param name='CENTER' value='0'>");
                    sb.Append("<param name='MAINTAINASPECT' value='0'>");
                    sb.Append("<param name='BACKGROUNDCOLOR' value='#000000'>");
                    sb.Append("<embed src='" + strUrl + "' type='audio/x-pn-realaudio-plugin' console='Console1' controls='ImageWindow' height='" + StrHeight + "' width='" + strWidth + "' autostart='true'>");
                    sb.Append("</OBJECT>");
                    break;                    
            }
            return sb.ToString();

        }
    }
}