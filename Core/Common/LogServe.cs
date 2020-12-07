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


using NLog;
using System;
using Core.Common.ICommon;
using Core.Common.ErrorDefined;


namespace Core.Common.Log
{

    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogServe : ILogServe
    {

        /// <summary> 类实例 </summary>
        private static LogServe _LogServeEntity = null;

        /// <summary> 线程锁 </summary>
        private static readonly object ThreadLock = new object();

        /// <summary> 服务核心 </summary>
        private readonly Logger LogServeCore = LogManager.GetCurrentClassLogger();

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
                LogServeCore.Debug(message);
                Console.WriteLine(message);
            }

            catch (Exception err)
            {
                LoggingSystemException(err, "DEBUG");
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
                LogServeCore.Info(message);
                Console.WriteLine(message);
            }

            catch (Exception err)
            {
                LoggingSystemException(err, "INFO");
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
                LogServeCore.Error(message);
                Console.WriteLine(message);
            }

            catch (Exception err)
            {
                LoggingSystemException(err, "ERROR");
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
                LogServeCore.Warn(message);
                Console.WriteLine(message);
            }

            catch (Exception err)
            {
                LoggingSystemException(err, "WARN");
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
                LogServeCore.Fatal(message);
                Console.WriteLine(message);
            }

            catch (Exception err)
            {
                LoggingSystemException(err, "FATAL");
            }
        }


        /// <summary>
        /// 日志系统异常处理
        /// </summary>
        /// <param name="err"> Exception 对象 </param>
        /// <param name="errName"> Exception 等级标识 </param>
        public void LoggingSystemException(Exception err, string errName)
        {

            LogServeCore.Error($"日志服务 LogServer 输出 {errName} 等级日志时，捕获了一个异常:: { err.Message }");

            throw new LogServeOutputException(err.Message);

        }

    }
}
