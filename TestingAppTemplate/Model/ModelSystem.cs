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
    /// 原生系统模型
    /// </summary>
    public class ModelSystem
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 模型名称 </summary>
        private readonly string ModelName = "系统模型";

        /// <summary> AndroidPuppeteer 构建类 </summary>
        private readonly AndroidPuppeteer AndroidPuppeteer;


        /// <summary>
        /// 初始化模型
        /// </summary>
        /// <param name="androidDriver"> AndroidDriver对象 </param>
        public ModelSystem(AndroidDriver<AndroidElement> androidDriver)
        {
            AndroidPuppeteer = new AndroidPuppeteer(androidDriver);
        }


        /// <summary> 程序组件 </summary>
        public AndroidEntitySystem System => AndroidPuppeteer.System();


        /// <summary> 屏幕组件 </summary>
        public AndroidEntityView View => AndroidPuppeteer.View();


        /// <summary> 首页向上箭头:: 打开应用程序列表 </summary>
        public AndroidEntityWidget UpArrows => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.google.android.apps.nexuslauncher:id/all_apps_handle",
                PageName = ModelName,
                WidgetName = "首页向上箭头",
            });


        /// <summary> 应用程序列表.搜索框 </summary>
        public AndroidEntityWidget AppsSearchInput => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.google.android.apps.nexuslauncher:id/search_box_input",
                PageName = ModelName,
                WidgetName = "应用程序列表.搜索框",
            });


        /// <summary> 应用程序列表.图标列表 </summary>
        public AndroidEntityWidget AppsAppIconList => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.google.android.apps.nexuslauncher:id/icon",
                PageName = ModelName,
                WidgetName = "应用程序列表.图标列表",
            });

    }

}
