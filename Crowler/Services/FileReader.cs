using System.Text;
using Crowler.Interfaces;

namespace Crowler.Services
{
    public class FileReader : IFileReader
    {
        public async Task<string> ReadFilesAsync(string[] filePaths)
        {
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var path in filePaths)
            {
                tasks.Add(File.ReadAllTextAsync(path));
            }

            string[] results = await Task.WhenAll(tasks);

            var sb = new StringBuilder();
            foreach (var text in results)
            {
                sb.Append(" ").Append(text);
            }

            return sb.ToString();
        }
    }
}
