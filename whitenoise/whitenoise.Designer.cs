namespace CodeNote.whitenoise
{
    partial class Whitenoise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Whitenoise));
            this.playlist = new System.Windows.Forms.ListBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // playlist
            // 
            this.playlist.FormattingEnabled = true;
            this.playlist.ItemHeight = 12;
            this.playlist.Location = new System.Drawing.Point(6, 9);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(260, 268);
            this.playlist.TabIndex = 4;
            this.playlist.DoubleClick += new System.EventHandler(this.playlist_DoubleClick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(6, 283);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(260, 45);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            // 
            // Whitenoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 332);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.playlist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Whitenoise";
            this.Text = "白噪音工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Whitenoise_FormClosing);
            this.Load += new System.EventHandler(this.whitenoise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox playlist;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}