using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    class Analyzer
    {
        public List<string> FileList { get; set; }
        public List<string> Vocab { get; set; }
        public List<List<string>> ParsedNames { get; set; }
        public Matrix<double> Input { get; set; }

        public void ParseDirectory(String path)
        {
            FileList = Directory.EnumerateFiles(path).Select(x => Path.GetFileName(x)).ToList();
            IEnumerable<char> distinctSymbols = FileList.
                Aggregate<String>((x, y) => x + y).
                ToCharArray().
                Distinct().
                Where(x => !Char.IsLetterOrDigit(x)).
                OrderByDescending(x => x);
            List<string[]> splitNames = FileList.Select(x => x.Split(distinctSymbols.ToArray<char>(), StringSplitOptions.RemoveEmptyEntries)).ToList();
            HashSet<string> vocabSet = new HashSet<string>();

            foreach (string[] tokens in splitNames)
            {
                foreach (string token in tokens)
                {
                    vocabSet.Add(token.ToLower());
                }
            }
            
            Vocab = vocabSet.ToList();
            ParsedNames = splitNames.Select(x => x.Select(y => Vocab.FindIndex(z => z.ToLower() == y.ToLower()).ToString()).ToList()).ToList();
           
            double[] v = ParsedNames
                .Select(x => Enumerable.Repeat(0.0, Vocab.Count).Select((a, i) => x.Contains(i.ToString()) ? 1.0 : 0.0))
                .Aggregate((x, y) => x.Concat(y))
                .ToArray();
            Input = CreateMatrix.Dense(Vocab.Count, ParsedNames.Count, v).Transpose();
            String s3 = ";";
            
        }

        
    }
}
