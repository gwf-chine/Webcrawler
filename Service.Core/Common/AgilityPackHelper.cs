using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Common
{
    public  static class AgilityPackHelper
    {

        public static string cookie="";
        public static CookieCollection cookieCollection=new CookieCollection();
        public static HtmlNode GetDoc(this HttpItem item)
        {
       

            var dom =  new HttpHelper().GetHtml(item);
            var i = 1;
            while (dom.Html.Contains("超时"))
            {
            
                i++;
                LogHelper.WriteLog("connect " + item.URL + " 连接超时，正在尝试第" + i + "次连接...");
                dom = new HttpHelper().GetHtml(item);
                if (i == 5)
                    break;
            }
            cookie = dom.Cookie;
            cookieCollection.Add( dom.CookieCollection);
            var doc = new HtmlDocument();
          
            doc.LoadHtml(dom.Html);

            return doc.DocumentNode;
        }
        public static HtmlNode GetDoc(this HttpItem item,string xpath)
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
            var doc = new HtmlDocument();
            doc.LoadHtml(dom.Html);
            var node= doc.DocumentNode.SelectSingleNode(xpath);
            if (node == null)
                return doc.DocumentNode;
            return HtmlNode.CreateNode( node.OuterHtml);
        }
        public static string GetAjax(this HttpItem item)
        {
            item.Header["X-Requested-With"] = "XMLHttpRequest";
            var dom = new HttpResult();
            var i = 1;

            do {
                LogHelper.WriteLog("connect " + item.URL + " 连接超时，正在尝试第" + i + "次连接...");

                dom = new HttpHelper().GetHtml(item);
                 if (i > 5)
                    break;
                i++;
            }
            while (dom.Html.Contains("超时"));
           
            return dom.Html;
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
            var n = node.SelectSingleNode(xpath);
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
