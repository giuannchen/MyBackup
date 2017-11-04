using System;

namespace MyBackup
{
    /// <summary>
    /// 設定檔資訊
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private string connectionString;

        /// <summary>
        /// 目的地
        /// </summary>
        private string destination;

        /// <summary>
        /// 目錄
        /// </summary>
        private string dir;

        /// <summary>
        /// 副檔名
        /// </summary>
        private string ext;

        /// <summary>
        /// 處理器
        /// </summary>
        private string[] handlers;

        /// <summary>
        /// 位置
        /// </summary>
        private string location;

        /// <summary>
        /// 是否搬移
        /// </summary>
        private bool remove;

        /// <summary>
        /// 子目錄
        /// </summary>
        private bool subDirectory;

        /// <summary>
        /// 單元
        /// </summary>
        private string unit;

        /// <summary>
        /// Instance constructor
        /// </summary>
        /// <param name="ext">副檔名</param>
        /// <param name="location">位置</param>
        /// <param name="subDirectory">子目錄</param>
        /// <param name="unit">單元</param>
        /// <param name="remove">是否移除</param>
        /// <param name="handlers">處理器</param>
        /// <param name="destination">目的地</param>
        /// <param name="dir">目錄</param>
        /// <param name="connectionString">連線字串</param>
        public Config(string ext, string location, bool subDirectory, string unit, bool remove, string[] handlers, string destination, string dir, string connectionString)
        {
            this.ext = ext;
            this.location = location;
            this.subDirectory = subDirectory;
            this.unit = unit;
            this.remove = remove;
            this.handlers = handlers;
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
                return this.connectionString;
            }
        }

        /// <summary>
        /// 處理後要儲存到什麼地方，directory : 目錄；db : 資料庫
        /// </summary>
        public string Destination
        {
            get
            {
                return this.destination;
            }
        }

        /// <summary>
        /// 處理後的目錄
        /// </summary>
        public string Dir
        {
            get
            {
                return this.dir;
            }
        }

        /// <summary>
        /// 設定檔案格式
        /// </summary>
        public string Ext
        {
            get
            {
                return this.ext;
            }
        }

        /// <summary>
        /// zip  : 壓縮；encode : 加密
        /// </summary>
        public string[] Handlers
        {
            get { return this.handlers; }
        }

        /// <summary>
        /// 設定要備份檔案的目錄
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// 處理完是否刪除檔案，true : 刪除；false : 不刪除
        /// </summary>
        public bool Remove
        {
            get
            {
                return this.remove;
            }
        }

        /// <summary>
        /// 是否處理子目錄，true : 處理子目錄；false :  不處理子目錄
        /// </summary>
        public bool SubDirectory
        {
            get
            {
                return this.subDirectory;
            }
        }

        /// <summary>
        /// 設定備份單位，file : 以單一檔案為處理單位；directory : 以整個目錄為處理單位
        /// </summary>
        public string Unit
        {
            get
            {
                return this.unit;
            }
        }
    }
}