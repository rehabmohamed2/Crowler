using System.Collections.Concurrent;
using Crowler.Interfaces;

namespace Crowler.Services
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public ConcurrentDictionary<string, int> GetWordsFrequency(string[] words)
        {
            var dict = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(words, word =>
            {
                dict.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
            });

            return dict;
        }
    }
}
