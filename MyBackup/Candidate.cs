using System;

namespace MyBackup
{
    /// <summary>
    /// 檔案資訊
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// 檔案資訊
        /// </summary>
        private Config config;

        /// <summary>
        /// 檔案的日期與時間
        /// </summary>
        private string fileDateTime;

        /// <summary>
        /// 檔案名稱
        /// </summary>
        private string name;

        /// <summary>
        /// 檔案程序名稱
        /// </summary>
        private string processName;

        /// <summary>
        /// 檔案大小
        /// </summary>
        private string size;

        /// <summary>
        /// 建立檔案資訊
        /// </summary>
        /// <param name="config">設定檔資訊</param>
        public Candidate(Config config)
        {
            this.config = config;
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
        public string FileDateTime
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
        public string Size
        {
            get
            {
                return this.size;
            }
        }
    }
}