namespace Server
{
    partial class File_transfer_tab
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_path_server_send = new System.Windows.Forms.TextBox();
            this.btn_BROWS = new System.Windows.Forms.Button();
            this.btn_SEND = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select file to send to client:";
            // 
            // tb_path_server_send
            // 
            this.tb_path_server_send.Location = new System.Drawing.Point(102, 162);
            this.tb_path_server_send.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_path_server_send.Name = "tb_path_server_send";
            this.tb_path_server_send.Size = new System.Drawing.Size(399, 20);
            this.tb_path_server_send.TabIndex = 5;
            this.tb_path_server_send.WordWrap = false;
            // 
            // btn_BROWS
            // 
            this.btn_BROWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BROWS.Location = new System.Drawing.Point(170, 215);
            this.btn_BROWS.Name = "btn_BROWS";
            this.btn_BROWS.Size = new System.Drawing.Size(81, 35);
            this.btn_BROWS.TabIndex = 8;
            this.btn_BROWS.Text = "BROWSE";
            this.btn_BROWS.UseVisualStyleBackColor = true;
            this.btn_BROWS.Click += new System.EventHandler(this.btn_BROWSE_Click);
            // 
            // btn_SEND
            // 
            this.btn_SEND.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SEND.Location = new System.Drawing.Point(346, 215);
            this.btn_SEND.Name = "btn_SEND";
            this.btn_SEND.Size = new System.Drawing.Size(81, 35);
            this.btn_SEND.TabIndex = 9;
            this.btn_SEND.TabStop = false;
            this.btn_SEND.Text = "SEND";
            this.btn_SEND.UseVisualStyleBackColor = true;
            this.btn_SEND.Click += new System.EventHandler(this.btn_SEND_Click);
            // 
            // File_transfer_tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_SEND);
            this.Controls.Add(this.btn_BROWS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_path_server_send);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "File_transfer_tab";
            this.Text = "File_transfer_tab";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_path_server_send;
        private System.Windows.Forms.Button btn_BROWS;
        private System.Windows.Forms.Button btn_SEND;
    }
}