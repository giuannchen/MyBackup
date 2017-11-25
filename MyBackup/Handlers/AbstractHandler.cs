using MyBackupCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 可以抽出共用的處理器
    /// </summary>
    internal class AbstractHandler : IHandler
    {
        /// <summary>
        /// 處理
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前的資料</param>
        /// <returns>處理後的資料</returns>
        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}