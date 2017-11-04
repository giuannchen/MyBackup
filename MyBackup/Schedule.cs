using System;

namespace MyBackup
{
    /// <summary>
    /// 設定檔資訊
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// 副檔名
        /// </summary>
        private string ext;

        /// <summary>
        /// 間隔
        /// </summary>
        private string interval;

        /// <summary>
        /// 時間
        /// </summary>
        private string time;

        /// <summary>
        /// Instance constructor
        /// </summary>
        /// <param name="ext">副檔名</param>
        /// <param name="time">間格</param>
        /// <param name="interval">時間</param>
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
                return this.ext;
            }
        }

        /// <summary>
        /// 設定此排程執行的間隔
        /// </summary>
        public string Interval
        {
            get
            {
                return this.interval;
            }
        }

        /// <summary>
        /// 設定此排程所處理的時間
        /// </summary>
        public string Time
        {
            get
            {
                return this.time;
            }
        }
    }
}