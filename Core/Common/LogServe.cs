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

using NLog;

using Core.Common.ErrorCustom;


namespace Core.Common.Log
{

    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogServe
    {

        /// <summary> 类实例 </summary>
        private static LogServe _LogServeEntity = null;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        /// <summary> 输出核心 </summary>
        private readonly Logger LoggerOutputCore = LogManager.GetCurrentClassLogger();

        /// <summary> 访问器 </summary>
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
        private LogServe()
        {
            // CODE TODO
        }


        /// <summary>
        /// 输出 DEBUG 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        public void Debug(string message)
        {
            try
            {
                Console.WriteLine(message);
                LoggerOutputCore.Debug(message);
            }

            catch (Exception err)
            {
                LoggingSystemExceptionHandling(err, "DEBUG");
            }
        }


        /// <summary>
        /// 输出 INFO 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        public void Info(string message)
        {
            try
            {
                Console.WriteLine(message);
                LoggerOutputCore.Info(message);
            }

            catch (Exception err)
            {
                LoggingSystemExceptionHandling(err, "INFO");
            }
        }


        /// <summary>
        /// 输出 ERROR 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        public void Error(string message)
        {
            try
            {
                Console.WriteLine(message);
                LoggerOutputCore.Error(message);
            }

            catch (Exception err)
            {
                LoggingSystemExceptionHandling(err, "ERROR");
            }
        }


        /// <summary>
        /// 输出 WARN 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        public void Warn(string message)
        {
            try
            {
                Console.WriteLine(message);
                LoggerOutputCore.Warn(message);
            }

            catch (Exception err)
            {
                LoggingSystemExceptionHandling(err, "WARN");
            }
        }


        /// <summary>
        /// 输出 WARN 等级日志
        /// </summary>
        /// <param name="message"> 打印日志String </param>
        public void Fatal(string message)
        {
            try
            {
                Console.WriteLine(message);
                LoggerOutputCore.Fatal(message);
            }

            catch (Exception err)
            {
                LoggingSystemExceptionHandling(err, "FATAL");
            }
        }


        /// <summary>
        /// 日志系统异常处理
        /// </summary>
        /// <param name="err"> Exception 对象 </param>
        /// <param name="errName"> Exception 等级标识 </param>
        public void LoggingSystemExceptionHandling(Exception err, string errName)
        {
            LoggerOutputCore.Error($"日志服务 LogServer 输出 {errName} 等级日志时，捕获了一个异常:: { err.Message }");

            throw new LogServeOutputException();
        }

    }
}
