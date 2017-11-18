using MyBackupCandidate;
using System.Collections.Generic;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// 檔案處理器
    /// </summary>
    public class LocalFileFinder : AbstractFileFinder
    {
        /// <summary>
        /// NEW
        /// </summary>
        public LocalFileFinder()
        {
        }

        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="config">設定檔</param>
        public LocalFileFinder(Config config) : base(config)
        {
            if (config.SubDirectory == true)
            {
                this.files = this.GetSubDirectoryFiles(config);
            }
            else
            {
                this.files =
                Directory.GetFiles(config.Location, "*." + config.Ext);
            }
        }

        /// <summary>
        /// 建立檔案資訊
        /// </summary>
        /// <param name="fileName">路徑</param>
        /// <returns>檔案資訊</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            FileInfo fileInfo;
            Candidate candidate = null;
            if (File.Exists(fileName))
            {
                fileInfo = new FileInfo(fileName);
                candidate = CandidateFactory.Create(this.config, fileName, fileInfo.CreationTime, fileInfo.Length);
            }
            return candidate;
        }

        /// <summary>
        /// 取得資料夾內所有檔案
        /// </summary>
        /// <param name="config">設定檔</param>
        /// <returns></returns>
        private string[] GetSubDirectoryFiles(Config config)
        {
            return System.IO.Directory.GetFiles(config.Dir, "*.*", System.IO.SearchOption.AllDirectories);
        }

        /// <summary>
        /// 判斷有無子目錄
        /// </summary>
        /// <param name="path">路徑</param>
        /// <returns>是否</returns>
        private bool HasSubfoldersDavidDax(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] subdirs = directory.GetDirectories();
            return (subdirs.Length != 0);
        }
    }
}