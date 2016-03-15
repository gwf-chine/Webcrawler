using Antuo.Core;
using Antuo.Model;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using Antuo.Model.Travels;

namespace Antuo.Controller
{
    #region [Q房网  www.qfang.com]
    public class QFangHelper
    {

        private HttpItem item = new HttpItem();
        private string domain = "http://shenzhen.qfang.com";
        public QFangHelper()
        {
            #region [ 基本参数配置]

            item.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            item.Allowautoredirect = true;

            item.ContentType = "text/html; charset=utf-8";
            item.ResultCookieType = ResultCookieType.CookieCollection;

            item.Method = "Get";
            item.KeepAlive = true;
            item.ResultType = ResultType.String;
            item.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.10 Safari/537.36";



            #endregion
        }
        /// <summary>
        /// 获取htmlNode
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private HtmlNode GetDocument(string xpath = "")
        {
            return item.GetDoc(xpath);

        }
        public void Search()
        {
            var total = "";
            var doc = HtmlNode.CreateNode("");
            var pageSize = 0;
            var pageIndex = 1;
            var list = new HtmlNodeCollection(null);
            LogHelper.SetConfig();

            #region [ 租房数据 ]
            LogHelper.WriteLog("<<开始抓取租房房数据>>");
            item.URL = "http://shenzhen.qfang.com/rent";
            doc = GetDocument();
            //查找总页数
            total = doc.SelectSingleNode("//*[@id=\"functionsBar\"]/div[3]/p/span").InnerText;
            pageSize = doc.SelectSingleNode("//*[@id=\"cycleListings\"]/ul").ChildNodes.Count();
            pageIndex = 1;




            item.URL = "http://shenzhen.qfang.com/rent/f" + pageIndex;
            doc = GetDocument();
            list = doc.SelectSingleNode("//*[@id=\"cycleListings\"]/ul").ChildNodes;
            try
            {
                foreach (var node in list)
                {
                    var model = new HouseBase();
                    model.Type = "Rent";
                    var tnode = HtmlNode.CreateNode(node.OuterHtml);

                    var title = tnode.SelectSingleNode("//div/div[1]/div[1]/h3/a");
                    if (title == null)
                        continue;


                    model.modelTitle = title.InnerText;
                    model.web = "Qfang";

                    var idNode = tnode.SelectSingleNode("//div/div[1]/div[1]/h3/a");
                    if (idNode == null)
                        continue;
                    model.modelID = idNode.Attributes["href"].Value;
                    var path = domain + model.modelID;
                    using (var context = new ATHouseContext())
                    {

                        model.ID = Guid.NewGuid();
                        var any = context.HouseBase.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any) { LogHelper.WriteLog("已存在next..."); continue; }
                        //详细页面地址
                        item.URL = path;

                        LogHelper.WriteLog("grap：" + path);
                        LogHelper.WriteLog("开始");


                        model.modelUrl = path;

                        #region [ 房源信息 ]
                        doc = GetDocument("//*[@id=\"detailconMainBase\"]");
                        if (doc != null)
                        {
                            //租金
                            model.totalPrice = doc.SelectSingleNode("//div[1]/p[1]/span").InnerText;
                            //房源户型
                            model.houseType = doc.SelectSingleNode("//div[2]/ul/li[1]/div/span[2]").InnerText;
                            //建筑面积
                            model.houseSize = doc.SelectSingleNode("//div[2]/ul/li[2]/div/span[2]").InnerText;
                            //所在楼层
                            model.houseFloor = doc.SelectSingleNode("//div[2]/ul/li[3]/div").InnerText;
                            //装修情况
                            model.houseFitment = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                            //朝向
                            model.houseOrt = doc.SelectSingleNode("//div[2]/ul/li[5]/div/span[2]").InnerText;
                            //建筑类型
                            model.buildType = doc.SelectSingleNode("//div[2]/ul/li[6]/div/span[2]").InnerText;
                            //所属区域
                            model.houseProportion = doc.SelectSingleNode("//div[2]/ul/li[7]/div/span[2]").InnerText;
                            //建筑年代
                            model.EstateAge = doc.SelectSingleNode("//div[2]/ul/li[8]/div/span[2]").InnerText;
                            //小区名称
                            model.EstatePlot = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                            //地址
                            model.houseAddress = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                        }
                        #endregion

                        #region [ 小区信息 ]
                        doc = GetDocument("//*[@id=\"scrollto2\"]");
                        if (doc != null)
                        {
                            model.EstateName = doc.SelectSingleNode("//div[2]/p").InnerText;
                            //物业
                            model.ManagerName = doc.SelectSingleNode("//div[2]/div[1]/div/p[2]").InnerText;
                            //物业开发商
                            model.EstateDevelopers = doc.SelectSingleNode("//div[2]/div[1]/div/p[3]").InnerText;
                            //物业类型
                            model.ManagerType = doc.SelectSingleNode("//div[2]/div[1]/div/p[4]").InnerText;
                            //占地面积
                            model.EstateArea = doc.SelectSingleNode("//div[2]/div[2]/div/p[2]").InnerText;
                            //绿化
                            model.EstateGreen = doc.SelectSingleNode("//div[2]/div[2]/div/p[3]").InnerText;
                            //物业费用
                            model.ManagerPrice = doc.SelectSingleNode("//div[2]/div[2]/div/p[4]").InnerText;
                            //车位
                            model.CarNum = doc.SelectSingleNode("//div[2]/div[2]/div/p[5]").InnerText;
                            //车位费用
                            model.CarPrice = doc.SelectSingleNode("//div[2]/div[2]/div/p[6]").InnerText;

                            //在售房源
                            model.SellHouseNum = doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[1]").InnerText;

                            //租房数量
                            model.Rentingnum = doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[2]/i") == null ? "0" : doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[2]/i").InnerText;
                            //小区当前均价与上月均价比较
                            model.EstateAvgPrice = doc.SelectSingleNode("//div[2]/div[3]/div/p[3]").InnerHtml;
                        }
                        #endregion

                        #region [ 中介信息 ]
                        doc = GetDocument("//div[@class=\"detailcon_side fr\"]");
                        if (doc != null)
                        {
                            model.brokerName = doc.SelectSingleNode("//div[1]/div[1]/p[1]/a").InnerText;
                            model.brokerWeb = doc.SelectSingleNode("//div[1]/div[1]/p[2]").InnerText;
                            model.brokerShoper = doc.SelectSingleNode("//div[1]/div[1]/p[3]").InnerText;
                            model.brokerMobile = doc.SelectSingleNode("//div[1]/div[2]/p[1]").InnerText;

                        }

                        #endregion


                        model.modelID = model.web + "-" + model.modelID;
                        context.HouseBase.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("error：" + ex.Message);
            }




            LogHelper.WriteLog("<<租房更新插入成功>>");


            #endregion

            #region [ 新房数据 ]
            LogHelper.WriteLog("<<开始抓取新房数据>>");
            item.URL = "http://shenzhen.qfang.com/newhouse/list";
            doc = GetDocument();
            //查找总页数
            total = doc.SelectSingleNode("//*[@id=\"functionsBar\"]/div[1]/p/span").InnerText;
            pageSize = doc.SelectSingleNode("//*[@id=\"cycleListings\"]/ul").ChildNodes.Count();
            pageIndex = 1;




            item.URL = "http://shenzhen.qfang.com/newhouse/list/n" + pageIndex;
            doc = GetDocument();
            list = doc.SelectSingleNode("//*[@id=\"cycleListings\"]/ul").ChildNodes;
            try
            {
                foreach (var node in list)
                {
                    var model = new NewHouses();


                    var tnode = HtmlNode.CreateNode(node.OuterHtml);
                    var title = tnode.SelectSingleNode("//div/div[2]/div[1]/h3/a");
                    if (title == null)
                        continue;

                    model.modelTitle = title.InnerText;
                    model.web = "Qfang";
                    model.modelID = title.Attributes["href"].Value;

                    using (var context = new ATHouseContext())
                    {

                        model.ID = Guid.NewGuid();
                        var any = context.NewHouses.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any) { LogHelper.WriteLog("已存在next..."); continue; }
                        var path = domain + model.modelID;
                        item.URL = path;
                        LogHelper.WriteLog("grap：" + path);
                        LogHelper.WriteLog("开始");
                        model.modelUrl = path;



                        #region [ 楼盘信息 ]
                        doc = GetDocument("/html/body/div[4]/div[3]/div[2]");
                        if (doc != null)
                        {
                            model.Mobile = doc.SelectSingleNode("//h3/div[2]").InnerText;
                            model.UnitPrice = doc.SelectSingleNode("//div[1]/p").InnerText;

                        
                            //物业类型
                            model.ManagerType = doc.SelectSingleNode("//div[2]/p[2]").InnerText;
                            model.OpenTime = doc.SelectSingleNode("//div[2]/p[3]").InnerText;
                            model.HouseTime = doc.SelectSingleNode("//div[2]/p[4]").InnerText;
                            //开发商
                            model.Developers = doc.SelectSingleNode("//div[2]/p[5]").InnerText;
                            model.EstateManagerFlot = doc.SelectSingleNode("//div[2]/p[6]").InnerText;

                            model.EstateBuildType = doc.SelectSingleNode("//div[2]/p[7]").InnerText;

                            model.EstateName = doc.SelectSingleNode("//div[2]/p[8]").InnerText;
                            model.EstateSellAddress = doc.SelectSingleNode("//div[2]/p[9]").InnerText;
                        }
                        doc = GetDocument("/html/body/div[4]/div[7]/div/div[2]/div[1]");
                        if (doc != null)
                        {

                            //占地面积
                            model.SpaceArea = doc.SelectSingleNode("//ul/li[2]").InnerText;
                            //区域  
                            model.EstateArea = doc.SelectSingleNode("//ul/li[3]").InnerText;
                            //车位
                            model.EstateCarNum = doc.SelectSingleNode("//ul/li[4]").InnerText;


                            //容积率
                            model.EstatePlotRatio = doc.SelectSingleNode("//ul/li[6]").InnerText;
                            model.Decoration = doc.SelectSingleNode("//ul/li[7]").InnerText;
                            //绿化
                            model.EstateGreenRatio = doc.SelectSingleNode("//ul/li[8]").InnerText;



                            //车位费用
                            model.EstateCarPrice = doc.SelectSingleNode("//ul/li[12]").InnerText;
                            model.Description = doc.SelectSingleNode("//div").InnerHtml;
                        }
                        #endregion




                        model.modelID = model.web + "-" + model.modelID;
                        context.NewHouses.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("error：" + ex.Message);
            }




            LogHelper.WriteLog("<<新房更新插入成功>>");


            #endregion

            #region [ 二手房数据 ]

            LogHelper.WriteLog("<<开始抓取二手房数据>>");
            item.URL = "http://shenzhen.qfang.com/sale";
            doc = GetDocument();
            pageSize = doc.SelectSingleNode("//*[@id=\"cycleListings\"]/ul").ChildNodes.Count();


            item.URL = "http://shenzhen.qfang.com/sale/f" + pageIndex;
            doc = GetDocument();
            list = doc.SelectSingleNode("//*[@id=\"cycleListings\"]/ul").ChildNodes;
            try
            {
                foreach (var node in list)
                {
                    var model = new HouseBase();
                    model.Type = "SecondHand";
                    var tnode = HtmlNode.CreateNode(node.OuterHtml);
                    var title = tnode.SelectSingleNode("//div/div[1]/div[1]/h3/a");
                    if (title == null)
                        continue;

                    model.modelTitle = title.InnerText;
                    model.web = "Qfang";

                    var idNode = tnode.SelectSingleNode("//div/div[1]/div[1]/h3/a");
                    if (idNode == null)
                        continue;
                    model.modelID = idNode.Attributes["href"].Value;
                    using (var context = new ATHouseContext())
                    {

                        model.ID = Guid.NewGuid();
                        var any = context.HouseBase.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any) { LogHelper.WriteLog("已存在next..."); continue; }

                        var path = domain + model.modelID;



                        item.URL = path;

                        LogHelper.WriteLog("grap：" + path);
                        LogHelper.WriteLog("开始");


                        model.modelUrl = path;

                        #region [ 房源信息 ]
                        doc = GetDocument("//*[@id=\"detailconMainBase\"]");
                        if (doc != null)
                        {
                            //总价
                            model.totalPrice = doc.SelectSingleNode("//div[1]/p[1]/span").InnerText;

                            //单价
                            model.unitPrice = doc.SelectSingleNode("//div[1]/div[1]/span").InnerText;
                            //房源户型
                            model.houseType = doc.SelectSingleNode("//div[2]/ul/li[1]/div/span[2]").InnerText;
                            //建筑面积
                            model.houseSize = doc.SelectSingleNode("//div[2]/ul/li[2]/div/span[2]").InnerText;
                            //所在楼层
                            model.houseFloor = doc.SelectSingleNode("//div[2]/ul/li[3]/div/span[2]").InnerText;
                            //装修情况
                            model.houseFitment = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                            //朝向
                            model.houseOrt = doc.SelectSingleNode("//div[2]/ul/li[5]/div/span[2]").InnerText;
                            //建筑类型
                            model.buildType = doc.SelectSingleNode("//div[2]/ul/li[6]/div/span[2]").InnerText;
                            //所属区域
                            model.houseProportion = doc.SelectSingleNode("//div[2]/ul/li[7]/div/span[2]").InnerText;
                            //建筑年代
                            model.EstateAge = doc.SelectSingleNode("//div[2]/ul/li[8]/div/span[2]").InnerText;
                            //小区名称
                            model.EstatePlot = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                            //地址
                            model.houseAddress = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                        }
                        #endregion

                        #region [ 小区信息 ]
                        doc = GetDocument("//*[@id=\"scrollto2\"]");
                        if (doc != null)
                        {
                            model.EstateName = doc.SelectSingleNode("//div[2]/p").InnerText;
                            //物业
                            model.ManagerName = doc.SelectSingleNode("//div[2]/div[1]/div/p[2]").InnerText;
                            //物业开发商
                            model.EstateDevelopers = doc.SelectSingleNode("//div[2]/div[1]/div/p[3]").InnerText;
                            //物业类型
                            model.ManagerType = doc.SelectSingleNode("//div[2]/div[1]/div/p[4]").InnerText;
                            //占地面积
                            model.EstateArea = doc.SelectSingleNode("//div[2]/div[2]/div/p[2]").InnerText;
                            //绿化
                            model.EstateGreen = doc.SelectSingleNode("//div[2]/div[2]/div/p[3]").InnerText;
                            //物业费用
                            model.ManagerPrice = doc.SelectSingleNode("//div[2]/div[2]/div/p[4]").InnerText;
                            //车位
                            model.CarNum = doc.SelectSingleNode("//div[2]/div[2]/div/p[5]").InnerText;
                            //车位费用
                            model.CarPrice = doc.SelectSingleNode("//div[2]/div[2]/div/p[6]").InnerText;

                            //在售房源
                            model.SellHouseNum = doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[1]").InnerText;

                            //租房数量
                            model.Rentingnum = doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[2]/i") == null ? "0" : doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[2]/i").InnerText;
                            //小区当前均价与上月均价比较
                            model.EstateAvgPrice = doc.SelectSingleNode("//div[2]/div[3]/div/p[3]").InnerHtml;
                        }
                        #endregion

                        #region [ 中介信息 ]
                        doc = GetDocument("//div[@class=\"detailcon_side fr\"]");
                        if (doc != null)
                        {
                            model.brokerName = doc.SelectSingleNode("//div[1]/div[1]/p[1]/a").InnerText;
                            model.brokerWeb = doc.SelectSingleNode("//div[1]/div[1]/p[2]").InnerText;
                            model.brokerShoper = doc.SelectSingleNode("//div[1]/div[1]/p[3]").InnerText;
                            model.brokerMobile = doc.SelectSingleNode("//div[1]/div[2]/p[1]").InnerText;

                        }

                        #endregion


                        model.modelID = model.web + "-" + model.modelID;
                        context.HouseBase.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("error：" + ex.Message);
            }




            LogHelper.WriteLog("<<二手房更新插入成功>>");


            #endregion


        }


    }
    #endregion

    #region [爱屋及乌  www.iwjw.com]
    public class iWJWHelper
    {

        private HttpItem item = new HttpItem();
        private string domain = "http://shenzhen.qfang.com";
        public iWJWHelper()
        {
            #region [ 基本参数配置]

            item.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            item.Allowautoredirect = true;

            item.ContentType = "text/html; charset=utf-8";
            item.ResultCookieType = ResultCookieType.CookieCollection;

            item.Method = "Get";
            item.KeepAlive = true;
            item.ResultType = ResultType.String;
            item.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.10 Safari/537.36";



            #endregion
        }
        /// <summary>
        /// 获取htmlNode
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private HtmlNode GetDocument(string xpath = "")
        {
            HtmlDocument doc = new HtmlDocument();
            var html = new HttpHelper().GetHtml(item).Html.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            doc.LoadHtml(html);
            if (xpath != "")
            {
                var node = doc.DocumentNode.SelectSingleNode(xpath);
                if (node == null)
                    return null;
                return HtmlNode.CreateNode(node.OuterHtml);
            }
            return doc.DocumentNode;

        }
        public void Search()
        {
            var total = "";
            var doc = HtmlNode.CreateNode("");
            var pageSize = 0;
            var pageIndex = 1;
            var list = new HtmlNodeCollection(null);
            LogHelper.SetConfig();

            #region [ 租房房数据 ]

            LogHelper.WriteLog("<<开始抓取租房房数据>>");
            item.URL = "http://www.iwjw.com/chuzu/";
            doc = GetDocument();
            pageSize = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div[3]/div/ol").ChildNodes.Count();
            item.URL = "http://www.iwjw.com/chuzu/p" + pageIndex + "/";
            doc = GetDocument();
            list = doc.SelectNodes("//*[@id=\"iwjw\"]/div/div[2]/div[3]/div/ol/li");

            foreach (var node in list)
            {
                try
                {
                    using (var context = new ATHouseContext())
                    {
                        var model = new HouseBase();
                        model.Type = "Rent";
                        var tnode = HtmlNode.CreateNode(node.OuterHtml);

                        var title = tnode.SelectSingleNode("//div/h4/b/a");
                        if (title == null)
                            continue;

                        model.modelTitle = title.InnerText;
                        model.web = "IWJW";

                        var idNode = tnode.SelectSingleNode("//div/div[1]/div[1]/h3/a");
                        if (idNode == null)
                            continue;
                        model.modelUrl = idNode.Attributes["href"].Value;
                        model.modelID = new Regex(@".*/chuzu/(\w*)/?", RegexOptions.Singleline).Match(model.modelUrl).Groups[1].Value;


                        model.ID = Guid.NewGuid();
                        var any = context.HouseBase.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any)
                        {
                            LogHelper.WriteLog("已存在next...");
                            continue;
                        }
                        item.URL = model.modelUrl;
                        doc = GetDocument();
                        LogHelper.WriteLog("grap：" + model.modelUrl); LogHelper.WriteLog("开始");

                        #region [ 房源信息 ]
                        doc = GetDocument("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]");
                        if (doc != null)
                        {
                            //总价
                            model.totalPrice = doc.SelectSingleNode("//div[1]/div/p/span[1]").InnerText;
                            //房源户型
                            model.houseType = doc.SelectSingleNode("//div[1]/div/p/span[2]").InnerText;
                            //建筑面积
                            model.houseSize = doc.SelectSingleNode("//div[1]/div/p/span[3]").InnerText;

                            //单价
                            model.unitPrice = doc.SelectSingleNode("//div[2]/div[1]/p").InnerText;


                            //所在楼层
                            model.houseFloor = doc.SelectSingleNode("//div[2]/div[2]/p[1]").InnerText;
                            //建筑年代
                            model.EstateAge = doc.SelectSingleNode("//div[2]/div[2]/p[2]").InnerText;
                            //朝向
                            model.houseOrt = doc.SelectSingleNode("//div[2]/div[3]/p[2]").InnerText;
                            //装修情况
                            model.houseFitment = doc.SelectSingleNode("//div[2]/div[4]/p").InnerText;

                            model.Feature = doc.SelectSingleNode("//div[2]/div[5]/em") == null ? "" : doc.SelectSingleNode("//div[2]/div[5]/em").InnerText;

                            //地址
                            model.houseAddress = doc.SelectSingleNode("//div[1]/h2").InnerText;
                        }
                        #endregion

                        #region [ 小区信息 ]
                        doc = GetDocument("//*[@id=\"detailpm\"]");
                        if (doc != null)
                        {


                            #region     [ 小区详细信息 ]
                            item.URL = doc.SelectSingleNode("//div[2]/div/p[4]/a").Attributes["href"].Value;
                            model.EstatePriceTrent = doc.SelectSingleNode("//div[2]/div/p").InnerHtml;
                            doc = GetDocument();
                            model.EstateName = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/h1").InnerText;
                            //区域
                            model.EstateLocal = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/h2").InnerText;
                            //当月均价
                            model.EstateAvgPrice = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/div/span[1]/i").InnerHtml;
                            //月价比较
                            model.Compare = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/div/span[2]").InnerHtml;
                            model.houseType = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[1]/p[1]/i[2]").InnerHtml;
                            model.HouseTotal = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[1]/p[2]").InnerHtml;
                            model.EstateAge = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[2]/p[1]").InnerHtml;


                            model.SpaceArea = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[2]/p[2]").InnerHtml;

                            //绿化
                            model.EstateGreen = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[4]/p[1]").InnerText;
                            //容积率
                            model.EstatePlot = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/p[1]").InnerText;
                            model.BuildArea = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/p[2]").InnerHtml;

                            //物业
                            model.ManagerName = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[4]/p[2]/i[2]").InnerText;
                            //车位
                            model.CarNum = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[5]/p[1]").InnerText;

                            //物业费用
                            model.ManagerPrice = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[5]/p[2]").InnerText;
                            model.EstateAdress = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[6]/p").InnerText;
                            //物业开发商
                            model.EstateDevelopers = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[7]/p").InnerText;
                            model.HouseDes = doc.SelectSingleNode("//*[@id=\"detailim\"]/div[2]").InnerHtml;
                            #endregion



                        }
                        #endregion




                        model.modelID = model.web + "-" + model.modelID;
                        model.CreateTime = DateTime.Now;
                        context.HouseBase.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("error：" + ex.Message);
                }
            }





            LogHelper.WriteLog("<<二手房更新插入成功>>");


            #endregion

            #region [ 二手房数据 ]

            LogHelper.WriteLog("<<开始抓取二手房数据>>");
            item.URL = "http://www.iwjw.com/sale/";
            doc = GetDocument();
            pageSize = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div[3]/div/ol").ChildNodes.Count();
            item.URL = "http://www.iwjw.com/sale/p" + pageIndex + "/";
            doc = GetDocument();
            list = doc.SelectNodes("//*[@id=\"iwjw\"]/div/div[2]/div[3]/div/ol/li");

            foreach (var node in list)
            {
                try
                {
                    using (var context = new ATHouseContext())
                    {
                        var model = new HouseBase();
                        model.Type = "SecondHand";
                        var tnode = HtmlNode.CreateNode(node.OuterHtml);

                        var title = tnode.SelectSingleNode("//div/h4/b/a");
                        if (title == null)
                            continue;

                        model.modelTitle = title.InnerText;
                        model.web = "IWJW";

                        var idNode = tnode.SelectSingleNode("//div/div[1]/div[1]/h3/a");
                        if (idNode == null)
                            continue;
                        model.modelUrl = idNode.Attributes["href"].Value;
                        model.modelID = new Regex(@".*/sale/(\w*)/?", RegexOptions.Singleline).Match(model.modelUrl).Groups[1].Value;


                        model.ID = Guid.NewGuid();
                        var any = context.HouseBase.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any)
                        {
                            LogHelper.WriteLog("已存在next...");
                            continue;
                        }
                        item.URL = model.modelUrl;
                        doc = GetDocument();
                        LogHelper.WriteLog("grap：" + model.modelUrl); LogHelper.WriteLog("开始");

                        #region [ 房源信息 ]
                        doc = GetDocument("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]");
                        if (doc != null)
                        {
                            //总价
                            model.totalPrice = doc.SelectSingleNode("//div[1]/div/p/span[1]").InnerText;
                            //房源户型
                            model.houseType = doc.SelectSingleNode("//div[1]/div/p/span[2]").InnerText;
                            //建筑面积
                            model.houseSize = doc.SelectSingleNode("//div[1]/div/p/span[3]").InnerText;

                            //单价
                            model.unitPrice = doc.SelectSingleNode("//div[2]/div[1]/p").InnerText;


                            //所在楼层
                            model.houseFloor = doc.SelectSingleNode("//div[2]/div[2]/p[1]").InnerText;
                            //建筑年代
                            model.EstateAge = doc.SelectSingleNode("//div[2]/div[2]/p[2]").InnerText;
                            //朝向
                            model.houseOrt = doc.SelectSingleNode("//div[2]/div[3]/p[2]").InnerText;
                            //装修情况
                            model.houseFitment = doc.SelectSingleNode("//div[2]/div[4]/p").InnerText;

                            model.Feature = doc.SelectSingleNode("//div[2]/div[5]/em").InnerText;
                            //建筑类型
                            model.buildType = "--";
                            //所属区域
                            model.houseProportion = "--";
                            //小区名称
                            model.EstatePlot = "--";
                            //地址
                            model.houseAddress = doc.SelectSingleNode("//div[1]/h2").InnerText;
                        }
                        #endregion

                        #region [ 小区信息 ]
                        doc = GetDocument("//*[@id=\"detailpm\"]");
                        if (doc != null)
                        {


                            #region     [ 小区详细信息 ]
                            item.URL = doc.SelectSingleNode("//div[2]/div/p[4]/a").Attributes["href"].Value;
                            doc = GetDocument();

                            #endregion


                            model.EstateName = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/h1").InnerText;
                            //区域
                            model.EstateLocal = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/h2").InnerText;
                            //当月均价
                            model.EstateAvgPrice = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/div/span[1]/i").InnerHtml;
                            //月价比较
                            model.Compare = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[1]/div/span[2]").InnerHtml;
                            model.houseType = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[1]/p[1]/i[2]").InnerHtml;
                            model.HouseTotal = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[1]/p[2]").InnerHtml;
                            model.EstateAge = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[2]/p[1]").InnerHtml;


                            model.SpaceArea = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[2]/p[2]").InnerHtml;

                            //绿化
                            model.EstateGreen = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[4]/p[1]").InnerText;
                            //容积率
                            model.EstatePlot = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/p[1]").InnerText;
                            model.BuildArea = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/p[2]").InnerHtml;

                            //物业
                            model.ManagerName = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[4]/p[2]/i[2]").InnerText;
                            //车位
                            model.CarNum = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[5]/p[1]").InnerText;

                            //物业费用
                            model.ManagerPrice = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[5]/p[2]").InnerText;
                            model.EstateAdress = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[6]/p").InnerText;
                            //物业开发商
                            model.EstateDevelopers = doc.SelectSingleNode("//*[@id=\"iwjw\"]/div/div[2]/div/div[2]/div[2]/div[2]/div[7]/p").InnerText;
                            model.HouseDes = doc.SelectSingleNode("//*[@id=\"detailim\"]/div[2]").InnerHtml;
                        }
                        #endregion




                        model.modelID = model.web + "-" + model.modelID;
                        model.CreateTime = DateTime.Now;
                        context.HouseBase.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("error：" + ex.Message);
                    continue;
                }
            }





            LogHelper.WriteLog("<<二手房更新插入成功>>");


            #endregion


        }


    }
    #endregion

    #region [房天下  www.fang.com]
    public class FangHelper
    {

        private HttpItem item = new HttpItem();
        private string domain = "http://zu.sz.fang.com";
        public FangHelper()
        {
            #region [ 基本参数配置]

            item.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            item.Allowautoredirect = true;

            item.ContentType = "text/html; charset=utf-8";
            item.ResultCookieType = ResultCookieType.CookieCollection;

            item.Method = "Get";
            item.KeepAlive = true;
            item.ResultType = ResultType.String;
            item.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.10 Safari/537.36";



            #endregion
        }
        /// <summary>
        /// 获取htmlNode
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private HtmlNode GetDocument(string xpath = "")
        {
            HtmlDocument doc = new HtmlDocument();
            var html = new HttpHelper().GetHtml(item).Html.Replace("\r", "").Replace("\n", "").Replace("\t", "");
            doc.LoadHtml(html);
            if (xpath != "")
            {
                var node = doc.DocumentNode.SelectSingleNode(xpath);
                if (node == null)
                    return null;
                return HtmlNode.CreateNode(node.OuterHtml);
            }
            return doc.DocumentNode;

        }
        public void Search()
        {
            var total = "";
            var doc = HtmlNode.CreateNode("");
            var pageSize = 0;
            var pageIndex = 1;
            var list = new HtmlNodeCollection(null);
            LogHelper.SetConfig();

            #region [ 租房数据 ]
            LogHelper.WriteLog("<<开始抓取租房房数据>>");
            item.URL = "http://zu.sz.fang.com/";
            doc = GetDocument();
            //查找总页数
            total = doc.SelectSingleNode("//*[@id=\"rentid_65\"]/div/i").InnerText;
            pageSize = doc.SelectNodes("//*[@class=\"list hiddenMap rel\"]").Count();
            pageIndex = 1;




            item.URL = "http://zu.sz.fang.com/house/i3" + pageIndex + "/";
            doc = GetDocument();
            list = doc.SelectNodes("//*[@class=\"list hiddenMap rel\"]");

            foreach (var node in list)
            {
                try
                {
                    var model = new HouseBase();
                    model.Type = "Rent";
                    var tnode = HtmlNode.CreateNode(node.OuterHtml);

                    var title = tnode.SelectSingleNode("//dd/p[1]/a");
                    if (title == null)
                        continue;


                    model.modelTitle = title.InnerText;
                    model.web = "Fang";
                    model.modelID = title.Attributes["href"].Value;
                    var path = domain + model.modelID;
                    using (var context = new ATHouseContext())
                    {

                        model.ID = Guid.NewGuid();
                        var any = context.HouseBase.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any)
                        {
                            LogHelper.WriteLog("已存在next...");
                            continue;
                        }

                        item.URL = path;

                        LogHelper.WriteLog("grap：" + path);
                        LogHelper.WriteLog("开始");
                        model.modelUrl = path;
                        doc = GetDocument();

                        #region [ 中介信息 ]
                        //地址
                        model.houseAddress = new Regex(@"address:\s'(\w+)',", RegexOptions.Singleline).Match(doc.OuterHtml).Groups[1].Value;
                        model.brokerMobile = new Regex(@"agentMobile:\s'(\d{3}-\d{3}-\d{4}\w{1}\d+)',", RegexOptions.Singleline).Match(doc.OuterHtml).Groups[1].Value;
                        model.brokerName = new Regex(@"agentName:\s'(\w+)',", RegexOptions.Singleline).Match(doc.OuterHtml).Groups[1].Value;
                        #endregion

                        #region [ 房源信息 ]

                        if (doc != null)
                        {
                            doc = GetDocument("//*[@id=\"body\"]/div[7]/div[2]/div[3]");
                            //租金
                            model.totalPrice = doc.SelectSingleNode("//ul/li[1]").InnerText;
                            model.EstateName = doc.SelectSingleNode("//ul/li/span[1]").InnerText;
                            doc = GetDocument("//*[@id=\"zf_baseInfo_anchor\"]/ul[1]");

                            //房源户型
                            model.houseType = doc.SelectSingleNode("//li[4]/p[2]").InnerText;
                            //建筑面积
                            model.houseSize = doc.SelectSingleNode("//li[6]/p[2]").InnerText;
                            //所在楼层
                            model.houseFloor = doc.SelectSingleNode("//li[8]/p[2]").InnerText;
                            //装修情况
                            model.houseFitment = doc.SelectSingleNode("//li[9]/p[2]").InnerText;

                        }
                        #endregion

                        model.modelID = model.web + "-" + model.modelID;
                        context.HouseBase.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("error：" + ex.Message);
                    continue;
                }
            }





            LogHelper.WriteLog("<<租房更新插入成功>>");


            #endregion

            #region [ 新房数据 ]
            LogHelper.WriteLog("<<开始抓取新房数据>>");
            item.URL = "http://newhouse.sz.fang.com/house/s/";
            doc = GetDocument();
            //查找总页数
            total = doc.SelectSingleNode("//*[@id=\"allUrl\"]/span").InnerText;
            pageSize = doc.SelectNodes("//*[@class=\"have_hb\"]").Count();
            pageIndex = 1;




            item.URL = "http://newhouse.sz.fang.com/house/s/b9" + pageIndex + "/";
            doc = GetDocument();
            list = doc.SelectNodes("//*[@class=\"have_hb\"]");

            foreach (var node in list)
            {
                try
                {
                    var model = new NewHouses();


                    var tnode = HtmlNode.CreateNode(node.OuterHtml);
                    var title = tnode.SelectSingleNode("//div[2]/div[1]/div[1]/a");
                    if (title == null)
                        continue;

                    model.modelTitle = title.InnerText;
                    model.web = "Fang";
                    model.modelUrl = title.Attributes["href"].Value;
                    model.modelID = new Regex("^http://(.*).fang.com/", RegexOptions.Singleline).Match(model.modelUrl).Groups[1].Value;


                    using (var context = new ATHouseContext())
                    {

                        model.ID = Guid.NewGuid();
                        var any = context.NewHouses.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any)
                        {
                            LogHelper.WriteLog("已存在next...");
                            continue;
                        }

                        item.URL = model.modelUrl;
                        LogHelper.WriteLog("grap：" + model.modelUrl);
                        LogHelper.WriteLog("开始");
                        doc = GetDocument();
                        item.URL = doc.SelectSingleNode("//*[@id=\"xfptxq_B04_14\"]").Attributes["href"].Value;


                        #region [ 楼盘信息 ]
                        doc = GetDocument("/html/body/div[8]/div[1]/div[1]/div[2]");
                        if (doc != null)
                        {


                            model.UnitPrice = doc.SelectSingleNode("//table/tbody/tr[12]/td/span[1]").InnerText;
                            model.HistoryPrice = doc.SelectSingleNode("//div[3]").InnerHtml;
                            model.ProjectMating = doc.SelectSingleNode("//div[5]").InnerHtml;
                            model.EstateFloor = doc.SelectSingleNode("//div[11]").InnerHtml;
                            model.EstateBuildFitment = doc.SelectSingleNode("//div[9]").InnerHtml;
                            model.EstateCarport = doc.SelectSingleNode("//div[13]").InnerHtml;
                            model.Description = doc.SelectSingleNode("//div[15]").InnerHtml;
                            model.ElseInfo = doc.SelectSingleNode("//div[17]").InnerHtml;
                            model.ManagerType = doc.SelectSingleNode("//table/tbody/tr[1]/td[1]").InnerText;
                            model.Feature = doc.SelectSingleNode("//table/tbody/tr[1]/td[2]").InnerText;
                            model.EstateBuildType = doc.SelectSingleNode("//table/tbody/tr[2]/td[1]").InnerText;
                            model.CaseFitment = doc.SelectSingleNode("//table/tbody/tr[2]/td[2]").InnerText;
                            model.EstatePlot = doc.SelectSingleNode("//table/tbody/tr[4]/td[1]").InnerText;
                            model.EstateGreen = doc.SelectSingleNode("//table/tbody/tr[4]/td[2]").InnerText;
                            model.LoopLine = doc.SelectSingleNode("//table/tbody/tr[3]/td[1]").InnerText;
                            model.CaseFitment = doc.SelectSingleNode("//table/tbody/tr[3]/td[2]").InnerText;
                            model.OpenTime = doc.SelectSingleNode("//table/tbody/tr[5]/td[1]").InnerText;
                            model.HouseTime = doc.SelectSingleNode("//table/tbody/tr[5]/td[2]").InnerText;
                            model.EstateManagerFlot = doc.SelectSingleNode("//table/tbody/tr[6]/td[1]").InnerText;
                            model.EstateManager = doc.SelectSingleNode("//table/tbody/tr[6]/td[2]").InnerText;
                            model.Developers = doc.SelectSingleNode("//table/tbody/tr[7]/td").InnerText;
                            model.EstateLicence = doc.SelectSingleNode("//table/tbody/tr[8]/td").InnerText;
                            model.EstateSellAddress = doc.SelectSingleNode("//table/tbody/tr[9]/td").InnerText;
                            model.EstateManagerAddress = doc.SelectSingleNode("//table/tbody/tr[10]/td").InnerText;
                            model.EstateTraffic = doc.SelectSingleNode("//div[7]").InnerHtml;
                        }

                        #endregion




                        model.modelID = model.web + "-" + model.modelID;
                        context.NewHouses.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("error：" + ex.Message);
                }
            }





            LogHelper.WriteLog("<<新房更新插入成功>>");


            #endregion

            #region [ 二手房数据 ]

            LogHelper.WriteLog("<<开始抓取二手房数据>>");
            item.URL = "http://esf.sz.fang.com/";
            doc = GetDocument();
            pageSize = doc.SelectSingleNode("/html/body/div[4]/div[4]/div[4]").ChildNodes.Count();


            item.URL = "http://esf.sz.fang.com/house/i3" + pageIndex + "/";
            doc = GetDocument();
            list = doc.SelectSingleNode("/html/body/div[4]/div[4]/div[4]").ChildNodes;

            foreach (var node in list)
            {
                try
                {
                    var model = new HouseBase();
                    model.Type = "SecondHand";
                    var tnode = HtmlNode.CreateNode(node.OuterHtml);
                    var title = tnode.SelectSingleNode("//dd/p[1]/a");
                    if (title == null)
                        continue;

                    model.modelTitle = title.InnerText;
                    model.web = "Fang";
                    model.modelID = title.Attributes["href"].Value;
                    using (var context = new ATHouseContext())
                    {

                        model.ID = Guid.NewGuid();
                        var any = context.HouseBase.Any(p => p.modelID == model.web + "-" + model.modelID);
                        if (any)
                        {
                            LogHelper.WriteLog("已存在next..."); continue;
                        }

                        var path = domain + model.modelID;



                        item.URL = path;

                        LogHelper.WriteLog("grap：" + path);
                        LogHelper.WriteLog("开始");


                        model.modelUrl = path;

                        #region [ 房源信息 ]
                        doc = GetDocument("//*[@id=\"detailconMainBase\"]");
                        if (doc != null)
                        {
                            //总价
                            model.totalPrice = doc.SelectSingleNode("//div[1]/p[1]/span").InnerText;

                            //单价
                            model.unitPrice = doc.SelectSingleNode("//div[1]/div[1]/span").InnerText;
                            //房源户型
                            model.houseType = doc.SelectSingleNode("//div[2]/ul/li[1]/div/span[2]").InnerText;
                            //建筑面积
                            model.houseSize = doc.SelectSingleNode("//div[2]/ul/li[2]/div/span[2]").InnerText;
                            //所在楼层
                            model.houseFloor = doc.SelectSingleNode("//div[2]/ul/li[3]/div/span[2]").InnerText;
                            //装修情况
                            model.houseFitment = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                            //朝向
                            model.houseOrt = doc.SelectSingleNode("//div[2]/ul/li[5]/div/span[2]").InnerText;
                            //建筑类型
                            model.buildType = doc.SelectSingleNode("//div[2]/ul/li[6]/div/span[2]").InnerText;
                            //所属区域
                            model.houseProportion = doc.SelectSingleNode("//div[2]/ul/li[7]/div/span[2]").InnerText;
                            //建筑年代
                            model.EstateAge = doc.SelectSingleNode("//div[2]/ul/li[8]/div/span[2]").InnerText;
                            //小区名称
                            model.EstatePlot = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                            //地址
                            model.houseAddress = doc.SelectSingleNode("//div[2]/ul/li[4]/div/span[2]").InnerText;
                        }
                        #endregion

                        #region [ 小区信息 ]
                        doc = GetDocument("//*[@id=\"scrollto2\"]");
                        if (doc != null)
                        {
                            model.EstateName = doc.SelectSingleNode("//div[2]/p").InnerText;
                            //物业
                            model.ManagerName = doc.SelectSingleNode("//div[2]/div[1]/div/p[2]").InnerText;
                            //物业开发商
                            model.EstateDevelopers = doc.SelectSingleNode("//div[2]/div[1]/div/p[3]").InnerText;
                            //物业类型
                            model.ManagerType = doc.SelectSingleNode("//div[2]/div[1]/div/p[4]").InnerText;
                            //占地面积
                            model.EstateArea = doc.SelectSingleNode("//div[2]/div[2]/div/p[2]").InnerText;
                            //绿化
                            model.EstateGreen = doc.SelectSingleNode("//div[2]/div[2]/div/p[3]").InnerText;
                            //物业费用
                            model.ManagerPrice = doc.SelectSingleNode("//div[2]/div[2]/div/p[4]").InnerText;
                            //车位
                            model.CarNum = doc.SelectSingleNode("//div[2]/div[2]/div/p[5]").InnerText;
                            //车位费用
                            model.CarPrice = doc.SelectSingleNode("//div[2]/div[2]/div/p[6]").InnerText;

                            //在售房源
                            model.SellHouseNum = doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[1]").InnerText;

                            //租房数量
                            model.Rentingnum = doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[2]/i") == null ? "0" : doc.SelectSingleNode("//div[2]/div[3]/div/p[2]/a[2]/i").InnerText;
                            //小区当前均价与上月均价比较
                            model.EstateAvgPrice = doc.SelectSingleNode("//div[2]/div[3]/div/p[3]").InnerHtml;
                        }
                        #endregion

                        #region [ 中介信息 ]
                        doc = GetDocument("//div[@class=\"detailcon_side fr\"]");
                        if (doc != null)
                        {
                            model.brokerName = doc.SelectSingleNode("//div[1]/div[1]/p[1]/a").InnerText;
                            model.brokerWeb = doc.SelectSingleNode("//div[1]/div[1]/p[2]").InnerText;
                            model.brokerShoper = doc.SelectSingleNode("//div[1]/div[1]/p[3]").InnerText;
                            model.brokerMobile = doc.SelectSingleNode("//div[1]/div[2]/p[1]").InnerText;

                        }

                        #endregion


                        model.modelID = model.web + "-" + model.modelID;
                        context.HouseBase.Add(model);
                        context.SaveChanges();
                        LogHelper.WriteLog("插入成功！ next...");
                        LogHelper.WriteLog("结束");
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("error：" + ex.Message);
                    continue;
                }
            }





            LogHelper.WriteLog("<<二手房更新插入成功>>");


            #endregion


        }


    }
    #endregion


}
