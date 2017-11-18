using MyBackup;
using System;

namespace MyBackupCandidate
{
    /// <summary>
    /// 檔案資訊
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// 檔案資訊
        /// </summary>
        private readonly Config config;

        /// <summary>
        /// 檔案的日期與時間
        /// </summary>
        private readonly DateTime fileDateTime;

        /// <summary>
        /// 檔案名稱
        /// </summary>
        private readonly string name;

        /// <summary>
        /// 檔案程序名稱
        /// </summary>
        private readonly string processName;

        /// <summary>
        /// 檔案大小
        /// </summary>
        private readonly long size;

        internal Candidate()
        {
            //
        }

        /// <summary>
        /// 建立檔案資訊
        /// </summary>
        /// <param name="config">設定檔資訊</param>
        internal Candidate(Config config, string name, DateTime fileDateTime, long size)
        {
            this.config = config;
            this.name = name;
            this.fileDateTime = fileDateTime;
            this.size = size;
        }

        /// <summary>
        /// 取得設定檔
        /// </summary>
        public Config Config
        {
            get => this.config;
        }

        /// <summary>
        /// 取得檔案建立日期與時間
        /// </summary>
        public DateTime FileDateTime
        {
            get
            {
                return this.fileDateTime;
            }
        }

        /// <summary>
        /// 取得檔名
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// 取得程序名稱
        /// </summary>
        public string ProcessName
        {
            get
            {
                return this.processName;
            }
        }

        /// <summary>
        /// 取得檔案大小
        /// </summary>
        public long Size
        {
            get
            {
                return this.size;
            }
        }
    }
}