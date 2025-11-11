using System.Collections.Concurrent;
using Crowler.Interfaces;

namespace Crowler.Services
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteFrequency(ConcurrentDictionary<string, int> frequency)
        {
            foreach (var kvp in frequency)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }
    }
}
