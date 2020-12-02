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


using System;
using System.Collections.Generic;
using Core.Common.Log;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 元素组件实现类
    /// </summary>
    public class AndroidConstructorsModule
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动 </summary>
        private readonly AndroidDriver<AndroidElement> AndroidDriver;

        /// <summary> 元素结构对象 </summary>
        private readonly ElementStructure ElementStructure;

        /// <summary> 元素列表容器 </summary>
        private List<AndroidElement> ElementContainer;


        /// <summary>
        /// 实例化屏幕组件实现类
        /// </summary>
        #region
        public AndroidConstructorsModule(AndroidDriverCore androidDriverCore, ElementStructure elementStructure)
        {

            AndroidDriver = androidDriverCore.StartUniqueDriver();
            ElementStructure = elementStructure;

        }
        #endregion


        /// <summary>
        /// 获取对象元素指定属性的值
        /// </summary>
        /// <param name="attName"> 指定属性名称 </param>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> string </returns>
        #region
        public string GetAttribute(string attName, int count = 0, int waitTime = 15, bool logOutput = true)
        {

            try
            {
                string elementAttribute = null;

                AnalyticalElement(waitTime);
                if (ElementContainer is { Count: > 0 })
                {
                    elementAttribute = ElementContainer[count].GetAttribute(attName);
                }

                if (logOutput) LogServe.Info($"获取属性 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {attName} => {elementAttribute}");
                return elementAttribute;
            }

            catch (Exception Err)
            {
                LogServe.Error($"获取对象元素的 Text 属性异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 获取对象元素的 Text 属性
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> string </returns>
        #region
        public string Text(int count = 0, int waitTime = 15, bool logOutput = true)
        {

            try
            {
                string elementText = null;

                AnalyticalElement(waitTime);
                if (ElementContainer is { Count: > 0 })
                {
                    elementText = ElementContainer[count].Text;
                }

                if (logOutput) LogServe.Info($"获取文本 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementText}");
                return elementText;
            }

            catch (Exception Err)
            {
                LogServe.Error($"获取对象元素的 Text 属性异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 获取对象元素的 Text 属性并提取其中的数字
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> string </returns>
        #region
        public string TextExtractedFloat(int count = 0, int waitTime = 15, bool logOutput = true)
        {

            try
            {
                string elementText = Text(count, waitTime, false);
                string elementFloat = null;

                if (elementText != null)
                {
                    elementFloat = System.Text.RegularExpressions.Regex.Replace(Text(count, waitTime, false), @"[^0-9]+", "");
                }

                if (logOutput) LogServe.Info($"提取数字 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementFloat}");
                return elementFloat;
            }

            catch (Exception Err)
            {
                LogServe.Error($"获取对象元素的 Text 属性并提取其中的数字异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 判断对象元素是否存在于当前可视页面
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 对象元素的 Text 属性 </returns>
        #region
        public bool IsInPage(int count = 0, int waitTime = 5, bool logOutput = true)
        {

            try
            {
                bool elementExist = true;

                AnalyticalElement(waitTime);
                if (ElementContainer.Count <= count)
                {
                    elementExist = false;
                }

                if (logOutput) LogServe.Info($"判断存在 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementExist}");
                return elementExist;
            }

            catch (Exception Err)
            {
                LogServe.Error($"判断对象元素是否存在于当前可视页面异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 解析函数
        /// <para> 解析 ElementStructure 对象如果获取到元素则放入 ElementContainer 容器列表 </para>
        /// </summary>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="tolerance"> 容错机制开关 </param>
        #region
        private void AnalyticalElement(int waitTime)
        {

            try
            {

                if (ElementStructure.AnchorBy != null)
                {
                    AndroidElement anchorElement = BaseWebDriverWait(ElementStructure.AnchorBy, ElementStructure.AnchorEl, waitTime)[int.Parse(ElementStructure.AnchorId)];

                    ElementContainer = BaseWebDriverWait(anchorElement, ElementStructure.By, ElementStructure.El, waitTime);
                }

                else
                {
                    ElementContainer = BaseWebDriverWait(ElementStructure.By, ElementStructure.El, waitTime);
                }

                if (ElementStructure.Id != null)
                {
                    ElementContainer = new List<AndroidElement> { ElementContainer[int.Parse(ElementStructure.Id)] };
                }

            }

            catch (Exception Err)
            {
                LogServe.Error($"AndroidConstructorsModule 解析函数异常 : { Err.Message }"); throw;
            }

        }
        #endregion



        /// <summary>
        /// 原生 WebDriverWait 封装
        /// </summary>
        /// <param name="by"> 元素定位方式 </param>
        /// <param name="el"> 元素定位对应属性 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        #region
        private List<AndroidElement> BaseWebDriverWait(string by, string el, int waitTime)
        {

            try
            {
                List<AndroidElement> androidElementList = new List<AndroidElement> { };

                WebDriverWait webDriverWait = new WebDriverWait(AndroidDriver, TimeSpan.FromSeconds(waitTime));
                IReadOnlyCollection<AndroidElement> elementsReadOnly = webDriverWait.Until((d) =>
                {
                    try
                    {
                        return AndroidDriver.FindElements(by, el);

                    } catch (Exception) { return null; }
                });

                if (elementsReadOnly != null)
                {
                    foreach (AndroidElement element in elementsReadOnly)
                    {
                        androidElementList.Add(element);
                    }
                }

                return androidElementList;
            }

            catch (Exception Err)
            {
                LogServe.Error($"AndroidConstructorsModule 解析函数异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 原生 WebDriverWait 封装
        /// <para> 重载:: 通过锚元素定位 </para>
        /// </summary>
        /// <param name="by"> 元素定位方式 </param>
        /// <param name="el"> 元素定位对应属性 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        #region
        private List<AndroidElement> BaseWebDriverWait(AndroidElement anchorElement, string by, string el, int waitTime)
        {

            try
            {
                List<AndroidElement> androidElementList = new List<AndroidElement> { };

                WebDriverWait webDriverWait = new WebDriverWait(AndroidDriver, TimeSpan.FromSeconds(waitTime));
                IReadOnlyCollection<AndroidElement> elementsReadOnly = (IReadOnlyCollection<AndroidElement>)webDriverWait.Until((d) =>
                {
                    try
                    {
                        return anchorElement.FindElements(by, el);

                    } catch (Exception) { return null; }
                });

                if (elementsReadOnly != null)
                {
                    foreach (AndroidElement element in elementsReadOnly)
                    {
                        androidElementList.Add(element);
                    }
                }

                return androidElementList;
            }

            catch (Exception Err)
            {
                LogServe.Error($"AndroidConstructorsModule 解析函数异常 : { Err.Message }"); throw;
            }

        }
        #endregion

    }
}
