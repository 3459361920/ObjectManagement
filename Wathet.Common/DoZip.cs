using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;

namespace Wathet.Common
{
    public class DoZip
    {
        //压缩差不多了,,解压缩还没写


        #region //创建空压缩包

        /// <summary>
        /// 创建空压缩包 (过程中需要一个临时的空文件夹)
        /// </summary>
        /// <param name="targetZip">要创建的压缩包位置</param>
        /// <param name="isDelOldZip">如果位置上已经有同名压缩包,是否删除</param>
        /// <returns></returns>
        public static bool ZipCreate_Empty(string targetZip, bool isDelOldZip = true)
        {
            if (string.IsNullOrEmpty(targetZip)) return false;
            var tempDir = @"tempZIP_" + DateTime.Now.Format_yyyyMMddHHmmssfff(false);
            var dir = new DirectoryInfo(tempDir);
            bool isNeedDelDir = false; //代码运行到后边是否需要删除创建的空文件夹, 防止原来就有这个文件夹,撞车误删文件
            try
            {
                if (!dir.Exists)
                {
                    dir.Create(); //原来没有,现在创建
                    isNeedDelDir = true; //创建的空文件夹要删除
                    var file = new FileInfo(targetZip);
                    if (!file.Directory.Exists) { file.Directory.Create(); } //若压缩包所在的文件夹不存在,则创建

                    if (file.Exists) //已存在并要删除的话
                    {
                        if (isDelOldZip) { file.Delete(); } //删除旧文件
                        else { return true; } //直接返回True, 因为文件的确存在
                    }

                    //创建空压缩文件
                    ZipFile.CreateFromDirectory(dir.FullName, targetZip, CompressionLevel.Optimal, false);

                    file.Refresh();
                    return file.Exists;
                }
                else
                {
                    System.Threading.Thread.Sleep(new Random().Next(20, 300)); //随机睡一会儿
                    return ZipCreate_Empty(targetZip); //如果临时文件夹有占用,则递归等待时间
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToSimple());
                return false;
            }
            finally
            {
                if (isNeedDelDir) { dir.Delete(); } //删除创建的临时文件夹
            }
        }
        #endregion

        #region //文件夹压缩

        /// <summary>
        /// 文件夹压缩
        /// </summary>
        /// <param name="path_SourceDirectory">路径 源文件夹目录位置</param>
        /// <param name="path_TargetZip">路径 目标压缩包的位置</param>
        /// <param name="isDelOldZip">如果位置上已经有同名压缩包,是否删除</param>
        /// <param name="isIncloudBaseDirectory">是否将文件夹本身也压缩进包,false时从文件夹的内容开始压缩,子文件夹也会在压缩包中是文件夹存在</param>
        /// <returns></returns>
        public static bool ZipCreate_ByDirectory(string path_SourceDirectory, string path_TargetZip, bool isDelOldZip = true, bool isIncloudBaseDirectory = false)
        {
            if (string.IsNullOrEmpty(path_SourceDirectory)) return false;
            if (string.IsNullOrEmpty(path_TargetZip)) return false;

            var dir = new DirectoryInfo(path_SourceDirectory);
            if (!dir.Exists) { return false; } //如果文件夹不存在,返回false

            var file = new FileInfo(path_TargetZip);
            if (file.Exists) //已存在并要删除的话
            {
                if (isDelOldZip) { file.Delete(); } //删除旧文件
                else { return false; } //直接返回false 因为没有将文件夹的内容放入压缩包
            }

            try
            {

                //创建空压缩文件
                ZipFile.CreateFromDirectory(dir.FullName, path_TargetZip, CompressionLevel.Optimal, isIncloudBaseDirectory);

                file.Refresh();
                return file.Exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToSimple());
                if (file.Exists) { file.Delete(); } //抛异常时,删除已经压缩的包
                return false;
            }
        }
        #endregion

        #region //单文件压缩

        /// <summary>
        /// 单文件压缩
        /// </summary>
        /// <param name="path_SourceFile">路径 源文件位置</param>
        /// <param name="path_TargetZip">路径 目标压缩包的位置</param>
        /// <param name="isDelOldZip">如果位置上已经有同名压缩包,是否删除</param>
        /// <param name="isIncloudBaseDirectory">是否将文件夹本身也压缩进包,false时从文件夹的内容开始压缩,子文件夹也会在压缩包中是文件夹存在</param>
        /// <returns></returns>
        public static bool ZipCreate_ByFile(string path_SourceFile, string path_TargetZip, bool isDelOldZip = true, bool isIncloudBaseDirectory = false)
        {
            if (string.IsNullOrEmpty((string)path_SourceFile)) return false;
            if (string.IsNullOrEmpty(path_TargetZip)) return false;

            var sourceFile = new FileInfo((string)path_SourceFile);
            if (!sourceFile.Exists) { return false; } //如果文件不存在,返回false

            var zipfile = new FileInfo(path_TargetZip);
            if (zipfile.Exists) //已存在并要删除的话
            {
                if (isDelOldZip) { zipfile.Delete(); } //删除旧文件
                else { return false; } //直接返回false 因为没有将文件放入压缩包
            }

            try
            {
                if (ZipCreate_Empty(zipfile.FullName)) //先创建一个空压缩包,true标识创建成功
                {
                    zipfile.Refresh(); //刷新包对象
                    using (ZipArchive archive = ZipFile.Open(zipfile.FullName, ZipArchiveMode.Update)) //打开包
                    {
                        archive.CreateEntryFromFile(sourceFile.FullName, sourceFile.Name); //放入文件.压缩                        
                    }
                }

                zipfile.Refresh();
                return zipfile.Exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToSimple());
                if (zipfile.Exists) { zipfile.Delete(); } //抛异常时,删除已经压缩的包
                return false;
            }
        }
        #endregion

        #region //单文件添加到压缩包

        /// <summary>
        /// 单文件添加到压缩包
        /// </summary>
        /// <param name="path_SourceFile">路径 源文件位置</param>
        /// <param name="path_TargetZip">路径 目标压缩包的位置</param>
        /// <param name="entryName">文件添加到压缩包中的位置或者名字,如果为空则使用源文件名</param>
        /// <param name="isCreateIfZipNotExists">如果目标压缩包不存在,是否创建</param>
        /// <returns></returns>
        public static bool ZipAdd_File(string path_SourceFile, string path_TargetZip, string entryName = "", bool isCreateIfZipNotExists = true)
        {
            if (string.IsNullOrEmpty((string)path_SourceFile)) return false;
            if (string.IsNullOrEmpty(path_TargetZip)) return false;

            var sourceFile = new FileInfo(path_SourceFile);
            if (!sourceFile.Exists) { return false; } //如果文件不存在,返回false
            entryName = string.IsNullOrEmpty(entryName) ? sourceFile.Name : entryName; //包内名
            entryName = entryName.TrimStart(new char[] { '\\', '/' }); //必须去除前边的路径定位符

            var zipfile = new FileInfo(path_TargetZip);
            if (!zipfile.Exists) //不存在并要创建的话
            {
                if (isCreateIfZipNotExists) { if (!ZipCreate_Empty(zipfile.FullName)) { return false; } } //创建新文件
                else { return false; } //直接返回false 因为没有将文件夹的内容放入压缩包
            }

            try
            {
                zipfile.Refresh(); //刷新包对象
                using (ZipArchive archive = ZipFile.Open(zipfile.FullName, ZipArchiveMode.Update)) //打开包
                {
                    archive.CreateEntryFromFile(sourceFile.FullName, entryName); //放入文件.压缩
                }

                return zipfile.Exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToSimple());
                return false;
            }
        }
        #endregion

    }
}
