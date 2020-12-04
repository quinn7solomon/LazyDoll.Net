using System;
using System.Collections.Generic;
using Core.Common.Overall;
using Core.TestingKit.App;
using Core.TestingKit.App.Android;
using OpenQA.Selenium.Appium.Android;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverConfig DriverConfig = new DriverConfig
            {
                PlatformName = "Android",
                PlatformVersion = "8.1.0",
                AutomationName = "UiAutomator2",
                DeviceName = "Android Device",
                AppPath = @"F:\CsharpCode\DollCookbook\AppTesting-TanDu\apk\tandu.apk",
                AppPackage = "com.ylyread.xs",
                AppActivity = "com.wxreader.com.activity.SplashActivity",
                NoReset = true
            };

            AndroidDriver<AndroidElement> AndroidDriver = new AndroidDriverCore(DriverConfig).StartUniqueDriver();
            AndroidPuppeteer AndroidPuppeteer = new AndroidPuppeteer(AndroidDriver);
            AndroidConstructorsSystem AndroidConstructorsSystem = AndroidPuppeteer.System();
            AndroidConstructorsView AndroidConstructorsView = AndroidPuppeteer.View();

            AndroidConstructorsModule Button1 = AndroidPuppeteer.Module(new Dictionary<string, string> 
                {
                    { GlobalConst.ELEMENT_BY, "id" },
                    { GlobalConst.ELEMENT_EL, "com.ylyread.xs:id/imageview" },
                    { GlobalConst.ELEMENT_ID, "2" },
                    { GlobalConst.ELEMENT_PAGE_NAME, "首页" },
                    { GlobalConst.ELEMENT_ELEMENT_NAME, "书城页icon" },
                });

            AndroidConstructorsModule Button2 = AndroidPuppeteer.Module(new Dictionary<string, string> 
                {
                    { GlobalConst.ELEMENT_BY, "id" },
                    { GlobalConst.ELEMENT_EL, "com.ylyread.xs:id/imageview" },
                    { GlobalConst.ELEMENT_ID, "4" },
                    { GlobalConst.ELEMENT_PAGE_NAME, "首页" },
                    { GlobalConst.ELEMENT_ELEMENT_NAME, "我的页icon" },
                });

            AndroidConstructorsView.SwipeDown();
            AndroidConstructorsView.SwipeDown();
            AndroidConstructorsView.SwipeLeft();
            AndroidConstructorsView.SwipeLeft();
            AndroidConstructorsView.SwipeRight();
            AndroidConstructorsView.SwipeRight();
            AndroidConstructorsView.SwipeUp();

            Button1.Tap();
            Button2.Tap();
            Button1.Tap();
            Button2.Tap();
            Button1.Tap();

            AndroidConstructorsSystem.Quit();
        }
    }
}
