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

using Core.Common;
using Core.Common.Log;
using Core.Common.ErrorCustom;


namespace Core.TestingKit.Web
{

    /// <summary>
    /// 浏览器模型组件构建类
    /// </summary>
    public class BrowserPuppeteer
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 浏览器驱动 </summary>
        private readonly IWebDriver BrowserDriver;

        /// <summary> 单例程序组件对象 </summary>
        private BrowserEntitySystem UniqueBrowserEntitySystem = null;

        /// <summary> 单例屏幕组件对象 </summary>
        private BrowserEntityView UniqueBrowserEntityView = null;


        /// <summary>
        /// 实例化浏览器模型组件构建类
        /// </summary>
        public BrowserPuppeteer(IWebDriver browserDriver)
        {
            BrowserDriver = browserDriver;
        }


        /// <summary>
        /// 构建程序组件
        /// </summary>
        /// <returns> 程序组件 </returns>
        public BrowserEntitySystem System()
        {
            if (UniqueBrowserEntitySystem == null)
            {
                try
                {
                    UniqueBrowserEntitySystem = new BrowserEntitySystem(BrowserDriver);
                }

                catch (Exception err)
                {
                    LogServe.Error($"Error:: 构建系统组件异常:: { err.Message }");

                    throw new AndroidcConstructorsSystemException();
                }
            }

            return UniqueBrowserEntitySystem;
        }


        /// <summary>
        /// 构建屏幕组件
        /// </summary>
        /// <returns> 屏幕组件 </returns>
        public BrowserEntityView View()
        {
            if (UniqueBrowserEntityView == null)
            {
                try
                {
                    UniqueBrowserEntityView = new BrowserEntityView(BrowserDriver);
                }

                catch (Exception err)
                {
                    LogServe.Error($"Error:: 构建屏幕组件异常:: { err.Message }");

                    throw new AndroidcConstructorsViewException();
                }
            }

            return UniqueBrowserEntityView;
        }


        /// <summary>
        /// 构建功能组件
        /// </summary>
        /// <returns> 功能组件 </returns>
        public BrowserEntityWidget Widget(ElementStructure elementStructure)
        {
            try
            {
                return new BrowserEntityWidget(BrowserDriver, elementStructure);
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 构建功能组件异常:: { err.Message }");

                throw new AndroidcConstructorsModuleException();
            }
        }

    }

}
