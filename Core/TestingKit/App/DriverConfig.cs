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

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;


namespace Core.TestingKit.App
{
    /// <summary>
    /// 驱动设备配置对象
    /// </summary>
    public class DriverConfig
    {

        /// <summary> 平台名称 </summary>
        public string PlatformName { get; set; }

        /// <summary> 平台版本 </summary>
        public string PlatformVersion { get; set; }

        /// <summary> 框架名称 </summary>
        public string AutomationName { get; set; }

        /// <summary> 设备名称 </summary>
        public string DeviceName { get; set; }

        /// <summary> 应用程序安装包路径 </summary>
        public string AppPath { get; set; }

        /// <summary> 应用程序包名 </summary>
        public string AppPackage { get; set; }

        /// <summary> 应用程序启动名 </summary>
        public string AppActivity { get; set; }

        /// <summary> 赋能:: 不重置启动应用程序 </summary>
        public bool NoReset { get; set; } = true;

        /// <summary> 赋能:: 启用 Unicode IME 软键盘 </summary>
        public bool UnicodeKeyboard { get; set; } = true;

        /// <summary> 赋能:: 重置自动化时设置的键盘 </summary>
        public bool ResetKeyBoard { get; set; } = true;


        /// <summary>
        /// 解析函数
        /// </summary>
        /// <returns> AppiumOptions 对象 </returns>
        public AppiumOptions AnalysisCapabilities()
        {

            AppiumOptions capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability("appPackage", AppPackage);
            capabilities.AddAdditionalCapability("appActivity", AppActivity);
            capabilities.AddAdditionalCapability("resetKeyboard", ResetKeyBoard);
            capabilities.AddAdditionalCapability("unicodeKeyboard", UnicodeKeyboard);
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, AppPath);
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, NoReset);
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, DeviceName);
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, PlatformName);
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, AutomationName);
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, PlatformVersion);

            return capabilities;

        }

    }
}
