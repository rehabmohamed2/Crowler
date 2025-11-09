using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Pragmastat;

namespace Crowler
{
    internal class Program
    {
        private static string[] SamplesPath = new[]
        {
            "D:\\SelfDevDemos\\Crowler\\Crowler\\Samples\\s1.txt",
            "D:\\SelfDevDemos\\Crowler\\Crowler\\Samples\\s2.txt"
        };
        static void Main(string[] args)
        {
            //read file as a string
            string text = ReadText();
            //split string by " "
            string[] words = Split(text);
            //store words in a datastructure
            Dictionary<string, int> keyValuePairs = GetWordsFrequency(words);
            //print each name with frequency
            PrintWordsFrequency(keyValuePairs);

        }

        private static string ReadText()
        {
            string result = "";
            foreach (var path in SamplesPath)
            {
                string text = File.ReadAllText(path);
                result = result +" " + text;
            }
            return result;
        }

        private static string[] Split(string text)
        {
            List<string> list = new List<string>();
            string word = "";
            foreach (var ch in text)
            {
                if(ch == '\r')
                    continue;

                if ((ch == ' ' || ch == '\n') && word.Length != 0)
                {
                    list.Add(word);
                    word = "";
                }
                else
                {
                    word += ch;
                }
            }
            if (word != "")
                list.Add(word);

            string[] arr=new string[list.Count];
            int i = 0;
            foreach (var item in list)
            {
                arr[i++] = item;
            }

            return arr;
        }

        private static Dictionary<string,int> GetWordsFrequency(string[] words)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict[word] = 1;
                }
            }

            return dict;
        }

        private static void PrintWordsFrequency(Dictionary<string, int> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }

    }
}

