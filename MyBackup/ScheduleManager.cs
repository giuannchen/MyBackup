using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MyBackup
{
    /// <summary>
    /// 使用者
    /// </summary>
    public class ScheduleManager : JsonManager
    {
        /// <summary>
        /// 排程檔名稱
        /// </summary>
        private const string FilePath = @"schedule.json";

        /// <summary>
        /// 存放多筆 Schedule 物件
        /// </summary>
        private List<Schedule> schedules = new List<Schedule>();

        ///  <summary>
        ///  取得指定的Schedule物件
        ///   </summary>
        ///   <param name="index">索引</param>
        ///   <returns> Schedule物件 </returns>
        public Schedule this[int index]
        {
            get
            {
                return schedules[index];
            }
        }

        /// <summary>
        /// 提供 Schedule的筆數
        /// </summary>
        /// <returns> Schedule筆數 </returns>
        public override Int32 GetCount()
        {
            return schedules.Count;
        }

        /// <summary>
        /// 將 schedule.json 轉成 List
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject scheduleData = this.GetJsonObject(FilePath);
            JArray scheduleDataArray = (JArray)scheduleData["schedules"];
            foreach (var schedule in scheduleDataArray.Children())
            {
                schedules.Add(
                             new Schedule(
                                          (string)schedule["ext"],
                                          (string)schedule["time"],
                                          (string)schedule["interval"]
                                        )
                              );
            }
        }
    }
}