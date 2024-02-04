namespace Server
{
    partial class ManageForm
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
            this.share_screen = new System.Windows.Forms.Button();
            this.Shut_down = new System.Windows.Forms.Button();
            this.Key_logger = new System.Windows.Forms.Button();
            this.File_trans = new System.Windows.Forms.Button();
            this.ScreenPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // share_screen
            // 
            this.share_screen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.share_screen.BackColor = System.Drawing.Color.Pink;
            this.share_screen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.share_screen.Location = new System.Drawing.Point(64, 359);
            this.share_screen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.share_screen.Name = "share_screen";
            this.share_screen.Size = new System.Drawing.Size(124, 52);
            this.share_screen.TabIndex = 0;
            this.share_screen.Text = "SHARE SCREEN";
            this.share_screen.UseVisualStyleBackColor = false;
            this.share_screen.Click += new System.EventHandler(this.share_screen_Click);
            // 
            // Shut_down
            // 
            this.Shut_down.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Shut_down.BackColor = System.Drawing.Color.Pink;
            this.Shut_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shut_down.Location = new System.Drawing.Point(205, 359);
            this.Shut_down.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Shut_down.Name = "Shut_down";
            this.Shut_down.Size = new System.Drawing.Size(124, 52);
            this.Shut_down.TabIndex = 1;
            this.Shut_down.Text = "SHUT DOWN";
            this.Shut_down.UseVisualStyleBackColor = false;
            this.Shut_down.Click += new System.EventHandler(this.Shut_down_Click);
            // 
            // Key_logger
            // 
            this.Key_logger.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Key_logger.BackColor = System.Drawing.Color.Pink;
            this.Key_logger.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key_logger.Location = new System.Drawing.Point(346, 359);
            this.Key_logger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Key_logger.Name = "Key_logger";
            this.Key_logger.Size = new System.Drawing.Size(124, 52);
            this.Key_logger.TabIndex = 2;
            this.Key_logger.Text = "KEY LOGGER";
            this.Key_logger.UseVisualStyleBackColor = false;
            this.Key_logger.Click += new System.EventHandler(this.Key_logger_Click);
            // 
            // File_trans
            // 
            this.File_trans.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.File_trans.BackColor = System.Drawing.Color.Pink;
            this.File_trans.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.File_trans.Location = new System.Drawing.Point(493, 359);
            this.File_trans.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.File_trans.Name = "File_trans";
            this.File_trans.Size = new System.Drawing.Size(124, 52);
            this.File_trans.TabIndex = 3;
            this.File_trans.Text = "FILE TRANS";
            this.File_trans.UseVisualStyleBackColor = false;
            this.File_trans.Click += new System.EventHandler(this.File_trans_Click);
            // 
            // ScreenPicture
            // 
            this.ScreenPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenPicture.BackColor = System.Drawing.Color.Transparent;
            this.ScreenPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScreenPicture.Location = new System.Drawing.Point(68, 24);
            this.ScreenPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ScreenPicture.Name = "ScreenPicture";
            this.ScreenPicture.Size = new System.Drawing.Size(544, 305);
            this.ScreenPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenPicture.TabIndex = 4;
            this.ScreenPicture.TabStop = false;
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Server.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(668, 433);
            this.Controls.Add(this.ScreenPicture);
            this.Controls.Add(this.File_trans);
            this.Controls.Add(this.Key_logger);
            this.Controls.Add(this.Shut_down);
            this.Controls.Add(this.share_screen);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageForm";
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.Menu_Tab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button share_screen;
        private System.Windows.Forms.Button Shut_down;
        private System.Windows.Forms.Button Key_logger;
        private System.Windows.Forms.Button File_trans;
        private System.Windows.Forms.PictureBox ScreenPicture;
    }
}

