using System.Collections.Concurrent;

namespace Crowler.Interfaces
{
    public interface IOutputWriter
    {
        void WriteFrequency(ConcurrentDictionary<string, int> frequency);
    }
}
