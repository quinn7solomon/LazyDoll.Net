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
using Core.Common.Log;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;


namespace Core.TestingKit.App.Android
{

    /// <summary>
    /// 屏幕组件实现类
    /// </summary>
    public class AndroidConstructorsView
    {

        /// <summary> 日志服务 </summary>
        private readonly LogServe LogServe = LogServe.Instance;

        /// <summary> 安卓驱动 </summary>
        private readonly AndroidDriver<AndroidElement> AndroidDriver;


        /// <summary>
        /// 实例化屏幕组件实现类
        /// </summary>
        public AndroidConstructorsView(AndroidDriverCore androidDriverCore)
        {

            AndroidDriver = androidDriverCore.StartUniqueDriver();

        }


        /// <summary>
        /// 应用程序后台休眠
        /// </summary>
        /// <param name="sleepTime"> 后台休眠时长 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void BackgroundApp(int sleepTime, bool logOutput = true)
        {
            try
            {
                if (logOutput) LogServe.Info($"应用程序执行后台休眠 => {sleepTime}");

                /* Thread.Sleep(1000); */
                AndroidDriver.BackgroundApp(TimeSpan.FromSeconds(sleepTime));

                if (logOutput) LogServe.Info($"应用程序结束后台休眠");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 应用程序执行后台休眠异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 隐藏软键盘
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        public void HideKeyboard(bool logOutput = true)
        {
            try
            {
                /* Thread.Sleep(1000); */
                AndroidDriver.HideKeyboard();

                if (logOutput) LogServe.Info($"隐藏软键盘");
            }

            catch (Exception err)
            {
                LogServe.Error($"Error:: 隐藏软键盘异常:: { err.Message }"); throw;
            }
        }


        /// <summary>
        /// 物理键盘 - Home键
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PressKeyHome(bool logOutput = true)
        {

            BasePressKey(AndroidKeyCode.Keycode_HOME, "Home键", logOutput);

        }
        #endregion


        /// <summary>
        /// 物理键盘 - 返回键
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PressKeyBack(bool logOutput = true)
        {

            BasePressKey(AndroidKeyCode.Keycode_BACK, "返回键", logOutput);

        }
        #endregion


        /// <summary>
        /// 物理键盘 - 电源键
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PressKeySupply(bool logOutput = true)
        {

            BasePressKey(AndroidKeyCode.Keycode_POWER, "电源键", logOutput);

        }
        #endregion


        /// <summary>
        /// 物理键盘 - 音量增加键
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PressKeyVoiceUp(bool logOutput = true)
        {

            BasePressKey(AndroidKeyCode.Keycode_VOLUME_UP, "音量增加键", logOutput);

        }
        #endregion


        /// <summary>
        /// 物理键盘 - 音量减少键
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PressKeyVoiceDown(bool logOutput = true)
        {

            BasePressKey(AndroidKeyCode.Keycode_VOLUME_DOWN, "音量减少键", logOutput);

        }
        #endregion


        /// <summary>
        /// 物理键盘 - 音量静音键
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void PressKeyVoiceMute(bool logOutput = true)
        {

            BasePressKey(AndroidKeyCode.Keycode_VOLUME_MUTE, "音量静音键", logOutput);

        }
        #endregion


        /// <summary>
        /// 点击物理按键事件封装
        /// </summary>
        /// <param name="KeyCode"></param>
        /// <param name="KeyName"> 是否打印执行日志 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        private void BasePressKey(int KeyCode, string KeyName, bool logOutput)
        {

            try
            {
                /* Thread.Sleep(1000); */
                AndroidDriver.PressKeyCode(KeyCode);
                if (logOutput) LogServe.Info($"点击物理按键 => {KeyName}");
            }

            catch (Exception Err)
            {
                LogServe.Error($"点击物理按键异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 滑动屏幕 - 上
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void SwipeUp(bool logOutput = true)
        {

            BaseSwipe("上", logOutput);

        }
        #endregion


        /// <summary>
        /// 滑动屏幕 - 下
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void SwipeDown(bool logOutput = true)
        {

            BaseSwipe("下", logOutput);

        }
        #endregion


        /// <summary>
        /// 滑动屏幕 - 左
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void SwipeLeft(bool logOutput = true)
        {

            BaseSwipe("左", logOutput);

        }
        #endregion


        /// <summary>
        /// 滑动屏幕 - 右
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void SwipeRight(bool logOutput = true)
        {

            BaseSwipe("右", logOutput);

        }
        #endregion


        /// <summary>
        /// 滑动屏幕封装
        /// </summary>
        /// <param name="direction"> 滑动方向 </param>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        private void BaseSwipe(string direction, bool logOutput)
        {

            try
            {
                /* Thread.Sleep(1000); */

                TouchAction action = new TouchAction(AndroidDriver);
                Size size = AndroidDriver.Manage().Window.Size;
                int height = size.Height;
                int width = size.Width;

                switch (direction)
                {
                    case "上":
                        action.LongPress(width / 2, height / 2).MoveTo(width / 2, height - 10).Release().Perform();
                        break;
                    case "下":
                        action.LongPress(width / 2, height / 2).MoveTo(width / 2, 10).Release().Perform();
                        break;
                    case "左":
                        action.LongPress(50, height / 2).MoveTo(width - 50, height / 2).Release().Perform();
                        break;
                    case "右":
                        action.LongPress(width - 50, height / 2).MoveTo(50, height / 2).Release().Perform();
                        break;
                }

                if (logOutput) LogServe.Info($"滑动屏幕 => {direction}");

                /* Thread.Sleep(1000); */
            }

            catch (Exception Err)
            {
                LogServe.Error($"滑动屏幕异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 锁定屏幕
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void Lock(bool logOutput = true)
        {

            try
            {
                AndroidDriver.Lock();

                if (logOutput) LogServe.Info("锁定屏幕");
            }

            catch (Exception Err)
            {
                LogServe.Error($"锁定屏幕异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 解锁屏幕
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void Unlock(bool logOutput = true)
        {

            try
            {
                AndroidDriver.Unlock();

                if (logOutput) LogServe.Info("解锁屏幕");
            }

            catch (Exception Err)
            {
                LogServe.Error($"解锁屏幕异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 判断当前屏幕是否已经被锁定
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        /// <returns> bool </returns>
        #region
        public bool IsLocked(bool logOutput = true)
        {

            try
            {
                bool screenType = AndroidDriver.IsLocked();
                if (logOutput) LogServe.Info($"判断当前屏幕是否已经被锁定 => {screenType}");
                return screenType;
            }

            catch (Exception Err)
            {
                LogServe.Error($"判断当前屏幕是否已经被锁定异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 当前屏幕截图
        /// </summary>
        /// <returns> Screenshot对象 </returns>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public Screenshot Screenshot(bool logOutput = true)
        {

            try
            {
                Screenshot screenshot = AndroidDriver.GetScreenshot();

                if (logOutput) LogServe.Info("当前屏幕截图");

                return screenshot;
            }

            catch (Exception Err)
            {
                LogServe.Error($"当前屏幕截图异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 开始录制屏幕
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void StartRecordingScreen(bool logOutput = true)
        {

            try
            {
                AndroidDriver.StartRecordingScreen(
                    AndroidStartScreenRecordingOptions.GetAndroidStartScreenRecordingOptions()
                    .WithTimeLimit(TimeSpan.FromSeconds(10))
                    .WithBitRate(500000)
                    .WithVideoSize("720x1280"));

                if (logOutput) LogServe.Info($"设备开始录制屏幕");
            }

            catch (Exception Err)
            {
                LogServe.Error($"设备录制屏幕异常 : { Err.Message }"); throw;
            }

        }
        #endregion


        /// <summary>
        /// 结束录制屏幕
        /// </summary>
        /// <param name="logOutput"> 是否打印执行日志 </param>
        #region
        public void StopRecordingScreen(bool logOutput = true)
        {

            try
            {
                AndroidDriver.StopRecordingScreen();

                if (logOutput) LogServe.Info($"设备结束录制屏幕");
            }

            catch (Exception Err)
            {
                LogServe.Error($"设备结束录制屏幕异常 : { Err.Message }"); throw;
            }

        }
        #endregion

    }
}
