using System.Text;
using Crowler.Interfaces;

namespace Crowler.Services
{
    public class TextProcessor : ITextProcessor
    {
        public string[] Split(string text, char[] delimiters)
        {
            List<string> list = new List<string>();
            StringBuilder word = new StringBuilder();

            foreach (var ch in text)
            {
                if (ch == '\r')
                    continue;

                if (IsDelimiter(ch, delimiters) && word.Length != 0)
                {
                    list.Add(word.ToString());
                    word.Clear();
                }
                else if (!IsDelimiter(ch, delimiters))
                {
                    word.Append(ch);
                }
            }

            if (word.Length > 0)
                list.Add(word.ToString());

            return list.ToArray();
        }

        private bool IsDelimiter(char ch, char[] delimiters)
        {
            foreach (var delimiter in delimiters)
            {
                if (ch == delimiter)
                    return true;
            }
            return false;
        }
    }
}
