using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 程序工廠
    /// </summary>
    public static class TaskFactory
    {
        public static ITask ITask
        {
            get => default(ITask);
            set
            {
            }
        }

        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static ITask Create(string task)
        {
            if (task == "simple")
                return new SimpleleTask();
            else if (task == "scheduled")
                return new ScheduledTask();
            else
                return null;
        }
    }
}