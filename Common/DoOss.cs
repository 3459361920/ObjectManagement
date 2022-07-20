using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aliyun.OSS;

namespace Wathet.Common
{
    public class DoOss
    {
        #region //属性
        /// <summary>
        /// AcessKeyId
        /// </summary>
        private string ossAcessKeyId = string.Empty;

        /// <summary>
        /// AcessKeySecret
        /// </summary>
        private string ossAcessKeySecret = string.Empty;

        /// <summary>
        /// Endpoint
        /// </summary>
        private string ossEndpoint = string.Empty;

        /// <summary>
        /// Bucket
        /// </summary>
        private string ossBucket = string.Empty;
        #endregion


        public DoOss(string appID, string appSecret, string Bucket, string Endpoint)
        {
            ossAcessKeyId = appID;
            ossAcessKeySecret = appSecret;
            ossEndpoint = Endpoint;
            ossBucket = Bucket;
        }


        #region //客户端
        OssClient GetClient()
        {
            return new OssClient(ossEndpoint, ossAcessKeyId, ossAcessKeySecret);
        }
        #endregion


        #region //推送文件
        /// <summary>
        /// 推送文件
        /// </summary>
        /// <param name="localFile">本地完整路径</param>
        /// <param name="remoteFileName">远程存储路径</param>
        /// <returns></returns>
        public bool PushFile(string localFile, string remoteFileName)
        {
            try
            {
                //localFile = DoPath.GetFullPath(localFile);
                remoteFileName = remoteFileName.TrimStart('\\').TrimStart('/').Replace("\\", "/");
                return GetClient().PutObject(ossBucket, remoteFileName, localFile).HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToSimple());
                return false;
            }
        }
        #endregion
        #region //推送文件(Stream)
        /// <summary>
        /// 推送文件
        /// </summary>
        /// <param name="content">上传文件流</param>
        /// <param name="remoteFileName">远程存储路径</param>
        /// <returns></returns>
        public bool PushFile(Stream content, string remoteFileName)
        {
            try
            {
                remoteFileName = remoteFileName.TrimStart('\\').TrimStart('/').Replace("\\", "/");
                return GetClient().PutObject(ossBucket, remoteFileName, content).HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToSimple()); }
            return false;
        }
        #endregion

        #region //下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="remoteFile">远程存储路径</param>
        /// <param name="localPath">下载存取地址</param>
        /// <param name="isOverWrite">如果本地文件已经存在，是否要求覆盖</param>
        /// <returns></returns>
        public bool DownOSSFile(string remoteFile, string localPath, bool isOverWrite = true)
        {
            try
            {
                remoteFile = remoteFile.TrimStart('/');
                var localFile = new FileInfo(localPath);
                if (!localFile.Directory.Exists) { localFile.Directory.Create(); } //文件可以自动创建，但是如果连文件夹都没有，可能会报错
                if (localFile.Exists)
                {
                    if (isOverWrite) { localFile.Delete(); }
                    else { return true; }  //如果文件存在，并且不允许覆盖的话，直接返回成功
                }


                // 下载文件到流。OssObject 包含了文件的各种信息，如文件所在的存储空间、文件名、元信息以及一个输入流。
                var obj = GetClient().GetObject(ossBucket, remoteFile);
                if (obj != null)
                {
                    Console.WriteLine($"开始下载，文件大小:{Common.DoString.GetDiskSizeStr(obj.ContentLength)}");
                }

                using (var requestStream = obj.Content)
                {
                    byte[] buf = new byte[1024];
                    var fs = File.Open(localPath, FileMode.OpenOrCreate);
                    var len = 0;
                    // 通过输入流将文件的内容读取到文件或者内存中。
                    while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                    {
                        fs.Write(buf, 0, len);
                    }
                    fs.Close();
                }

                var result = obj.HttpStatusCode == System.Net.HttpStatusCode.OK;
                Console.WriteLine($"下载完成，结果：{(result ? "成功" : "失败")}");
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region//下载文件，返回byte数组
        /// <summary>
        /// 获取文件的byte数组
        /// </summary>
        /// <param name="remoteFile">远程路径</param>
        /// <returns></returns>
        public byte[] DownOSSFile(string remoteFile)
        {
            try
            {
                var obj = GetClient().GetObject(ossBucket, remoteFile);
                if (obj.Content != null)
                {
                    return DoIOFile.ToBytes(obj.Content);
                }
                return null;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToSimple()); 
            }
            return null;
        }
        #endregion

        #region //删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="remoteFileName">远程存储路径</param>
        /// <returns></returns>
        public bool RemoveFile(string remoteFileName)
        {
            try
            {
                remoteFileName = remoteFileName.TrimStart('\\').Replace("\\", "/");
                GetClient().DeleteObject(ossBucket, remoteFileName);
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToSimple()); return false; }
        }
        #endregion

        #region //获取有过期时间的文件路径

        /// <summary>
        /// 获取有过期时间的文件路径
        /// </summary>
        /// <param name="remoteFileName">远程存储路径</param>
        /// <param name="expireTime">过期时间，默认100年</param>
        /// <returns></returns>
        public string GetAuthUrl(string remoteFileName, DateTime? expireTime = null)
        {
            try
            {
                var newTime = expireTime ?? DateTime.Now.AddYears(100);
                var req = new GeneratePresignedUriRequest(ossBucket, remoteFileName, SignHttpMethod.Get)
                {
                    Expiration = newTime
                };
                return GetClient().GeneratePresignedUri(req).ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToSimple()); return string.Empty; }
        }
        #endregion

        #region //文件是否存在

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="remoteFileName"></param>
        /// <returns></returns>
        public bool ExistsFile(string remoteFileName)
        {
            try
            {
                remoteFileName = remoteFileName.TrimStart('\\').Replace("\\", "/");
                return GetClient().DoesObjectExist(ossBucket, remoteFileName);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToSimple()); return false; }
        }
        #endregion


    }
}
