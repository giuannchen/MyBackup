using MyBackupCandidate;
using System.Collections.Generic;

namespace MyBackup
{
    /// <summary>
    /// 抽出共用
    /// </summary>
    public abstract class AbstractTask : ITask
    {
        /// <summary>
        /// 檔案處理器
        /// </summary>
        protected IFileFinder fileFinder;

        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="config">設定檔</param>
        /// <param name="schedule">排程檔</param>
        public virtual void Execute(Config config, Schedule schedule)
        {
            this.fileFinder = FileFinderFactory.Create("file", config);
        }

        /// <summary>
        /// 並將處理完的資料，交給下一個 handler
        /// </summary>
        /// <param name="candidate">處理前資料</param>
        protected void BroadcastToHandlers(Candidate candidate)
        {
            List<IHandler> handlers = this.FindHandlers(candidate);
            byte[] target = null;
            foreach (IHandler handler in handlers)
                target = handler.Perform(candidate, target);
        }

        /// <summary>
        /// 尋找檔案處理器
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <returns>檔案處理器集合</returns>
        protected List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>();
            handlers.Add(HandlerFactory.Create("file"));
            foreach (string handler in candidate.Config.Handlers)
                handlers.Add(HandlerFactory.Create(handler));
            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));
            return handlers;
        }
    }
}