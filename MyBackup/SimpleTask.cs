using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 簡單備份
    /// </summary>
    public class SimpleleTask : AbstractTask
    {
        /// <summary>
        /// 覆寫
        /// </summary>
        /// <param name="config">設定檔</param>
        /// <param name="schedule">排程檔</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);
            foreach (Candidate candidate in this.fileFinder)
                this.BroadcastToHandlers(candidate);
        }
    }
}