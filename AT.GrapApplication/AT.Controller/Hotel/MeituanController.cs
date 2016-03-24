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
using System.Threading;
using System.Threading.Tasks;

namespace AT.Controller.Hotel
{
    public class MeituanController : BaseController
    {


        public MeituanController(ITravelBaseRepository _travel, ITravelCommentRepository _travelcomment, IUnitOfWork _unitOfWork) :
        base(_travel, _travelcomment, _unitOfWork)
        {

        }



        public override void Run(params string[] toCitys)
        {
            if (toCitys == null)
                return;
            toCitys.ToList().ForEach(item =>
            {
                Search(item);
            });

        }

        public override void RunAndStartCity(string startCity, params string[] keys)
        {
            throw new NotImplementedException();
        }

        private void Search(string toCity)
        {
            var pageIndex = 1;
            domain = "http://s.tuniu.com";



            var pageCount = 0;
            do
            {

                #region 携程根据关键词检索旅游信息（pageIndex）页面数据

                htmlItem.URL = "http://s.tuniu.com/search_complex/whole-shz-0-" + toCity + "/" + pageIndex + "/";
                //加载列表页面
                htmlDoc = htmlItem.GetDoc();

                pageCount = htmlDoc.SelectNodes("//*[@id=\"niuren_list\"]/div[2]/div[1]/div[7]/div/a").ToList().LastOrDefault().PreviousSibling.InnerText.ToInt();

                var items = htmlDoc.SelectNodes("//*[@id='niuren_list']/div[2]/div[1]/div[6]/ul/li");
                foreach (var item in items)
                {
                    var link = item.SelectSingleNode(".//div[1]/dl/dt/p[1]/a");
                    if (link == null)
                        continue;
                    htmlItem.URL = link.Attributes["href"].Value;

                    htmlDoc = htmlItem.GetDoc();

                    #region 解析旅游信息
                    var model = new TravelBases();

                    //获取携程数据标识
                    model.TravelID = htmlDoc.SignleNodeValue("//*[@id=\"route_id_tmp\"]");
                    model.Web = "TuNiu";
                    if (travelBase.Exits(p => p.TravelID == model.TravelID && p.Web == model.Web))
                        continue;
                    model.Title = htmlDoc.NodeText("//*[@id=\"wrapMain\"]/div[2]/div[1]/div[1]/h1");
                    model.ProductCode = model.TravelID;
                    model.StartCity = htmlDoc.NodeText("//*[@id=\"order_mess\"]/dl[2]/dd/div/div/p");
                    model.Notice = htmlDoc.NodeHtml("//*[@id=\"ydxz\"]/div[3]");
                    model.Scheduling = htmlDoc.NodeHtml("//*[@id=\"tripcontent0\"]/div[1]");
                    model.WebPrice = htmlDoc.NodeText("//*[@id=\"wrapMain\"]/div[2]/div[1]/div[3]/div[2]/div[1]/dl[1]/dd/span[1]/em");
                    model.Url = htmlItem.URL;
                    model.Mobile = htmlDoc.NodeText("//*[@id=\"wrapMain\"]/div[2]/div[1]/div[3]/div[2]/div[3]/div/em");
                    model.SpecialInfo = htmlDoc.NodeHtml("//*[@id=\"abhor_hover\"]/div/p");
                    //產品特色
                    model.ProductSpecial = htmlDoc.NodeHtml("//*[@id=\"cpts\"]/div/div/div/div/div[2]");
                    model.CommentCount = htmlDoc.NodeText("//*[@id=\"pkg-detail-tab-bd\"]/li[6]/a").RegInt();
                    model.ID = Guid.NewGuid();
                    #endregion

                    //获取当前目的地所在携程数据ID
                    var citycode = htmlDoc.SignleNodeValue("//*[@id=\"order_mess\"]/dl[2]/dd/div/div/p", "citycode");
                    var commentPageIndex = 1;
                    var commentPageSize = 1000;
                    var i = 1;
                    var totalCount = 0;
                    var verificationIndex = 0; //网站验证重复次数
                    do
                    {
                        #region 解析评论信息
                        htmlItem.URL = "http://shz.tuniu.com/yii.php?currentPage=" + commentPageIndex + "&productIds%5B%5D=" + model.TravelID + "&pageLimit=" + commentPageSize + "&r=recall%2FremarkAjax";

                        //获取评论json字符串

                        #region 途牛网站验证设置
                        /*
                        *暂停5秒,继续发送
                        */
                        var jsonData = JsonObject.Parse(htmlItem.GetAjax("访问速度过快"));

                        totalCount = jsonData.Get("totalItems").ToInt();
                        if (totalCount <= 0)
                        {
                            do
                            {
                                Thread.Sleep(5000);
                                jsonData = JsonObject.Parse(htmlItem.GetAjax("访问速度过快"));

                                totalCount = jsonData.Get("totalItems").ToInt();
                                verificationIndex++;
                                if (verificationIndex > 5)
                                    break;
                            } while (totalCount <= 0);

                            break;
                        }
                        #endregion
                        //获取评论数据 
                        var list = jsonData.ArrayObjects("contents");
                        if (list == null)
                            break;
                        //当前数据库存储的数量
                        var dataCount = travelComment.GetMany(p => p.ProductCode == model.ProductCode).Count();
                        //判断是否数据变动
                        if (dataCount >= list.Count())
                            break;

                        foreach (var json in list)
                        {

                            //解析携程评论数据

                            var comment = new TravelComments();
                            comment.ProductCode = model.ProductCode;
                            comment.RateId = json.Get("id") + model.Web;
                            i++;
                            if (travelComment.Exits(p => p.RateId == comment.RateId))
                            {
                                LogHelper.WriteLog("当前评论已存在，next");
                                continue;
                            }

                            comment.TravelID = model.ID;
                            comment.UserID = json.Object("user").Get("cust_indentity");
                            comment.userName = json.Object("user").Get("nickname");
                            comment.UserGrade = json.Object("user").Get("level");
                            comment.UserClient = json.Get("remarkChannelName");
                            comment.CommentTime = json.Get("startTime");
                            comment.TravelType = json.Get("productCategoryName");
                            comment.Comment = json.Object("compTextContent").Get("dataSvalue");
                            comment.OverComment = json.Get("subTextContents");
                            comment.CommentTitle = json.Get("CommentTitle");
                            comment.ReplyContent = json.Get("LastReplyContent");
                            comment.ReplyTime = json.Get("LastReplyDate");
                            comment.ID = Guid.NewGuid();
                            travelComment.Add(comment);

                            LogHelper.WriteLog("旅游评论" + i);
                        }
                        unitOfWork.Commit();
                        commentPageIndex++;
                        LogHelper.WriteLog("旅游评论,第" + commentPageIndex + "页数据");
                        Thread.Sleep(1000);

                        #endregion

                    } while (i <= totalCount);


                    model.CommentCount = totalCount;
                    model.CreateTime = DateTime.Now;
                    travelBase.Add(model);
                    unitOfWork.Commit();


                }
                pageIndex++;
                #endregion

            } while (pageIndex <= pageCount);



        }


    }
}
