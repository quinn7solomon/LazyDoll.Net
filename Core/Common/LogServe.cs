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

using NLog;
using System;

using Core.Common.ICommon;
using Core.Common.ErrorDefined;


namespace Core.Common.Log
{

    /// <summary>
    /// 日志服务
    /// <para> 日志配置文件:: NLog.config </para>
    /// </summary>
    public class LogServe : ILogServe
    {

        /// <summary> 类实例 </summary>
        private static LogServe _LogServeEntity = null;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        /// <summary> 日志输出对象 </summary>
        private readonly Logger LogServeCore = LogManager.GetCurrentClassLogger();

        /// <summary> 实例访问器 </summary>
        public static LogServe Instance
        {
            get
            {
                lock (ThreadLock)
                {
                    return _LogServeEntity ??= new LogServe();
                }
            }
        }


        /// <summary>
        /// 实例化
        /// </summary>
        #region
        private LogServe()
        {

            // CODE TODO

        }
        #endregion


        /// <summary>
        /// 输出 DEBUG 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        #region
        public void Debug(string message)
        {

            try
            {
                LogServeCore.Debug(message);
            }

            catch (Exception Err)
            {
                LoggingSystemException(Err, "DEBUG");
            }

        }
        #endregion


        /// <summary>
        /// 输出 INFO 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        #region
        public void Info(string message)
        {

            try
            {
                LogServeCore.Info(message);
            }

            catch (Exception Err)
            {
                LoggingSystemException(Err, "INFO");
            }

        }
        #endregion


        /// <summary>
        /// 输出 ERROR 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        #region
        public void Error(string message)
        {

            try
            {
                LogServeCore.Error(message);
            }

            catch (Exception Err)
            {
                LoggingSystemException(Err, "ERROR");
            }

        }
        #endregion


        /// <summary>
        /// 输出 WARN 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        #region
        public void Warn(string message)
        {

            try
            {
                LogServeCore.Warn(message);
            }

            catch (Exception Err)
            {
                LoggingSystemException(Err, "WARN");
            }

        }
        #endregion


        /// <summary>
        /// 输出 WARN 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        #region
        public void Fatal(string message)
        {

            try
            {
                LogServeCore.Fatal(message);
            }

            catch (Exception Err)
            {
                LoggingSystemException(Err, "FATAL");
            }

        }
        #endregion


        /// <summary>
        /// 日志系统异常处理
        /// </summary>
        /// <param name="err"> Exception 对象 </param>
        /// <param name="errName"> Exception 等级名称 </param>
        public void LoggingSystemException(Exception err, string errName)
        {

            LogServeCore.Error($"日志服务 LogServer 输出 {errName} 等级日志时，捕获了一个异常 :: { err.Message }");

            throw new LogServeOutputException(err.Message);

        }

    }
}
