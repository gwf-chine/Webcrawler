using Antuo.Data.Core.Repositories;
using Antuo.Data.Infrastructure;
using Antuo.Model.Travels;
using Service.Core.Common;
using Service.Utility.Extensions;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AT.Controller.Travel
{
    public class QunarController : BaseController
    {


        public QunarController(ITravelBaseRepository _travel, ITravelCommentRepository _travelcomment, IUnitOfWork _unitOfWork):base(_travel, _travelcomment, _unitOfWork)
        {

        }

        public override void Run(params string[] keys)
        {
            throw new NotImplementedException();
        }

      

        public override void RunAndStartCity(string startCity, params string[] citys)
        {
            if (citys == null)
                return;
            citys.ToList().ForEach(item =>
            {
                Search(startCity, item);
            });

        }
        public void Search(string startCity, string keywords)
        {
            var pageIndex = 1;
            var pageSize = 20;
            domain = "http://dujia.qunar.com";
            htmlItem = new HttpItem();

            var addCount = 0;
            var totalCount = 0;
            do
            {

                #region 携程根据关键词检索旅游信息（pageIndex）页面数据
                htmlItem.URL = "http://dujia.qunar.com/golfz/routeList/adaptors/pcTop?isTouch=0&t=all&o=sale-desc&lm="+(pageIndex-1)+"%2C"+pageSize+"&fhLimit="+(pageIndex-1)+"%2C"+pageSize+"&q="+keywords+"&d="+startCity+"&s=all&qs_ts=1458530873109&ti=3&tm=l01_all_search_origin&sourcepage=list&qssrc=eyJ0cyI6IjE0NTg1NDU1MTczODAiLCJzcmMiOiJhbGwuZW52YSIsImFjdCI6InNjcm9sbCJ9&m=l%2CbookingInfo%2Clm&displayStatus=pc&lowPrice=other&lines6To10=0";
                var dataJson = JsonObject.Parse(htmlItem.GetAjax());
                //加载列表页面
                totalCount = dataJson.Object("data").Object("list").Get("numFound").ToInt();

                var list = dataJson.Object("data").Object("list").ArrayObjects("results");
                if (list == null)
                    return;


                foreach (var item in list)
                {
                    var model = new TravelBases();
                    var link = item.Get("url");
                    if (link == null)
                        continue;
                    htmlItem.URL = "http:"+link;
                    htmlItem.Allowautoredirect = true;
                    model.Title = item.Get("title");
                    model.TraficcInfo = item.Get("trafficInfo");
                    model.TravelID = item.Get("id");
                    var type = item.Get("type");
                    htmlItem.Allowautoredirect = true;
                
                
                    htmlDoc = htmlItem.GetDoc();
                    htmlItem.URL ="http:"+new Regex(@"location.href\s=\s'(.*)'\s\+\swindow.location.hash;").Match(htmlDoc.OuterHtml).Groups[1].Value;
                    htmlDoc = htmlItem.GetDoc();
                    if (type == "freetrip")
                    {
                        #region 解析旅游信息 自由行

                        //获取月份信息
                        var month = new Regex(@".*QNR.bookdata.validMonths\s=\s\[""(.*)"",""(.*)""\];.*").Match(htmlDoc.OuterHtml).Groups[1].Value;
                        //获取所有价格信息
                        model.WebPrice = ("http://zygl3.package.qunar.com/api/calPrices.json?pId=" + model.TravelID + "&month=" + month).GetAjax();
                        model.Web = "Qunar";
                        if (travelBase.Exits(p => p.TravelID == model.TravelID && p.Web == model.Web))
                            continue;
                        model.ProductCode = model.TravelID;
                        model.StartCity = htmlDoc.NodeText("//*[@id=\"page-root\"]/div[2]/div[3]/div[2]/div[3]/ul/li[2]/span/em[1]");
                        model.Notice = htmlDoc.NodeHtml("//*[@id=\"ss-attention\"]/div/div[2]");
                        model.Scheduling = htmlDoc.NodeHtml("//*[@id=\"ss-reference-travel-content\"]");
                        model.Url = htmlItem.URL;
                        model.Mobile = htmlDoc.NodeText("//*[@id=\"js-detail-main-info\"]/div[2]/div/div/div[2]/em/small");
                        //產品特色
                        var specia = htmlDoc.SelectNodes("//*[@id=\"page-root\"]/div[2]/div[3]/div[2]/div[3]/ul/li[3]/div/span[1]");
                        if (specia != null) specia.ToList().ForEach(s =>
                        {
                            model.SpecialInfo += s.NodeText("//span") + "|";
                        });
                        var getCommentUrl = ("http://hkaw3.package.qunar.com/user/comment/product/productCommentStatus.json").PostAjax("productId=" + model.TravelID);
                        model.CommentCount = JsonObject.Parse(getCommentUrl).Object("data").Get("totalRatings").ToInt();
                        model.ID = Guid.NewGuid();
                        model.CreateTime = DateTime.Now;
                        travelBase.Add(model);
                        unitOfWork.Commit();
                        #endregion
                    }
                    else
                    {
                        #region 解析旅游信息 跟团游

                        //获取月份信息
                        var month = new Regex(@".*QNR.bookdata.validMonths\s=\s+\[""(.*)"",""(.*)""\];.*").Match(htmlDoc.OuterHtml).Groups[1].Value;
                        //获取所有价格信息
                        model.WebPrice = ("http://zygl3.package.qunar.com/api/calPrices.json?pId=" + model.TravelID + "&month=" + month).GetAjax();
                        model.Web = "Qunar";
                        if (travelBase.Exits(p => p.TravelID == model.TravelID && p.Web == model.Web))
                            continue;
                        model.ProductCode = model.TravelID;
                        model.StartCity = htmlDoc.NodeText("/html/body/div[1]/div[7]/div[1]/div[1]/div/div[2]/div/div[2]/div");
                        model.Notice = htmlDoc.NodeHtml("//*[@id=\"js_notes\"]/div[2]/div");
                        model.Scheduling = htmlDoc.NodeHtml("//*[@id=\"js_advice\"]/div[2]");
                        model.Url = htmlItem.URL;
                        model.Mobile = htmlDoc.NodeText("//*[@id=\"js_detail_wrapper\"]/div[2]/div/div[1]/div[2]/em");

                        //產品特色
                        var specia = htmlDoc.SelectNodes("//*[@id=\"js_activities_wrapper\"]/div");
                        if (specia != null) specia.ToList().ForEach(s =>
                        {
                            model.SpecialInfo += s.NodeText("//div") + "|";
                        });
                        var getCommentUrl = ("http://hkaw3.package.qunar.com/user/comment/product/productCommentStatus.json").PostAjax("productId=" + model.TravelID);
                        model.CommentCount = JsonObject.Parse(getCommentUrl).Object("data").Get("totalRatings").ToInt();

                        model.ID = Guid.NewGuid();
                        model.CreateTime = DateTime.Now;
                        travelBase.Add(model);
                        unitOfWork.Commit();
                        #endregion
                    }
                    addCount++;
                    if (model.CommentCount <= 0)
                        continue;
                    #region 解析评论信息
                    var commentPageIndex = 1;
                    var commentPageSize = 10;
                    var i = 1;

                  
                    //获取评论json字符串


                    var commentTotalCount = 0;
                    do
                    {
                        htmlItem.URL = "http://zygl3.package.qunar.com/user/comment/product/queryComments.json";
                        htmlItem.Method = "post";
                        htmlItem.Postdata = "type=all&pageNo=" + commentPageIndex + "&pageSize=" + commentPageSize + "&productId=" + model.TravelID + "&rateStatus=ALL";

                        htmlItem.KeepAlive = true;


                        htmlItem.Referer = model.Url;
                        htmlItem.Accept = "text/html,application/xhtml+xml,application/xml; q = 0.9,*/*;q=0.8";
                        htmlItem.Header["Accept-Encoding"] = "gzip, deflate";
                        htmlItem.Header["Accept-Language"] = "zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3";

                        var jsonData = JsonObject.Parse(htmlItem.GetAjax()).Object("data");
                        commentTotalCount = jsonData.Get("totalComment").ToInt();
                        if (commentTotalCount == 0)
                            break;
                        var commentlist = jsonData.ArrayObjects("mainCommentList");
                       
                        commentlist.ForEach(json =>
                        {

                            //解析携程评论数据
                            var comment = new TravelComments();
                            comment.ProductCode = model.ProductCode;
                            comment.TravelID = model.ID;
                            comment.RateId = json.Get("id");
                            comment.userName = json.Get("shownUserName");
                            comment.UserClient = json.Get("deviceSource");
                            comment.TravelType = type;
                            comment.OverComment = json.Get("rating");
                            comment.ReplyContent = json.Get("replyVo");
                            comment.Comment = json.Get("content");
                            comment.ID = Guid.NewGuid();
                            travelComment.Add(comment);
                            i++;

                        });
                        unitOfWork.Commit();
                        commentPageIndex++;
                    } while (i <= commentTotalCount);


                    #endregion

                

                }
                pageIndex++;
                #endregion

            } while (addCount <= totalCount);



        }


    }
}
