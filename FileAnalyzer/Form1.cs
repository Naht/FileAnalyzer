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
            analyzer.ParseDirectory(@"C:\Downloads");

            Matrix<double> m = Matrix<double>.Build.Random(10, 10);
            analyzer.ParsedNames.ForEach(x => fileListView.Items.Add(x.Aggregate((a, b) => a + " " + b)));

        }

        private void SetupFileList()
        {
            fileListView.Scrollable = true;
            fileListView.View = View.Details;
            ColumnHeader header = new ColumnHeader();
            header.Text = "File Names";
            header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            fileListView.Columns.Add(header);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
