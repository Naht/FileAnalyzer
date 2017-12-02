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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Analyzer analyzer = new Analyzer();
            SetupFileList();
            analyzer.ParseDirectory(@"C:\MEMES");

            Matrix<double> m = Matrix<double>.Build.Random(10, 10);

            //analyzer.ParsedNames.ForEach(x => fileListView.Items.Add(x.Aggregate((a, b) => a + " " + b)));

            debugData.Text += analyzer.Vocab.Aggregate((x, y) => x + ", " + y);
            //  debugData.Text += "Rows: "+analyzer.Input.RowCount;
            //  debugData.Text += "\nCols: " + analyzer.Input.ColumnCount;
            analyzer.Input.EnumerateRowsIndexed().ToList().ForEach(x => fileListView.Items.Add(new ListViewItem(new[] { analyzer.FileList[x.Item1], x.Item2.Select(y => y.ToString()).Aggregate((a, b) => a + ", " + b) })));
            FormatFileList();
        }

        private void SetupFileList()
        {
            fileListView.Scrollable = true;
            fileListView.View = View.Details;
            
        }

        private void FormatFileList()
        {
            ColumnHeader header = new ColumnHeader();
            header.Text = "File Names";
            header.Width = 100;
            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "Decomposition";

            fileListView.Columns.Add(header);
            fileListView.Columns.Add(header2);
            header2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

