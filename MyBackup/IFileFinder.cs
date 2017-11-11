using System.Collections;

namespace MyBackup
{
    /// <summary>
    /// 繼承 .NET Framework 的 IEnumerable 與 IEnumerator interface
    /// </summary>
    public interface IFileFinder : IEnumerable, IEnumerator
    {
    }
}