using System.Collections.Concurrent;

namespace Crowler.Interfaces
{
    public interface IWordFrequencyAnalyzer
    {
        ConcurrentDictionary<string, int> GetWordsFrequency(string[] words);
    }
}
