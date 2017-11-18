using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MyBackup
{
    /// <summary>
    /// 提供給使用者呼叫的服務
    /// </summary>
    public class MyBackupService
    {
        /// <summary>
        /// 存放多筆 JsonManager 物件
        /// </summary>
        private List<JsonManager> managers = new List<JsonManager>();

        private TaskDispatcher taskDispatcher;

        /// <summary>
        /// 初始化加入Manager
        /// </summary>
        public MyBackupService()
        {
            this.managers.Add(new ConfigManager());
            this.managers.Add(new ScheduleManager());
            this.taskDispatcher = new TaskDispatcher();
            this.Init();
        }

        public TaskDispatcher TaskDispatcher
        {
            get => default(TaskDispatcher);
            set
            {
            }
        }

        /// <summary>
        /// 擷取Json檔筆數
        /// </summary>
        /// <returns>回傳筆數</returns>
        public string DoPrintCount()
        {
            string SumCountString = string.Empty;
            for (int i = 0; i < this.managers.Count; i++)
            {
                SumCountString += this.managers[i].GetCount() + Environment.NewLine;
            }

            return SumCountString;
        }

        /// <summary>
        /// 讀取設定檔
        /// </summary>
        public void ProcessJsonConfigs()
        {
            for (int i = 0; i < this.managers.Count; i++)
            {
                this.managers[i].ProcessJsonConfig();
            }
        }

        /// <summary>
        /// 排程備份
        /// </summary>
        public void ScheduledBackup()
        {
            this.taskDispatcher.ScheduledTask(managers);
        }

        /// <summary>
        /// 簡單備份
        /// </summary>
        public void SimpleBackup()
        {
            this.taskDispatcher.SimpleTask(managers);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.ProcessJsonConfigs();
        }
    }
}