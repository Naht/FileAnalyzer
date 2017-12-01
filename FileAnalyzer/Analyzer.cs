using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    class Analyzer
    {
        

        public List<List<string>> ParsedNames { get => ParsedNames; set => ParsedNames = value; }

        public void ParseDirectory(String path)
        {
            List<String> fileList = Directory.EnumerateFiles(path).Select(x => Path.GetFileName(x)).ToList();
            IEnumerable<char> distinctSymbols = fileList.
                Aggregate<String>((x, y) => x + y).
                ToCharArray().
                Distinct().
                Where(x => !Char.IsLetterOrDigit(x)).
                OrderByDescending(x => x);
            List<string[]> splitNames = fileList.Select(x => x.Split(distinctSymbols.ToArray<char>(), StringSplitOptions.RemoveEmptyEntries)).ToList();
            HashSet<string> vocab = new HashSet<string>();

            foreach (string[] tokens in splitNames)
            {
                foreach (string token in tokens)
                {
                    vocab.Add(token);
                }
            }
            List<string> index = vocab.OrderBy(x => x).ToList();
            ParsedNames = splitNames.Select(x => x.Select(y => index.FindIndex(z => z == y).ToString()).ToList()).ToList();
            //todo: boolean index

            
        }

        
    }
}
