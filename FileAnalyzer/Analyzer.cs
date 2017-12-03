using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace FileAnalyzer
{
    class Analyzer
    {
        public List<List<Vector<double>>> CentroidHistory { get; set; }
        public List<List<int>> AssignedClusterHistory { get; set; }
        public List<double> Estimate { get; set; }

        public List<int> BestClustering { get; set; }

        public List<int> AssignedClusters { get; set; }
        public List<Vector<double>> Centroids { get; set; }
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

       
       
            
        }

        private void InitCentroids(int centroidCount)
        {

            Centroids = new List<Vector<double>>();
            Random r = new Random();
            for (int i = 0; i < centroidCount; i++)
            {
                Centroids.Add(Input.Row(r.Next(Input.RowCount)));
            }
        }

        public void RunKMeans(int numberOfCentroids)
        {
            InitCentroids(numberOfCentroids);
            AssignToClusters();
            for (int i = 0; i < 10; i++)
            {
                ComputeNewCentroids();
                
            }
            

        }
        public void RunKMeans()
        {
            Estimate = new List<double>();
            AssignedClusterHistory = new List<List<int>>();
            CentroidHistory = new List<List<Vector<double>>>();
            for (int i = 2; i<20; i++)
            {
                RunKMeans(i);
                Estimate.Add(ComputeEstimate());
                AssignedClusterHistory.Add(AssignedClusters);
                CentroidHistory.Add(Centroids);
            }

            BestClustering = AssignedClusterHistory[Estimate.FindIndex(x=>x==Estimate.Min())];
        }

        private double ComputeEstimate()
        {
            double result = 0;
            for(int c = 0; c<Centroids.Count; c++)
            {
                foreach (double[] item in GetClusterOfInput(c))
                {
                    result += (CreateVector.Dense(item) - Centroids[c]).L2Norm();
                } 
            }
            return result/Centroids.Count;
        }

        private void AssignToClusters()
        {
            AssignedClusters = new List<int>(Enumerable.Repeat(0, Input.RowCount));
            
            for(int i = 0; i < Input.RowCount; i++)
            {
                double minDist = double.PositiveInfinity;
                double dist = 0;
                for(int c = 0; c< Centroids.Count; c++)
                {
                    dist = (Input.Row(i) - Centroids[c]).L2Norm();
                    if (minDist>dist)
                    {
                        minDist = dist;
                        AssignedClusters[i] = c;
                    }
                }

            }
        }

        private void ComputeNewCentroids()
        {
            for (int c = 0; c < Centroids.Count; c++)
            {
                
                int[] clusterIndex =  AssignedClusters.FindAllIndexof(c);
                List<double[]> clusterRows = Input.ToRowArrays().Where((x, i) => clusterIndex.Contains(i)).ToList();

                List<double> newCentroid = new List<double>(Enumerable.Repeat(0.0, Input.ColumnCount));
                for (int j = 0; j < clusterRows.Count; j++)
                {
                    for (int i = 0; i < Input.ColumnCount; i++)
                    {
                        newCentroid[i] = (newCentroid[i] + clusterRows[j][i])/2;
                    }
                }
                Centroids[c] = CreateVector.Dense(newCentroid.ToArray());
                

               
                
            }
        }

        public List<double[]> GetClusterOfInput(int clusterNumber)
        {
            return Input.ToRowArrays().Where((x, i) => AssignedClusters.FindAllIndexof(clusterNumber).Contains(i)).ToList();
        }

        public List<string> GetCluster(int clusterNumber)
        {
            return FileList.Where((x, i) => BestClustering.FindAllIndexof(clusterNumber).Contains(i)).ToList();
        }
        
    }
}
