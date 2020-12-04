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


namespace Core.Common.ErrorDefined
{

    public class LogServeOutputException : ApplicationException
    {

        /// <summary> 日志服务输出异常 </summary>
        public LogServeOutputException(string message) : base(message) { }

    }


    public class AndroidDriverException : ApplicationException
    {

        /// <summary> 安卓设备驱动异常 </summary>
        public AndroidDriverException(string message) : base(message) { }

    }


    public class ElementResolvesToEmptyException : ApplicationException
    {

        /// <summary> 元素解析为空异常 </summary>
        public ElementResolvesToEmptyException(string message) : base(message) { }

    }


    public class AndroidcConstructorsSystemException : ApplicationException
    {

        /// <summary> 安卓系统组件构建异常 </summary>
        public AndroidcConstructorsSystemException() : base("安卓系统组件构建异常") { }

    }


    public class AndroidcConstructorsViewException : ApplicationException
    {

        /// <summary> 安卓屏幕组件构建异常 </summary>
        public AndroidcConstructorsViewException() : base("安卓屏幕组件构建异常") { }

    }


    public class AndroidcConstructorsModuleException : ApplicationException
    {

        /// <summary> 安卓功能组件构建异常 </summary>
        public AndroidcConstructorsModuleException() : base("安卓功能组件构建异常") { }

    }

}
