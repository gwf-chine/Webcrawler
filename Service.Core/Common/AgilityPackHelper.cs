using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antuo.Core
{
    public  static class AgilityPackHelper
    {
     
        public static HtmlNode GetDoc(this HttpItem item)
        {
            var dom =  new HttpHelper().GetHtml(item);
            var doc = new HtmlDocument();
            doc.LoadHtml(dom.Html);
            return doc.DocumentNode;
        }
        public static HtmlNode GetDoc(this HttpItem item,string xpath)
        {
            var dom = new HttpHelper().GetHtml(item);
            var doc = new HtmlDocument();
            doc.LoadHtml(dom.Html);
            var node= doc.DocumentNode.SelectSingleNode(xpath);
            if (node == null)
                return doc.DocumentNode;
            return HtmlNode.CreateNode( node.OuterHtml);
        }
        public static string GetAjax(this HttpItem item)
        {
            item.Header[""] = "";
            var dom = new HttpHelper().GetHtml(item);
         
            return dom.Html;
        }
        public static string GetHtml(this HttpItem item)
        {
          
            var dom = new HttpHelper().GetHtml(item);

            return dom.Html;
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
