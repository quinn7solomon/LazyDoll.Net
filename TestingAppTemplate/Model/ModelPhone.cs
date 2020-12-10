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
    /// 拨打电话模型
    /// </summary>
    class ModelPhone
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 模型名称 </summary>
        private readonly string ModelName = "拨打电话模型";

        /// <summary> 应用程序包名 </summary>
        private readonly string AppPackage = "com.google.android.dialer";

        /// <summary> 应用程序启动名 </summary>
        private readonly string AppActivity = "com.google.android.dialer.extensions.GoogleDialtactsActivity";

        /// <summary> AndroidPuppeteer 构建类 </summary>
        private readonly AndroidPuppeteer AndroidPuppeteer;


        /// <summary>
        /// 初始化模型
        /// </summary>
        /// <param name="androidDriver"> AndroidDriver对象 </param>
        public ModelPhone(AndroidDriver<AndroidElement> androidDriver)
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


        /// <summary> 红色操作键 </summary>
        public AndroidEntityWidget RedStartButton => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.google.android.dialer:id/floating_action_button",
                PageName = ModelName,
                WidgetName = "红色操作键",
            });


        /// <summary> 绿色拨打键 </summary>
        public AndroidEntityWidget GreenCallButton => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.google.android.dialer:id/dialpad_floating_action_button",
                PageName = ModelName,
                WidgetName = "绿色拨打键",
            });


        /// <summary>
        /// 数字键:: 0-9
        /// </summary>
        /// <param name="number"> 0-9 的数字 </param>
        public AndroidEntityWidget NumericKeys(int number)
        {
            return AndroidPuppeteer.Widget(new ElementStructure
            {
                By = "xpath",
                El = $"//*[@text='{number}']",
                PageName = ModelName,
                WidgetName = $"数字键.{number}",
            });
        }


        /// <summary> 通话中:: 挂断键 </summary>
        public AndroidEntityWidget HangPhoneButton => AndroidPuppeteer.Widget(
            new ElementStructure
            {
                By = "id",
                El = "com.google.android.dialer:id/incall_end_call",
                PageName = ModelName,
                WidgetName = "通话中.挂断键",
            });

    }

}
