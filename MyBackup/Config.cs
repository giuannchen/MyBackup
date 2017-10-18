using System;

namespace MyBackup
{
    /// <summary>
    /// 設定檔資訊
    /// </summary>
    public class Config
    {
        private string connectionString;
        private string destination;
        private string dir;
        private string ext;
        private string handler;
        private string location;
        private bool remove;
        private bool subDirectory;
        private string unit;

        /// <summary>
        /// Instance constructor
        /// </summary>
        public Config(string ext, string location, bool subDirectory, string unit, bool remove, string handler, string destination, string dir, string connectionString)
        {
            this.ext = ext;
            this.location = location;
            this.subDirectory = subDirectory;
            this.unit = unit;
            this.remove = remove;
            this.handler = handler;
            this.destination = destination;
            this.dir = dir;
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 設定資料庫連接字串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        /// <summary>
        /// 處理後要儲存到什麼地方，directory : 目錄；db : 資料庫
        /// </summary>
        public string Destination
        {
            get
            {
                return destination;
            }
        }

        /// <summary>
        /// 處理後的目錄
        /// </summary>
        public string Dir
        {
            get
            {
                return dir;
            }
        }

        /// <summary>
        /// 設定檔案格式
        /// </summary>
        public string Ext
        {
            get
            {
                return ext;
            }
        }

        /// <summary>
        /// zip  : 壓縮；encode : 加密
        /// </summary>
        public string Handler
        {
            get
            {
                return handler;
            }
        }

        /// <summary>
        /// 設定要備份檔案的目錄
        /// </summary>
        public string Location
        {
            get
            {
                return location;
            }
        }

        /// <summary>
        /// 處理完是否刪除檔案，true : 刪除；false : 不刪除
        /// </summary>
        public bool Remove
        {
            get
            {
                return remove;
            }
        }

        /// <summary>
        /// 是否處理子目錄，true : 處理子目錄；false :  不處理子目錄
        /// </summary>
        public bool SubDirectory
        {
            get
            {
                return subDirectory;
            }
        }

        /// <summary>
        /// 設定備份單位，file : 以單一檔案為處理單位；directory : 以整個目錄為處理單位
        /// </summary>
        public string Unit
        {
            get
            {
                return unit;
            }
        }
    }
}