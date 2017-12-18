using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Statistics;
using static MathNet.Numerics.Statistics.Statistics;



namespace FileAnalyzer
{
    public partial class Form1 : Form
    {
        Analyzer analyzer = new Analyzer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            
            analyzer.ParseDirectory(@"C:\Downloads");
            
            
        }

        private void SetupFileList()
        {
            fileListView.Columns.Clear();
            fileListView.ScrollBars = ScrollBars.Both;
            fileListView.Columns.Add("fileName", "File Name");
            fileListView.Columns.Add("Cluster", "Cluster");
            fileListView.Columns.Add("decomposition", "Decomposition");

        }

        private void FormatFileList()
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileListButton_Click(object sender, EventArgs e)
        {
            SetupFileList();
            FormatFileList();
            analyzer.Input.EnumerateRowsIndexed().ToList().
                ForEach(x => fileListView.Rows.
                Add(new[] { analyzer.FileList[x.Item1], analyzer.BestClustering[x.Item1].ToString(), x.Item2.Select(y => y.ToString()).Aggregate((a, b) => a + ", " + b) }));
            fileListView.Columns[0].Width = 100;
            fileListView.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);
            fileListView.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCells);
        }

        private void ShowClusterButton_Click(object sender, EventArgs e)
        {
            fileListView.Columns.Clear();
            fileListView.Columns.Add("Dummy", "Dummy");
            
            fileListView.Rows.Add(analyzer.FileList.Count);
            for (int i = 0; i < analyzer.Centroids.Count; i++)
            {
                fileListView.Columns.Add(i.ToString(), "Cluster: " + i);

                

                analyzer.GetCluster(i).Select((x, j) => fileListView.Rows[j].Cells[i+1].Value = x).ToList();
            }
          //  foreach (var item in analyzer.BestClustering)
            {
          //      
          //      analyzer.GetCluster((int)ClusterBox.SelectedItem).ForEach(x => fileListView[]);
            }
            
            
            fileListView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            fileListView.Columns[0].Width = 0;
        }

        private void clusterCovariance_Click(object sender, EventArgs e)
        {
            debugData.Columns.Clear();
            double[][] v = Correlation.PearsonMatrix(analyzer.GetClusterOfInput((int)ClusterBox.SelectedItem).ToArray()).ToRowArrays();
            foreach (double item in v[0])
            {
                debugData.Columns.Add("", "");
            }

            //   debugData.Columns[0].Width = 0;
            debugData.Rows.Add(v.Count());
            for (int i = 0; i < v.Count(); i++)
            {
                double[] row = v[i];
                for (int j = 0; j < row.Count(); j++)
                {
                    debugData.Rows[i].Cells[j].Value = v[i][j];
                    //  debugData.Text += item.Select(x => new String(x.ToString().Take(4).ToArray())).Aggregate((a, b) => a + "  |  " + b);
                    //debugData.Text += '\n';
                }
            }
        }

        private void inpCov_Click(object sender, EventArgs e)
        {
            debugData.Columns.Clear();
            double[][] v = Correlation.PearsonMatrix(analyzer.Input.ToRowArrays()).ToRowArrays();
            foreach (double item in v[0])
            {
                debugData.Columns.Add("", "");
            }

            //   debugData.Columns[0].Width = 0;
            debugData.Rows.Add(v.Count());
            for (int i = 0; i < v.Count(); i++)
            {
                double[] row = v[i];
                for (int j = 0; j < row.Count(); j++)
                {
                    debugData.Rows[i].Cells[j].Value = v[i][j];
                    //  debugData.Text += item.Select(x => new String(x.ToString().Take(4).ToArray())).Aggregate((a, b) => a + "  |  " + b);
                    //debugData.Text += '\n';
                }
            }
        }

        private void ClusterBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void showEstimatesButton_Click(object sender, EventArgs e)
        {
            debugData.Columns.Clear();
           // double[] v = analyzer.Estimate[0];
            //foreach (double item in v)
            {
                debugData.Columns.Add("", "");
            }
            int count = analyzer.Estimate.Count;
            debugData.Rows.Add(count);
            for (int i = 0; i < count; i++)
            {
               // for (int j = 0; j < v.Count(); j++)
                {
                    
                    debugData.Rows[i].Cells[0].Value = analyzer.Estimate[i];
                }
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            analyzer.RunKMeans();
            analyzer.AssignedClusters.Distinct().OrderBy(x => x).ToList().ForEach(x => ClusterBox.Items.Add(x));
            ShowClusterButton.Enabled = true;
            elapsed.Text = analyzer.timer.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analyzer.AccordKMeans();
            ShowClusterButton.Enabled = true;
            elapsed.Text = analyzer.timer.ToString();
        }
    }
}

