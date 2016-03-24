

using Antuo.Data.Core.Repositories;
using Antuo.Data.Infrastructure;
using HtmlAgilityPack;
using Service.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Controller
{
    public abstract class BaseController
    {
        protected ITravelBaseRepository travelBase;
        protected ITravelCommentRepository travelComment;
        protected IUnitOfWork unitOfWork;
        public static HttpItem htmlItem { get; set; }
        public static HtmlNode htmlDoc { get; set; }
        public static HtmlNode Node { get; set; }
        public static string domain { get; set; }
        protected static IndexTable thisIndex { get; set; }
        public BaseController()
        {
            #region [ 基本参数配置]
            htmlItem = new HttpItem();
            htmlItem.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            htmlItem.Allowautoredirect = true;

            htmlItem.ContentType = "text/html; charset=utf-8";
            htmlItem.ResultCookieType = ResultCookieType.CookieCollection;
            htmlItem.Header["Accept-Encoding"] = "gzip, deflate";
            htmlItem.Header["Accept-Language"] = "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3";

            htmlItem.Method = "Get";
            htmlItem.KeepAlive = true;
            htmlItem.ResultType = ResultType.String;
            htmlItem.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.10 Safari/537.36";



            #endregion
        }
        protected class IndexTable
        {
            public string ProductUrl { get; set; }
            public string CommentUrl { get; set; }
            public int PageIndex { get; set; }
            public int CommentPageIndex { get; set; }
            public DateTime LastRunTime { get; set; }
        }
        protected virtual void SetIndex(IndexTable obj )
        {
            thisIndex = obj;
        }
        public BaseController(ITravelBaseRepository _travel, ITravelCommentRepository _travelcomment, IUnitOfWork _unitOfWork)
        {
            this.travelBase = _travel;
            this.travelComment = _travelcomment;
            this.unitOfWork = _unitOfWork;
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

        public abstract void Run(params string[] toCitys);
        public abstract void RunAndStartCity(string startCity,params string[] toCitys);
    }
}
