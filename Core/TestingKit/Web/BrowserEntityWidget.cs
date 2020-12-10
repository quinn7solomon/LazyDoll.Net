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
using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

using Core.Common;
using Core.Common.Log;
using Core.Common.ErrorCustom;


namespace Core.TestingKit.Web
{

    public class BrowserEntityWidget
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 浏览器驱动 </summary>
        private readonly IWebDriver BrowserDriver;

        /// <summary> 元素结构对象 </summary>
        private readonly ElementStructure ElementStructure;

        /// <summary> 元素列表容器 </summary>
        private List<IWebElement> ElementContainer;

        /// <summary> 常量:: 默认的元素等待时长 </summary>
        private const int TacitlyElementWaitTime = 15;


        /// <summary>
        /// 实例化功能组件实现类
        /// </summary>
        public BrowserEntityWidget(IWebDriver browserDriver, ElementStructure elementStructure)
        {
            BrowserDriver = browserDriver;
            ElementStructure = elementStructure;
        }


        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Tap(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                new Actions(BrowserDriver).Click(ElementContainer[count]).Perform();

                if (logOutput) LogServe.Info($"单击事件 => {ElementStructure.PageName} => {ElementStructure.WidgetName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 单击事件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void DoubleTap(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                new Actions(BrowserDriver).DoubleClick(ElementContainer[count]).Perform();

                if (logOutput) LogServe.Info($"双击事件 => {ElementStructure.PageName} => {ElementStructure.WidgetName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 双击事件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 长按事件
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void LongPress(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                new Actions(BrowserDriver).ClickAndHold(ElementContainer[count]).Perform();

                if (logOutput) LogServe.Info($"长按事件 => {ElementStructure.PageName} => {ElementStructure.WidgetName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 长按事件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 悬停事件:: 将鼠标移动至元素中心
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Hover(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                new Actions(BrowserDriver).MoveToElement(ElementContainer[count]).Perform();

                if (logOutput) LogServe.Info($"将鼠标悬停至 => {ElementStructure.PageName} => {ElementStructure.WidgetName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 悬停事件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 拖拽事件
        /// </summary>
        /// <param name="x"> 移动路径的 X 坐标 </param>
        /// <param name="y"> 移动路径的 Y 坐标 </param>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void MoveTo(int x, int y, int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                new Actions(BrowserDriver).MoveToElement(ElementContainer[count]).Perform();
                new TouchAction(AndroidDriver).MoveTo(ElementContainer[count], x, y).Perform();

                if (logOutput) LogServe.Info($"拖拽事件 => {ElementStructure.PageName} => {ElementStructure.WidgetName} => [x:{x} | y:{y}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 拖拽事件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 元素结构对象解析函数
        /// <para> 解析 ElementStructure 对象如果获取到元素则放入 ElementContainer 容器列表 </para>
        /// </summary>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="tolerance"> 容错机制开关 </param>
        private void AnalyticalElement(int waitTime, bool tolerance = false)
        {
            try
            {
                // 如果 ElementStructure 存在锚元素则先获取锚元素
                if (ElementStructure.AnchorBy != null)
                {
                    IWebElement anchorElement = BaseWebDriverWait(ElementStructure.AnchorBy, ElementStructure.AnchorEl, waitTime)[int.Parse(ElementStructure.AnchorId)];

                    ElementContainer = BaseWebDriverWait(ElementStructure.By, ElementStructure.El, waitTime, anchorElement);
                }
                // 否则 直接获取目标元素
                else
                {
                    ElementContainer = BaseWebDriverWait(ElementStructure.By, ElementStructure.El, waitTime);
                }

                // 如果元素容器列表为空 且 容错机制开关为关闭 则 抛出 ElementResolvesToEmptyException 异常
                if (ElementContainer is { Count: < 1 } && tolerance == false)
                {
                    throw new ElementResolvesToEmptyException();
                }

                // 如果 ElementStructure 中存在元素ID 则 过滤掉其他多余的元素
                if (ElementStructure.Id != null)
                {
                    ElementContainer = new List<IWebElement> { ElementContainer[int.Parse(ElementStructure.Id)] };
                }
            }

            catch (Exception Err)
            {
                LogServe.Error($"Error:: 元素结构对象解析函数异常:: { Err.Message }"); throw;
            }
        }


        /// <summary>
        /// 原生 WebDriverWait 封装函数
        /// </summary>
        /// <param name="by"> 元素定位方式 </param>
        /// <param name="el"> 元素定位对应属性 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <returns> 元素列表 </returns>
        private List<IWebElement> BaseWebDriverWait(string by, string el, int waitTime, IWebElement anchorElement = null)
        {
            try
            {
                // 空的元素列表容器
                List<IWebElement> androidElementList = new List<IWebElement> { };

                // webDriverWait 显式等待似乎不起作用
                // 因而通过改变全隐式等待时长来完成这一目的
                BrowserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);


                // 显示等待委托获取元素
                WebDriverWait webDriverWait = new WebDriverWait(BrowserDriver, TimeSpan.FromSeconds(waitTime));
                IReadOnlyCollection<IWebElement> elementsReadOnly = webDriverWait.Until((d) =>
                {
                    try
                    {
                        if (anchorElement != null)
                        {
                            return FinElements(by, el, anchorElement);
                        }
                        return FinElements(by, el);
                    }
                    catch (Exception) { return null; }
                });

                // 如果元素存在 则 提取并入元素列表容器
                if (elementsReadOnly != null)
                {
                    foreach (IWebElement element in elementsReadOnly)
                    {
                        androidElementList.Add(element);
                    }
                }

                return androidElementList;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 原生 WebDriverWait 封装函数异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 原生 FinElements 封装函数
        /// </summary>
        /// <param name="by"> 元素定位方式 </param>
        /// <param name="el"> 元素定位对应属性 </param>
        /// <returns>IReadOnlyCollection<IWebElement></returns>
        private IReadOnlyCollection<IWebElement> FinElements(string by, string el, IWebElement anchorElement = null)
        {
            By swayBy = null;

            switch (by)
            {
                case "id":
                    swayBy = By.Id(el);
                    break;
                case "name":
                    swayBy = By.Name(el);
                    break;
                case "xpath":
                    swayBy = By.XPath(el);
                    break;
                case "className":
                    swayBy = By.ClassName(el);
                    break;
                case "cssSelector":
                    swayBy = By.CssSelector(el);
                    break;
            }

            if (anchorElement != null)
            {
                return anchorElement.FindElements(swayBy);
            }

            return BrowserDriver.FindElements(swayBy);
        }

    }

}
