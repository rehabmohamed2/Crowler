using Crowler.Interfaces;
using Crowler.Services;

namespace Crowler
{
    internal class Program
    {
        private static readonly string[] SamplesPath = new[]
        {
            "Samples\\s1.txt",
            "Samples\\s2.txt"
        };

        private static readonly char[] Delimiters = new[] { ' ', '\n', '\t' };

        static async Task Main(string[] args)
        {
            IFileReader fileReader = new FileReader();
            ITextProcessor textProcessor = new TextProcessor();
            IWordFrequencyAnalyzer frequencyAnalyzer = new WordFrequencyAnalyzer();
            IOutputWriter outputWriter = new OutputWriter();

            string text = await fileReader.ReadFilesAsync(SamplesPath);
            string[] words = textProcessor.Split(text, Delimiters);
            var frequency = frequencyAnalyzer.GetWordsFrequency(words);
            outputWriter.WriteFrequency(frequency);
        }
    }
}
