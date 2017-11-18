using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 程序實作
    /// </summary>
    public class TaskDispatcher
    {
        /// <summary>
        /// interface
        /// </summary>
        private ITask task;

        /// <summary>
        /// 排程程序
        /// </summary>
        /// <param name="managers">managers</param>
        public void ScheduledTask(List<JsonManager> managers)
        {
            ConfigManager configManager = (ConfigManager)managers[0];
            ScheduleManager scheduleManager = (ScheduleManager)managers[1];
            for (int i = 0; i < scheduleManager.GetCount(); i++)
            {
                for (int j = 0; j < configManager.GetCount(); i++)
                {
                    if (scheduleManager[i].Ext == configManager[j].Ext)
                    {
                        this.task = TaskFactory.Create("scheduled");
                        this.task.Execute(configManager[j], scheduleManager[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 簡單程序
        /// </summary>
        /// <param name="managers"></param>
        public void SimpleTask(List<JsonManager> managers)
        {
            ConfigManager configManager = (ConfigManager)managers[0];
            for (int i = 0; i < configManager.GetCount(); i++)
            {
                this.task = TaskFactory.Create("simple");
                this.task.Execute(configManager[i], null);
            }
        }
    }
}