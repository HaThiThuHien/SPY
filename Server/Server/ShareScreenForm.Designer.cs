namespace Server
{
    partial class ShareScreenForm
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
            this.ScreenPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenPicture
            // 
            this.ScreenPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScreenPicture.Location = new System.Drawing.Point(27, 12);
            this.ScreenPicture.Name = "ScreenPicture";
            this.ScreenPicture.Size = new System.Drawing.Size(1239, 665);
            this.ScreenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenPicture.TabIndex = 0;
            this.ScreenPicture.TabStop = false;
            // 
            // ShareScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 689);
            this.Controls.Add(this.ScreenPicture);
            this.Name = "ShareScreenForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ScreenPicture;
    }
}