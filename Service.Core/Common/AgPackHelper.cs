using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Core.Common
{
    public  static class AgPackHelper
    {

        public static string cookie="";
        public static CookieCollection cookieCollection=new CookieCollection();
        public static HtmlNode GetDoc(this HttpItem item, string verificationKeys = "")
        {

            var dom = new HttpResult();
            var i = 1;
            do
            {
                dom = InitDom(item, verificationKeys, i);
                i++;
                if (i >= 5)
                    break;
            } while (dom.Html.Contains("无法连接到远程服务器"));
            cookie = dom.Cookie;
            cookieCollection.Add( dom.CookieCollection ?? new CookieCollection());
            var doc = new HtmlDocument();
          
            doc.LoadHtml(dom.Html);

            return doc.DocumentNode;
        }
        public static HtmlNode GetDoc(this HttpItem item,string xpath, string verificationKeys = "")
        {
            var dom =new HttpResult();
            var i = 1;
            do
            {
                dom = InitDom(item, verificationKeys, i);
                i++;
                if (i >= 5)
                    break;
            }    while (dom.Html.Contains("无法连接到远程服务器")) ;
            var doc = new HtmlDocument();
            doc.LoadHtml(dom.Html);
            var node= doc.DocumentNode.SelectSingleNode(xpath);
            if (node == null)
                return doc.DocumentNode;
            return HtmlNode.CreateNode( node.OuterHtml);
        }
        public static string GetAjax(this HttpItem item, string verificationKeys = "")
        {
            item.Header["X-Requested-With"] = "XMLHttpRequest";
            var dom = new HttpResult();
            var i = 1;

            do
            {
                dom = InitDom(item, verificationKeys, i);
                i++;
                if (i >= 5)
                    break;
            }
            while (
               dom.Html.Contains("无法连接到远程服务器")
            || dom.Html.Contains("未能解析")
        
            );
           
            return dom.Html;
        }

        private static HttpResult InitDom(HttpItem item, string verificationKeys, int i)
        {
            HttpResult dom;
            if (i == 1)
                LogHelper.WriteLog("connect " + item.URL + ",正在尝试第" + i + "次连接...");
            else
                LogHelper.WriteLog("connect " + item.URL + " 连接超时，正在尝试第" + i + "次连接...");

            dom = new HttpHelper().GetHtml(item);
            if (!string.IsNullOrEmpty(verificationKeys))
            {

                while
                (
                   dom.Html.Contains(verificationKeys)
                )
                {
                    Thread.Sleep(5000);
                    dom = new HttpHelper().GetHtml(item);
                }
               
            }

            return dom;
        }

        public static string GetAjax(this string url)
        {
            HttpItem item = new HttpItem() { URL = url, Method = "get" };
            return item.GetAjax();

        }
        public static string PostAjax(this string url, string postData)
        {
            HttpItem item = new HttpItem() { URL = url, Method = "post", PostDataType=PostDataType.String, Postdata=postData };
            return item.GetAjax();

        }
        public static void DownImg(this string url,string filename)
        {
            Utils.DownImg(url,filename);

        }

        public static string GetHtml(this HttpItem item)
        {
          
            var dom = new HttpHelper().GetHtml(item);
            var i = 1;
            while (dom.Html.Contains("超时"))
            {

                i++;
                LogHelper.WriteLog("connect " + item.URL + " 连接超时，正在尝试第" + i + "次连接...");
                dom = new HttpHelper().GetHtml(item);
                if (i == 5)
                    break;
            }
            return dom.Html;
        }

        public static string NodeText(this HtmlNode node)
        {
            
            return node.InnerText;
        }
        public static string Value(this HtmlNode node)
        {

            return node.Attributes["value"].Value;
        }
        public static HtmlNode SignleNode(this HtmlNode node,string xpath)
        {

            return node.SelectSingleNode(xpath);
        }
        public static string SignleNodeText(this HtmlNode node, string xpath)
        {
            var n = node.SelectSingleNode(xpath);
            if (n == null)
                return "";
            return n.NodeText();
        }
        public static string SignleNodeValue(this HtmlNode node, string xpath)
        {
            var n = node.SelectSingleNode(xpath);
            if (n == null)
                return "";
            return n.Value();
        }

        public static string SignleNodeValue(this HtmlNode node, string xpath,string valueName)
        {
            var n = node.SelectSingleNode(xpath);
            if (n == null)
                return "";
            return n.Value(valueName);
        }

        public static string Value(this HtmlNode node,string valueName)
        {

            return node.Attributes[valueName].Value;
        }
        public static string NodeText(this HtmlNode node,string xpath)
        {
            var newnode = HtmlNode.CreateNode(node.OuterHtml);
            var n = newnode.SelectSingleNode(xpath);
            if (n == null)
                return "";
            return n.InnerText;
        }
        public static string NodeHtml(this HtmlNode node, string xpath)
        {
            var n = node.SelectSingleNode(xpath);
            if (n == null)
                return "";
            return n.InnerHtml;
        }
        public static int NodeInt(this HtmlNode node, string xpath)
        {
            var n = node.SelectSingleNode(xpath);
            var r = 0;
            int.TryParse(n==null ? "0":n.InnerText, out r);
            return r;
        }
    }
}
