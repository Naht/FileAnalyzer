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

            
            listView1.Scrollable = true;
            listView1.View = View.Details;
            ColumnHeader header = new ColumnHeader();

            header.Text = "File Names";
            
            listView1.Columns.Add(header);

            List<String> fileList = Directory.EnumerateFiles(@"C:\Downloads").Select(x => Path.GetFileName(x)).ToList();
            

            
            IEnumerable<char> distinctSymbols = fileList.
                Aggregate<String>((x, y)=>x+y).
                ToCharArray().
                Distinct().
                Where(x => !Char.IsLetterOrDigit(x)).
                OrderByDescending(x=>x);
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
            List<List<string>> parsedNames = splitNames.Select(x => x.Select(y => index.FindIndex(z=>z==y).ToString()).ToList()).ToList();
            //todo: boolean index
            richTextBox1.Text += new string(distinctSymbols.ToArray());
            parsedNames.ForEach(x => listView1.Items.Add(x.Aggregate((a, b)=>a+" "+b)));
            header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            string maxLength = fileList.Max(x => x.Length).ToString();
            maxLenText.Text = maxLength;
            Matrix<double> m = Matrix<double>.Build.Random(10, 10);


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
