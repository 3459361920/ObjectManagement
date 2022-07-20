using System;
using System.Collections.Generic;
using System.Drawing;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using QRCoder;

namespace Wathet.Common
{
    public class DoQRCode
    {
        #region //创建二维码

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="obj">目标字符串</param>
        /// <param name="filePath">生成的目标位置</param>
        /// <param name="imgName">生成的二维码图片的名称</param>
        /// <param name="Logo">中间Logo图片的位置</param>
        /// <param name="isCover">是否覆盖之前</param>
        /// <returns></returns>
        public static string Create(string obj, string filePath, string imgName, string Logo, bool isCover = false)
        {
            try
            {
                //文件名称  
                string guid = imgName.Replace("/", " ").Replace("\\", " ").Replace("\"", " ") + ".jpg";
                if (isCover)
                {
                    try { new FileInfo(filePath + guid).Delete(); }
                    catch (Exception) { }
                }

                //文件夹不存在就创建  文件存在就删除
                FileInfo file = new FileInfo(DoPath.GetFullPath(filePath));
                if (!file.Directory.Exists) { file.Directory.Create(); }
                if (file.Exists) { file.Delete(); }

                Bitmap logo = null;
                //if (!string.IsNullOrEmpty(Logo) && new FileInfo(Logo).Exists) { logo = new Bitmap(DoPath.GetFullPath(Logo)); }


                QRCodeData qrCodeData = new QRCoder.QRCodeGenerator().CreateQrCode(obj, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(qrCodeData);

                // qrcode.GetGraphic 方法可参考最下发“补充说明”
                Bitmap qrCodeImage = qrcode.GetGraphic(15, System.DrawingCore.Color.Black, System.DrawingCore.Color.White, logo, 15, 6, false);

                //保存到本地
                qrCodeImage.Save(filePath + guid, ImageFormat.Jpeg);

                if (System.IO.File.Exists(filePath + guid))
                    return "1";
                else
                    return "0," + filePath + guid;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            #region //GetGraphic方法参数说明

            /*
            public Bitmap GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, Bitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true)            
             
            int pixelsPerModule:生成二维码图片的像素大小 ，我这里设置的是5             
            
            Color darkColor：暗色   一般设置为Color.Black 黑色            
            
            Color lightColor:亮色   一般设置为Color.White  白色            
            
            Bitmap icon :二维码 水印图标 例如：Bitmap icon = new Bitmap(context.Server.MapPath("~/images/zs.png")); 默认为NULL ，加上这个二维码中间会显示一个图标            
             
            int iconSizePercent： 水印图标的大小比例 ，可根据自己的喜好设置             
            
            int iconBorderWidth： 水印图标的边框            
            
            bool drawQuietZones:静止区，位于二维码某一边的空白边界,用来阻止读者获取与正在浏览的二维码无关的信息 即是否绘画二维码的空白边框区域 默认为true
            */
            #endregion
        }
        #endregion

        #region 压缩文件
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="filePath">压缩位置</param>
        /// <param name="imgs">图片组</param>
        /// <returns></returns>
        public static string Compress(string filePath, List<string> imgs)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = null;

            using (ICSharpCode.SharpZipLib.Zip.ZipFile file = ICSharpCode.SharpZipLib.Zip.ZipFile.Create(ms))
            {
                file.BeginUpdate();
                file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。

                foreach (string img in imgs)
                {
                    if (!string.IsNullOrEmpty(img))
                        file.Add(img);
                }

                file.CommitUpdate();

                buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
            }
            var flag = Bytes2File(buffer, filePath);
            if (flag)
                return Directory.GetCurrentDirectory() + "/webupload/" + "qrcode_list.zip";
            else
                return "";
        }
        public static bool Bytes2File(byte[] buff, string savepath)
        {
            try
            {
                if (System.IO.File.Exists(savepath))
                {
                    System.IO.File.Delete(savepath);
                }

                FileStream fs = new FileStream(savepath, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buff, 0, buff.Length);
                bw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
        {

            #region INameTransform 成员

            public string TransformDirectory(string name)
            {
                return null;
            }

            public string TransformFile(string name)
            {
                return Path.GetFileName(name);
            }

            #endregion
        }
        #endregion
    }
}
