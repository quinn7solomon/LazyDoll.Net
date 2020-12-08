
using Core.TestingKit.App;
using Core.TestingKit.App.Android;
using OpenQA.Selenium.Appium.Android;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverConfiguration DriverConfig = new DriverConfiguration
            {
                PlatformName = "Android",
                PlatformVersion = "8.1.0",
                AutomationName = "UiAutomator2",
/*              DeviceName = "Android Device",
                AppPath = @"F:\CsharpCode\DollCookbook\AppTesting-TanDu\apk\tandu.apk",
                AppPackage = "com.ylyread.xs",
                AppActivity = "com.wxreader.com.activity.SplashActivity",      */
                NoReset = true
            };

            AndroidDriver<AndroidElement> AndroidDriver = new AndroidDriverCore(DriverConfig).StartEngine();
            AndroidPuppeteer AndroidPuppeteer = new AndroidPuppeteer(AndroidDriver);

            AndroidEntitySystem AndroidConstructorsSystem = AndroidPuppeteer.System();
            AndroidEntityView AndroidConstructorsView = AndroidPuppeteer.View();

            AndroidEntityWidget Button1 = AndroidPuppeteer.Widget(new ElementStructure
            {
                By = "id",
                El = "com.ylyread.xs:id/imageview",
                Id = "2",
                PageName = "首页",
                WidgetName = "书城页icon",
            });

            AndroidConstructorsSystem.AppOpen("com.ylyread.xs", "com.wxreader.com.activity.SplashActivity");
            AndroidConstructorsSystem.AppIsInstalled("com.ylyread.xs");

            AndroidConstructorsSystem.Quit();
        }
    }
}
