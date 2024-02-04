using System.Windows.Forms;

namespace Server
{
    partial class KeyLogger
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
            this.LogBx = new System.Windows.Forms.TextBox();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.IPBx = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogBx
            // 
            this.LogBx.BackColor = System.Drawing.SystemColors.ControlText;
            this.LogBx.Font = new System.Drawing.Font("Ubuntu", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBx.ForeColor = System.Drawing.SystemColors.Info;
            this.LogBx.Location = new System.Drawing.Point(12, 92);
            this.LogBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogBx.Multiline = true;
            this.LogBx.Name = "LogBx";
            this.LogBx.ReadOnly = true;
            this.LogBx.Size = new System.Drawing.Size(765, 346);
            this.LogBx.TabIndex = 0;
            // 
            // ExportBtn
            // 
            this.ExportBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExportBtn.Font = new System.Drawing.Font("Ubuntu", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ExportBtn.Location = new System.Drawing.Point(593, 30);
            this.ExportBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(155, 50);
            this.ExportBtn.TabIndex = 1;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = false;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // IPBx
            // 
            this.IPBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPBx.Location = new System.Drawing.Point(86, 30);
            this.IPBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IPBx.Name = "IPBx";
            this.IPBx.ReadOnly = true;
            this.IPBx.Size = new System.Drawing.Size(245, 28);
            this.IPBx.TabIndex = 2;
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Font = new System.Drawing.Font("Ubuntu", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(54, 37);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(26, 21);
            this.IPLabel.TabIndex = 3;
            this.IPLabel.Text = "IP";
            // 
            // KeyLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IPBx);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.LogBx);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KeyLogger";
            this.Text = "KeyLogger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox LogBx;
        private Button ExportBtn;
        private TextBox IPBx;
        private Label IPLabel;
    }
}