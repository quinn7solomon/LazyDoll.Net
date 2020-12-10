/* 
     ___            __     ________   ___  ___  ________      ______    ___      ___               _____  ___    _______  ___________  
    |"  |          /""\   ("      "\ |"  \/"  ||"      "\    /    " \  |"  |    |"  |             (\"   \|"  \  /"     "|("     _   ") 
    ||  |         /    \   \___/   :) \   \  / (.  ___  :)  // ____  \ ||  |    ||  |             |.\\   \    |(: ______) )__/  \\__/  
    |:  |        /' /\  \    /  ___/   \\  \/  |: \   ) || /  /    ) :)|:  |    |:  |             |: \.   \\  | \/    |      \\_ /     
     \  |___    //  __'  \  //  \__    /   /   (| (___\ ||(: (____/ //  \  |___  \  |___    _____ |.  \    \. | // ___)_     |.  |     
    ( \_|:  \  /   /  \\  \(:   / "\  /   /    |:       :) \        /  ( \_|:  \( \_|:  \  ))_  ")|    \    \ |(:      "|    \:  |     
     \_______)(___/    \___)\_______)|___/     (________/   \"_____/    \_______)\_______)(_____(  \___|\____\) \_______)     \__|     


    Copyright © 2020 - 2020 Quinn7k.All Rights Reserved.

    GitHub.Url   : https://github.com/quinn7solomon/LazyDoll.Net
    CreatorMail  : quinn.7@foxmail.com

 */


using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using Core.Common.Log;
using Core.Common.ErrorCustom;
using Core.Common.GlobalGovernance;


namespace Core.TestingKit.Web
{

    /// <summary>
    /// 浏览器驱动核心
    /// </summary>
    public class BrowserDriverCore
    {

        /// <summary> 类实例 </summary>
        private static BrowserDriverCore _BrowserDriverCoreEntity = null;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 访问器 </summary>
        public static BrowserDriverCore Instance
        {
            get
            {
                lock (ThreadLock)
                {
                    return _BrowserDriverCoreEntity ??= new BrowserDriverCore();
                }
            }
        }


        /// <summary>
        /// 实例化
        /// </summary>
        private BrowserDriverCore()
        {
            // CODE TODO
        }


        /// <summary>
        /// 创建 Edge 浏览器驱动
        /// </summary>
        public IWebDriver CreationEdgeDriver()
        {
            try
            {
                EdgeOptions edgeOptions = new EdgeOptions();
                return new EdgeDriver(edgeOptions);
            }

            catch (Exception err)
            {
                CreationBrowserDriverExceptionHandling(err, Const.DRIVER_TYPE_BROWSER_EDGE);
                return null;
            }
        }


        /// <summary>
        /// 创建 Chrome 浏览器驱动
        /// </summary>
        public IWebDriver CreationChromeDriver()
        {
            try
            {
                ChromeOptions edgeOptions = new ChromeOptions();
                return new ChromeDriver(edgeOptions);
            }

            catch (Exception err)
            {
                CreationBrowserDriverExceptionHandling(err, Const.DRIVER_TYPE_BROWSER_CHROME);
                return null;
            }
        }


        /// <summary>
        /// 创建 Firefox 浏览器驱动
        /// </summary>
        public IWebDriver CreationFirefoxDriver()
        {
            try
            {
                FirefoxOptions edgeOptions = new FirefoxOptions();
                return new FirefoxDriver(edgeOptions);
            }

            catch (Exception err)
            {
                CreationBrowserDriverExceptionHandling(err, Const.DRIVER_TYPE_BROWSER_FIREFOX);
                return null;
            }
        }


        /// <summary>
        /// 创建浏览器驱动类型异常处理
        /// </summary>
        /// <param name="err"> Exception 对象 </param>
        /// <param name="browserType"> 浏览器驱动类型 </param>
        public void CreationBrowserDriverExceptionHandling(Exception err, string browserType)
        {
            LogServe.Error($"创建浏览器驱动类型 {browserType} 时，捕获了一个异常:: { err.Message }");

            throw new CreationBrowserDriverException();
        }
    }

}
