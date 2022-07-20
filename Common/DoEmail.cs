using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wathet.Common
{
    public class DoEmail
    {
        public bool SendDirect(string SmtpServer, string SmtpAccount, string SmtpPassword, string FromEmail, string FromEmailName, string EmailAddress, string mailTitle, string mailBody, ref string SendResult,(byte[] content,string name) attachment,bool ssl=true)
        {
            mailTitle = GetEnvironment() + mailTitle;
            var mail = new MailMessage
            {
                From = new MailAddress(FromEmail, FromEmailName),
                Subject = mailTitle
            };

            foreach (var email in EmailAddress.Split(new char []{ ',' },StringSplitOptions.RemoveEmptyEntries)) { if (IsValidEmail(email)) mail.To.Add(email); }


            if (mail.To.Count > 0)
            {
                mail.Priority = MailPriority.High;
                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(mailBody, Encoding.UTF8, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(avHtml);
                mail.IsBodyHtml = true;
            
                try
                {
                    using var stream = new MemoryStream(attachment.content);
                    var file = new Attachment(stream, attachment.name);
                    mail.Attachments.Add(file);
                    SmtpClient client = null;

                    client = new SmtpClient(SmtpServer);
                    client.EnableSsl = ssl;
                    //client.Port =465;
                    client.UseDefaultCredentials = false;
                    if (SmtpAccount != "")
                    {
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new NetworkCredential(SmtpAccount, SmtpPassword);
                    }
                    client.Send(mail);

                    client.Dispose();
                    SendResult = "发送成功!!";
                    return true;
                }
                catch (Exception ex)
                {
                    SendResult = ex.ToString();
                }
            }
            return false;

        }

        public bool SendDirect(string smtpServer, string smtpAccount, string smtpPassword, string fromEmail, string fromEmailName, string emailAddress, string mailTitle, string mailBody, ref string sendResult, bool ssl = true)
        {
            mailTitle = GetEnvironment() + mailTitle;
            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail, fromEmailName),
                Subject = mailTitle
            };

            foreach (var email in emailAddress.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) { if (IsValidEmail(email)) mail.To.Add(email); }


            if (mail.To.Count > 0)
            {
                mail.Priority = MailPriority.High;
                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(mailBody, Encoding.UTF8, MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(avHtml);
                mail.IsBodyHtml = true;

                try
                {
                    SmtpClient client = null;

                    client = new SmtpClient(smtpServer) {EnableSsl = ssl, UseDefaultCredentials = false};
                    //client.Port =465;
                    if (smtpAccount != "")
                    {
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new NetworkCredential(smtpAccount, smtpPassword);
                    }
                    client.Send(mail);

                    client.Dispose();
                    sendResult = "发送成功!!";
                    return true;
                }
                catch (Exception ex)
                {
                    sendResult = ex.ToString();
                }
            }
            return false;

        }

        private string GetEnvironment()
        {
            var appVersion = Environment.GetEnvironmentVariable("BME-environment-version");
            switch (appVersion)
            {
                case "uat":
                    appVersion = "【UAT】";
                    break;
                case "prd":
                    appVersion = "【PROD】";
                    break;
                default:
                    appVersion = "【UAT】";
                    break;
            }

            return appVersion;
        }

        /// <summary>
        /// 检查邮件地址
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// Sends the completed callback.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.AsyncCompletedEventArgs"/> instance containing the event data.</param>
        public void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            //try
            //{
            //    if (e.Cancelled)
            //    {
            //        SentResult = false;
            //    }
            //    if (e.Error != null)
            //    {
            //        Logger.Error(MailServer.SmtpServer);
            //        Logger.Error(e.Error);
            //        SentResult = false;
            //    }
            //    else
            //    {
            //        Logger.Info("发送成功：" + EmailAddress);
            //        SentResult = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Error("SendCompletedCallback.");
            //    Logger.Error(ex);
            //}
        }
        public static void SendWebEmail(List<string> ReceiveAddressList, string Subject, string Content, Dictionary<string, string> AttachFile, string SendeEmail = "", string PassWord = "")
        {
            //smtp客户端
            SmtpClient smtp = new SmtpClient("smtp.exmail.qq.com");
            //发件人邮箱身份验证凭证。 参数分别为 发件邮箱登录名和密码  
            SendeEmail = string.IsNullOrEmpty(SendeEmail) ? "" : SendeEmail;
            PassWord = string.IsNullOrEmpty(PassWord) ? "" : PassWord;
            smtp.Credentials = new NetworkCredential(SendeEmail, PassWord);
            //创建邮件
            MailMessage mail = new MailMessage();
            //主题编码  
            //mail.SubjectEncoding = Encoding.GetEncoding("GB2312");
            ////正文编码  
            //mail.BodyEncoding = Encoding.GetEncoding("GB2312");
            //邮件优先级
            mail.Priority = MailPriority.Normal;
            //以HTML格式发送邮件,为false则发送纯文本邮箱
            mail.IsBodyHtml = false;
            //发件人邮箱  
            mail.From = new MailAddress(SendeEmail);
            //添加收件人,如果有多个,可以多次添加  
            if (ReceiveAddressList.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < ReceiveAddressList.Count; i++)
                {
                    mail.To.Add(ReceiveAddressList[i].ToString());
                }
                //邮件主题和内容
                mail.Subject = Subject;
                mail.Body = Content;
                //定义附件,参数为附件文件名,包含路径,推荐使用绝对路径  
                if (AttachFile != null)
                {
                    foreach (string skey in AttachFile.Keys)
                    {
                        System.Net.Mail.Attachment objFile = new System.Net.Mail.Attachment(AttachFile[skey].ToString());
                        objFile.Name = skey;
                        mail.Attachments.Add(objFile);
                    }
                }

                try
                {
                    //发送邮件
                    smtp.Send(mail);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    smtp.Dispose();
                }
            }
        }
    }
}
