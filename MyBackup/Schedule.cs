using System;

namespace MyBackup
{
    /// <summary>
    /// 設定檔資訊
    /// </summary>
    public class Schedule
    {
        private string ext;
        private string interval;
        private string time;

        /// <summary>
        /// Instance constructor
        /// </summary>
        public Schedule(string ext, string time, string interval)
        {
            this.ext = ext;
            this.time = time;
            this.interval = interval;
        }

        /// <summary>
        /// 設定此排程所處理的檔案格式
        /// </summary>
        public string Ext
        {
            get
            {
                return ext;
            }
        }

        /// <summary>
        /// 設定此排程執行的間隔
        /// </summary>
        public string Interval
        {
            get
            {
                return interval;
            }
        }

        /// <summary>
        /// 設定此排程所處理的時間
        /// </summary>
        public string Time
        {
            get
            {
                return time;
            }
        }
    }
}