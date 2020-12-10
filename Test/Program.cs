using System;

using OpenQA.Selenium;

using Core.Common;
using Core.TestingKit.Web;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            BrowserDriverCore DriverCore = BrowserDriverCore.Instance;
            IWebDriver Driver = DriverCore.CreationChromeDriver();

            BrowserPuppeteer Puppeteer = new BrowserPuppeteer(Driver);

            BrowserEntitySystem System = Puppeteer.System();
            BrowserEntityView View = Puppeteer.View();

            BrowserEntityWidget button1 = Puppeteer.Widget(new ElementStructure
            {
                By = "id",
                El = "kw",
                PageName = "百度",
                WidgetName = "搜索框",
            });
            View.WindowHandleRetrieval();
            View.OpenWindow("http://www.hao123.com/");
            View.OpenWindow("http://www.baidu.com/");
            View.GoToWindow(0);
            View.GoToWindow(1);
            View.Close();

            button1.Tap();

        }
    }
}
