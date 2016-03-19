

using Antuo.Model.Travels;
using HtmlAgilityPack;
using Service.Core.Common;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Utility.Extensions;
using Antuo.Data.Core.Repositories;
using Antuo.Data.Infrastructure;

namespace AT.Controller.Travel
{

    public class XieChengController : TravelBase
    {

        static ITravelBaseRepository _travel;
        static ITravelCommentRepository _travelcomment;
        static IUnitOfWork _unitOfWork;
        public XieChengController(ITravelBaseRepository travel, ITravelCommentRepository travelcomment, IUnitOfWork unitOfWork)
        {
            _travel = travel;
            _travelcomment = travelcomment;
            _unitOfWork = unitOfWork;
        }
       

      



        
       
        public void Run(params string[] citys)
        {
            if (citys == null)
                return;
            citys.ToList().ForEach(item =>
            {
                Search(item);
            });

        }
        public static void Search(string keywords)
        {
            var pageIndex = 1;
            domain = "http://vacations.ctrip.com";
            htmlItem = new HttpItem();
            //获取url跳转地址
            htmlItem.URL = "http://vacations.ctrip.com/tour-mainsite-vacations/api/entry/do?tab=126&keyword="+keywords+"&src=Online";
            var urlJson =JsonObject.Parse( htmlItem.GetAjax());
            var pageCount = 0;
            do
            {

                #region 携程根据关键词检索旅游信息（pageIndex）页面数据

                htmlItem.URL = domain + urlJson.Get("Link") + "/p" + pageIndex;
                //加载列表页面
                htmlDoc = htmlItem.GetDoc();
                pageCount = htmlDoc.SelectNodes("//*[@id=\"_pg\"]/a").ToList().LastOrDefault().PreviousSibling.InnerText.ToInt();

                var items = htmlDoc.SelectNodes("//*[@id=\"_prd\"]/div[@class=\"main_mod product_box\"]");
                foreach (var item in items)
                {
                    var link = item.SelectSingleNode("//div[2]/h2/a");
                    if (link == null)
                        continue;
                    htmlItem.URL = domain + link.Attributes["href"].Value;
                    htmlItem.Allowautoredirect = true;
                    htmlDoc = htmlItem.GetDoc();

                    var model = new TravelBases();
                    model.Title = htmlDoc.NodeText("//*[@id=\"base_bd\"]/div[1]/div[2]/div[2]/div[1]/h1");
                    model.ProductCode = htmlDoc.NodeText("//*[@id=\"base_bd\"]/div[1]/div[2]/div[2]/div[1]/ul/li[1]");
                    model.StartCity = htmlDoc.NodeText("//*[@id=\"base_bd\"]/div[1]/div[2]/div[2]/div[1]/ul/li[2]/span");
                    //多线路
                    var muti = htmlDoc.SelectNodes("//*[@id=\"base_bd\"]/div[1]/div[2]/div[2]/div[1]/ul/li[3]/div/a");
                    if (muti != null) muti.ToList().ForEach(r =>
                    {
                        var road = HtmlNode.CreateNode(r.OuterHtml);
                        model.Scheduling += road.NodeText() + "|";
                    });
                    model.Notice = htmlDoc.NodeHtml("//*[@id=\"js_order_needknow\"]");

                    model.Scheduling = htmlDoc.NodeHtml("//*[@id=\"simpleJourneyBox\"]");
                    model.WebPrice = htmlDoc.NodeText("//*[@id=\"J_total_price\"]");
                    model.Url = htmlItem.URL;
                    model.Mobile = htmlDoc.NodeText("//*[@id=\"J_hot_telphone\"]/p");
                  
                    //產品特色
                    var specia = htmlDoc.SelectNodes("//*[@id=\"base_bd\"]/div[1]/div[2]/div[2]/div[1]/dl[1]/dd/span");
                    if (specia != null) specia.ToList().ForEach(s =>
                    {
                        model.SpecialInfo += s.NodeText() + "|";
                    });
                    model.CommentCount = htmlDoc.NodeText("//*[@id=\"js_main_price_wrap\"]/div[1]/a[2]");
                    model.TravelID = htmlDoc.SignleNodeValue("//*[@id=\"TrackProductId\"]");
                    model.Web = "XieCheng";
                    model.ID = Guid.NewGuid();

               
                    var cityId = htmlDoc.SignleNodeValue("//*[@id=\"TrackStartCityId\"]");
                
                    #region 解析评论信息
                    var commentPageIndex = 1;
                    var i = 1;

                    htmlItem.URL = "http://vacations.ctrip.com/bookingnext/Comment/Search?pkg=" + model.TravelID + "&destEname=&districtID=0&country=0&urlCategory=morelinetravel&PMPicture=http://dimg04.c-ctrip.com/images/fd/vacations/g4/M02/9C/60/CggYHlbP72qAEb9xAAEvy2FhYh4068.jpg&pageIndex=" + commentPageIndex + "&score=undefined&IsTourGroupProduct=1";
                    htmlItem.Cookie = AgilityPackHelper.cookie;
                    htmlItem.CookieCollection = AgilityPackHelper.cookieCollection;
                    htmlItem.KeepAlive = true;
                

                    htmlItem.Referer = model.Url;
                    htmlItem.Accept = "text/html,application/xhtml+xml,application/xml; q = 0.9,*/*;q=0.8";
                    htmlItem.Header["Accept-Encoding"] = "gzip, deflate";
                    htmlItem.Header["Accept-Language"] = "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3";
                    //获取评论json字符串
                    var jsonData = JsonObject.Parse(htmlItem.GetAjax()).Object("data");
                    if (jsonData != null)
                    {
                        var totalCount = jsonData.Get("TotalPageCount").ToInt();
                        while (i <= totalCount)
                        {

                            jsonData = JsonObject.Parse(htmlItem.GetAjax()).Object("data");
                            var list = jsonData.ArrayObjects("CommentsInfoList");
                            if (list.Count() <= 0)
                                break;
                            list.ForEach(json =>
                            {

                                //解析携程评论数据

                                var comment = new TravelComments();
                                comment.TravelID = model.ID;
                                comment.UserID = json.Get("UID");
                                comment.userName = json.Get("UID");
                                comment.UserGrade = json.Get("CommentGrade");
                                comment.UserClient = json.Get("AFrom");
                                comment.TravelType = json.Get("TravelTypeString");
                                comment.TravelTraficc = "";
                                json.ArrayObjects("PkgCommentAswersTitle").ForEach(ser =>
                                {
                                    comment.OverComment = ser.Get("QuestionTitle") + ":" + ser.Get("AGrade") + ">";
                                });
                                comment.CommentTitle = json.Get("CommentTitle");
                                comment.ReplyContent = json.Get("LastReplyContent");
                                comment.ReplyTime = json.Get("LastReplyDate");
                                comment.Comment = json.Get("CommentContent");

                                comment.ID = Guid.NewGuid();

                                
                                _travelcomment.Add(comment);
                                    

                            });
                  
                            commentPageIndex++;
                        }
                    }

                    #endregion

                    _travel.Add(model);
                    _unitOfWork.Commit();
                }
                pageIndex++;
                #endregion

            } while (pageIndex<=pageCount);

            

        }

      
    }
}
