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
using System.Drawing;
using Core.Common.ErrorDefined;
using Core.Common.Log;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
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

        /// <summary> 触屏操作对象 </summary>
        private readonly TouchAction TouchAction;

        /// <summary> 元素结构对象 </summary>
        private readonly ElementStructure ElementStructure;

        /// <summary> 元素列表容器 </summary>
        private List<AndroidElement> ElementContainer;

        /// <summary> 常量:: 默认的元素等待时长 </summary>
        private const int TacitlyElementWaitTime = 15;


        /// <summary>
        /// 实例化屏幕组件实现类
        /// </summary>
        public AndroidConstructorsModule(AndroidDriverCore androidDriverCore, ElementStructure elementStructure)
        {

            AndroidDriver = androidDriverCore.StartUniqueDriver();
            TouchAction = new TouchAction(AndroidDriver);
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
                TouchAction.Tap(ElementContainer[count]).Perform();

                if (logOutput) LogServe.Info($"单击事件 => {ElementStructure.PageName} => {ElementStructure.ElementName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 单击事件异常:: { err.Message }"); throw;
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
                TouchAction.LongPress(ElementContainer[count]).Perform();

                if (logOutput) LogServe.Info($"长按事件 => {ElementStructure.PageName} => {ElementStructure.ElementName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 长按事件异常:: { err.Message }"); throw;
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
                TouchAction.MoveTo(ElementContainer[count], x, y).Perform();

                if (logOutput) LogServe.Info($"拖拽事件 => {ElementStructure.PageName} => {ElementStructure.ElementName} => [x:{x} | y:{y}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 拖拽事件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 输入内容
        /// </summary>
        /// <param name="keys"> 输入内容 </param>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void SendKey(string keys, int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                ElementContainer[count].SendKeys(keys);

                if (logOutput) LogServe.Info($"输入内容 => {ElementStructure.PageName} => {ElementStructure.ElementName} => [{keys}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 输入内容异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 清除内容
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Clear(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                AnalyticalElement(waitTime);
                ElementContainer[count].Clear();

                if (logOutput) LogServe.Info($"清除内容 => {ElementStructure.PageName} => {ElementStructure.ElementName}");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 清除内容异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 返回元素的 content-desc 属性值，若不存在则返回其 text 属性值
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> content-desc 属性值 | text 属性值 </returns>
        public string GetAttributeText(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return BaseGetAttribute("name", count, waitTime, logOutput);
        }


        /// <summary>
        /// 返回元素的 class 属性值
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> class 属性值 </returns>
        public string GetAttributeClass(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return BaseGetAttribute("className", count, waitTime, logOutput);
        }


        /// <summary>
        /// 返回元素的 id 属性
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> id 属性值 </returns>
        public string GetAttributeId(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return BaseGetAttribute("resourceId", count, waitTime, logOutput);
        }


        /// <summary>
        /// 返回元素的 clickable 属性，表示 button 是否可被点击
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool GetAttributeClickable(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return bool.Parse(BaseGetAttribute("clickable", count, waitTime, logOutput));
        }


        /// <summary>
        /// 返回元素的 longClickable 属性，表示 button 是否可被长按
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool GetAttributeLongClickable(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return bool.Parse(BaseGetAttribute("longClickable", count, waitTime, logOutput));
        }


        /// <summary>
        /// 返回元素的 enabled 属性，表示 button 是否处于可响应
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool GetAttributeEnabled(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return bool.Parse(BaseGetAttribute("enabled", count, waitTime, logOutput));
        }


        /// <summary>
        /// 返回元素的 checkable 属性，表示触发器(trigger)的状态为 "按下" 或 "弹起"
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool GetAttributeCheckable(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return bool.Parse(BaseGetAttribute("checkable", count, waitTime, logOutput));
        }


        /// <summary>
        /// 返回元素的 checked 属性，表示复选框 iteam 是否被选中
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool GetAttributeChecked(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return bool.Parse(BaseGetAttribute("checked", count, waitTime, logOutput));
        }


        /// <summary>
        /// 返回元素的 selected 属性，表示元素是否被选中
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool GetAttributeSelected(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            return bool.Parse(BaseGetAttribute("selected", count, waitTime, logOutput));
        }


        /// <summary>
        /// 获取元素的 content-desc 或 text 属性并提取其中的数字
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 元素文本的数字值 </returns>
        public string GetAttributeFloat(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                string elementText = GetAttributeText(count, waitTime, false);
                string elementFloat = System.Text.RegularExpressions.Regex.Replace(elementText, @"[^0-9]+", "");

                if (logOutput) LogServe.Info($"提取数字 => {ElementStructure.PageName} => {ElementStructure.ElementName} => [{elementFloat}]");
                return elementFloat;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取对象元素的 Text 属性并提取其中的数字异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 判断对象元素是否存在于当前可视页面
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool IsInPage(int count = 0, int waitTime = 5, bool logOutput = true)
        {
            try
            {
                bool elementExist = true;

                AnalyticalElement(waitTime, true);
                if (ElementContainer.Count <= count)
                {
                    elementExist = false;
                }

                if (logOutput) LogServe.Info($"判断存在 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementExist}");
                return elementExist;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 判断对象元素是否存在于当前可视页面异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取对象元素数量
        /// </summary>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 捕获的元素数量 </returns>
        public int Count(int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                int elementCount;

                AnalyticalElement(waitTime);
                elementCount = ElementContainer.Count;

                if (logOutput) LogServe.Info($"获取元素数量 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementCount}");
                return elementCount;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取对象元素数量异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取对象元素的位于屏幕的坐标
        /// </summary>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 表示屏幕坐标的 Point 对象 </returns>
        public Point Location(int count = 0, int waitTime = TacitlyElementWaitTime, bool logOutput = true)
        {
            try
            {
                Point elementLocation = new Point(0, 0);

                AnalyticalElement(waitTime);
                elementLocation = ElementContainer[count].Location;

                if (logOutput) LogServe.Info($"获取坐标 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementLocation}");
                return elementLocation;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取对象元素的位于屏幕的坐标异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取对象元素的大小
        /// </summary>
        /// <param name="attributeName"> 指定属性名称 </param>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 表示元素大小的 Size 对象 </returns>
        public Size Size(int count = 0, int waitTime = 15, bool logOutput = true)
        {
            try
            {
                Size elementSize = new Size();

                AnalyticalElement(waitTime);
                elementSize = ElementContainer[count].Size;

                if (logOutput) LogServe.Info($"获取大小 => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementSize}");
                return elementSize;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取对象元素的大小异常:: { err.Message }"); throw;
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
                    AndroidElement anchorElement = BaseWebDriverWait(ElementStructure.AnchorBy, ElementStructure.AnchorEl, waitTime)[int.Parse(ElementStructure.AnchorId)];

                    ElementContainer = BaseWebDriverWait(anchorElement, ElementStructure.By, ElementStructure.El, waitTime);
                }
                // 否则 直接获取目标元素
                else
                {
                    ElementContainer = BaseWebDriverWait(ElementStructure.By, ElementStructure.El, waitTime);
                }

                // 如果元素容器列表为空 且 容错机制开关为关闭 则 抛出 ElementResolvesToEmptyException 异常
                if (ElementContainer is { Count: < 1 } && tolerance == false)
                {
                    throw new ElementResolvesToEmptyException("元素解析结果为空");
                }

                // 如果 ElementStructure 中存在元素ID 则 过滤掉其他多余的元素
                if (ElementStructure.Id != null)
                {
                    ElementContainer = new List<AndroidElement> { ElementContainer[int.Parse(ElementStructure.Id)] };
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
        private List<AndroidElement> BaseWebDriverWait(string by, string el, int waitTime)
        {
            try
            {
                // 空的元素列表容器
                List<AndroidElement> androidElementList = new List<AndroidElement> { };

                // 显示等待委托获取元素
                WebDriverWait webDriverWait = new WebDriverWait(AndroidDriver, TimeSpan.FromSeconds(waitTime));
                IReadOnlyCollection<AndroidElement> elementsReadOnly = webDriverWait.Until((d) =>
                {
                    try
                    {
                        return AndroidDriver.FindElements(by, el);

                    } catch (Exception) { return null; }
                });

                // 如果元素存在 则 元素列表容器
                if (elementsReadOnly != null)
                {
                    foreach (AndroidElement element in elementsReadOnly)
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
        /// 原生 WebDriverWait 封装函数
        /// <para> 重载方法:: 通过锚元素定位 </para>
        /// </summary>
        /// <param name="by"> 元素定位方式 </param>
        /// <param name="el"> 元素定位对应属性 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <returns> 元素列表 </returns>
        private List<AndroidElement> BaseWebDriverWait(AndroidElement anchorElement, string by, string el, int waitTime)
        {
            try
            {
                // 空的元素列表容器
                List<AndroidElement> androidElementList = new List<AndroidElement> { };

                // 从锚元素中通过显示等待委托获取元素
                WebDriverWait webDriverWait = new WebDriverWait(AndroidDriver, TimeSpan.FromSeconds(waitTime));
                IReadOnlyCollection<AndroidElement> elementsReadOnly = (IReadOnlyCollection<AndroidElement>)webDriverWait.Until((d) =>
                {
                    try
                    {
                        return anchorElement.FindElements(by, el);

                    } catch (Exception) { return null; }
                });

                // 如果元素存在 则 元素列表容器
                if (elementsReadOnly != null)
                {
                    foreach (AndroidElement element in elementsReadOnly)
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
        /// 获取对象元素属性封装函数
        /// </summary>
        /// <param name="attributeName"> 指定属性名称 </param>
        /// <param name="count"> 指定元素下标 </param>
        /// <param name="waitTime"> 元素等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 对应属性的值 </returns>
        private string BaseGetAttribute(string attributeName, int count, int waitTime, bool logOutput)
        {
            try
            {
                string elementAttribute = null;

                AnalyticalElement(waitTime);
                elementAttribute = ElementContainer[count].GetAttribute(attributeName);

                if (logOutput) LogServe.Info($"获取属性[{attributeName}] => {ElementStructure.PageName} => {ElementStructure.ElementName} => {elementAttribute}");
                return elementAttribute;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取对象元素属性封装函数异常:: { err.Message }"); throw;
            }
        }

    }
}
