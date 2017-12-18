namespace FileAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elapsed = new System.Windows.Forms.TextBox();
            this.fileListButton = new System.Windows.Forms.Button();
            this.ClusterBox = new System.Windows.Forms.ComboBox();
            this.ShowClusterButton = new System.Windows.Forms.Button();
            this.fileListView = new System.Windows.Forms.DataGridView();
            this.debugData = new System.Windows.Forms.DataGridView();
            this.clusterCovariance = new System.Windows.Forms.Button();
            this.inpCov = new System.Windows.Forms.Button();
            this.showEstimatesButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugData)).BeginInit();
            this.SuspendLayout();
            // 
            // elapsed
            // 
            this.elapsed.Location = new System.Drawing.Point(426, 344);
            this.elapsed.Name = "elapsed";
            this.elapsed.ReadOnly = true;
            this.elapsed.Size = new System.Drawing.Size(204, 20);
            this.elapsed.TabIndex = 2;
            // 
            // fileListButton
            // 
            this.fileListButton.Location = new System.Drawing.Point(12, 339);
            this.fileListButton.Name = "fileListButton";
            this.fileListButton.Size = new System.Drawing.Size(93, 23);
            this.fileListButton.TabIndex = 4;
            this.fileListButton.Text = "Show File List";
            this.fileListButton.UseVisualStyleBackColor = true;
            this.fileListButton.Click += new System.EventHandler(this.fileListButton_Click);
            // 
            // ClusterBox
            // 
            this.ClusterBox.FormattingEnabled = true;
            this.ClusterBox.Location = new System.Drawing.Point(111, 341);
            this.ClusterBox.Name = "ClusterBox";
            this.ClusterBox.Size = new System.Drawing.Size(121, 21);
            this.ClusterBox.TabIndex = 5;
            this.ClusterBox.SelectedIndexChanged += new System.EventHandler(this.ClusterBox_SelectedIndexChanged);
            // 
            // ShowClusterButton
            // 
            this.ShowClusterButton.Enabled = false;
            this.ShowClusterButton.Location = new System.Drawing.Point(924, 341);
            this.ShowClusterButton.Name = "ShowClusterButton";
            this.ShowClusterButton.Size = new System.Drawing.Size(115, 23);
            this.ShowClusterButton.TabIndex = 6;
            this.ShowClusterButton.Text = "Show Cluster";
            this.ShowClusterButton.UseVisualStyleBackColor = true;
            this.ShowClusterButton.Click += new System.EventHandler(this.ShowClusterButton_Click);
            // 
            // fileListView
            // 
            this.fileListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(1254, 333);
            this.fileListView.TabIndex = 7;
            // 
            // debugData
            // 
            this.debugData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debugData.Location = new System.Drawing.Point(0, 370);
            this.debugData.Name = "debugData";
            this.debugData.Size = new System.Drawing.Size(1254, 328);
            this.debugData.TabIndex = 8;
            // 
            // clusterCovariance
            // 
            this.clusterCovariance.Location = new System.Drawing.Point(238, 339);
            this.clusterCovariance.Name = "clusterCovariance";
            this.clusterCovariance.Size = new System.Drawing.Size(75, 23);
            this.clusterCovariance.TabIndex = 9;
            this.clusterCovariance.Text = "Covariance";
            this.clusterCovariance.UseVisualStyleBackColor = true;
            this.clusterCovariance.Click += new System.EventHandler(this.clusterCovariance_Click);
            // 
            // inpCov
            // 
            this.inpCov.Location = new System.Drawing.Point(330, 339);
            this.inpCov.Name = "inpCov";
            this.inpCov.Size = new System.Drawing.Size(75, 23);
            this.inpCov.TabIndex = 10;
            this.inpCov.Text = "Inp Cov\r\n";
            this.inpCov.UseVisualStyleBackColor = true;
            this.inpCov.Click += new System.EventHandler(this.inpCov_Click);
            // 
            // showEstimatesButton
            // 
            this.showEstimatesButton.Location = new System.Drawing.Point(843, 341);
            this.showEstimatesButton.Name = "showEstimatesButton";
            this.showEstimatesButton.Size = new System.Drawing.Size(75, 23);
            this.showEstimatesButton.TabIndex = 12;
            this.showEstimatesButton.Text = "Estimates";
            this.showEstimatesButton.UseVisualStyleBackColor = true;
            this.showEstimatesButton.Click += new System.EventHandler(this.showEstimatesButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(1045, 342);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(112, 23);
            this.runButton.TabIndex = 13;
            this.runButton.Text = "Run K-means";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(725, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Accord K-means";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 699);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.showEstimatesButton);
            this.Controls.Add(this.inpCov);
            this.Controls.Add(this.clusterCovariance);
            this.Controls.Add(this.debugData);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.ShowClusterButton);
            this.Controls.Add(this.ClusterBox);
            this.Controls.Add(this.fileListButton);
            this.Controls.Add(this.elapsed);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox elapsed;
        private System.Windows.Forms.Button fileListButton;
        private System.Windows.Forms.ComboBox ClusterBox;
        private System.Windows.Forms.Button ShowClusterButton;
        private System.Windows.Forms.DataGridView fileListView;
        private System.Windows.Forms.DataGridView debugData;
        private System.Windows.Forms.Button clusterCovariance;
        private System.Windows.Forms.Button inpCov;
        private System.Windows.Forms.Button showEstimatesButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button button1;
    }
}

