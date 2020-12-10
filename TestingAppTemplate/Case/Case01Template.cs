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
using System.Threading;
using Allure.Commons;
using OpenQA.Selenium.Appium.Android;

using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

using Core.Common.Log;
using Core.TestingKit.App;
using Core.TestingKit.App.Android;

using TestingAppTemplate.Model;


namespace TestingAppTemplate.Case
{

    [TestFixture]
    [AllureNUnit]
    [AllureSuite("谷歌原生系统测试示例")]
    [AllureSeverity(SeverityLevel.critical)]
    public class Case01Template
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动配置对象 </summary>
        private readonly DriverConfiguration DriverConfiguration = new DriverConfiguration
        {
            PlatformName = "Android",
            PlatformVersion = "8.1.0",
            AutomationName = "UiAutomator2",
            NoReset = false,
        };

        /// <summary> 安卓驱动 </summary>
        AndroidDriver<AndroidElement> AndroidDriver;

        /// <summary> 操作模型:: 原生系统 </summary>
        ModelSystem ModelSystemCore;

        /// <summary> 操作模型:: 计算器 </summary>
        ModelCalculator ModelCalculatorCore;

        /// <summary> 操作模型:: 谷歌浏览器 </summary>
        ModelChrome ModelChromeCore;

        /// <summary> 操作模型:: 拨打电话 </summary>
        ModelPhone ModelPhoneCore;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AndroidDriver = new AndroidDriverCore(DriverConfiguration).StartEngine();
            ModelChromeCore = new ModelChrome(AndroidDriver);
            ModelSystemCore = new ModelSystem(AndroidDriver);
            ModelCalculatorCore = new ModelCalculator(AndroidDriver);
            ModelPhoneCore = new ModelPhone(AndroidDriver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ModelSystemCore.System.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            Thread.Sleep(1000);  // The first sheep.
        }

        [TearDown]
        public void TearDown()
        {
            ModelSystemCore.View.PressKeyHome(false);
        }


        /// <summary>
        /// 通过应用程序列表搜索框搜索 Calculator
        /// </summary>
        [AllureSeverity(SeverityLevel.critical)]
        [Test(Description = "通过应用程序列表搜索框搜索 Calculator")]
        public void Test01SearchAppsCalculator()
        {
            try
            {
                ModelSystemCore.UpArrows.Tap();
                ModelSystemCore.AppsSearchInput.SendKey("Calculator");
                string appName = ModelSystemCore.AppsAppIconList.GetAttributeText(0);
                bool assert = string.Equals(appName, "Calculator");

                LogServe.Info($"预期字段='Calculator', 结果字段='{appName}'");
                Assert.AreEqual(appName, "Calculator");
            }

            catch (Exception) { Assert.IsTrue(false); }
        }


        /// <summary>
        /// 打开系统原生计算器并计算加法
        /// </summary>
        [Sequential]
        [AllureSeverity(SeverityLevel.critical)]
        [Test(Description = "打开系统原生计算器并计算加法")]
        public void Test02CalculatorAddition([Values(2, 4, 6)] int a, [Values(3, 5, 7)] int b)
        {
            try
            {
                ModelCalculatorCore.Open();
                ModelCalculatorCore.VirtualButtonsNumber(a).Tap();
                ModelCalculatorCore.VirtualButtonsOpAdd.Tap();
                ModelCalculatorCore.VirtualButtonsNumber(b).Tap();
                ModelCalculatorCore.VirtualButtonsEq.Tap();
                string result = ModelCalculatorCore.ComputationResult.GetAttributeText();

                LogServe.Info($"预期字段='{a + b}', 结果字段='{result}'");
                Assert.AreEqual(result, (a + b).ToString());
            }

            catch (Exception) { Assert.IsTrue(false); }
        }


        /// <summary>
        /// 启动谷歌浏览器并搜索百度URL
        /// </summary>
        [AllureSeverity(SeverityLevel.critical)]
        [Test(Description = "启动谷歌浏览器并搜索百度URL")]
        public void Test03GoogleBrowserBaiduSearch()
        {
            try
            {
                ModelSystemCore.UpArrows.Tap();
                ModelSystemCore.AppsSearchInput.SendKey("Chrome");
                ModelSystemCore.AppsAppIconList.Tap();

                // 如果初次启动谷歌浏览器，就跳过必要选项，
                if (ModelChromeCore.GooglePolicyConsentOk.IsInPage())
                {
                    ModelChromeCore.GooglePolicyConsentOk.Tap();
                    ModelChromeCore.GoogleNoThanks.Tap();
                }

                ModelChromeCore.HomeSearchInputBox.SendKey("www.baidu.com");
                ModelChromeCore.View.PressKeyEnter();

                // 如果弹出警告框则点击允许
                if (ModelChromeCore.WarningWindowAllow.IsInPage())
                {
                    ModelChromeCore.WarningWindowAllow.Tap();
                }

                ModelChromeCore.View.PressKeyBack();

                // 该用例为流程用例，即运行到此已算跳过，断言恒为True
                Assert.IsTrue(true);
            }

            catch (Exception) { Assert.IsTrue(false); }
        }


        /// <summary>
        /// 模拟拨打电话后挂断
        /// </summary>
        [AllureSeverity(SeverityLevel.critical)]
        [Test(Description = "模拟拨打电话后挂断")]
        public void Test04AnalogDialing()
        {
            try
            {
                ModelPhoneCore.Open();
                ModelPhoneCore.RedStartButton.Tap();
                ModelPhoneCore.NumericKeys(1).Tap();
                ModelPhoneCore.NumericKeys(8).Tap();
                ModelPhoneCore.NumericKeys(8).Tap();
                ModelPhoneCore.GreenCallButton.Tap();
                ModelPhoneCore.HangPhoneButton.Tap();

                Assert.IsTrue(true);
            }

            catch (Exception) { Assert.IsTrue(false); }
        }

    }

}
