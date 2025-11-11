using System.Text;

namespace Crowler.Extensions
{
    public static class StringExtensions
    {
        public static string[] SplitByDelimiters(this string text, char[] delimiters)
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

        private static bool IsDelimiter(char ch, char[] delimiters)
        {
            foreach (var delimiter in delimiters)
            {
                if (ch == delimiter)
                    return true;
            }
            return false;
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
