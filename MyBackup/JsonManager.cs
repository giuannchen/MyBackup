using System;
using System.IO;
using Newtonsoft.Json.Linq;

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
        /// <returns>筆數</returns>
        public abstract int GetCount();

        /// <summary>
        /// 將讀取Json抽象化
        /// </summary>
        public abstract void ProcessJsonConfig();

        /// <summary>
        /// 抽出共用的部分
        /// </summary>
        /// <param name="Path">檔案路徑</param>
        /// <returns>Jason物件</returns>
        protected JObject GetJsonObject(string Path)
        {
            string configValue = File.ReadAllText(Path);
            return JObject.Parse(configValue);
        }
    }
}