/* 
     ___            __     ________   ___  ___  ________      ______    ___      ___               _____  ___    _______  ___________  
    |"  |          /""\   ("      "\ |"  \/"  ||"      "\    /    " \  |"  |    |"  |             (\"   \|"  \  /"     "|("     _   ") 
    ||  |         /    \   \___/   :) \   \  / (.  ___  :)  // ____  \ ||  |    ||  |             |.\\   \    |(: ______) )__/  \\__/  
    |:  |        /' /\  \    /  ___/   \\  \/  |: \   ) || /  /    ) :)|:  |    |:  |             |: \.   \\  | \/    |      \\_ /     
     \  |___    //  __'  \  //  \__    /   /   (| (___\ ||(: (____/ //  \  |___  \  |___    _____ |.  \    \. | // ___)_     |.  |     
    ( \_|:  \  /   /  \\  \(:   / "\  /   /    |:       :) \        /  ( \_|:  \( \_|:  \  ))_  ")|    \    \ |(:      "|    \:  |     
     \_______)(___/    \___)\_______)|___/     (________/   \"_____/    \_______)\_______)(_____(  \___|\____\) \_______)     \__|     
                                                                                                                                   

    Copyright (c) 2020, @ quinn.7@foxmail.com, All rights reserved

    GitPath      : https://github.com/quinn7solomon/LazyDoll.Net
    FrameName    : LazyDoll.Net
    CreatorName  : Quinn7k
    CreationTime : 2020.11.19

    Module Responsibility Description : NA

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

        public string By;
        public string El;
        public string Id;
        public string PageName;
        public string ElementName;
        public string AnchorBy;
        public string AnchorEl;
        public string AnchorId;
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