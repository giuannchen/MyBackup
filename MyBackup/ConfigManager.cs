using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MyBackup
{
    /// <summary>
    /// 設定檔管理用者
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// 存放多筆 Config 物件
        /// </summary>
        private List<Config> configs = new List<Config>();

        /// <summary>
        /// 提供 Config的筆數
        /// </summary>
        /// <returns> Config筆數 </returns>
        public Int32 Count
        {
            get
            {
                return configs.Count;
            }
        }

        ///  <summary>
        ///  取得指定的Config物件
        ///   </summary>
        ///   <param name="index">索引</param>
        ///   <returns> Config物件 </returns>
        public Config this[int index]
        {
            get
            {
                return configs[index];
            }
        }

        /// <summary>
        /// 將 config.json 轉成 List
        /// </summary>
        public void ProcessConfigs()
        {
            //設定檔名稱
            string setupFileName = "config.json";
            if (File.Exists(setupFileName) != false)
            {
                JObject configData = JObject.Parse(File.ReadAllText(setupFileName));
                JArray configDataArray = (JArray)configData["configs"];
                foreach (var config in configDataArray.Children())
                {
                    configs.Add(
                                 new Config(
                                              (string)config["ext"],
                                              (string)config["location"],
                                              (bool)config["subDirectory"],
                                              (string)config["unit"],
                                              (bool)config["remove"],
                                              (string)config["handler"],
                                              (string)config["destination"],
                                              (string)config["dir"],
                                              (string)config["connectionString"]
                                            )
                                  );
                }
            }
        }
    }
}