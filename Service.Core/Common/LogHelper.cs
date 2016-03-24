using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Common
{
    /// <summary>
    /// LogHelper的摘要说明。
    /// </summary>
    public class LogHelper
    {
        public LogHelper()
        {
           
    
        }

        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public  void SetConfig()
        {
            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo( "log4net.config"));
        }

        public  void SetConfig(FileInfo configFile)
        {
            XmlConfigurator.Configure(configFile);
        }

        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }
    }
}
