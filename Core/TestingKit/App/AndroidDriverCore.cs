/* 
     ___            __     ________   ___  ___  ________      ______    ___      ___               _____  ___    _______  ___________  
    |"  |          /""\   ("      "\ |"  \/"  ||"      "\    /    " \  |"  |    |"  |             (\"   \|"  \  /"     "|("     _   ") 
    ||  |         /    \   \___/   :) \   \  / (.  ___  :)  // ____  \ ||  |    ||  |             |.\\   \    |(: ______) )__/  \\__/  
    |:  |        /' /\  \    /  ___/   \\  \/  |: \   ) || /  /    ) :)|:  |    |:  |             |: \.   \\  | \/    |      \\_ /     
     \  |___    //  __'  \  //  \__    /   /   (| (___\ ||(: (____/ //  \  |___  \  |___    _____ |.  \    \. | // ___)_     |.  |     
    ( \_|:  \  /   /  \\  \(:   / "\  /   /    |:       :) \        /  ( \_|:  \( \_|:  \  ))_  ")|    \    \ |(:      "|    \:  |     
     \_______)(___/    \___)\_______)|___/     (________/   \"_____/    \_______)\_______)(_____(  \___|\____\) \_______)     \__|     
                                                                                                                                   

    Copyright (c) 2020, @ quinn.7@foxmail.com, All rights reserved

    GitPath      : https://github.com/quinn7solomon/LazyDoll.Net
    FrameName    : LazyDoll.Net
    CreatorName  : Quinn7k
    CreationTime : 2020.11.19

    Module Responsibility Description : NA

 */

using System;
using Core.Common.Log;
using Core.Common.ErrorDefined;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 安卓驱动器核心类
    /// </summary>
    public class AndroidDriverCore
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> AndroidDriver 实例 </summary>
        private static AndroidDriver<AndroidElement> _AndroidDriverEntity = null;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        private readonly string ClientUrl;
        private readonly string ClientPort;
        private readonly DriverConfig DriverConfig;


        /// <summary>
        /// 实例化安卓驱动器核心类
        /// </summary>
        /// <param name="driverConfig"> DriverConfig 对象 </param>
        /// <param name="clientPort"> 客户端端口值 </param>
        public AndroidDriverCore(DriverConfig driverConfig, string clientUrl = "127.0.0.1", string clientPort = "4723")
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
                    return _AndroidDriverEntity ??= new AndroidDriver<AndroidElement>
                        (new Uri($"http://{ClientUrl}:{ClientPort}/wd/hub"), DriverConfig.AnalysisCapabilities());
                }

            }

            catch (Exception Err)
            {

                LogServe.Error($"安卓设备驱动核心启动失败: {Err.Message}");

                throw new AndroidDriverStartException(Err.Message);

            }
        }
    }
}
