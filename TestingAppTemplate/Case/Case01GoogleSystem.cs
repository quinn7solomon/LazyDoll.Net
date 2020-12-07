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
    class Case01GoogleSystem
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动配置对象 </summary>
        private readonly DriverConfiguration DriverConfiguration = new DriverConfiguration
        {
            PlatformName = "Android",
            PlatformVersion = "8.1.0",
            AutomationName = "UiAutomator2",
            DeviceName = "Android Device",
            NoReset = true
        };

        /// <summary> 安卓驱动 </summary>
        AndroidDriver<AndroidElement> AndroidDriver;

        /// <summary> 操作模型:: 原生系统 </summary>
        ModelSystem ModelSystem;
        /// <summary> 操作模型:: 计算器 </summary>
        ModelCalculator ModelCalculator;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AndroidDriver = new AndroidDriverCore(DriverConfiguration).StartUniqueDriver();
            ModelSystem = new ModelSystem(AndroidDriver);
            ModelCalculator = new ModelCalculator(AndroidDriver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ModelSystem.System.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            /* -- */
        }

        [TearDown]
        public void TearDown()
        {
            ModelSystem.View.PressKeyHome(false);
        }


        /// <summary>
        /// 通过应用程序列表搜索框搜索 Calculator
        /// </summary>
        [Test(Description = "通过应用程序列表搜索框搜索 Calculator")]
        public void Test01SearchAppsCalculator()
        {
            try
            {
                ModelSystem.UpArrows.Tap();
                ModelSystem.AppsSearchInput.SendKey("Calculator");
                string appName = ModelSystem.AppsAppIconList.GetAttributeText(0);
                bool assert = string.Equals(appName, "Calculator");

                LogServe.Info($"预期字段='Calculator', 结果字段='{appName}'");
                Assert.AreEqual(appName, "Calculator");
            }

            catch (Exception) { Assert.IsTrue(false); }
        }


        /// <summary>
        /// 系统原生计算器计算加法
        /// </summary>
        [Sequential]
        [Test(Description = "系统原生计算器计算加法")]
        public void Test02CalculatorAddition([Values(2, 4, 6)]int a, [Values(3, 5, 7)]int b)
        {
            try
            {
                ModelSystem.UpArrows.Tap();
                ModelSystem.AppsSearchInput.SendKey("Calculator");
                ModelSystem.AppsAppIconList.Tap(0);
                ModelCalculator.VirtualButtonsNumber(a).Tap();
                ModelCalculator.VirtualButtonsOpAdd.Tap();
                ModelCalculator.VirtualButtonsNumber(b).Tap();
                ModelCalculator.VirtualButtonsEq.Tap();
                string result = ModelCalculator.ComputationResult.GetAttributeText();

                LogServe.Info($"预期字段='{a+b}', 结果字段='{result}'");
                Assert.AreEqual(result, (a+b).ToString());
            }

            catch (Exception) { Assert.IsTrue(false); }
        }

    }

}
