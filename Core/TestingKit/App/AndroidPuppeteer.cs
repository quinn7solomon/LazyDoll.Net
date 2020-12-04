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
using System.Collections.Generic;
using Core.Common.ErrorDefined;
using Core.Common.Log;
using OpenQA.Selenium.Appium.Android;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 安卓模型组件构建类
    /// </summary>
    public class AndroidPuppeteer
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动 </summary>
        private readonly AndroidDriver<AndroidElement> AndroidDriver;

        /// <summary> 独一的程序组件对象 </summary>
        private AndroidConstructorsSystem UniqueAndroidConstructorsApp = null;

        /// <summary> 独一的屏幕组件对象 </summary>
        private AndroidConstructorsView UniqueAndroidConstructorsView = null;


        /// <summary>
        /// 实例化程序组件实现类
        /// </summary>
        public AndroidPuppeteer(AndroidDriver<AndroidElement> androidDriver)
        {

            AndroidDriver = androidDriver;

        }


        /// <summary>
        /// 构建程序组件
        /// </summary>
        /// <returns> 程序组件 </returns>
        public AndroidConstructorsSystem System()
        {
            if (UniqueAndroidConstructorsApp == null)
            {
                try
                {
                    UniqueAndroidConstructorsApp = new AndroidConstructorsSystem(AndroidDriver);
                }

                catch (Exception err)
                {
                    LogServe.Error($"Error:: 构建系统组件异常:: { err.Message }"); 
                    throw new AndroidcConstructorsSystemException();
                }
            }

            return UniqueAndroidConstructorsApp;
        }


        /// <summary>
        /// 构建屏幕组件
        /// </summary>
        /// <returns> 屏幕组件 </returns>
        public AndroidConstructorsView View()
        {
            if (UniqueAndroidConstructorsView == null)
            {
                try
                {
                    UniqueAndroidConstructorsView = new AndroidConstructorsView(AndroidDriver);
                }

                catch (Exception err)
                {
                    LogServe.Error($"Error:: 构建屏幕组件异常:: { err.Message }");
                    throw new AndroidcConstructorsViewException();
                }
            }

            return UniqueAndroidConstructorsView;
        }


        /// <summary>
        /// 构建功能组件
        /// </summary>
        /// <returns> 功能组件 </returns>
        public AndroidConstructorsModule Module(Dictionary<string, string> elementDictionary)
        {
            try
            {
                return new AndroidConstructorsModule(AndroidDriver, elementDictionary);
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 构建功能组件异常:: { err.Message }");
                throw new AndroidcConstructorsModuleException();
            }
        }

    }

}
