namespace XsdValidate
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnValidate = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.edXsd = new System.Windows.Forms.RichTextBox();
            this.edData = new System.Windows.Forms.RichTextBox();
            this.edLog = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnValidate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 48);
            this.panel1.TabIndex = 0;
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnValidate.Location = new System.Drawing.Point(29, 8);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(194, 31);
            this.btnValidate.TabIndex = 0;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.edXsd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.edData);
            this.splitContainer1.Size = new System.Drawing.Size(1120, 376);
            this.splitContainer1.SplitterDistance = 524;
            this.splitContainer1.TabIndex = 1;
            // 
            // edXsd
            // 
            this.edXsd.BackColor = System.Drawing.SystemColors.InfoText;
            this.edXsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edXsd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edXsd.ForeColor = System.Drawing.Color.PaleGreen;
            this.edXsd.Location = new System.Drawing.Point(0, 0);
            this.edXsd.Name = "edXsd";
            this.edXsd.Size = new System.Drawing.Size(524, 376);
            this.edXsd.TabIndex = 0;
            this.edXsd.Text = resources.GetString("edXsd.Text");
            // 
            // edData
            // 
            this.edData.BackColor = System.Drawing.SystemColors.InfoText;
            this.edData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edData.ForeColor = System.Drawing.Color.PaleGreen;
            this.edData.Location = new System.Drawing.Point(0, 0);
            this.edData.Name = "edData";
            this.edData.Size = new System.Drawing.Size(592, 376);
            this.edData.TabIndex = 0;
            this.edData.Text = "";
            // 
            // edLog
            // 
            this.edLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.edLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.edLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edLog.ForeColor = System.Drawing.Color.Red;
            this.edLog.Location = new System.Drawing.Point(0, 424);
            this.edLog.Name = "edLog";
            this.edLog.Size = new System.Drawing.Size(1120, 204);
            this.edLog.TabIndex = 1;
            this.edLog.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 628);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.edLog);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xsd Validate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox edXsd;
        private System.Windows.Forms.RichTextBox edData;
        private System.Windows.Forms.RichTextBox edLog;
    }
}

