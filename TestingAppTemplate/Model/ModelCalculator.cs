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


using Core.Common.Log;
using Core.TestingKit.App;
using Core.TestingKit.App.Android;
using OpenQA.Selenium.Appium.Android;


namespace TestingAppTemplate.Model
{

    /// <summary>
    /// 计算器模型
    /// </summary>
    public class ModelCalculator
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 模型名称 </summary>
        private readonly string ModelName = "计算器模型";

        /// <summary> AndroidPuppeteer 构建类 </summary>
        private readonly AndroidPuppeteer AndroidPuppeteer;


        /// <summary>
        /// 初始化模型
        /// </summary>
        /// <param name="androidDriver"> AndroidDriver对象 </param>
        public ModelCalculator(AndroidDriver<AndroidElement> androidDriver)
        {

            AndroidPuppeteer = new AndroidPuppeteer(androidDriver);

        }


        /// <summary> 程序组件 </summary>
        public AndroidEntitySystem System => AndroidPuppeteer.System();


        /// <summary> 屏幕组件 </summary>
        public AndroidEntityView View => AndroidPuppeteer.View();


        /// <summary>
        /// 虚拟按键:: 0-9
        /// </summary>
        /// <param name="number"> 0-9 的数字 </param>
        public AndroidEntityWidget VirtualButtonsNumber(int number)
        {
            return AndroidPuppeteer.Widget(new ElementStructure
            {
                By = "id",
                El = $"com.android.calculator2:id/digit_{number}",
                PageName = ModelName,
                ElementName = $"虚拟按键.{number}",
            });
        }


        /// <summary> 虚拟按键.加号 </summary>
        public AndroidEntityWidget VirtualButtonsOpAdd => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.android.calculator2:id/op_add",
                PageName = ModelName,
                ElementName = "虚拟按键.加号",
            });


        /// <summary> 虚拟按键.等于号 </summary>
        public AndroidEntityWidget VirtualButtonsEq => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.android.calculator2:id/eq",
                PageName = ModelName,
                ElementName = "虚拟按键.等于号",
            });


        /// <summary> 计算结果 </summary>
        public AndroidEntityWidget ComputationResult => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.android.calculator2:id/result",
                PageName = ModelName,
                ElementName = "计算结果",
            });

    }

}
