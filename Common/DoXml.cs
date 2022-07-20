using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;
using System.Configuration;
using System.Xml.Linq;

namespace Wathet.Common
{
    public static class DoXml
    {
        /// <summary>
        /// 创建XML文档
        /// </summary>
        /// <param name="name">根节点名称</param>
        /// <param name="type">根节点的一个属性值</param>
        /// <returns></returns>
        /// moss中调用方法：创建的文件如果要存到moss的文档库中,则：
        ///          XmlDocument doc = XmlOperate.CreateXmlDocument("project", "T");
        ///            在此可嵌入增加子节点方法,如AddTaskNode(taskObj, ref doc); ..
        ///          byte[] fileContent = Encoding.UTF8.GetBytes(doc.OuterXml);
        ///          folder.Files.Add("name.xml", fileContent, true);
        ///          web.Update();
        /// .net中调用方法：写入文件中,则：
        ///          document = XmlOperate.CreateXmlDocument("sex", "sexy");
        ///          document.Save("c:/bookstore.xml");         
        public static XmlDocument CreateXmlDocument(string name, string type)
        {
            XmlDocument doc = null;
            XmlElement rootEle = null;
            try
            {
                doc = new XmlDocument();
                doc.LoadXml("<" + name + "/>");
                rootEle = doc.DocumentElement;
                rootEle.SetAttribute("type", type);
            }
            catch (Exception er)
            {
                throw er;
            }
            return doc;
        }


        /// <summary>
        /// 获取Xml结果中对应节点的值
        /// </summary>
        ///  <param name="_resultXml"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static string GetXmlValue(this XDocument _resultXml, string nodeName)
        {
            if (_resultXml == null || _resultXml.Element("xml") == null
                || _resultXml.Element("xml").Element(nodeName) == null)
            {
                return "";
            }
            return _resultXml.Element("xml").Element(nodeName).Value;
        }

        /// <summary>
        /// 在根节点下增加子元素
        /// </summary>
        /// <param name="document"></param>
        /// <param name="nodeName"></param>
        /// <param name="type"></param>
        /// 调用方法：
        ///      document = xmloper.CreateXmlDocument("animal", "carnivore");
        ///      XmlOperate.AddNewNode1(ref document, "carnivore", "high");
        public static void AddNewNode1(ref XmlDocument document, string nodeName, string type)
        {
            XmlElement taskEle = null;
            try
            {
                taskEle = document.CreateElement(nodeName);
                taskEle.SetAttribute("type", type);
                document.DocumentElement.AppendChild((XmlNode)taskEle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 在元素下增加子元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nodeName"></param>
        /// <param name="type"></param>
        /// 调用方法：
        ///       XmlDocument document = new XmlDocument();
        ///       先取到相应的元素,然后调用该方法在该元素下增加子元素
        ///       XmlElement root = (XmlElement)document.SelectSingleNode("//animal/third");
        ///       XmlOperate.AddNewNode2(ref root,"thaw","boost investor confidence");
        ///注意上面的"//animal/third"也可换成"[@type='T' and @isSpecial='1']"这种形式用来获取带有相应属性的元素
        public static void AddNewNode2(ref XmlElement element, string nodeName, string type)
        {
            XmlElement taskEle = null;
            try
            {
                taskEle = element.OwnerDocument.CreateElement(nodeName);
                taskEle.SetAttribute("type", type);
                element.AppendChild((XmlNode)taskEle);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 获取类型为制定值的一组节点
        /// </summary>
        /// <param name="type">类型值。E.G.[@type='T' and @isSpecial='1']</param>
        /// <returns></returns>
        /// 注意：返回的 XmlNodeList 类型是个类似于arraylist的类型,所以要得到它的值只能遍历
        public static XmlNodeList GetDesiredNode(string type)
        {
            XmlDocument document = new XmlDocument();
            return document.SelectNodes("type");
        }


        /// <summary>
        /// 抓取网页上的xml文档赋值给XmlDocument对象
        /// </summary>
        /// <param name="url">网页的url（网页的内容必须是xml格式的）</param>
        /// <returns></returns>
        public static XmlDocument GetXMLDocumentFromWebPage(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = 0;
            myRequest.Proxy = null;

            // Get response 
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();

            XmlDocument document = new XmlDocument();
            document.LoadXml(content);
            return document;
        }

        /// <summary>
        /// 获取服务器上指定文件的xml文件内容
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string GetXMLFile(string location)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"G:\ttt.xml");
            return document.InnerXml;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Read(path, "/Node", "")
         * XmlHelper.Read(path, "/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public static string Read(string path, string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch { }
            return value;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "Element", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Element", "Attribute", "Value")
         * XmlHelper.Insert(path, "/Node", "", "Attribute", "Value")
         ************************************************/
        public static void Insert(string path, string node, string element, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Attribute", "Value")
         ************************************************/
        public static void Update(string path, string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Delete(path, "/Node", "")
         * XmlHelper.Delete(path, "/Node", "Attribute")
         ************************************************/
        public static void Delete(string path, string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            }
            catch { }
        }

    }
}
