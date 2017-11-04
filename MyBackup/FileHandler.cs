using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 轉換成 Byte
    /// </summary>
    internal class FileHandler : AbstractHandler
    {
        /// <summary>
        /// 覆寫
        /// </summary>
        /// <param name="cadidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        public override byte[] Perform(Candidate cadidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(cadidate, target);
            if (target == null)
            {
                result = this.ConvertFileToByteArray(cadidate);
            }
            else
            {
                this.ConvertByteArrayToFile(cadidate, target);
            }

            return result;
        }

        /// <summary>
        /// 寫檔
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        private void ConvertByteArrayToFile(Candidate candidate, byte[] target)
        {
            using (var fs = new FileStream(candidate.Name, FileMode.Create, FileAccess.Write))
            {
                fs.Write(target, 0, target.Length);
            }
        }

        /// <summary>
        /// 讀檔
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <returns>處理後</returns>
        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            if (File.Exists(candidate.Name) == false)
            {
                throw new FileNotFoundException();
            }

            return File.ReadAllBytes(candidate.Name);
        }
    }
}