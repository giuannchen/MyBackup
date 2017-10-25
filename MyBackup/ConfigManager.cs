using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MyBackup
{
    /// <summary>
    /// 設定檔管理用者
    /// </summary>
    public class ConfigManager : JsonManager
    {
        /// <summary>
        /// 檔案位置
        /// </summary>
        private const string FilePath = @"config.json";

        /// <summary>
        /// 存放多筆 Config 物件
        /// </summary>
        private List<Config> configs = new List<Config>();

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
        /// 提供 Config的筆數
        /// </summary>
        public override Int32 GetCount()
        {
            return configs.Count;
        }

        /// <summary>
        /// 將 config.json 轉成 List
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configData = this.GetJsonObject(FilePath);
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