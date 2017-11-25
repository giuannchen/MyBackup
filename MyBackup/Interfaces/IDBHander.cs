using MyBackupCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 抽出共同函式
    /// </summary>
    public interface IDBHandler
    {
        // 關閉資料庫連線
        void CloseConnection();

        // 開啟資料庫連線
        void OpenConnection();

        //實作
        byte[] Perform(Candidate candidate, byte[] target);
    }
}