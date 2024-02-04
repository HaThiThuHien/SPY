using System.Drawing;
using System.Windows.Forms;

namespace Server
{
    partial class DashBoardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardForm));
            this.ConnectBx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectBx
            // 
            this.ConnectBx.BackColor = System.Drawing.SystemColors.ControlText;
            this.ConnectBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBx.ForeColor = System.Drawing.SystemColors.Info;
            this.ConnectBx.Location = new System.Drawing.Point(12, 28);
            this.ConnectBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnectBx.Multiline = true;
            this.ConnectBx.Name = "ConnectBx";
            this.ConnectBx.ReadOnly = true;
            this.ConnectBx.Size = new System.Drawing.Size(525, 386);
            this.ConnectBx.TabIndex = 0;
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 437);
            this.Controls.Add(this.ConnectBx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashBoardForm";
            this.Load += new System.EventHandler(this.DashBoardForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox ConnectBx;
    }
}