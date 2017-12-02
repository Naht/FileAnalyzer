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
            this.fileListView = new System.Windows.Forms.ListView();
            this.maxLength = new System.Windows.Forms.Label();
            this.maxLenText = new System.Windows.Forms.TextBox();
            this.debugData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // fileListView
            // 
            this.fileListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView.Location = new System.Drawing.Point(12, 12);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(1230, 504);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 699);
            this.Controls.Add(this.debugData);
            this.Controls.Add(this.maxLenText);
            this.Controls.Add(this.maxLength);
            this.Controls.Add(this.fileListView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.Label maxLength;
        private System.Windows.Forms.TextBox maxLenText;
        private System.Windows.Forms.RichTextBox debugData;
    }
}

