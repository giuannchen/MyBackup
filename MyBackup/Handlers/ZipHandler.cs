using MyBackupCandidate;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 壓縮處理器
    /// </summary>
    internal class ZipHandler : AbstractHandler
    {
        /// <summary>
        /// 覆寫處理器
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
                result = this.ZipData(cadidate, target);
            }

            return result;
        }

        /// <summary>
        /// 壓縮
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        private byte[] ZipData(Candidate candidate, byte[] target)
        {
            MemoryStream originalFileStream = new MemoryStream();
            using (DeflateStream decompressionStream = new DeflateStream(originalFileStream, CompressionMode.Decompress))
            {
                decompressionStream.Write(target, 0, target.Length);
            }

            return originalFileStream.ToArray();
        }
    }
}