using MyBackup;
using System;

namespace MyBackupCandidate
{
    internal class CandidateFactory
    {
        public Candidate Candidate
        {
            get => default(Candidate);
            set
            {
            }
        }

        /// <summary>
        /// 檔案資訊工廠
        /// </summary>
        /// <param name="config"></param>
        /// <param name="name"></param>
        /// <param name="fileDateTime"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Candidate Create(Config config, string name, DateTime fileDateTime, long size)
        {
            return new Candidate(config, name, fileDateTime, size);
        }
    }
}