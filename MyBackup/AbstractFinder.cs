using System.Collections;
using System.Linq;

namespace MyBackup
{
    /// <summary>
    /// 所有 finder 共用程式碼處
    /// </summary>
    public abstract class AbstractFileFinder : IFileFinder
    {
        /// <summary>
        /// 設定檔
        /// </summary>
        protected Config config;

        /// <summary>
        /// 檔案集合
        /// </summary>
        protected string[] files;

        /// <summary>
        /// 預設起始路徑
        /// </summary>
        protected int index = -1;

        /// <summary>
        /// new
        /// </summary>
        protected AbstractFileFinder()
        {
        }

        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="config">設定檔</param>
        protected AbstractFileFinder(Config config)
        {
            if (config != null)
                this.config = config;
        }

        /// <summary>
        ///  IEnumerator
        /// </summary>
        public object Current => this.CreateCandidate(this.files[this.index]);

        /// <summary>
        /// IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        /// <summary>
        /// IEnumerator 下一個
        /// </summary>
        /// <returns>有無</returns>
        public bool MoveNext()
        {
            this.index++;
            return (this.index < this.files.Count());
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            this.index = -1;
        }

        /// <summary>
        /// 建立檔案資訊
        /// </summary>
        /// <param name="fileName">路徑</param>
        /// <returns>檔案資訊</returns>
        protected abstract Candidate CreateCandidate(string fileName);
    }
}