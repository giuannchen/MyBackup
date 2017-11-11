using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    public class FileFinderFactory
    {
        public static IFileFinder Create(string finder, Config config)
        {
            if (finder == "file")
                return new LocalFileFinder(config);
            else
                return null;
        }
    }
}