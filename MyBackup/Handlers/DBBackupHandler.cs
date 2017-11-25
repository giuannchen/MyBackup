using MyBackupCandidate;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 備份處理器
    /// </summary>
    public class DBBackupHandler : AbstractDBHandler
    {
        /// <summary>
        /// 實作
        /// </summary>
        /// <param name="cadidate">檔案資訊</param>
        /// <param name="target">處理前的資料</param>
        /// <returns>處理後的資料</returns>
        public byte[] Perform(Candidate cadidate, byte[] target)
        {
            FileStream fs = new FileStream(cadidate.Name, FileMode.Open);

            // 用來儲存檔案的 byte 陣列，檔案有多大，陣列就有多大
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            // 寫入資料庫
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT Table1(Body) VALUES(@Body)";
            cmd.Parameters.Add("@Body", SqlDbType.Binary);
            cmd.Parameters["@Body"].Value = buffer;
            base.WriteDB(cmd);
            return target;
        }
    }
}