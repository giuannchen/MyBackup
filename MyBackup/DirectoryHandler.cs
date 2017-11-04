using System.IO;

namespace MyBackup
{
    /// <summary>
    /// 複製處理器
    /// </summary>
    internal class DirectoryHandler : AbstractHandler
    {
        /// <summary>
        /// 覆寫處理程序
        /// </summary>
        /// <param name="cadidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        public override byte[] Perform(Candidate cadidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(cadidate, target);
            if (target != null)
            {
                result = this.CopyToDirectory(cadidate, target);
            }

            return result;
        }

        /// <summary>
        /// 複製
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        private byte[] CopyToDirectory(Candidate candidate, byte[] target)
        {
            ////檔案是否存在
            if (Directory.Exists(candidate.Config.Dir) == false)
            {
                throw new DirectoryNotFoundException();
            }

            ////寫入新位置
            using (var fs = new FileStream(candidate.Config.Dir + candidate.Name, FileMode.Create, FileAccess.Write))
            {
                fs.Write(target, 0, target.Length);
            }

            return target;
        }
    }
}