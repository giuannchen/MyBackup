using MyBackupCandidate;
using System.Data;
using System.Data.SqlClient;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫紀錄
    /// </summary>
    public class DBLogHandler : AbstractDBHandler
    {
        /// <summary>
        /// 實作
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前的資料</param>
        /// <returns>處理後的資料</returns>
        public byte[] Perform(Candidate candidate, byte[] target)
        {
            // 寫入資料庫
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT TableLog(FileName,FileDateTime) VALUES(@FileName,@FileDateTime)";
            cmd.Parameters.Add("@FileName", SqlDbType.NVarChar);
            cmd.Parameters["@FileName"].Value = candidate.Name;
            cmd.Parameters.Add("@FileDateTime", SqlDbType.NVarChar);
            cmd.Parameters["@FileDateTime"].Value = candidate.FileDateTime;
            WriteDB(cmd);
            return target;
        }
    }
}