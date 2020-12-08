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
    /// 谷歌浏览器模型
    /// </summary>
    class ModelChrome
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 模型名称 </summary>
        private readonly string ModelName = "谷歌浏览器模型";

        /// <summary> 应用程序包名 </summary>
        private readonly string AppPackage = "com.android.chrome";

        /// <summary> 应用程序启动名 </summary>
        private readonly string AppActivity = "com.google.android.apps.chrome.Main";

        /// <summary> AndroidPuppeteer 构建类 </summary>
        private readonly AndroidPuppeteer AndroidPuppeteer;


        /// <summary>
        /// 初始化模型
        /// </summary>
        /// <param name="androidDriver"> AndroidDriver对象 </param>
        public ModelChrome(AndroidDriver<AndroidElement> androidDriver)
        {
            AndroidPuppeteer = new AndroidPuppeteer(androidDriver);
        }


        /// <summary> 程序组件 </summary>
        public AndroidEntitySystem System => AndroidPuppeteer.System();


        /// <summary> 屏幕组件 </summary>
        public AndroidEntityView View => AndroidPuppeteer.View();


        /// <summary>
        /// 启动应用程序
        /// </summary>
        public void Open()
        {
            System.AppOpen(AppPackage, AppActivity);
        }


        /// <summary>
        /// 结束应用程序
        /// </summary>
        public void Kill()
        {
            System.AppKill(AppActivity);
        }


        /// <summary> 谷歌政策.同意按钮:: 首次启动须选择 </summary>
        public AndroidEntityWidget GooglePolicyConsentOk => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.android.chrome:id/terms_accept",
                PageName = ModelName,
                WidgetName = "谷歌政策.同意按钮",
            });


        /// <summary> 是否登录.NO THANKS:: 首次启动须选择 </summary>
        public AndroidEntityWidget GoogleNoThanks => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.android.chrome:id/negative_button",
                PageName = ModelName,
                WidgetName = "是否登录.NO THANKS",
            });


        /// <summary> 首页搜索输入框 </summary>
        public AndroidEntityWidget HomeSearchInputBox => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.android.chrome:id/search_box_text",
                PageName = ModelName,
                WidgetName = "首页搜索输入框",
            });


        /// <summary> 弹出警告窗.允许按钮 </summary>
        public AndroidEntityWidget WarningWindowAllow => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "android:id/button1",
                PageName = ModelName,
                WidgetName = "弹出警告窗.允许按钮",
            });

    }

}
