using MyBackupCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫處理器
    /// </summary>
    internal class DBAdapter : AbstractHandler
    {
        /// <summary>
        /// 備份介接
        /// </summary>
        private IDBHandler backupHandler = new DBBackupHandler();

        /// <summary>
        /// 紀錄介接
        /// </summary>
        private IDBHandler logHandler = new DBLogHandler();

        /// <summary>
        /// 執行備份與Log
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            base.Perform(candidate, target);
            this.SaveBackupToDB(candidate, target);
            this.SaveLogToDB(candidate, target);
            return target;
        }

        /// <summary>
        /// 寫入資料庫
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        private void SaveBackupToDB(Candidate candidate, byte[] target)
        {
            this.backupHandler.OpenConnection();
            this.backupHandler.Perform(candidate, target);
            this.backupHandler.CloseConnection();
        }

        /// <summary>
        /// 紀錄
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        private void SaveLogToDB(Candidate candidate, byte[] target)
        {
            this.logHandler.OpenConnection();
            this.logHandler.Perform(candidate, target);
            this.logHandler.CloseConnection();
        }
    }
}