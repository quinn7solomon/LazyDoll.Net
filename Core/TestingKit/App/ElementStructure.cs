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


using System.Collections.Generic;
using Core.Common.Overall;


namespace Core.TestingKit.App
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

        /// <summary> 元素组件名称 </summary>
        public string ElementName { get; set; }

        /// <summary> 锚元素定位方式 </summary>
        public string AnchorBy { get; set; }

        /// <summary> 锚元素定位对应属性 </summary>
        public string AnchorEl { get; set; }

        /// <summary> 锚元素列表下标 </summary>
        public string AnchorId { get; set; }

        /// <summary> 源字典 </summary>
        private readonly Dictionary<string, string> SourceDictionary;


        /// <summary>
        /// 初始化并解析元素结构字典
        /// </summary>
        /// <param name="sourceDictionary"></param>
        public ElementStructure(Dictionary<string, string> sourceDictionary)
        {
            SourceDictionary = sourceDictionary;

            By = sourceDictionary[GlobalConst.ELEMENT_BY];
            El = sourceDictionary[GlobalConst.ELEMENT_EL];
            PageName = sourceDictionary[GlobalConst.ELEMENT_PAGE_NAME];
            ElementName = sourceDictionary[GlobalConst.ELEMENT_ELEMENT_NAME];

            if (sourceDictionary.ContainsKey(GlobalConst.ELEMENT_ID))
            {
                Id = sourceDictionary[GlobalConst.ELEMENT_ID];
            }

            if (sourceDictionary.ContainsKey(GlobalConst.ANCHOR_ELEMENT_BY))
            {
                AnchorBy = sourceDictionary[GlobalConst.ANCHOR_ELEMENT_BY];
                AnchorEl = sourceDictionary[GlobalConst.ANCHOR_ELEMENT_EL];
                AnchorId = sourceDictionary[GlobalConst.ANCHOR_ELEMENT_ID];
            }
        }


        /// <summary>
        /// 获取源字典
        /// </summary>
        public Dictionary<string, string> GetSourceDictionary => SourceDictionary;

    }

}