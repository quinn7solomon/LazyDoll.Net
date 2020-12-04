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
using Core.Common.Log;
using OpenQA.Selenium.Appium.Android;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 系统组件实现类
    /// </summary>
    public class AndroidConstructorsSystem
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动 </summary>
        private readonly AndroidDriver<AndroidElement> AndroidDriver;


        /// <summary>
        /// 实例化系统组件实现类
        /// </summary>
        public AndroidConstructorsSystem(AndroidDriver<AndroidElement> androidDriver)
        {

            AndroidDriver = androidDriver;

        }


        /// <summary>
        /// 销毁安卓驱动
        /// </summary>
        public void Quit()
        {
            try
            {
                AndroidDriver.Quit();

                LogServe.Info("安卓驱动已被销毁");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 销毁安卓驱动异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 打开应用程序
        /// </summary>
        /// <param name="appPackage">应用程序包名</param>
        /// <param name="appActivity">应用程序启动名</param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void OpenApp(string appPackage, string appActivity, bool logOutput = true)
        {
            try
            {
                AndroidDriver.StartActivity(appPackage, appActivity);

                if (logOutput) LogServe.Info($"打开应用程序 => [Package:{appPackage} | Activity:{appActivity}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 打开应用程序异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 安装应用程序
        /// </summary>
        /// <param name="apkPath">应用程序安装包路径</param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void AppInstall(string apkPath, bool logOutput = true)
        {
            try
            {
                AndroidDriver.InstallApp(apkPath);

                if (logOutput) LogServe.Info($"安装应用程序，安装包路径为 => [{apkPath}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 安装应用程序异常:: { err.Message }");
                throw;
            }
        }


        /// <summary>
        /// 卸载应用程序
        /// </summary>
        /// <param name="appPackage"> 应用程序包名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void AppUnInstall(string appPackage, bool logOutput = true)
        {
            try
            {
                AndroidDriver.RemoveApp(appPackage);

                if (logOutput) LogServe.Info($"卸载应用程序，包名为 => [{appPackage}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 卸载应用程序异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 启动应用程序
        /// </summary>
        /// <param name="appActivity"> 应用程序启动名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void AppStart(string appActivity, bool logOutput = true)
        {
            try
            {
                AndroidDriver.ActivateApp(appActivity);

                if (logOutput) LogServe.Info($"启动应用程序，启动名为 => [{appActivity}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 启动应用程序异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 终止应用程序
        /// </summary>
        /// <param name="appActivity"> 应用程序启动名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void AppKill(string appActivity, bool logOutput = true)
        {
            try
            {
                AndroidDriver.TerminateApp(appActivity);

                if (logOutput) LogServe.Info($"终止应用程序，启动名为 => [{appActivity}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 终止应用程序异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取当前应用程序包名
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 当前应用程序包名 </returns>
        public string GetCurrentAppPackage(bool logOutput = true)
        {
            try
            {
                string appPackage = AndroidDriver.CurrentPackage;

                if (logOutput) LogServe.Info($"获取当前应用程序包名 => [{appPackage}]");
                return appPackage;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取当前应用程序包名异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取当前应用程序启动名
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 当前应用程序启动名 </returns>
        public string GetCurrentAppActivity(bool logOutput = true)
        {
            try
            {
                string appActivity = AndroidDriver.CurrentActivity;

                if (logOutput) LogServe.Info($"获取当前应用程序启动名 => [{appActivity}]");
                return appActivity;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取当前应用程序启动名异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 终止当前打开的应用程序
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void CurrentAppKill(bool logOutput = true)
        {
            try
            {
                AndroidDriver.CloseApp();

                if (logOutput) LogServe.Info("终止当前打开的应用程序");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 终止当前打开的应用程序异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 重置当前打开的应用程序
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void CurrentAppReset(bool logOutput = true)
        {
            try
            {
                AndroidDriver.ResetApp();

                if (logOutput) LogServe.Info("重置当前打开的应用程序");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 重置当前打开的应用程序异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 判断应用程序是否已经安装
        /// </summary>
        /// <param name="appPackage"> 应用程序包名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 布尔值 </returns>
        public bool IsAppInstalled(string appPackage, bool logOutput = true)
        {
            try
            {   
                bool appInstallType = AndroidDriver.IsAppInstalled(appPackage);

                if (logOutput) LogServe.Info($"应用程序包[{appPackage}]是否已安装 => [{appInstallType}]");
                return appInstallType;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 判断应用程序是否已经安装异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 获取设备系统时间
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 设备系统时间 </returns>
        public string GetDeviceTime(bool logOutput = true)
        {
            try
            {
                string driverTime = AndroidDriver.DeviceTime;

                if (logOutput) LogServe.Info($"获取设备系统时间 => [{driverTime}]");
                return driverTime;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 获取设备系统时间异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 推送文件到设备上
        /// </summary>
        /// <param name="originFilePath"> 源文件路径 </param>
        /// <param name="driverFilePath"> 设备文件路径 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void PushFile(string originFilePath, string driverFilePath, bool logOutput = true)
        {
            try
            {
                AndroidDriver.PushFile(driverFilePath, new FileInfo(originFilePath));

                if (logOutput) LogServe.Info($"推送文件到设备: [{originFilePath}] => [{driverFilePath}]");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 推送文件到设备异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 从设备上检索文件
        /// </summary>
        /// <param name="driverFilePath"> 设备文件路径 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 文件内容字节数组 </returns>
        public byte[] FilePull(string driverFilePath, bool logOutput = true)
        {
            try
            {
                byte[] fileByteList = AndroidDriver.PullFile(driverFilePath);

                if (logOutput) LogServe.Info($"从设备上检索文件 => [{driverFilePath}]");
                return fileByteList;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 从设备上检索文件异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 从设备上检索文件夹
        /// </summary>
        /// <param name="driverFilePath"> 设备文件路径 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 文件夹内容字节数组 </returns>
        public byte[] FolderPull(string driverFilePath, bool logOutput = true)
        {
            try
            {
                byte[] folderByteList = AndroidDriver.PullFolder(driverFilePath);

                if (logOutput) LogServe.Info($"从设备上检索文件 => [{driverFilePath}]");
                return folderByteList;
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 从设备上检索文件夹异常:: { err.Message }"); throw;
            }
        }

    }
}
