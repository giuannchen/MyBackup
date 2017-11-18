using MyBackupCandidate;
using System;

namespace MyBackup
{
    /// <summary>
    /// 排程備份
    /// </summary>
    public class ScheduledTask : AbstractTask
    {
        /// <summary>
        /// 覆寫
        /// </summary>
        /// <param name="config">設定檔</param>
        /// <param name="schedule">排程檔</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);
            if (((schedule.Interval == "Everyday") || (
                schedule.Interval == DateTime.Now.DayOfWeek.ToString()
                )) &&
                (schedule.Time == DateTime.Now.ToString("HH:mm"))
                )
            {
                foreach (Candidate candidate in this.fileFinder)
                    this.BroadcastToHandlers(candidate);
            }
        }
    }
}