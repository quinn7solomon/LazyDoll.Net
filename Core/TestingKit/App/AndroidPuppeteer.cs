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

using OpenQA.Selenium.Appium.Android;

using Core.Common.Log;
using Core.Common.ErrorCustom;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 安卓模型组件构建类
    /// </summary>
    public class AndroidPuppeteer
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        /// <summary> 安卓驱动 </summary>
        private readonly AndroidDriver<AndroidElement> AndroidDriver;

        /// <summary> 单例程序组件对象 </summary>
        private AndroidEntitySystem UniqueAndroidConstructorsApp = null;

        /// <summary> 单例屏幕组件对象 </summary>
        private AndroidEntityView UniqueAndroidConstructorsView = null;


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
        public AndroidEntitySystem System()
        {
            if (UniqueAndroidConstructorsApp == null)
            {
                try
                {
                    UniqueAndroidConstructorsApp = new AndroidEntitySystem(AndroidDriver);
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
        public AndroidEntityView View()
        {
            if (UniqueAndroidConstructorsView == null)
            {
                try
                {
                    UniqueAndroidConstructorsView = new AndroidEntityView(AndroidDriver);
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
        public AndroidEntityWidget Widget(ElementStructure elementStructure)
        {
            try
            {
                return new AndroidEntityWidget(AndroidDriver, elementStructure);
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 构建功能组件异常:: { err.Message }");

                throw new AndroidcConstructorsModuleException();
            }
        }

    }

}
