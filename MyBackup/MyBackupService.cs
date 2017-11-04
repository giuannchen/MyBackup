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

        /// <summary>
        /// 初始化加入Manager
        /// </summary>
        public MyBackupService()
        {
            this.managers.Add(new ConfigManager());
            this.managers.Add(new ScheduleManager());
        }

        /// <summary>
        /// 執行備份
        /// </summary>
        public void DoBackup()
        {
            List<Candidate> candidates = this.FindFiles();
            foreach (Candidate candidate in candidates)
            {
                this.BroadcastToHandlers(candidate);
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
        /// 並將處理完的資料，交給下一個 handler
        /// </summary>
        /// <param name="candidate">處理前資料</param>
        private void BroadcastToHandlers(Candidate candidate)
        {
            List<IHandler> handlers = this.FindHandlers(candidate);
            byte[] target = null;
            foreach (IHandler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }
        }

        /// <summary>
        /// Homework 4
        /// </summary>
        /// <returns>檔案清單</returns>
        private List<Candidate> FindFiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 尋找檔案處理器
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <returns>檔案處理器集合</returns>
        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>();
            handlers.Add(HandlerFactory.Create("file"));
            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));
            return handlers;
        }
    }
}