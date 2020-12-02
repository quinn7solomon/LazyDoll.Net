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
using System.IO;
using Core.Common.Log;
using OpenQA.Selenium.Appium.Android;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 程序组件实现类
    /// </summary>
    public class AndroidConstructorsApp
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动 </summary>
        private readonly AndroidDriver<AndroidElement> AndroidDriver;

        /// <summary> 默认等待时长 </summary>
        private readonly int DefaultWaitTime = 10;


        /// <summary>
        /// 实例化程序组件实现类
        /// </summary>
        #region
        public AndroidConstructorsApp(AndroidDriverCore androidDriverCore)
        {

            AndroidDriver = androidDriverCore.StartUniqueDriver();

        }
        #endregion


        /// <summary>
        /// 安卓驱动安全登出
        /// </summary>
        #region
        public void Quit()
        {

            try
            {
                AndroidDriver.Quit();

                LogServe.Info("安卓驱动已被销毁");
            }

            catch (Exception Err)
            {
                LogServe.Error($"安卓驱动销毁异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 设置安卓驱动全局等待时长
        /// </summary>
        /// <param name="waitTime"> 等待时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void SetDriverWaitTime(int waitTime, bool logOutput = true)
        {

            try
            {
                AndroidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);

                if (logOutput) LogServe.Info($"安卓驱动全局等待时长设置为 => {waitTime}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"安卓驱动全局等待时长设置异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 设置安卓驱动全局等待时长 => 默认的等待时长(20s)
        /// </summary>
        #region
        public void SetDriverWaitTime()
        {

            SetDriverWaitTime(DefaultWaitTime);

        }
        #endregion


        /// <summary>
        /// 打开已安装的应用程序
        /// </summary>
        /// <param name="appPackage">应用程序包名</param>
        /// <param name="appActivity">应用程序启动名</param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void OpenApp(string appPackage, string appActivity, bool logOutput = true)
        {

            try
            {
                AndroidDriver.StartActivity(appPackage, appActivity);

                if (logOutput) LogServe.Info($"打开已安装的应用程序 => {appPackage}|{appActivity}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"打开已安装的应用程序异常：{ Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 通过安装包路径安装应用程序
        /// </summary>
        /// <param name="appPath">应用程序安装包路径</param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void AppInstall(string appPath, bool logOutput = true)
        {

            try
            {
                AndroidDriver.InstallApp(appPath);

                if (logOutput) LogServe.Info($"安装应用程序，安装包路径为 => {appPath}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"通过安装包路径安装应用程序异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 通过包名卸载已安装的应用程序
        /// </summary>
        /// <param name="appPackage"> 应用程序包名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void AppUnInstall(string appPackage, bool logOutput = true)
        {

            try
            {
                AndroidDriver.RemoveApp(appPackage);

                if (logOutput) LogServe.Info($"卸载应用程序，包名为 => {appPackage}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"通过包名卸载已安装的应用程序异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 通过启动名启动已安装的应用程序进程
        /// </summary>
        /// <param name="appActivity"> 应用程序启动名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void AppStart(string appActivity, bool logOutput = true)
        {

            try
            {
                AndroidDriver.ActivateApp(appActivity);

                if (logOutput) LogServe.Info($"启动应用程序进程，启动名为 => {appActivity}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"通过启动名启动已安装的应用程序进程异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 通过启动名终止已安装的应用程序进程
        /// </summary>
        /// <param name="appActivity"> 应用程序启动名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void Appkill(string appActivity, bool logOutput = true)
        {

            try
            {
                AndroidDriver.TerminateApp(appActivity);

                if (logOutput) LogServe.Info($"终止应用程序进程，启动名为 => {appActivity}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"通过启动名终止已安装的应用程序进程异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 获取当前应用程序包名
        /// </summary>
        /// <returns> APP包名 </returns>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public string GetCurrentAppPackage(bool logOutput = true)
        {

            try
            {
                string appPackage = AndroidDriver.CurrentPackage;
                if (logOutput) LogServe.Info($"获取当前应用程序包名 => {appPackage}");
                return appPackage;
            }

            catch (Exception Err)
            {
                LogServe.Error($"获取当前应用程序包名异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 获取当前应用程序启动名
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> APP启动名 </returns>
        #region
        public string GetCurrentAppActivity(bool logOutput = true)
        {

            try
            {
                string appActivity = AndroidDriver.CurrentActivity;
                if (logOutput) LogServe.Info($"获取当前应用程序启动名 => {appActivity}");
                return appActivity;
            }

            catch (Exception Err)
            {
                LogServe.Error($"获取当前应用程序启动名异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 终止设备当前打开的应用程序
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void CurrentAppKill(bool logOutput = true)
        {

            try
            {
                AndroidDriver.CloseApp();

                if (logOutput) LogServe.Info("终止设备当前打开的应用程序");
            }

            catch (Exception Err)
            {
                LogServe.Error($"终止设备当前打开的应用程序异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 重置设备当前打开的应用程序
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void CurrentAppReset(bool logOutput = true)
        {

            try
            {
                AndroidDriver.ResetApp();

                if (logOutput) LogServe.Info("重置设备当前打开的应用程序");
            }

            catch (Exception Err)
            {
                LogServe.Error($"重置设备当前打开的应用程序异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 通过包名判断应用程序是否已经安装
        /// </summary>
        /// <param name="appPackage"> 应用程序包名 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> bool </returns>
        #region
        public bool IsAppInstalled(string appPackage, bool logOutput = true)
        {

            try
            {   
                bool appInstallType = AndroidDriver.IsAppInstalled(appPackage);
                if (logOutput) LogServe.Info($"判断包名{appPackage}是否已安装 => {appInstallType}");
                return appInstallType;
            }

            catch (Exception Err)
            {
                LogServe.Error($"通过包名判断应用程序是否已经安装异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 获取设备系统时间
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> 设备系统时间 </returns>
        #region
        public string GetDriverTime(bool logOutput = true)
        {

            try
            {
                string driverTime = AndroidDriver.DeviceTime;
                if (logOutput) LogServe.Info($"获取设备系统时间 => {driverTime}");
                return driverTime;
            }

            catch (Exception Err)
            {
                LogServe.Error($"获取设备系统时间异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 推送文件到设备上
        /// </summary>
        /// <param name="originPath"> 源文件路径 </param>
        /// <param name="driverFilePath"> 设备文件路径 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PushFile(string originFilePath, string driverFilePath, bool logOutput = true)
        {

            try
            {
                AndroidDriver.PushFile(driverFilePath, new FileInfo(originFilePath));

                if (logOutput) LogServe.Info($"推送文件到设备: {originFilePath} => {driverFilePath}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"推送文件到设备异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 从设备上检索文件
        /// </summary>
        /// <param name="driverFilePath"> 设备文件路径 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns></returns>
        #region
        public byte[] FilePull(string driverFilePath, bool logOutput = true)
        {

            try
            {
                byte[] fileByteList = AndroidDriver.PullFile(driverFilePath);
                if (logOutput) LogServe.Info($"从设备上检索文件 => {driverFilePath}");
                return fileByteList;
            }

            catch (Exception Err)
            {
                LogServe.Error($"从设备上检索文件异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 从设备上检索文件夹
        /// </summary>
        /// <param name="driverFilePath"> 设备文件路径 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns></returns>
        #region
        public byte[] FolderPull(string driverFilePath, bool logOutput = true)
        {

            try
            {
                byte[] folderByteList = AndroidDriver.PullFolder(driverFilePath);
                if (logOutput) LogServe.Info($"从设备上检索文件 => {driverFilePath}");
                return folderByteList;
            }

            catch (Exception Err)
            {
                LogServe.Error($"从设备上检索文件夹异常 : { Err.Message }"); throw;
            }

        }
        #endregion

    }
}
