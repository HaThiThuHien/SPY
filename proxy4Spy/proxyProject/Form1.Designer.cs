namespace proxyProject
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
            this.IPBx = new System.Windows.Forms.TextBox();
            this.IP_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShareBx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mainBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.KeylogBx = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListenBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.proxyportBx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fileBx = new System.Windows.Forms.TextBox();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // IPBx
            // 
            this.IPBx.Location = new System.Drawing.Point(260, 45);
            this.IPBx.Name = "IPBx";
            this.IPBx.Size = new System.Drawing.Size(229, 22);
            this.IPBx.TabIndex = 0;
            // 
            // IP_label
            // 
            this.IP_label.AutoSize = true;
            this.IP_label.Location = new System.Drawing.Point(157, 51);
            this.IP_label.Name = "IP_label";
            this.IP_label.Size = new System.Drawing.Size(19, 16);
            this.IP_label.TabIndex = 1;
            this.IP_label.Text = "IP";
            this.IP_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Share Screen Port";
            // 
            // ShareBx
            // 
            this.ShareBx.Location = new System.Drawing.Point(260, 177);
            this.ShareBx.MaxLength = 5;
            this.ShareBx.Name = "ShareBx";
            this.ShareBx.Size = new System.Drawing.Size(229, 22);
            this.ShareBx.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Main port";
            // 
            // mainBx
            // 
            this.mainBx.Location = new System.Drawing.Point(260, 83);
            this.mainBx.MaxLength = 5;
            this.mainBx.Name = "mainBx";
            this.mainBx.Size = new System.Drawing.Size(229, 22);
            this.mainBx.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "KeyLogger Port";
            // 
            // KeylogBx
            // 
            this.KeylogBx.Location = new System.Drawing.Point(260, 129);
            this.KeylogBx.MaxLength = 5;
            this.KeylogBx.Name = "KeylogBx";
            this.KeylogBx.Size = new System.Drawing.Size(229, 22);
            this.KeylogBx.TabIndex = 6;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(760, 197);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(126, 42);
            this.AddBtn.TabIndex = 8;
            this.AddBtn.Text = "Add Server";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(178, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(708, 296);
            this.dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IP";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "main port";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Keylogger port";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Share Screen Port";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // ListenBtn
            // 
            this.ListenBtn.Location = new System.Drawing.Point(950, 45);
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(126, 42);
            this.ListenBtn.TabIndex = 10;
            this.ListenBtn.Text = "Start proxy";
            this.ListenBtn.UseVisualStyleBackColor = true;
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Proxy port";
            // 
            // proxyportBx
            // 
            this.proxyportBx.Location = new System.Drawing.Point(681, 51);
            this.proxyportBx.MaxLength = 5;
            this.proxyportBx.Name = "proxyportBx";
            this.proxyportBx.Size = new System.Drawing.Size(229, 22);
            this.proxyportBx.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "File Tranfer port";
            // 
            // fileBx
            // 
            this.fileBx.Location = new System.Drawing.Point(260, 226);
            this.fileBx.MaxLength = 5;
            this.fileBx.Name = "fileBx";
            this.fileBx.Size = new System.Drawing.Size(229, 22);
            this.fileBx.TabIndex = 13;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "File Tranfer port";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 693);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.proxyportBx);
            this.Controls.Add(this.ListenBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeylogBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShareBx);
            this.Controls.Add(this.IP_label);
            this.Controls.Add(this.IPBx);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBx;
        private System.Windows.Forms.Label IP_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ShareBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mainBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KeylogBx;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ListenBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox proxyportBx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fileBx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

