using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Statistics;
using Accord.Math;
using Accord.Math.Decompositions;
using Accord.MachineLearning;
using System.Diagnostics;

namespace FileAnalyzer
{
    class Analyzer
    {

        public long timer { get; set; }

        public List<List<Vector<double>>> CentroidHistory { get; set; }
        public List<List<int>> AssignedClusterHistory { get; set; }
        public List<double> Estimate { get; set; }

        public List<int> BestClustering { get; set; }

        public List<int> AssignedClusters { get; set; }
        public List<Vector<double>> Centroids { get; set; }
        public List<string> FileList { get; set; }
        public List<Tuple<string, string>> Vocab { get; set; }
        public List<List<int>> ParsedNames { get; set; }
        public Matrix<double> Input { get; set; }

        public void ParseDirectory(String path)
        {
            FileList = Directory.EnumerateFiles(path).Select(x => Path.GetFileName(x)).ToList();
            IEnumerable<char> distinctSymbols = FileList.
                Aggregate<String>((x, y) => x + y).
                ToCharArray().
                Distinct().
                Where(x => !Char.IsLetter(x)).
                OrderByDescending(x => x);
            List<string[]> splitNames = FileList.Select(x => x.Split(distinctSymbols.ToArray<char>(), StringSplitOptions.RemoveEmptyEntries)).ToList();
            IEnumerable<IEnumerable<Tuple<string, string>>> splitSingleNames = splitNames.Select(x => x.Select(a => Tuple.Create("", a.ToLower())));
            IEnumerable<IEnumerable<Tuple<string, string>>> splitPairNames = splitNames.Select(x=>x.Zip(x.Skip(1), (a, b)=>Tuple.Create(a.ToLower(), b.ToLower())));
            IEnumerable<IEnumerable<Tuple<string, string>>> union = splitPairNames;//splitSingleNames.Zip(splitPairNames, (a, b) => a.Concat(b));
            HashSet<Tuple<string, string>> vocabSet = new HashSet<Tuple<string, string>>();

            foreach (IEnumerable<Tuple<string, string>> tokens in union)
            {
                foreach (Tuple<string, string> token in tokens)
                {
                    vocabSet.Add(token);
                   
                }
            }
            
            Vocab = vocabSet.ToList();
            ParsedNames = union.Select(x => x.Select(y => Vocab.FindIndex(z => z.Item1.ToLower() == y.Item1.ToLower() && z.Item2.ToLower() == y.Item2.ToLower())).ToList()).ToList();
            IEnumerable<double> zeros = Enumerable.Repeat(0.0, Vocab.Count);
            double[] v = ParsedNames
                .Select(x => zeros.Select((a, i) => x.Contains(i) ? /*IndexLookup.IsNumeric(Vocab[i].Item2)?5.0:*/15.0 : 0.0))
                .Aggregate((x, y) => x.Concat(y))
                .ToArray();
            Input = CreateMatrix.Dense(Vocab.Count, ParsedNames.Count, v).Transpose().NormalizeRows(2);

       
       
            
        }

        private void InitCentroids(int centroidCount)
        {

            Centroids = new List<Vector<double>>();
            Random r = new Random();
            int rowCount = Input.RowCount;
            for (int i = 0; i < centroidCount; i++)
            {
                Centroids.Add(Input.Row(r.Next(rowCount)));
            }
        }

        public void RunKMeans(int numberOfCentroids)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            InitCentroids(numberOfCentroids);
            AssignToClusters();
            for (int i = 0; i < 10; i++)
            {
                ComputeNewCentroids();
                AssignToClusters();
            }
            stopwatch.Stop();
            timer = stopwatch.ElapsedTicks;

        }
        public void RunKMeans()
        {
            Estimate = new List<double>();
            AssignedClusterHistory = new List<List<int>>();
            CentroidHistory = new List<List<Vector<double>>>();
         //   for (int i = 0; i<30; i++)
            {
                RunKMeans(50);
                Estimate.Add(ComputeEstimate());
                AssignedClusterHistory.Add(AssignedClusters);
                CentroidHistory.Add(Centroids);
            }

      

            BestClustering = AssignedClusterHistory[Estimate.FindIndex(x=>x==Estimate.Max())];
        }

        private double ComputeEstimate()
        {
            double[] globalMean = Input.ToArray().Mean(0);
            int rowCount = Input.RowCount;
            double[] result = new double[globalMean.Count()];
            double[] explainedVariance = new double[globalMean.Count()];
            double[] unexplainedVariance = new double[globalMean.Count()];
            int Kcount = Centroids.Count;
            
            for (int c = 0; c< Kcount; c++)
            {
                List<double[]> cluster = GetClusterOfInput(c);
                if(cluster.Count == 0) continue;
                double[] clusterMean = cluster.ToArray().Mean(0);
                int clusterObservations = cluster.Count;
                explainedVariance = explainedVariance.Add(


                    clusterMean.Subtract(globalMean).Pow(2).Multiply(clusterObservations).Divide(Kcount-1)


                    );
                foreach (double[] item in cluster)
                {
                    unexplainedVariance = unexplainedVariance.Add(


                    item.Subtract(clusterMean).Pow(2).Divide(rowCount - Kcount)


                    );
                }
                

            }                                                                                                                    
            return explainedVariance.Sum()/unexplainedVariance.Sum();
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
            int columnCount = Input.ColumnCount;
            for (int c = 0; c < Centroids.Count; c++)
            {
                
                int[] clusterIndex =  AssignedClusters.FindAllIndexof(c);
                List<double[]> clusterRows = Input.ToRowArrays().Where((x, i) => clusterIndex.Contains(i)).ToList();

                List<double> newCentroid = new List<double>(Enumerable.Repeat(0.0, Input.ColumnCount));

                int clusterRowCount = clusterRows.Count;
                for (int j = 0; j < clusterRowCount; j++)
                {
                    
                    for (int i = 0; i < columnCount; i++)
                    {
                        newCentroid[i] = (newCentroid[i] + clusterRows[j][i])/2; //vectorize this shit
                    }
                }
                Centroids[c] = CreateVector.Dense(newCentroid.ToArray());
                

               
                
            }
            Centroids.RemoveAll(x => x.Count == 0);
        }

        public List<double[]> GetClusterOfInput(int clusterNumber)
        {
            return Input.ToRowArrays().Where((x, i) => AssignedClusters.FindAllIndexof(clusterNumber).Contains(i)).ToList();
        }

        public List<string> GetCluster(int clusterNumber)
        {
            return FileList.Where((x, i) => BestClustering.FindAllIndexof(clusterNumber).Contains(i)).ToList();
        }
        



        public void AccordKMeans()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            KMeans kmeans = new KMeans(50);
            double[][] v = Input.ToRowArrays();
            KMeansClusterCollection clusters = kmeans.Learn(v);
            AssignedClusters = clusters.Decide(v).ToList();
            BestClustering = AssignedClusters;
            Centroids = clusters.Centroids.Select(x => CreateVector.Dense(x)).ToList();
            stopwatch.Stop();
            timer = stopwatch.ElapsedTicks;
        }
    }
}
