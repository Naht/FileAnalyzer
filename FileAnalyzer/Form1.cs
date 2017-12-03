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
         
            
            analyzer.ParseDirectory(@"C:\MEMES");

            Matrix<double> m = Matrix<double>.Build.Random(10, 10);

            //analyzer.ParsedNames.ForEach(x => fileListView.Items.Add(x.Aggregate((a, b) => a + " " + b)));

            debugData.Text += analyzer.Vocab.Aggregate((x, y) => x + ", " + y);
            //  debugData.Text += "Rows: "+analyzer.Input.RowCount;
            //  debugData.Text += "\nCols: " + analyzer.Input.ColumnCount;
           

            analyzer.RunKMeans();
            analyzer.AssignedClusters.Distinct().OrderBy(x=>x).ToList().ForEach(x => ClusterBox.Items.Add(x));
            debugData.Clear();
            for(int i = 0; i<analyzer.Estimate.Count; i++)
            {
                debugData.Text += ("-- " + i + ":: " + analyzer.Estimate[i] + "\n");
            }
            
            
            ShowClusterButton.Enabled = true;
            
        }

        private void SetupFileList()
        {
            fileListView.Columns.Clear();
            fileListView.ScrollBars = ScrollBars.Both;
            fileListView.Columns.Add("fileName", "File Name");
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
                Add(new[] { analyzer.FileList[x.Item1], x.Item2.Select(y => y.ToString()).Aggregate((a, b) => a + ", " + b) }));
            fileListView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ShowClusterButton_Click(object sender, EventArgs e)
        {
            fileListView.Columns.Clear();
            fileListView.Columns.Add("fileName", "File Name");
            analyzer.GetCluster((int)ClusterBox.SelectedItem).ForEach(x => fileListView.Rows.Add(x));
            fileListView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
    }
}

