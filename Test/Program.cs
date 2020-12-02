using System;
using System.Collections.Generic;
using Core.Common.Overall;
using Core.TestingKit.App;
using Core.TestingKit.App.Android;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverConfig DriverConfig = new DriverConfig();
            DriverConfig.PlatformName = "Android";
            DriverConfig.PlatformVersion = "8.1.0";
            DriverConfig.AutomationName = "UiAutomator2";
            DriverConfig.DeviceName = "Android Device";
            DriverConfig.AppPath = @"F:\CsharpCode\DollCookbook\AppTesting-TanDu\apk\tandu.apk";
            DriverConfig.AppPackage = "com.ylyread.xs";
            DriverConfig.AppActivity = "com.wxreader.com.activity.SplashActivity";
            AndroidDriverCore AndroidDriverCore = new AndroidDriverCore(DriverConfig);

            ElementStructure ElementStructure = new ElementStructure(
                new Dictionary<string, string>{
                    { GlobalConst.ELEMENT_BY, "id" },
                    { GlobalConst.ELEMENT_EL, "com.ylyread.xs:id/dialog_btn_ok" },
                    { GlobalConst.ELEMENT_PAGE_NAME, "用户隐私政策弹窗" },
                    { GlobalConst.ELEMENT_ELEMENT_NAME, "我同意" },
                });

            AndroidConstructorsApp AndroidConstructorsApp = new AndroidConstructorsApp(AndroidDriverCore);
            AndroidConstructorsModule AndroidConstructorsModule = new AndroidConstructorsModule(AndroidDriverCore, ElementStructure);
            Console.WriteLine(AndroidConstructorsModule.Text());
            Console.WriteLine(AndroidConstructorsModule.GetAttribute("text"));
            Console.WriteLine(AndroidConstructorsModule.GetAttribute("className"));
            Console.WriteLine(AndroidConstructorsModule.IsInPage());
            Console.WriteLine(AndroidConstructorsModule.IsInPage(1));
        }
    }
}
