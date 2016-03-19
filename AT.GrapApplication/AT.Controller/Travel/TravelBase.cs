

using HtmlAgilityPack;
using Service.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Controller
{
    public abstract class TravelBase
    {
        public static HttpItem htmlItem { get; set; }
        public static HtmlNode htmlDoc { get; set; }
        public static HtmlNode Node { get; set; }
        public static string domain { get; set; }
        public TravelBase()
        {
            #region [ 基本参数配置]
            htmlItem = new HttpItem();
            htmlItem.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            htmlItem.Allowautoredirect = true;

            htmlItem.ContentType = "text/html; charset=utf-8";
            htmlItem.ResultCookieType = ResultCookieType.CookieCollection;

            htmlItem.Method = "Get";
            htmlItem.KeepAlive = true;
            htmlItem.ResultType = ResultType.String;
            htmlItem.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.10 Safari/537.36";



            #endregion
        }
    
    }
}
