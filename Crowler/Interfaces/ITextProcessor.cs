namespace Crowler.Interfaces
{
    public interface ITextProcessor
    {
        string[] Split(string text, char[] delimiters);
    }
}
