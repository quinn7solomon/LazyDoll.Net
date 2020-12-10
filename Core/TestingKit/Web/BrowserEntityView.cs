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
using System.IO;

using OpenQA.Selenium;

using Core.Common.Log;


namespace Core.TestingKit.Web
{

    public class BrowserEntityView
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 浏览器驱动 </summary>
        private readonly IWebDriver BrowserDriver;

        /// <summary> 驱动器句柄数量 </summary>
        private int WindowHandleCount;

        /// <summary> 当前驱动器句柄 </summary>
        private string CurrentWindowHandle;


        /// <summary>
        /// 实例化系统组件实现类
        /// </summary>
        public BrowserEntityView(IWebDriver browserDriver)
        {
            BrowserDriver = browserDriver;
            WindowHandleCount = BrowserDriver.WindowHandles.Count;
            CurrentWindowHandle = BrowserDriver.CurrentWindowHandle;
        }


        /// <summary>
        /// 获取当前页面URL
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return BrowserDriver.Url;
        }


        /// <summary>
        /// 设置当前页面URL
        /// </summary>
        public void SetUrl(string newUrl)
        {
            BrowserDriver.Url = newUrl;
        }


        /// <summary>
        /// 获取当前页面Title
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return BrowserDriver.Title;
        }


        /// <summary>
        /// 访问URL
        /// </summary>
        /// <param name="url"> 目标URL </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void GoToUrl(string url, bool logOutput = true)
        {
            try
            {
                BrowserDriver.Navigate().GoToUrl(url);

                if (logOutput) LogServe.Info($"访问URL => [{url}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 访问URL异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 浏览器打开新标签页
        /// </summary>
        /// <param name="newWindowUrlbool"> 新页面URL </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void OpenWindow(string newWindowUrlbool, bool logOutput = true)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)BrowserDriver;
                string title = (string)js.ExecuteScript($"window.open('{newWindowUrlbool}')");

                WindowHandleRetrieval();

                if (logOutput) LogServe.Info($"浏览器打开新标签页 => [{newWindowUrlbool}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 浏览器打开新标签页异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 浏览器切换标签页
        /// </summary>
        /// <param name="handleCount"> 切换目标窗口的序号 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void GoToWindow(int handleCount, bool logOutput = true)
        {
            try
            {
                BrowserDriver.SwitchTo().Window(BrowserDriver.WindowHandles[handleCount]);
                CurrentWindowHandle = BrowserDriver.CurrentWindowHandle;

                if (logOutput) LogServe.Info($"浏览器切换标签页 => [{handleCount}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 浏览器切换标签页异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 浏览器关闭当前标签页
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Close(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Close();
                WindowHandleRetrieval();

                if (logOutput) LogServe.Info("浏览器关闭当前标签页");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 浏览器关闭当前标签页异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 浏览器后退
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Back(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Navigate().Back();

                if (logOutput) LogServe.Info($"浏览器执行后退操作");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 浏览器执行后退操作异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 浏览器前进
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Forward(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Navigate().Forward();

                if (logOutput) LogServe.Info($"浏览器执行前进操作");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 浏览器执行前进操作异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 浏览器刷新
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void Refresh(bool logOutput = true)
        {
            try
            {
                BrowserDriver.Navigate().Refresh();

                if (logOutput) LogServe.Info($"浏览器执行刷新操作");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 浏览器执行刷新操作异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 窗口句柄实时检索处理
        /// </summary>
        public void WindowHandleRetrieval()
        {
            try
            {
                if (BrowserDriver.WindowHandles.Count != WindowHandleCount)
                {
                    WindowHandleCount = BrowserDriver.WindowHandles.Count;
                    BrowserDriver.SwitchTo().Window(BrowserDriver.WindowHandles[^1]);
                    CurrentWindowHandle = BrowserDriver.CurrentWindowHandle;
                }
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 窗口句柄动态处理异常:: { err.Message }"); throw;
            }
        }

    }

}
