namespace MyBackup
{
    /// <summary>
    /// 抽出共同函式
    /// </summary>
    public interface ITask
    {
        void Execute(Config config, Schedule shedule);
    }
}