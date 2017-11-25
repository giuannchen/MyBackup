using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 處理器工廠
    /// </summary>
    internal class HandlerFactory
    {
        /// <summary>
        /// 對照檔
        /// </summary>
        private static Dictionary<string, string> handlerDictionary;

        /// <summary>
        /// 讀取設定檔
        /// </summary>
        static HandlerFactory()
        {
            string jsonString =
            File.ReadAllText("handler_mapping.json");
            HandlerFactory.handlerDictionary =
            JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        /// <summary>
        /// 建立處理器
        /// </summary>
        /// <param name="key">指定處理器</param>
        /// <returns>處理器</returns>
        public static IHandler Create(string key)
        {
            return (IHandler)Activator.CreateInstance("MyBackupService", HandlerFactory.handlerDictionary[key]).Unwrap();
        }
    }
}