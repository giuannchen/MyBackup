using System;

namespace MyBackup
{
    /// <summary>
    /// 抽出共同函式
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// 檔案處理
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        byte[] Perform(Candidate candidate, byte[] target);
    }
}