namespace Crowler.Interfaces
{
    public interface IFileReader
    {
        Task<string> ReadFilesAsync(string[] filePaths);
    }
}
