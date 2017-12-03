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
            this.maxLength = new System.Windows.Forms.Label();
            this.maxLenText = new System.Windows.Forms.TextBox();
            this.debugData = new System.Windows.Forms.RichTextBox();
            this.fileListButton = new System.Windows.Forms.Button();
            this.ClusterBox = new System.Windows.Forms.ComboBox();
            this.ShowClusterButton = new System.Windows.Forms.Button();
            this.fileListView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.fileListView)).BeginInit();
            this.SuspendLayout();
            // 
            // maxLength
            // 
            this.maxLength.AutoSize = true;
            this.maxLength.Location = new System.Drawing.Point(18, 525);
            this.maxLength.Name = "maxLength";
            this.maxLength.Size = new System.Drawing.Size(63, 13);
            this.maxLength.TabIndex = 1;
            this.maxLength.Text = "Max Length";
            // 
            // maxLenText
            // 
            this.maxLenText.Location = new System.Drawing.Point(87, 522);
            this.maxLenText.Name = "maxLenText";
            this.maxLenText.ReadOnly = true;
            this.maxLenText.Size = new System.Drawing.Size(100, 20);
            this.maxLenText.TabIndex = 2;
            // 
            // debugData
            // 
            this.debugData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugData.Location = new System.Drawing.Point(12, 548);
            this.debugData.Name = "debugData";
            this.debugData.Size = new System.Drawing.Size(1230, 139);
            this.debugData.TabIndex = 3;
            this.debugData.Text = "";
            // 
            // fileListButton
            // 
            this.fileListButton.Location = new System.Drawing.Point(12, 484);
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
            this.ClusterBox.Location = new System.Drawing.Point(139, 484);
            this.ClusterBox.Name = "ClusterBox";
            this.ClusterBox.Size = new System.Drawing.Size(121, 21);
            this.ClusterBox.TabIndex = 5;
            // 
            // ShowClusterButton
            // 
            this.ShowClusterButton.Enabled = false;
            this.ShowClusterButton.Location = new System.Drawing.Point(266, 482);
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
            this.fileListView.Size = new System.Drawing.Size(1254, 466);
            this.fileListView.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 699);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.ShowClusterButton);
            this.Controls.Add(this.ClusterBox);
            this.Controls.Add(this.fileListButton);
            this.Controls.Add(this.debugData);
            this.Controls.Add(this.maxLenText);
            this.Controls.Add(this.maxLength);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label maxLength;
        private System.Windows.Forms.TextBox maxLenText;
        private System.Windows.Forms.RichTextBox debugData;
        private System.Windows.Forms.Button fileListButton;
        private System.Windows.Forms.ComboBox ClusterBox;
        private System.Windows.Forms.Button ShowClusterButton;
        private System.Windows.Forms.DataGridView fileListView;
    }
}

