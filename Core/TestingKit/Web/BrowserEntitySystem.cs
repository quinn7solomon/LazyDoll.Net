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
using System.Drawing;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Core.Common.Log;


namespace Core.TestingKit.Web
{

    /// <summary>
    /// 系统组件实现类
    /// </summary>
    public class BrowserEntitySystem
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 浏览器驱动 </summary>
        private readonly IWebDriver BrowserDriver;

        /// <summary> 浏览器尺寸 </summary>
        public Size WindowSize;

        /// <summary> 浏览器坐标 </summary>
        public Point WindowPosition;


        /// <summary>
        /// 实例化系统组件实现类
        /// </summary>
        public BrowserEntitySystem(IWebDriver browserDriver)
        {
            BrowserDriver = browserDriver;
            WindowSize = BrowserDriver.Manage().Window.Size;
            WindowPosition = BrowserDriver.Manage().Window.Position;
        }


        /// <summary>
        /// 设置浏览器尺寸
        /// </summary>
        /// <param name="width"> 浏览器宽度 </param>
        /// <param name="height"> 浏览器高度 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void SetWindowSize(int width, int height, bool logOutput = true)
        {
            try
            {
                BrowserDriver.Manage().Window.Size = new Size(width, height);
                WindowSize = BrowserDriver.Manage().Window.Size;

                if (logOutput) LogServe.Info($"设置浏览器尺寸 => [宽度::{width} | 高度::{height}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 设置浏览器尺寸异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 设置浏览器坐标
        /// </summary>
        /// <param name="x"> X坐标 </param>
        /// <param name="y"> Y坐标 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void SetWindowPosition(int x, int y, bool logOutput = true)
        {
            try
            {
                BrowserDriver.Manage().Window.Position = new Point(x, y);
                WindowPosition = BrowserDriver.Manage().Window.Position;

                if (logOutput) LogServe.Info($"设置浏览器坐标 => [X坐标::{x} | Y坐标::{y}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 设置浏览器坐标异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 窗口最大化
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void WindowMaximize(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Manage().Window.Maximize();
                WindowSize = BrowserDriver.Manage().Window.Size;
                WindowPosition = BrowserDriver.Manage().Window.Position;

                if (logOutput) LogServe.Info("窗口最大化");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 窗口最大化异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 窗口最小化
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void WindowMinimize(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Manage().Window.Minimize();
                WindowSize = BrowserDriver.Manage().Window.Size;
                WindowPosition = BrowserDriver.Manage().Window.Position;

                if (logOutput) LogServe.Info("窗口最小化");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 窗口最小化异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 窗口全屏化
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void WindowFullScreen(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Manage().Window.FullScreen();
                WindowSize = BrowserDriver.Manage().Window.Size;
                WindowPosition = BrowserDriver.Manage().Window.Position;

                if (logOutput) LogServe.Info("窗口全屏化");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 窗口全屏化异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 销毁浏览器驱动
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Quit(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Quit();

                if (logOutput) LogServe.Info("浏览器驱动完成销毁");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 销毁浏览器驱动异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 截图当前窗口
        /// <para>注释1:: 截图文件为PNG图片格式， fileName需要带后缀</para>
        /// </summary>
        /// <param name="fileName"> 截图文件名称 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void WindowScreenshot(string fileName, bool logOutput = true)
        {
            try
            {
                Screenshot screenshot = (BrowserDriver as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);

                if (logOutput) LogServe.Info($"截图当前窗口 => [{fileName}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 截图当前窗口异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取处理 JavaScript 警告框、提示框和确认框的 Alert对象
        /// </summary>
        /// <returns> Alert对象 </returns>
        public IAlert GetWindowAlert()
        {
            WebDriverWait webDriverWait = new WebDriverWait(BrowserDriver, TimeSpan.FromSeconds(15));
            return webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

    }

}
