using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MyBackup
{
    /// <summary>
    /// 將 ConfigManager 與 ScheduleManager 抽象化
    /// </summary>
    public abstract class JsonManager
    {
        /// <summary>
        /// 將擷取筆數抽象化
        /// </summary>
        public abstract Int32 GetCount();

        /// <summary>
        /// 將讀取Json抽象化
        /// </summary>
        public abstract void ProcessJsonConfig();

        /// <summary>
        /// 抽出共用的部分
        /// </summary>
        protected JObject GetJsonObject(string Path)
        {
            string configValue = File.ReadAllText(Path);
            return JObject.Parse(configValue);
        }
    }
}