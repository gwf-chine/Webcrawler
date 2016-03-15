using Service.Core;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HtmlAgilityPack;
using System.Web;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using Service.Controller;
using log4net;

namespace Service.ConsoleControl
{
    class Program
    {
        static void Main(string[] args)
        {

         


            new   QFangHelper().Search();
            Console.ReadKey();
        }
        #region [华为]
        private static void Huawei()
        {
            HtmlDocument doc = new HtmlDocument();
            // Console.WriteLine("---开始抓取");
            // Console.WriteLine("请输入你要搜索的内容");
            // Console.Read();
            // var t= Console.ReadLine();
            // Console.WriteLine("你要搜索的内容:"+t);
            // doc.LoadHtml(  Utils.HttpGet("http://www.vmall.com/search?keyword="+ HttpUtility.UrlEncode (t)));

            //var searchItems= doc.DocumentNode.SelectSingleNode("//*[@id=\"pro-list\"]");



            setConfig();

            var temp = getConfig();

            doc.LoadHtml(Utils.HttpGet("http://www.vmall.com/product/1396.html"));

            foreach (var item in temp.GetType().GetProperties())
            {
                var node = doc.DocumentNode.SelectSingleNode(item.GetValue(temp).ToString());
                if (node == null)
                    continue;
                if (node.HasChildNodes)
                    Console.WriteLine(node.InnerHtml);
                else
                    Console.WriteLine(node.InnerText);
                Console.WriteLine(item.Name + ":" + item.GetValue(temp));
                Console.WriteLine("===============================================");
            }
        }

        static void setConfig()
        {
            var model = new HuaWeiConfig();
            model._pro_title = "//*[@id=\"pro-name\"]";
            model._pro_subTitle = "//*[@id=\"skuPromWord\"]";
            model._pro_price = "//*[@id=\"pro-price\"]/b";
            model._pro_coding = "//*[@id=\"pro-sku-code\"]";
            model._pro_detail = "//*[@id=\"pro-tab-feature-content\"]";
            model._pro_comment = "//*[@id=\"pro-tab-evaluate-content\"]";

            ConfigHelper<HuaWeiConfig>.saveConifg(model, model.xmlPath);
        }
        static HuaWeiConfig getConfig()
        {
            return ConfigHelper<HuaWeiConfig>.loadConfig(new HuaWeiConfig().xmlPath);
        }
        #endregion

        #region [天猫]
        public static string tmallParser()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
            HttpItem item = new HttpItem()
            {
                Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
                Allowautoredirect = true,
                CerPath =@AppDomain.CurrentDomain.BaseDirectory + "cert\\tmall_base64.cer",
                ContentType = "text/html; charset=utf-8",
                ResultCookieType = ResultCookieType.CookieCollection,
                URL = "https://www.tmall.com/",
                Method = "Get",

                KeepAlive = true,
                ResultType = ResultType.String,
    
                UserAgent= "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.10 Safari/537.36",
                Referer= "https://www.tmall.com/"
               
            };
            item.URL = "https://detail.tmall.com/item.htm?id=523167135875&sku_properties=5919063:6536025";

            
        
    
           
            var result =new HttpHelper().GetHtml(item);
            var itemid = new Regex(@"itemId:""(\d+)"",").Match(result.Html).Groups[1].Value;

            //查找产品详细信息  
            item.URL = "https://mdskip.taobao.com/core/initItemDetail.htm?tmallBuySupport=true&sellerPreview=false&cachedTimestamp=1451084281661&progressiveSupport=true&isUseInventoryCenter=false&addressLevel=4&isForbidBuyItem=false&isAreaSell=false&household=false&queryMemberRight=true&isApparel=false&itemId="+itemid+"&cartEnable=true&offlineShop=false&isRegionLevel=true&showShopProm=false&isSecKill=false&service3C=true&tryBeforeBuy=false&callback=setMdskip&timestamp=1451111794482&isg=ArS05d97jAX1rqlnCvsm0UfbpHgmn9h3";
            result = new HttpHelper().GetHtml(item);
            var detail= new Regex(@"setMdskip\((.*)\)", RegexOptions.Singleline).Match(result.Html).Groups[1].Value;

            var obj = JObject.Parse(detail);
            var price = obj["defaultModel"]["itemPriceResultDO"].ToList();   
    
           var savePath= @AppDomain.CurrentDomain.BaseDirectory + "tmall.html";
            
           var fl= System.IO.File.Create(savePath);
            fl.Close();
            doc.LoadHtml(detail);

            doc.Save(savePath,Encoding.UTF8);
            return result.Html;
        }
        #endregion

      


    }
  

}
