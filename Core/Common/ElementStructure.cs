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


namespace Core.Common
{

    /// <summary>
    /// 元素结构对象
    /// </summary>
    public class ElementStructure
    {

        /// <summary> 元素定位方式 </summary>
        public string By { get; set; }

        /// <summary> 元素定位对应属性 </summary>
        public string El { get; set; }

        /// <summary> 元素列表下标 </summary>
        public string Id { get; set; }

        /// <summary> 模型页面名称 </summary>
        public string PageName { get; set; }

        /// <summary> 组件名称 </summary>
        public string WidgetName { get; set; }

        /// <summary> 锚元素定位方式 </summary>
        public string AnchorBy { get; set; }

        /// <summary> 锚元素定位对应属性 </summary>
        public string AnchorEl { get; set; }

        /// <summary> 锚元素列表下标 </summary>
        public string AnchorId { get; set; }

    }

}