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
using Core.Common.Log;
using Core.Common.ErrorDefined;
using OpenQA.Selenium.Appium.Android;
using System.Threading;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 实例化安卓驱动类
    /// </summary>
    public class AndroidDriverCore
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> AndroidDriver 实例 </summary>
        private static AndroidDriver<AndroidElement> _AndroidDriverEntity = null;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        /// <summary> Appium客户端URL </summary>
        private readonly string ClientUrl;

        /// <summary> Appium客户端端口 </summary>
        private readonly string ClientPort;

        /// <summary> 驱动配置对象 </summary>
        private readonly DriverConfiguration DriverConfig;


        /// <summary>
        /// 实例化安卓驱动类
        /// </summary>
        /// <param name="driverConfig"> DriverConfig 对象 </param>
        /// <param name="clientPort"> 客户端端口值 </param>
        public AndroidDriverCore(DriverConfiguration driverConfig, string clientUrl = "127.0.0.1", string clientPort = "4723")
        {

            ClientUrl = clientUrl;
            ClientPort = clientPort;
            DriverConfig = driverConfig;

        }


        /// <summary>
        /// 开始函数
        /// </summary>
        /// <returns></returns>
        public AndroidDriver<AndroidElement> StartUniqueDriver()
        {
            try
            {
                lock (ThreadLock)
                {
                    _AndroidDriverEntity ??= new AndroidDriver<AndroidElement>
                        (new Uri($"http://{ClientUrl}:{ClientPort}/wd/hub"), DriverConfig.AnalysisCapabilities());

                    Thread.Sleep(1000);

                    return _AndroidDriverEntity;
                }
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 安卓设备驱动启动失败: {err.Message}");

                throw new AndroidDriverException(err.Message);
            }
        }
    
    }
}
