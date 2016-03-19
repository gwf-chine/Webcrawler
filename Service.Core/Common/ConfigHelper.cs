using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Common
{
    public class ConfigHelper<T> where T : class, new()
    {
        private static object lockHelper = new object();



        public ConfigHelper() { }

      


        /// <summary>
        ///  读取站点配置文件
        /// </summary>
        public static  T loadConfig(string configFilePath)
        {
            return (T)SerializationHelper.Load(typeof(T), configFilePath);
        }

        /// <summary>
        /// 写入站点配置文件
        /// </summary>
        public static T saveConifg(T model, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(model, configFilePath);
            }
            return model;
        }
    }
}
