using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    /// <summary>
    /// 編碼處理器
    /// </summary>
    internal class EncodeHandler : AbstractHandler
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
            if (target != null)
            {
                result = this.EncodeData(cadidate, target);
            }

            return result;
        }

        /// <summary>
        /// 編碼程序
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">處理前</param>
        /// <returns>處理後</returns>
        private byte[] EncodeData(Candidate candidate, byte[] target)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] key = Encoding.ASCII.GetBytes("SENAORD3");
            byte[] iv = Encoding.ASCII.GetBytes("MyBackup");
            des.Key = key;
            des.IV = iv;

            byte[] dataByteArray = target;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
        }
    }
}