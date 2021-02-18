namespace QQ_piracy.MusicForms
{
    partial class MusicMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicMainForm));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.tackBarMove = new System.Windows.Forms.TrackBar();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.panelPlayControl = new System.Windows.Forms.Panel();
            this.pbVolume = new System.Windows.Forms.PictureBox();
            this.btnPlayMode = new System.Windows.Forms.Button();
            this.labelMusicTimer = new System.Windows.Forms.Label();
            this.labelMusicDetail = new System.Windows.Forms.Label();
            this.pbSmallAlbum = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbMusicVolume = new System.Windows.Forms.TrackBar();
            this.panelMusicVlume = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            this.panelPlayControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmallAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).BeginInit();
            this.panelMusicVlume.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(722, 250);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(223, 189);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // tackBarMove
            // 
            this.tackBarMove.AutoSize = false;
            this.tackBarMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tackBarMove.Location = new System.Drawing.Point(258, 43);
            this.tackBarMove.Maximum = 100;
            this.tackBarMove.Name = "tackBarMove";
            this.tackBarMove.Size = new System.Drawing.Size(356, 10);
            this.tackBarMove.TabIndex = 2;
            this.tackBarMove.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // pbNext
            // 
            this.pbNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbNext.Image = global::QQ_piracy.Properties.Resources.下一首;
            this.pbNext.Location = new System.Drawing.Point(133, 18);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(35, 35);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 17;
            this.pbNext.TabStop = false;
            this.toolTip1.SetToolTip(this.pbNext, "下一首");
            this.pbNext.MouseLeave += new System.EventHandler(this.pbNext_MouseLeave);
            this.pbNext.MouseHover += new System.EventHandler(this.pbNext_MouseHover);
            // 
            // pbBack
            // 
            this.pbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbBack.Image = global::QQ_piracy.Properties.Resources.上一首;
            this.pbBack.Location = new System.Drawing.Point(18, 18);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(35, 35);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 16;
            this.pbBack.TabStop = false;
            this.toolTip1.SetToolTip(this.pbBack, "上一首");
            this.pbBack.MouseLeave += new System.EventHandler(this.pbBack_MouseLeave);
            this.pbBack.MouseHover += new System.EventHandler(this.pbBack_MouseHover);
            // 
            // pbPlay
            // 
            this.pbPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbPlay.Image = global::QQ_piracy.Properties.Resources.播放;
            this.pbPlay.Location = new System.Drawing.Point(67, 9);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(50, 50);
            this.pbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlay.TabIndex = 15;
            this.pbPlay.TabStop = false;
            this.toolTip1.SetToolTip(this.pbPlay, "播放/暂停");
            this.pbPlay.MouseLeave += new System.EventHandler(this.pbPlay_MouseLeave);
            this.pbPlay.MouseHover += new System.EventHandler(this.pbPlay_MouseHover);
            // 
            // panelPlayControl
            // 
            this.panelPlayControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelPlayControl.Controls.Add(this.pbVolume);
            this.panelPlayControl.Controls.Add(this.tackBarMove);
            this.panelPlayControl.Controls.Add(this.btnPlayMode);
            this.panelPlayControl.Controls.Add(this.labelMusicTimer);
            this.panelPlayControl.Controls.Add(this.labelMusicDetail);
            this.panelPlayControl.Controls.Add(this.pbSmallAlbum);
            this.panelPlayControl.Controls.Add(this.pbNext);
            this.panelPlayControl.Controls.Add(this.pbBack);
            this.panelPlayControl.Controls.Add(this.pbPlay);
            this.panelPlayControl.Location = new System.Drawing.Point(0, 523);
            this.panelPlayControl.Name = "panelPlayControl";
            this.panelPlayControl.Size = new System.Drawing.Size(990, 70);
            this.panelPlayControl.TabIndex = 18;
            // 
            // pbVolume
            // 
            this.pbVolume.Image = ((System.Drawing.Image)(resources.GetObject("pbVolume.Image")));
            this.pbVolume.Location = new System.Drawing.Point(681, 20);
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(35, 35);
            this.pbVolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVolume.TabIndex = 19;
            this.pbVolume.TabStop = false;
            this.pbVolume.MouseHover += new System.EventHandler(this.pbVolume_MouseHover);
            // 
            // btnPlayMode
            // 
            this.btnPlayMode.BackgroundImage = global::QQ_piracy.Properties.Resources.随机播放;
            this.btnPlayMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayMode.FlatAppearance.BorderSize = 0;
            this.btnPlayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMode.Location = new System.Drawing.Point(632, 20);
            this.btnPlayMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayMode.Name = "btnPlayMode";
            this.btnPlayMode.Size = new System.Drawing.Size(35, 35);
            this.btnPlayMode.TabIndex = 19;
            this.btnPlayMode.UseVisualStyleBackColor = true;
            // 
            // labelMusicTimer
            // 
            this.labelMusicTimer.AutoSize = true;
            this.labelMusicTimer.BackColor = System.Drawing.Color.Transparent;
            this.labelMusicTimer.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMusicTimer.ForeColor = System.Drawing.Color.White;
            this.labelMusicTimer.Location = new System.Drawing.Point(510, 18);
            this.labelMusicTimer.Name = "labelMusicTimer";
            this.labelMusicTimer.Size = new System.Drawing.Size(98, 13);
            this.labelMusicTimer.TabIndex = 21;
            this.labelMusicTimer.Text = "00:00 / 03:50";
            // 
            // labelMusicDetail
            // 
            this.labelMusicDetail.AutoSize = true;
            this.labelMusicDetail.BackColor = System.Drawing.Color.Transparent;
            this.labelMusicDetail.Font = new System.Drawing.Font("幼圆", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMusicDetail.ForeColor = System.Drawing.Color.White;
            this.labelMusicDetail.Location = new System.Drawing.Point(255, 18);
            this.labelMusicDetail.Name = "labelMusicDetail";
            this.labelMusicDetail.Size = new System.Drawing.Size(98, 13);
            this.labelMusicDetail.TabIndex = 20;
            this.labelMusicDetail.Text = "音乐名 - 歌手";
            // 
            // pbSmallAlbum
            // 
            this.pbSmallAlbum.BackgroundImage = global::QQ_piracy.Properties.Resources.defaultSmallAblum;
            this.pbSmallAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSmallAlbum.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbSmallAlbum.Location = new System.Drawing.Point(185, 3);
            this.pbSmallAlbum.Name = "pbSmallAlbum";
            this.pbSmallAlbum.Size = new System.Drawing.Size(64, 64);
            this.pbSmallAlbum.TabIndex = 19;
            this.pbSmallAlbum.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSmallAlbum, "打开音乐详情页");
            // 
            // tbMusicVolume
            // 
            this.tbMusicVolume.AutoSize = false;
            this.tbMusicVolume.Location = new System.Drawing.Point(20, 21);
            this.tbMusicVolume.Name = "tbMusicVolume";
            this.tbMusicVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicVolume.Size = new System.Drawing.Size(15, 104);
            this.tbMusicVolume.TabIndex = 19;
            this.tbMusicVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // panelMusicVlume
            // 
            this.panelMusicVlume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelMusicVlume.Controls.Add(this.tbMusicVolume);
            this.panelMusicVlume.Location = new System.Drawing.Point(671, 397);
            this.panelMusicVlume.Name = "panelMusicVlume";
            this.panelMusicVlume.Size = new System.Drawing.Size(54, 140);
            this.panelMusicVlume.TabIndex = 20;
            this.panelMusicVlume.Visible = false;
            this.panelMusicVlume.MouseLeave += new System.EventHandler(this.panelMusicVlume_MouseLeave);
            // 
            // MusicMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(989, 597);
            this.Controls.Add(this.panelMusicVlume);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panelPlayControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MusicMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音乐播放器";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            this.panelPlayControl.ResumeLayout(false);
            this.panelPlayControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmallAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).EndInit();
            this.panelMusicVlume.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TrackBar tackBarMove;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.Panel panelPlayControl;
        private System.Windows.Forms.Label labelMusicTimer;
        private System.Windows.Forms.Label labelMusicDetail;
        private System.Windows.Forms.PictureBox pbSmallAlbum;
        private System.Windows.Forms.PictureBox pbVolume;
        private System.Windows.Forms.Button btnPlayMode;
        private System.Windows.Forms.TrackBar tbMusicVolume;
        private System.Windows.Forms.Panel panelMusicVlume;
    }
}