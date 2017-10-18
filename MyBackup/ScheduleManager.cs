using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MyBackup
{
    /// <summary>
    /// 使用者
    /// </summary>
    public class ScheduleManager
    {
        /// <summary>
        /// 存放多筆 Schedule 物件
        /// </summary>
        private List<Schedule> schedules = new List<Schedule>();

        /// <summary>
        /// 提供 Schedule的筆數
        /// </summary>
        /// <returns> Schedule筆數 </returns>
        public Int32 Count
        {
            get
            {
                return schedules.Count;
            }
        }

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
        /// 將 schedule.json 轉成 List
        /// </summary>
        public void ProcessSchedules()
        {
            //設定檔名稱
            string scheduleFileName = "schedule.json";
            if (File.Exists(scheduleFileName) != false)
            {
                JObject scheduleData = JObject.Parse(File.ReadAllText(scheduleFileName));
                JArray configDataArray = (JArray)scheduleData["schedules"];
                foreach (var config in configDataArray.Children())
                {
                    schedules.Add(
                                 new Schedule(
                                              (string)config["ext"],
                                              (string)config["time"],
                                              (string)config["interval"]
                                            )
                                  );
                }
            }
        }
    }
}