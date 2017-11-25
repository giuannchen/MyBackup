using System;
using MyBackupCandidate;
using System.Data.SqlClient;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫可以抽出共用的處理器
    /// </summary>
    public abstract class AbstractDBHandler : IDBHandler
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private SqlConnection dbConnection = new SqlConnection("ConnectionString");

        /// <summary>
        /// 關閉連線
        /// </summary>
        public virtual void CloseConnection()
        {
            this.dbConnection.Close();
        }

        /// <summary>
        /// 開啟連線
        /// </summary>
        public virtual void OpenConnection()
        {
            this.dbConnection.Open();
        }

        /// <summary>
        /// 實作
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前的資料</param>
        /// <returns>處理後的資料</returns>
        public byte[] Perform(Candidate candidate, byte[] target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 執行資料庫命令
        /// </summary>
        /// <param name="dbCommand">SqlCommand</param>
        /// <returns>影響筆數</returns>
        public virtual int WriteDB(SqlCommand dbCommand)
        {
            dbCommand.Connection = this.dbConnection;
            return dbCommand.ExecuteNonQuery();
        }
    }
}