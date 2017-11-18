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
        public static Candidate Create(Config config, string name, DateTime fileDateTime, long size)
        {
            return new Candidate(config, name, fileDateTime, size);
        }
    }
}