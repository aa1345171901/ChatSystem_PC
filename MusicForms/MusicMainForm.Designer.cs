using QQ_piracy.Model;

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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbMinForm = new System.Windows.Forms.PictureBox();
            this.pbMaxForm = new System.Windows.Forms.PictureBox();
            this.pbCloseForm = new System.Windows.Forms.PictureBox();
            this.labelListCount = new System.Windows.Forms.Label();
            this.pbHiFi = new System.Windows.Forms.PictureBox();
            this.pbMusicStyle = new System.Windows.Forms.PictureBox();
            this.pbListCount = new System.Windows.Forms.PictureBox();
            this.pbLike = new System.Windows.Forms.PictureBox();
            this.pbLyric = new System.Windows.Forms.PictureBox();
            this.btnPlayMode = new System.Windows.Forms.Button();
            this.labelMusicDetail = new System.Windows.Forms.Label();
            this.pbSmallAlbum = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.pbLyricClose = new System.Windows.Forms.PictureBox();
            this.pbLyricMin = new System.Windows.Forms.PictureBox();
            this.pbFavoriteUser = new System.Windows.Forms.PictureBox();
            this.pbUserLocal = new System.Windows.Forms.PictureBox();
            this.pbBackGroundUser = new System.Windows.Forms.PictureBox();
            this.tbMusicVolume = new System.Windows.Forms.TrackBar();
            this.panelMusicVlume = new System.Windows.Forms.Panel();
            this.lvSongList = new System.Windows.Forms.ListView();
            this.columnNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSinger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pbAddSong = new System.Windows.Forms.PictureBox();
            this.lbNoResult = new System.Windows.Forms.Label();
            this.MyMusic = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripnotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPlayMode = new System.Windows.Forms.ToolStripMenuItem();
            this.notiTsmiSingleLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.notiTsmiShuffle = new System.Windows.Forms.ToolStripMenuItem();
            this.notiTsmiListLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSong = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.cmsSongListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveSongFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPlayModeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSingleLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShuffle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiListLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListSongMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNext = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipListView = new System.Windows.Forms.ToolTip(this.components);
            this.timerToolTIp = new System.Windows.Forms.Timer(this.components);
            this.timerLyrc = new System.Windows.Forms.Timer(this.components);
            this.panelListSong = new QQ_piracy.Model.NewPanel(this.components);
            this.labelClearSongList = new System.Windows.Forms.Label();
            this.pbListSongClose = new System.Windows.Forms.PictureBox();
            this.lbListSong = new System.Windows.Forms.ListBox();
            this.labelListSong = new System.Windows.Forms.Label();
            this.panelMenu = new QQ_piracy.Model.NewPanel(this.components);
            this.lbMenu = new System.Windows.Forms.ListBox();
            this.panelSetting = new QQ_piracy.Model.NewPanel(this.components);
            this.labelNickName = new System.Windows.Forms.Label();
            this.txtSreachSongName = new System.Windows.Forms.TextBox();
            this.pbFace = new System.Windows.Forms.PictureBox();
            this.panelPlayControl = new QQ_piracy.Model.NewPanel(this.components);
            this.pbVolume = new System.Windows.Forms.PictureBox();
            this.tackBarMove = new System.Windows.Forms.TrackBar();
            this.labelMusicTimer = new System.Windows.Forms.Label();
            this.panelLyrc = new QQ_piracy.Model.NewPanel(this.components);
            this.panelLyricLabels = new QQ_piracy.Model.NewPanel(this.components);
            this.panelLyricIng = new System.Windows.Forms.Panel();
            this.labelLyricIng = new System.Windows.Forms.Label();
            this.labelLyric1 = new System.Windows.Forms.Label();
            this.labelLyric2 = new System.Windows.Forms.Label();
            this.labelLyric3 = new System.Windows.Forms.Label();
            this.labelLyric4 = new System.Windows.Forms.Label();
            this.labelLyric6 = new System.Windows.Forms.Label();
            this.labelLyric5 = new System.Windows.Forms.Label();
            this.labelLyric7 = new System.Windows.Forms.Label();
            this.labelLyric8 = new System.Windows.Forms.Label();
            this.labelLyric9 = new System.Windows.Forms.Label();
            this.labelLyric10 = new System.Windows.Forms.Label();
            this.labelLyric11 = new System.Windows.Forms.Label();
            this.labelNoLyric = new System.Windows.Forms.Label();
            this.linkLabelAddLyrc = new System.Windows.Forms.LinkLabel();
            this.panelUser = new QQ_piracy.Model.NewPanel(this.components);
            this.labelFavoriteListUser = new System.Windows.Forms.Label();
            this.labelFavoriteListCountUser = new System.Windows.Forms.Label();
            this.labelLoclaListCountUser = new System.Windows.Forms.Label();
            this.labelLocalListUser = new System.Windows.Forms.Label();
            this.separator2 = new System.Windows.Forms.Label();
            this.labelSelfMusicList = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.pbUserFace = new System.Windows.Forms.PictureBox();
            this.labelUserNickName = new System.Windows.Forms.Label();
            this.labelUserId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaxForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHiFi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusicStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbListCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLyric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmallAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLyricClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLyricMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavoriteUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGroundUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).BeginInit();
            this.panelMusicVlume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddSong)).BeginInit();
            this.contextMenuStripnotify.SuspendLayout();
            this.cmsSongListMenu.SuspendLayout();
            this.cmsPlayModeMenu.SuspendLayout();
            this.cmsListSongMenu.SuspendLayout();
            this.panelListSong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbListSongClose)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).BeginInit();
            this.panelPlayControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarMove)).BeginInit();
            this.panelLyrc.SuspendLayout();
            this.panelLyricLabels.SuspendLayout();
            this.panelLyricIng.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserFace)).BeginInit();
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
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.AxWmp_PlayStateChange);
            // 
            // pbMinForm
            // 
            this.pbMinForm.Image = ((System.Drawing.Image)(resources.GetObject("pbMinForm.Image")));
            this.pbMinForm.Location = new System.Drawing.Point(878, 15);
            this.pbMinForm.Name = "pbMinForm";
            this.pbMinForm.Padding = new System.Windows.Forms.Padding(6);
            this.pbMinForm.Size = new System.Drawing.Size(30, 30);
            this.pbMinForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinForm.TabIndex = 22;
            this.pbMinForm.TabStop = false;
            this.toolTip1.SetToolTip(this.pbMinForm, "最小化");
            this.pbMinForm.Click += new System.EventHandler(this.FormControlButton_Click);
            this.pbMinForm.MouseEnter += new System.EventHandler(this.MoveEnter_PanelSeting);
            this.pbMinForm.MouseLeave += new System.EventHandler(this.MoveLeave_PanelSeting);
            // 
            // pbMaxForm
            // 
            this.pbMaxForm.Image = ((System.Drawing.Image)(resources.GetObject("pbMaxForm.Image")));
            this.pbMaxForm.Location = new System.Drawing.Point(909, 16);
            this.pbMaxForm.Name = "pbMaxForm";
            this.pbMaxForm.Padding = new System.Windows.Forms.Padding(6);
            this.pbMaxForm.Size = new System.Drawing.Size(28, 28);
            this.pbMaxForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMaxForm.TabIndex = 23;
            this.pbMaxForm.TabStop = false;
            this.toolTip1.SetToolTip(this.pbMaxForm, "最大化");
            this.pbMaxForm.Click += new System.EventHandler(this.FormControlButton_Click);
            this.pbMaxForm.MouseEnter += new System.EventHandler(this.MoveEnter_PanelSeting);
            this.pbMaxForm.MouseLeave += new System.EventHandler(this.MoveLeave_PanelSeting);
            // 
            // pbCloseForm
            // 
            this.pbCloseForm.Image = ((System.Drawing.Image)(resources.GetObject("pbCloseForm.Image")));
            this.pbCloseForm.Location = new System.Drawing.Point(938, 15);
            this.pbCloseForm.Name = "pbCloseForm";
            this.pbCloseForm.Padding = new System.Windows.Forms.Padding(8);
            this.pbCloseForm.Size = new System.Drawing.Size(30, 30);
            this.pbCloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCloseForm.TabIndex = 24;
            this.pbCloseForm.TabStop = false;
            this.toolTip1.SetToolTip(this.pbCloseForm, "关闭");
            this.pbCloseForm.Click += new System.EventHandler(this.FormControlButton_Click);
            this.pbCloseForm.MouseEnter += new System.EventHandler(this.MoveEnter_PanelSeting);
            this.pbCloseForm.MouseLeave += new System.EventHandler(this.MoveLeave_PanelSeting);
            // 
            // labelListCount
            // 
            this.labelListCount.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelListCount.ForeColor = System.Drawing.Color.Silver;
            this.labelListCount.Location = new System.Drawing.Point(946, 30);
            this.labelListCount.Name = "labelListCount";
            this.labelListCount.Size = new System.Drawing.Size(41, 25);
            this.labelListCount.TabIndex = 22;
            this.toolTip1.SetToolTip(this.labelListCount, "播放列表");
            this.labelListCount.Click += new System.EventHandler(this.btnSongList_Click);
            this.labelListCount.MouseLeave += new System.EventHandler(this.pbListCount_MouseLeave);
            this.labelListCount.MouseHover += new System.EventHandler(this.pbListCount_MouseHover);
            // 
            // pbHiFi
            // 
            this.pbHiFi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbHiFi.Image = global::QQ_piracy.Properties.Resources.HiFi;
            this.pbHiFi.Location = new System.Drawing.Point(777, 12);
            this.pbHiFi.Name = "pbHiFi";
            this.pbHiFi.Size = new System.Drawing.Size(48, 48);
            this.pbHiFi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHiFi.TabIndex = 19;
            this.pbHiFi.TabStop = false;
            this.toolTip1.SetToolTip(this.pbHiFi, "开启HiFi独占模式（功能暂未开启）");
            this.pbHiFi.MouseLeave += new System.EventHandler(this.pbHiFi_MouseLeave);
            this.pbHiFi.MouseHover += new System.EventHandler(this.pbHiFi_MouseHover);
            // 
            // pbMusicStyle
            // 
            this.pbMusicStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbMusicStyle.Image = global::QQ_piracy.Properties.Resources.音效;
            this.pbMusicStyle.Location = new System.Drawing.Point(713, 12);
            this.pbMusicStyle.Name = "pbMusicStyle";
            this.pbMusicStyle.Size = new System.Drawing.Size(48, 48);
            this.pbMusicStyle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMusicStyle.TabIndex = 19;
            this.pbMusicStyle.TabStop = false;
            this.toolTip1.SetToolTip(this.pbMusicStyle, "点击开启音效（功能暂未开启）");
            this.pbMusicStyle.MouseLeave += new System.EventHandler(this.pbMusicStyle_MouseLeave);
            this.pbMusicStyle.MouseHover += new System.EventHandler(this.pbMusicStyle_MouseHover);
            // 
            // pbListCount
            // 
            this.pbListCount.Image = global::QQ_piracy.Properties.Resources.列表;
            this.pbListCount.Location = new System.Drawing.Point(926, 24);
            this.pbListCount.Name = "pbListCount";
            this.pbListCount.Size = new System.Drawing.Size(25, 25);
            this.pbListCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbListCount.TabIndex = 19;
            this.pbListCount.TabStop = false;
            this.toolTip1.SetToolTip(this.pbListCount, "播放列表");
            this.pbListCount.Click += new System.EventHandler(this.btnSongList_Click);
            this.pbListCount.MouseLeave += new System.EventHandler(this.pbListCount_MouseLeave);
            this.pbListCount.MouseHover += new System.EventHandler(this.pbListCount_MouseHover);
            // 
            // pbLike
            // 
            this.pbLike.Image = global::QQ_piracy.Properties.Resources.收藏;
            this.pbLike.Location = new System.Drawing.Point(883, 24);
            this.pbLike.Name = "pbLike";
            this.pbLike.Size = new System.Drawing.Size(22, 22);
            this.pbLike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLike.TabIndex = 19;
            this.pbLike.TabStop = false;
            this.toolTip1.SetToolTip(this.pbLike, "收藏");
            this.pbLike.Click += new System.EventHandler(this.pbLikeBtnClick);
            // 
            // pbLyric
            // 
            this.pbLyric.Image = global::QQ_piracy.Properties.Resources.词;
            this.pbLyric.Location = new System.Drawing.Point(841, 21);
            this.pbLyric.Name = "pbLyric";
            this.pbLyric.Size = new System.Drawing.Size(30, 30);
            this.pbLyric.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLyric.TabIndex = 19;
            this.pbLyric.TabStop = false;
            this.toolTip1.SetToolTip(this.pbLyric, "显示桌面歌词");
            this.pbLyric.MouseLeave += new System.EventHandler(this.pbLyric_MouseLeave);
            this.pbLyric.MouseHover += new System.EventHandler(this.pbLyric_MouseHover);
            // 
            // btnPlayMode
            // 
            this.btnPlayMode.BackgroundImage = global::QQ_piracy.Properties.Resources.随机播放;
            this.btnPlayMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayMode.FlatAppearance.BorderSize = 0;
            this.btnPlayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMode.Location = new System.Drawing.Point(621, 25);
            this.btnPlayMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayMode.Name = "btnPlayMode";
            this.btnPlayMode.Size = new System.Drawing.Size(25, 25);
            this.btnPlayMode.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnPlayMode, "随机播放");
            this.btnPlayMode.UseVisualStyleBackColor = true;
            this.btnPlayMode.BackgroundImageChanged += new System.EventHandler(this.btnPlayMode_BackgroundImageChanged);
            this.btnPlayMode.Click += new System.EventHandler(this.btnPlayMode_Click);
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
            this.toolTip1.SetToolTip(this.labelMusicDetail, "音乐名 - 歌手");
            // 
            // pbSmallAlbum
            // 
            this.pbSmallAlbum.BackgroundImage = global::QQ_piracy.Properties.Resources.zzz;
            this.pbSmallAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSmallAlbum.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbSmallAlbum.Location = new System.Drawing.Point(185, 3);
            this.pbSmallAlbum.Name = "pbSmallAlbum";
            this.pbSmallAlbum.Size = new System.Drawing.Size(64, 64);
            this.pbSmallAlbum.TabIndex = 19;
            this.pbSmallAlbum.TabStop = false;
            this.toolTip1.SetToolTip(this.pbSmallAlbum, "打开音乐详情页");
            this.pbSmallAlbum.Click += new System.EventHandler(this.pbSmallAlbum_Click);
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
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
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
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
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
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            this.pbPlay.MouseLeave += new System.EventHandler(this.pbPlay_MouseLeave);
            this.pbPlay.MouseHover += new System.EventHandler(this.pbPlay_MouseHover);
            // 
            // pbLyricClose
            // 
            this.pbLyricClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLyricClose.Image = global::QQ_piracy.Properties.Resources.lyricClose;
            this.pbLyricClose.Location = new System.Drawing.Point(937, 12);
            this.pbLyricClose.Name = "pbLyricClose";
            this.pbLyricClose.Size = new System.Drawing.Size(40, 40);
            this.pbLyricClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLyricClose.TabIndex = 3;
            this.pbLyricClose.TabStop = false;
            this.toolTip1.SetToolTip(this.pbLyricClose, "收起");
            this.pbLyricClose.Click += new System.EventHandler(this.LyricButtonClick);
            this.pbLyricClose.MouseEnter += new System.EventHandler(this.LyricButtonEnter);
            this.pbLyricClose.MouseLeave += new System.EventHandler(this.LyricButtonLeave);
            // 
            // pbLyricMin
            // 
            this.pbLyricMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLyricMin.Image = global::QQ_piracy.Properties.Resources.lyricMin;
            this.pbLyricMin.Location = new System.Drawing.Point(878, 12);
            this.pbLyricMin.Name = "pbLyricMin";
            this.pbLyricMin.Size = new System.Drawing.Size(40, 40);
            this.pbLyricMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLyricMin.TabIndex = 3;
            this.pbLyricMin.TabStop = false;
            this.toolTip1.SetToolTip(this.pbLyricMin, "最小化");
            this.pbLyricMin.Click += new System.EventHandler(this.LyricButtonClick);
            this.pbLyricMin.MouseEnter += new System.EventHandler(this.LyricButtonEnter);
            this.pbLyricMin.MouseLeave += new System.EventHandler(this.LyricButtonLeave);
            // 
            // pbFavoriteUser
            // 
            this.pbFavoriteUser.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pbFavoriteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbFavoriteUser.Image = global::QQ_piracy.Properties.Resources.starUser;
            this.pbFavoriteUser.Location = new System.Drawing.Point(198, 278);
            this.pbFavoriteUser.Name = "pbFavoriteUser";
            this.pbFavoriteUser.Size = new System.Drawing.Size(125, 125);
            this.pbFavoriteUser.TabIndex = 6;
            this.pbFavoriteUser.TabStop = false;
            this.toolTip1.SetToolTip(this.pbFavoriteUser, "打开收藏音乐列表");
            this.pbFavoriteUser.Click += new System.EventHandler(this.pbUserLocal_Click);
            // 
            // pbUserLocal
            // 
            this.pbUserLocal.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pbUserLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbUserLocal.Image = global::QQ_piracy.Properties.Resources.listUser;
            this.pbUserLocal.Location = new System.Drawing.Point(36, 278);
            this.pbUserLocal.Name = "pbUserLocal";
            this.pbUserLocal.Size = new System.Drawing.Size(125, 125);
            this.pbUserLocal.TabIndex = 6;
            this.pbUserLocal.TabStop = false;
            this.toolTip1.SetToolTip(this.pbUserLocal, "打开本地音乐列表");
            this.pbUserLocal.Click += new System.EventHandler(this.pbUserLocal_Click);
            // 
            // pbBackGroundUser
            // 
            this.pbBackGroundUser.BackColor = System.Drawing.Color.Transparent;
            this.pbBackGroundUser.Image = global::QQ_piracy.Properties.Resources.Ps123_Net_0663;
            this.pbBackGroundUser.Location = new System.Drawing.Point(35, 16);
            this.pbBackGroundUser.Name = "pbBackGroundUser";
            this.pbBackGroundUser.Size = new System.Drawing.Size(731, 203);
            this.pbBackGroundUser.TabIndex = 0;
            this.pbBackGroundUser.TabStop = false;
            this.toolTip1.SetToolTip(this.pbBackGroundUser, "部分功能尚未完善，Σ(っ °Д °;)っ");
            // 
            // tbMusicVolume
            // 
            this.tbMusicVolume.AutoSize = false;
            this.tbMusicVolume.Location = new System.Drawing.Point(6, 11);
            this.tbMusicVolume.Maximum = 100;
            this.tbMusicVolume.Name = "tbMusicVolume";
            this.tbMusicVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicVolume.Size = new System.Drawing.Size(15, 111);
            this.tbMusicVolume.TabIndex = 19;
            this.tbMusicVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMusicVolume.Value = 50;
            this.tbMusicVolume.ValueChanged += new System.EventHandler(this.tbMusicVolume_ValueChanged);
            this.tbMusicVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbMusicVolume_MouseDown);
            // 
            // panelMusicVlume
            // 
            this.panelMusicVlume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelMusicVlume.Controls.Add(this.tbMusicVolume);
            this.panelMusicVlume.Location = new System.Drawing.Point(653, 405);
            this.panelMusicVlume.Name = "panelMusicVlume";
            this.panelMusicVlume.Size = new System.Drawing.Size(25, 140);
            this.panelMusicVlume.TabIndex = 20;
            this.panelMusicVlume.Visible = false;
            this.panelMusicVlume.MouseLeave += new System.EventHandler(this.panelMusicVlume_MouseLeave);
            // 
            // lvSongList
            // 
            this.lvSongList.BackColor = System.Drawing.Color.White;
            this.lvSongList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSongList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNum,
            this.columnName,
            this.columnSinger,
            this.columnAlbum,
            this.columnDuration,
            this.columnSize,
            this.columnTime});
            this.lvSongList.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvSongList.ForeColor = System.Drawing.Color.White;
            this.lvSongList.FullRowSelect = true;
            this.lvSongList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSongList.HideSelection = false;
            this.lvSongList.Location = new System.Drawing.Point(188, 96);
            this.lvSongList.MultiSelect = false;
            this.lvSongList.Name = "lvSongList";
            this.lvSongList.OwnerDraw = true;
            this.lvSongList.Scrollable = false;
            this.lvSongList.Size = new System.Drawing.Size(800, 427);
            this.lvSongList.TabIndex = 0;
            this.lvSongList.UseCompatibleStateImageBehavior = false;
            this.lvSongList.View = System.Windows.Forms.View.Details;
            this.lvSongList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvSongList_DrawColumnHeader);
            this.lvSongList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvSongList_DrawSubItem);
            this.lvSongList.DoubleClick += new System.EventHandler(this.lvSongList_DoubleClick);
            this.lvSongList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSongList_MouseDown);
            this.lvSongList.MouseLeave += new System.EventHandler(this.lvSongList_MouseLeave);
            this.lvSongList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvSongList_MouseMove);
            // 
            // columnNum
            // 
            this.columnNum.Text = "";
            // 
            // columnName
            // 
            this.columnName.Text = "歌名";
            this.columnName.Width = 200;
            // 
            // columnSinger
            // 
            this.columnSinger.Text = "歌手";
            this.columnSinger.Width = 120;
            // 
            // columnAlbum
            // 
            this.columnAlbum.Text = "专辑";
            this.columnAlbum.Width = 100;
            // 
            // columnDuration
            // 
            this.columnDuration.Text = "时长";
            this.columnDuration.Width = 80;
            // 
            // columnSize
            // 
            this.columnSize.Text = "大小";
            this.columnSize.Width = 80;
            // 
            // columnTime
            // 
            this.columnTime.Text = "添加时间";
            this.columnTime.Width = 180;
            // 
            // pbAddSong
            // 
            this.pbAddSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddSong.Image = ((System.Drawing.Image)(resources.GetObject("pbAddSong.Image")));
            this.pbAddSong.Location = new System.Drawing.Point(220, 66);
            this.pbAddSong.Name = "pbAddSong";
            this.pbAddSong.Size = new System.Drawing.Size(96, 24);
            this.pbAddSong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddSong.TabIndex = 20;
            this.pbAddSong.TabStop = false;
            this.pbAddSong.Click += new System.EventHandler(this.pbAddSong_Click);
            this.pbAddSong.MouseEnter += new System.EventHandler(this.MoveEnter_PanelSeting);
            this.pbAddSong.MouseLeave += new System.EventHandler(this.MoveLeave_PanelSeting);
            // 
            // lbNoResult
            // 
            this.lbNoResult.AutoSize = true;
            this.lbNoResult.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNoResult.Location = new System.Drawing.Point(446, 323);
            this.lbNoResult.Name = "lbNoResult";
            this.lbNoResult.Size = new System.Drawing.Size(119, 14);
            this.lbNoResult.TabIndex = 21;
            this.lbNoResult.Text = "没有相关搜索结果";
            // 
            // MyMusic
            // 
            this.MyMusic.ContextMenuStrip = this.contextMenuStripnotify;
            this.MyMusic.Icon = ((System.Drawing.Icon)(resources.GetObject("MyMusic.Icon")));
            this.MyMusic.Text = "音乐播放器";
            this.MyMusic.Visible = true;
            this.MyMusic.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStripnotify
            // 
            this.contextMenuStripnotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsmiPlayMode,
            this.tsmiSong,
            this.tsmiShowMain,
            this.tsmiQuit});
            this.contextMenuStripnotify.Name = "contextMenuStripnotify";
            this.contextMenuStripnotify.Size = new System.Drawing.Size(149, 98);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmiPlayMode
            // 
            this.tsmiPlayMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notiTsmiSingleLoop,
            this.notiTsmiShuffle,
            this.notiTsmiListLoop});
            this.tsmiPlayMode.Name = "tsmiPlayMode";
            this.tsmiPlayMode.Size = new System.Drawing.Size(148, 22);
            this.tsmiPlayMode.Text = "播放模式";
            // 
            // notiTsmiSingleLoop
            // 
            this.notiTsmiSingleLoop.Name = "notiTsmiSingleLoop";
            this.notiTsmiSingleLoop.Size = new System.Drawing.Size(124, 22);
            this.notiTsmiSingleLoop.Text = "单曲循环";
            this.notiTsmiSingleLoop.Click += new System.EventHandler(this.tsmiPlayModeBtn_Click);
            // 
            // notiTsmiShuffle
            // 
            this.notiTsmiShuffle.Name = "notiTsmiShuffle";
            this.notiTsmiShuffle.Size = new System.Drawing.Size(124, 22);
            this.notiTsmiShuffle.Text = "随机播放";
            this.notiTsmiShuffle.Click += new System.EventHandler(this.tsmiPlayModeBtn_Click);
            // 
            // notiTsmiListLoop
            // 
            this.notiTsmiListLoop.Name = "notiTsmiListLoop";
            this.notiTsmiListLoop.Size = new System.Drawing.Size(124, 22);
            this.notiTsmiListLoop.Text = "顺序播放";
            this.notiTsmiListLoop.Click += new System.EventHandler(this.tsmiPlayModeBtn_Click);
            // 
            // tsmiSong
            // 
            this.tsmiSong.Name = "tsmiSong";
            this.tsmiSong.Size = new System.Drawing.Size(148, 22);
            this.tsmiSong.Text = "显示桌面歌词";
            // 
            // tsmiShowMain
            // 
            this.tsmiShowMain.Name = "tsmiShowMain";
            this.tsmiShowMain.Size = new System.Drawing.Size(148, 22);
            this.tsmiShowMain.Text = "显示主菜单";
            this.tsmiShowMain.Click += new System.EventHandler(this.tsmiShowMain_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(148, 22);
            this.tsmiQuit.Text = "退出";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timerPlay
            // 
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // cmsSongListMenu
            // 
            this.cmsSongListMenu.BackColor = System.Drawing.Color.White;
            this.cmsSongListMenu.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmsSongListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSongListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFavorite,
            this.tsmiRemoveSongFromList,
            this.tsmiOpenFilePath});
            this.cmsSongListMenu.Name = "cmsSongListMenu";
            this.cmsSongListMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsSongListMenu.Size = new System.Drawing.Size(188, 82);
            // 
            // tsmiFavorite
            // 
            this.tsmiFavorite.BackColor = System.Drawing.Color.White;
            this.tsmiFavorite.ForeColor = System.Drawing.Color.Black;
            this.tsmiFavorite.Image = global::QQ_piracy.Properties.Resources.喜欢;
            this.tsmiFavorite.Name = "tsmiFavorite";
            this.tsmiFavorite.Size = new System.Drawing.Size(187, 26);
            this.tsmiFavorite.Text = "收藏到歌单(&I)";
            this.tsmiFavorite.Click += new System.EventHandler(this.tsmiFavorite_Click);
            // 
            // tsmiRemoveSongFromList
            // 
            this.tsmiRemoveSongFromList.BackColor = System.Drawing.Color.White;
            this.tsmiRemoveSongFromList.ForeColor = System.Drawing.Color.Black;
            this.tsmiRemoveSongFromList.Image = ((System.Drawing.Image)(resources.GetObject("tsmiRemoveSongFromList.Image")));
            this.tsmiRemoveSongFromList.Name = "tsmiRemoveSongFromList";
            this.tsmiRemoveSongFromList.Size = new System.Drawing.Size(187, 26);
            this.tsmiRemoveSongFromList.Text = "从列表中删除(&D)";
            this.tsmiRemoveSongFromList.Click += new System.EventHandler(this.tsmiRemoveSongFromList_Click);
            // 
            // tsmiOpenFilePath
            // 
            this.tsmiOpenFilePath.BackColor = System.Drawing.Color.White;
            this.tsmiOpenFilePath.ForeColor = System.Drawing.Color.Black;
            this.tsmiOpenFilePath.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpenFilePath.Image")));
            this.tsmiOpenFilePath.Name = "tsmiOpenFilePath";
            this.tsmiOpenFilePath.Size = new System.Drawing.Size(187, 26);
            this.tsmiOpenFilePath.Text = "打开文件位置(&F)";
            this.tsmiOpenFilePath.Click += new System.EventHandler(this.tsmiOpenFilePath_Click);
            // 
            // cmsPlayModeMenu
            // 
            this.cmsPlayModeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsPlayModeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPlayModeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSingleLoop,
            this.tsmiShuffle,
            this.tsmiListLoop});
            this.cmsPlayModeMenu.Name = "cmsPlayModeMenu";
            this.cmsPlayModeMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsPlayModeMenu.Size = new System.Drawing.Size(164, 82);
            // 
            // tsmiSingleLoop
            // 
            this.tsmiSingleLoop.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsmiSingleLoop.ForeColor = System.Drawing.Color.LightGray;
            this.tsmiSingleLoop.Image = global::QQ_piracy.Properties.Resources.单曲循环1;
            this.tsmiSingleLoop.Name = "tsmiSingleLoop";
            this.tsmiSingleLoop.Size = new System.Drawing.Size(163, 26);
            this.tsmiSingleLoop.Text = "    单曲循环";
            this.tsmiSingleLoop.Click += new System.EventHandler(this.tsmiPlayModeBtn_Click);
            // 
            // tsmiShuffle
            // 
            this.tsmiShuffle.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsmiShuffle.ForeColor = System.Drawing.Color.LightGray;
            this.tsmiShuffle.Image = global::QQ_piracy.Properties.Resources.随机播放;
            this.tsmiShuffle.Name = "tsmiShuffle";
            this.tsmiShuffle.Size = new System.Drawing.Size(163, 26);
            this.tsmiShuffle.Text = "    随机播放";
            this.tsmiShuffle.Click += new System.EventHandler(this.tsmiPlayModeBtn_Click);
            // 
            // tsmiListLoop
            // 
            this.tsmiListLoop.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsmiListLoop.ForeColor = System.Drawing.Color.LightGray;
            this.tsmiListLoop.Image = global::QQ_piracy.Properties.Resources.列表循环;
            this.tsmiListLoop.Name = "tsmiListLoop";
            this.tsmiListLoop.Size = new System.Drawing.Size(163, 26);
            this.tsmiListLoop.Text = "    顺序播放";
            this.tsmiListLoop.Click += new System.EventHandler(this.tsmiPlayModeBtn_Click);
            // 
            // cmsListSongMenu
            // 
            this.cmsListSongMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBack,
            this.tsmiPlay,
            this.tsmiNext,
            this.tsmiDelete});
            this.cmsListSongMenu.Name = "cmsListSongMenu";
            this.cmsListSongMenu.Size = new System.Drawing.Size(145, 92);
            // 
            // tsmiBack
            // 
            this.tsmiBack.Name = "tsmiBack";
            this.tsmiBack.Size = new System.Drawing.Size(144, 22);
            this.tsmiBack.Text = "        上一首";
            this.tsmiBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // tsmiPlay
            // 
            this.tsmiPlay.Name = "tsmiPlay";
            this.tsmiPlay.Size = new System.Drawing.Size(144, 22);
            this.tsmiPlay.Text = "        播   放";
            this.tsmiPlay.Click += new System.EventHandler(this.tsmiPlay_Click);
            // 
            // tsmiNext
            // 
            this.tsmiNext.Name = "tsmiNext";
            this.tsmiNext.Size = new System.Drawing.Size(144, 22);
            this.tsmiNext.Text = "        下一首";
            this.tsmiNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(144, 22);
            this.tsmiDelete.Text = "        删   除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolTipListView
            // 
            this.toolTipListView.AutomaticDelay = 0;
            this.toolTipListView.AutoPopDelay = 0;
            this.toolTipListView.InitialDelay = 0;
            this.toolTipListView.ReshowDelay = 0;
            this.toolTipListView.ShowAlways = true;
            // 
            // timerToolTIp
            // 
            this.timerToolTIp.Tick += new System.EventHandler(this.timerToolTip_Tick);
            // 
            // timerLyrc
            // 
            this.timerLyrc.Tick += new System.EventHandler(this.timerLyrc_Tick);
            // 
            // panelListSong
            // 
            this.panelListSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelListSong.Controls.Add(this.labelClearSongList);
            this.panelListSong.Controls.Add(this.pbListSongClose);
            this.panelListSong.Controls.Add(this.lbListSong);
            this.panelListSong.Controls.Add(this.labelListSong);
            this.panelListSong.Location = new System.Drawing.Point(600, 82);
            this.panelListSong.Name = "panelListSong";
            this.panelListSong.Size = new System.Drawing.Size(390, 445);
            this.panelListSong.TabIndex = 22;
            this.panelListSong.Visible = false;
            this.panelListSong.MouseLeave += new System.EventHandler(this.panelListSong_MouseLeave);
            // 
            // labelClearSongList
            // 
            this.labelClearSongList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelClearSongList.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelClearSongList.ForeColor = System.Drawing.Color.LightGray;
            this.labelClearSongList.Location = new System.Drawing.Point(306, 9);
            this.labelClearSongList.Name = "labelClearSongList";
            this.labelClearSongList.Size = new System.Drawing.Size(39, 20);
            this.labelClearSongList.TabIndex = 25;
            this.labelClearSongList.Text = "清空";
            this.labelClearSongList.Click += new System.EventHandler(this.labelClearSongList_Click);
            this.labelClearSongList.MouseLeave += new System.EventHandler(this.labelClearListSong_MouseLeave);
            this.labelClearSongList.MouseHover += new System.EventHandler(this.labelClearListSong_MouseHover);
            // 
            // pbListSongClose
            // 
            this.pbListSongClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pbListSongClose.Image = ((System.Drawing.Image)(resources.GetObject("pbListSongClose.Image")));
            this.pbListSongClose.Location = new System.Drawing.Point(355, 3);
            this.pbListSongClose.Name = "pbListSongClose";
            this.pbListSongClose.Padding = new System.Windows.Forms.Padding(8);
            this.pbListSongClose.Size = new System.Drawing.Size(30, 30);
            this.pbListSongClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbListSongClose.TabIndex = 24;
            this.pbListSongClose.TabStop = false;
            this.pbListSongClose.Click += new System.EventHandler(this.pbListSongClose_Click);
            this.pbListSongClose.MouseEnter += new System.EventHandler(this.MoveEnter_PanelSeting);
            this.pbListSongClose.MouseLeave += new System.EventHandler(this.MoveLeave_PanelSeting);
            // 
            // lbListSong
            // 
            this.lbListSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbListSong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbListSong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbListSong.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbListSong.ForeColor = System.Drawing.Color.White;
            this.lbListSong.FormattingEnabled = true;
            this.lbListSong.Location = new System.Drawing.Point(0, 40);
            this.lbListSong.Name = "lbListSong";
            this.lbListSong.Size = new System.Drawing.Size(388, 392);
            this.lbListSong.TabIndex = 0;
            this.lbListSong.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbListSong_DrawItem);
            this.lbListSong.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbListSong_MeasureItem);
            this.lbListSong.DoubleClick += new System.EventHandler(this.lbListSong_DoubleClick);
            this.lbListSong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbListSong_MouseDown);
            this.lbListSong.MouseLeave += new System.EventHandler(this.panelListSong_MouseLeave);
            this.lbListSong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbListSong_MouseMove);
            // 
            // labelListSong
            // 
            this.labelListSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.labelListSong.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelListSong.ForeColor = System.Drawing.Color.DarkGray;
            this.labelListSong.Location = new System.Drawing.Point(0, 0);
            this.labelListSong.Name = "labelListSong";
            this.labelListSong.Size = new System.Drawing.Size(390, 37);
            this.labelListSong.TabIndex = 1;
            this.labelListSong.Text = "   播放列表为空";
            this.labelListSong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelListSong.MouseLeave += new System.EventHandler(this.panelListSong_MouseLeave);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.panelMenu.Controls.Add(this.lbMenu);
            this.panelMenu.Location = new System.Drawing.Point(-1, 54);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(189, 470);
            this.panelMenu.TabIndex = 23;
            // 
            // lbMenu
            // 
            this.lbMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.lbMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbMenu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbMenu.ForeColor = System.Drawing.Color.White;
            this.lbMenu.FormattingEnabled = true;
            this.lbMenu.Location = new System.Drawing.Point(1, -1);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(185, 466);
            this.lbMenu.TabIndex = 0;
            this.lbMenu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbMenu_DrawItem);
            this.lbMenu.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbMenu_MeasureItem);
            this.lbMenu.SelectedIndexChanged += new System.EventHandler(this.lbMenu_SelectedIndexChanged);
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelSetting.Controls.Add(this.labelNickName);
            this.panelSetting.Controls.Add(this.txtSreachSongName);
            this.panelSetting.Controls.Add(this.pbFace);
            this.panelSetting.Controls.Add(this.pbMinForm);
            this.panelSetting.Controls.Add(this.pbMaxForm);
            this.panelSetting.Controls.Add(this.pbCloseForm);
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(990, 57);
            this.panelSetting.TabIndex = 21;
            this.panelSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelSetting.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // labelNickName
            // 
            this.labelNickName.BackColor = System.Drawing.Color.Transparent;
            this.labelNickName.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelNickName.Location = new System.Drawing.Point(59, 15);
            this.labelNickName.Name = "labelNickName";
            this.labelNickName.Size = new System.Drawing.Size(100, 23);
            this.labelNickName.TabIndex = 28;
            this.labelNickName.Text = "nickName";
            // 
            // txtSreachSongName
            // 
            this.txtSreachSongName.BackColor = System.Drawing.Color.White;
            this.txtSreachSongName.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSreachSongName.ForeColor = System.Drawing.Color.Gray;
            this.txtSreachSongName.Location = new System.Drawing.Point(220, 16);
            this.txtSreachSongName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSreachSongName.Name = "txtSreachSongName";
            this.txtSreachSongName.Size = new System.Drawing.Size(234, 25);
            this.txtSreachSongName.TabIndex = 25;
            this.txtSreachSongName.Text = "输入要搜索的歌曲名";
            this.txtSreachSongName.TextChanged += new System.EventHandler(this.txtSreachSongName_TextChanged);
            this.txtSreachSongName.Enter += new System.EventHandler(this.txtSreachSongName_Enter);
            this.txtSreachSongName.Leave += new System.EventHandler(this.txtSreachSongName_Leave);
            // 
            // pbFace
            // 
            this.pbFace.BackColor = System.Drawing.Color.Transparent;
            this.pbFace.BackgroundImage = global::QQ_piracy.Properties.Resources.zzz;
            this.pbFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFace.Image = global::QQ_piracy.Properties.Resources.mask;
            this.pbFace.Location = new System.Drawing.Point(3, 3);
            this.pbFace.Name = "pbFace";
            this.pbFace.Size = new System.Drawing.Size(50, 50);
            this.pbFace.TabIndex = 27;
            this.pbFace.TabStop = false;
            // 
            // panelPlayControl
            // 
            this.panelPlayControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelPlayControl.Controls.Add(this.labelListCount);
            this.panelPlayControl.Controls.Add(this.pbHiFi);
            this.panelPlayControl.Controls.Add(this.pbMusicStyle);
            this.panelPlayControl.Controls.Add(this.pbListCount);
            this.panelPlayControl.Controls.Add(this.pbLike);
            this.panelPlayControl.Controls.Add(this.pbLyric);
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
            this.panelPlayControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelPlayControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // pbVolume
            // 
            this.pbVolume.Image = global::QQ_piracy.Properties.Resources.声音;
            this.pbVolume.Location = new System.Drawing.Point(653, 25);
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(25, 25);
            this.pbVolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVolume.TabIndex = 19;
            this.pbVolume.TabStop = false;
            this.pbVolume.MouseLeave += new System.EventHandler(this.pbVolume_MouseLeave);
            this.pbVolume.MouseHover += new System.EventHandler(this.pbVolume_MouseHover);
            // 
            // tackBarMove
            // 
            this.tackBarMove.AutoSize = false;
            this.tackBarMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tackBarMove.Location = new System.Drawing.Point(258, 41);
            this.tackBarMove.Maximum = 100;
            this.tackBarMove.Name = "tackBarMove";
            this.tackBarMove.Size = new System.Drawing.Size(356, 15);
            this.tackBarMove.SmallChange = 10;
            this.tackBarMove.TabIndex = 2;
            this.tackBarMove.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tackBarMove.Scroll += new System.EventHandler(this.tackBarMove_Scroll);
            this.tackBarMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tackBarMove_MouseDown);
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
            // panelLyrc
            // 
            this.panelLyrc.BackColor = System.Drawing.Color.Transparent;
            this.panelLyrc.BackgroundImage = global::QQ_piracy.Properties.Resources.wallhaven_12422;
            this.panelLyrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLyrc.Controls.Add(this.panelLyricLabels);
            this.panelLyrc.Controls.Add(this.pbLyricClose);
            this.panelLyrc.Controls.Add(this.pbLyricMin);
            this.panelLyrc.Controls.Add(this.labelNoLyric);
            this.panelLyrc.Controls.Add(this.linkLabelAddLyrc);
            this.panelLyrc.Location = new System.Drawing.Point(0, 0);
            this.panelLyrc.Name = "panelLyrc";
            this.panelLyrc.Size = new System.Drawing.Size(990, 524);
            this.panelLyrc.TabIndex = 29;
            this.panelLyrc.Visible = false;
            this.panelLyrc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelLyrc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // panelLyricLabels
            // 
            this.panelLyricLabels.Controls.Add(this.panelLyricIng);
            this.panelLyricLabels.Controls.Add(this.labelLyric1);
            this.panelLyricLabels.Controls.Add(this.labelLyric2);
            this.panelLyricLabels.Controls.Add(this.labelLyric3);
            this.panelLyricLabels.Controls.Add(this.labelLyric4);
            this.panelLyricLabels.Controls.Add(this.labelLyric6);
            this.panelLyricLabels.Controls.Add(this.labelLyric5);
            this.panelLyricLabels.Controls.Add(this.labelLyric7);
            this.panelLyricLabels.Controls.Add(this.labelLyric8);
            this.panelLyricLabels.Controls.Add(this.labelLyric9);
            this.panelLyricLabels.Controls.Add(this.labelLyric10);
            this.panelLyricLabels.Controls.Add(this.labelLyric11);
            this.panelLyricLabels.Location = new System.Drawing.Point(281, 4);
            this.panelLyricLabels.Name = "panelLyricLabels";
            this.panelLyricLabels.Size = new System.Drawing.Size(461, 515);
            this.panelLyricLabels.TabIndex = 6;
            this.panelLyricLabels.Visible = false;
            // 
            // panelLyricIng
            // 
            this.panelLyricIng.Controls.Add(this.labelLyricIng);
            this.panelLyricIng.Location = new System.Drawing.Point(27, 187);
            this.panelLyricIng.Name = "panelLyricIng";
            this.panelLyricIng.Size = new System.Drawing.Size(402, 42);
            this.panelLyricIng.TabIndex = 5;
            // 
            // labelLyricIng
            // 
            this.labelLyricIng.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyricIng.ForeColor = System.Drawing.Color.Yellow;
            this.labelLyricIng.Location = new System.Drawing.Point(0, 0);
            this.labelLyricIng.Name = "labelLyricIng";
            this.labelLyricIng.Size = new System.Drawing.Size(402, 42);
            this.labelLyricIng.TabIndex = 4;
            this.labelLyricIng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric1
            // 
            this.labelLyric1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric1.ForeColor = System.Drawing.Color.White;
            this.labelLyric1.Location = new System.Drawing.Point(44, 26);
            this.labelLyric1.Name = "labelLyric1";
            this.labelLyric1.Size = new System.Drawing.Size(357, 23);
            this.labelLyric1.TabIndex = 4;
            this.labelLyric1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric2
            // 
            this.labelLyric2.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric2.ForeColor = System.Drawing.Color.White;
            this.labelLyric2.Location = new System.Drawing.Point(44, 66);
            this.labelLyric2.Name = "labelLyric2";
            this.labelLyric2.Size = new System.Drawing.Size(357, 23);
            this.labelLyric2.TabIndex = 4;
            this.labelLyric2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric3
            // 
            this.labelLyric3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric3.ForeColor = System.Drawing.Color.White;
            this.labelLyric3.Location = new System.Drawing.Point(44, 106);
            this.labelLyric3.Name = "labelLyric3";
            this.labelLyric3.Size = new System.Drawing.Size(357, 23);
            this.labelLyric3.TabIndex = 4;
            this.labelLyric3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric4
            // 
            this.labelLyric4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric4.ForeColor = System.Drawing.Color.White;
            this.labelLyric4.Location = new System.Drawing.Point(44, 146);
            this.labelLyric4.Name = "labelLyric4";
            this.labelLyric4.Size = new System.Drawing.Size(357, 23);
            this.labelLyric4.TabIndex = 4;
            this.labelLyric4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric6
            // 
            this.labelLyric6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric6.ForeColor = System.Drawing.Color.White;
            this.labelLyric6.Location = new System.Drawing.Point(44, 248);
            this.labelLyric6.Name = "labelLyric6";
            this.labelLyric6.Size = new System.Drawing.Size(357, 23);
            this.labelLyric6.TabIndex = 4;
            this.labelLyric6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric5
            // 
            this.labelLyric5.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric5.ForeColor = System.Drawing.Color.White;
            this.labelLyric5.Location = new System.Drawing.Point(27, 187);
            this.labelLyric5.Name = "labelLyric5";
            this.labelLyric5.Size = new System.Drawing.Size(402, 42);
            this.labelLyric5.TabIndex = 4;
            this.labelLyric5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric7
            // 
            this.labelLyric7.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric7.ForeColor = System.Drawing.Color.White;
            this.labelLyric7.Location = new System.Drawing.Point(44, 288);
            this.labelLyric7.Name = "labelLyric7";
            this.labelLyric7.Size = new System.Drawing.Size(357, 23);
            this.labelLyric7.TabIndex = 4;
            this.labelLyric7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric8
            // 
            this.labelLyric8.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric8.ForeColor = System.Drawing.Color.White;
            this.labelLyric8.Location = new System.Drawing.Point(44, 328);
            this.labelLyric8.Name = "labelLyric8";
            this.labelLyric8.Size = new System.Drawing.Size(357, 23);
            this.labelLyric8.TabIndex = 4;
            this.labelLyric8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric9
            // 
            this.labelLyric9.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric9.ForeColor = System.Drawing.Color.White;
            this.labelLyric9.Location = new System.Drawing.Point(44, 368);
            this.labelLyric9.Name = "labelLyric9";
            this.labelLyric9.Size = new System.Drawing.Size(357, 23);
            this.labelLyric9.TabIndex = 4;
            this.labelLyric9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric10
            // 
            this.labelLyric10.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric10.ForeColor = System.Drawing.Color.White;
            this.labelLyric10.Location = new System.Drawing.Point(44, 408);
            this.labelLyric10.Name = "labelLyric10";
            this.labelLyric10.Size = new System.Drawing.Size(357, 23);
            this.labelLyric10.TabIndex = 4;
            this.labelLyric10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLyric11
            // 
            this.labelLyric11.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLyric11.ForeColor = System.Drawing.Color.White;
            this.labelLyric11.Location = new System.Drawing.Point(44, 448);
            this.labelLyric11.Name = "labelLyric11";
            this.labelLyric11.Size = new System.Drawing.Size(357, 23);
            this.labelLyric11.TabIndex = 4;
            this.labelLyric11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNoLyric
            // 
            this.labelNoLyric.BackColor = System.Drawing.Color.Transparent;
            this.labelNoLyric.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNoLyric.ForeColor = System.Drawing.Color.Black;
            this.labelNoLyric.Location = new System.Drawing.Point(440, 210);
            this.labelNoLyric.Name = "labelNoLyric";
            this.labelNoLyric.Size = new System.Drawing.Size(111, 23);
            this.labelNoLyric.TabIndex = 2;
            this.labelNoLyric.Text = "暂未找到歌词";
            // 
            // linkLabelAddLyrc
            // 
            this.linkLabelAddLyrc.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelAddLyrc.Location = new System.Drawing.Point(546, 210);
            this.linkLabelAddLyrc.Name = "linkLabelAddLyrc";
            this.linkLabelAddLyrc.Size = new System.Drawing.Size(100, 23);
            this.linkLabelAddLyrc.TabIndex = 1;
            this.linkLabelAddLyrc.TabStop = true;
            this.linkLabelAddLyrc.Text = "添加歌词";
            this.linkLabelAddLyrc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddLyrc_LinkClicked);
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelUser.Controls.Add(this.labelFavoriteListUser);
            this.panelUser.Controls.Add(this.labelFavoriteListCountUser);
            this.panelUser.Controls.Add(this.labelLoclaListCountUser);
            this.panelUser.Controls.Add(this.labelLocalListUser);
            this.panelUser.Controls.Add(this.pbFavoriteUser);
            this.panelUser.Controls.Add(this.pbUserLocal);
            this.panelUser.Controls.Add(this.separator2);
            this.panelUser.Controls.Add(this.labelSelfMusicList);
            this.panelUser.Controls.Add(this.separator);
            this.panelUser.Controls.Add(this.pbUserFace);
            this.panelUser.Controls.Add(this.labelUserNickName);
            this.panelUser.Controls.Add(this.labelUserId);
            this.panelUser.Controls.Add(this.pbBackGroundUser);
            this.panelUser.Location = new System.Drawing.Point(185, 54);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(803, 470);
            this.panelUser.TabIndex = 7;
            // 
            // labelFavoriteListUser
            // 
            this.labelFavoriteListUser.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFavoriteListUser.Location = new System.Drawing.Point(211, 406);
            this.labelFavoriteListUser.Name = "labelFavoriteListUser";
            this.labelFavoriteListUser.Size = new System.Drawing.Size(100, 23);
            this.labelFavoriteListUser.TabIndex = 7;
            this.labelFavoriteListUser.Text = "收藏音乐";
            this.labelFavoriteListUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFavoriteListCountUser
            // 
            this.labelFavoriteListCountUser.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFavoriteListCountUser.Location = new System.Drawing.Point(211, 429);
            this.labelFavoriteListCountUser.Name = "labelFavoriteListCountUser";
            this.labelFavoriteListCountUser.Size = new System.Drawing.Size(100, 23);
            this.labelFavoriteListCountUser.TabIndex = 7;
            this.labelFavoriteListCountUser.Text = "4首歌曲";
            this.labelFavoriteListCountUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLoclaListCountUser
            // 
            this.labelLoclaListCountUser.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLoclaListCountUser.Location = new System.Drawing.Point(50, 429);
            this.labelLoclaListCountUser.Name = "labelLoclaListCountUser";
            this.labelLoclaListCountUser.Size = new System.Drawing.Size(100, 23);
            this.labelLoclaListCountUser.TabIndex = 7;
            this.labelLoclaListCountUser.Text = "4首歌曲";
            this.labelLoclaListCountUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLocalListUser
            // 
            this.labelLocalListUser.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLocalListUser.Location = new System.Drawing.Point(50, 406);
            this.labelLocalListUser.Name = "labelLocalListUser";
            this.labelLocalListUser.Size = new System.Drawing.Size(100, 23);
            this.labelLocalListUser.TabIndex = 7;
            this.labelLocalListUser.Text = "本地音乐";
            this.labelLocalListUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.separator2.Location = new System.Drawing.Point(34, 233);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(100, 2);
            this.separator2.TabIndex = 5;
            // 
            // labelSelfMusicList
            // 
            this.labelSelfMusicList.BackColor = System.Drawing.Color.Transparent;
            this.labelSelfMusicList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelSelfMusicList.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelfMusicList.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.labelSelfMusicList.Location = new System.Drawing.Point(33, 238);
            this.labelSelfMusicList.Name = "labelSelfMusicList";
            this.labelSelfMusicList.Size = new System.Drawing.Size(100, 23);
            this.labelSelfMusicList.TabIndex = 4;
            this.labelSelfMusicList.Text = "自建歌单";
            this.labelSelfMusicList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator
            // 
            this.separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.separator.Location = new System.Drawing.Point(135, 258);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(630, 1);
            this.separator.TabIndex = 3;
            // 
            // pbUserFace
            // 
            this.pbUserFace.BackColor = System.Drawing.Color.Transparent;
            this.pbUserFace.BackgroundImage = global::QQ_piracy.Properties.Resources.zzz;
            this.pbUserFace.Image = global::QQ_piracy.Properties.Resources.Mask2;
            this.pbUserFace.Location = new System.Drawing.Point(378, 54);
            this.pbUserFace.Name = "pbUserFace";
            this.pbUserFace.Size = new System.Drawing.Size(64, 64);
            this.pbUserFace.TabIndex = 2;
            this.pbUserFace.TabStop = false;
            // 
            // labelUserNickName
            // 
            this.labelUserNickName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.labelUserNickName.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUserNickName.Location = new System.Drawing.Point(292, 152);
            this.labelUserNickName.Name = "labelUserNickName";
            this.labelUserNickName.Size = new System.Drawing.Size(247, 23);
            this.labelUserNickName.TabIndex = 1;
            this.labelUserNickName.Text = "nickName";
            this.labelUserNickName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUserId
            // 
            this.labelUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.labelUserId.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelUserId.Location = new System.Drawing.Point(51, 39);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(100, 23);
            this.labelUserId.TabIndex = 1;
            this.labelUserId.Text = "用户ID : ";
            this.labelUserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MusicMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 597);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.panelMusicVlume);
            this.Controls.Add(this.panelListSong);
            this.Controls.Add(this.lvSongList);
            this.Controls.Add(this.lbNoResult);
            this.Controls.Add(this.pbAddSong);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panelPlayControl);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panelLyrc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MusicMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音乐播放器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MusicMainForm_Closed);
            this.Load += new System.EventHandler(this.MusicMainForm_Load);
            this.Shown += new System.EventHandler(this.MusicMainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaxForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHiFi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMusicStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbListCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLyric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmallAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLyricClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLyricMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavoriteUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGroundUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).EndInit();
            this.panelMusicVlume.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddSong)).EndInit();
            this.contextMenuStripnotify.ResumeLayout(false);
            this.cmsSongListMenu.ResumeLayout(false);
            this.cmsPlayModeMenu.ResumeLayout(false);
            this.cmsListSongMenu.ResumeLayout(false);
            this.panelListSong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbListSongClose)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).EndInit();
            this.panelPlayControl.ResumeLayout(false);
            this.panelPlayControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tackBarMove)).EndInit();
            this.panelLyrc.ResumeLayout(false);
            this.panelLyricLabels.ResumeLayout(false);
            this.panelLyricIng.ResumeLayout(false);
            this.panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        /*
        this.panelPlayControl = new NewPanel(this.components); // 用于防止panel闪烁
        this.panelListSong = new NewPanel(this.components);
        this.panelLyrc = new NewPanel(this.components);
        this.panelMenu = new NewPanel(this.components);
        this.panelSetting = new NewPanel(this.components);
        this.panelLyricLabels = new NewPanel(this.components);
        */
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TrackBar tackBarMove;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.Label labelMusicTimer;
        private System.Windows.Forms.Label labelMusicDetail;
        private System.Windows.Forms.PictureBox pbSmallAlbum;
        private System.Windows.Forms.PictureBox pbVolume;
        private System.Windows.Forms.Button btnPlayMode;
        private System.Windows.Forms.TrackBar tbMusicVolume;
        private System.Windows.Forms.Panel panelMusicVlume;
        private System.Windows.Forms.PictureBox pbMusicStyle;
        private System.Windows.Forms.PictureBox pbHiFi;
        private System.Windows.Forms.PictureBox pbListCount;
        private System.Windows.Forms.PictureBox pbLike;
        private System.Windows.Forms.PictureBox pbLyric;
        private System.Windows.Forms.Label labelListCount;
        private System.Windows.Forms.PictureBox pbMinForm;
        private System.Windows.Forms.PictureBox pbMaxForm;
        private System.Windows.Forms.PictureBox pbCloseForm;
        private System.Windows.Forms.Label labelNickName;
        private System.Windows.Forms.ListView lvSongList;
        public System.Windows.Forms.ListBox lbMenu;
        private System.Windows.Forms.ColumnHeader columnNum;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnSinger;
        private System.Windows.Forms.ColumnHeader columnAlbum;
        private System.Windows.Forms.ColumnHeader columnDuration;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.NotifyIcon MyMusic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripnotify;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pbAddSong;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.ContextMenuStrip cmsSongListMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFavorite;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveSongFromList;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFilePath;
        private System.Windows.Forms.Label lbNoResult;
        private System.Windows.Forms.ContextMenuStrip cmsPlayModeMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSingleLoop;
        private System.Windows.Forms.ToolStripMenuItem tsmiListLoop;
        private System.Windows.Forms.ToolStripMenuItem tsmiShuffle;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlayMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiSong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtSreachSongName;
        private System.Windows.Forms.PictureBox pbListSongClose;
        private System.Windows.Forms.Label labelListSong;
        private System.Windows.Forms.ListBox lbListSong;
        private System.Windows.Forms.ToolStripMenuItem notiTsmiSingleLoop;
        private System.Windows.Forms.ToolStripMenuItem notiTsmiListLoop;
        private System.Windows.Forms.ToolStripMenuItem notiTsmiShuffle;
        private System.Windows.Forms.Label labelClearSongList;
        private System.Windows.Forms.ContextMenuStrip cmsListSongMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBack;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlay;
        private System.Windows.Forms.ToolStripMenuItem tsmiNext;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolTip toolTipListView;
        private System.Windows.Forms.Timer timerToolTIp;
        private System.Windows.Forms.Timer timerLyrc;
        private System.Windows.Forms.LinkLabel linkLabelAddLyrc;
        private System.Windows.Forms.Label labelNoLyric;
        private System.Windows.Forms.PictureBox pbLyricMin;
        private System.Windows.Forms.PictureBox pbLyricClose;
        private System.Windows.Forms.Label labelLyric11;
        private System.Windows.Forms.Label labelLyric10;
        private System.Windows.Forms.Label labelLyric9;
        private System.Windows.Forms.Label labelLyric8;
        private System.Windows.Forms.Label labelLyric7;
        private System.Windows.Forms.Label labelLyric6;
        private System.Windows.Forms.Label labelLyric5;
        private System.Windows.Forms.Label labelLyric4;
        private System.Windows.Forms.Label labelLyric3;
        private System.Windows.Forms.Label labelLyric2;
        private System.Windows.Forms.Label labelLyric1;
        private System.Windows.Forms.Panel panelLyricIng;
        private System.Windows.Forms.Label labelLyricIng;
        private NewPanel panelPlayControl;
        private NewPanel panelSetting;
        private NewPanel panelMenu;
        private NewPanel panelListSong;
        private NewPanel panelLyrc;
        private NewPanel panelLyricLabels;
        private System.Windows.Forms.PictureBox pbBackGroundUser;
        public System.Windows.Forms.PictureBox pbFace;
        private System.Windows.Forms.PictureBox pbUserFace;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.Label labelSelfMusicList;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label labelUserNickName;
        private System.Windows.Forms.PictureBox pbUserLocal;
        private System.Windows.Forms.Label separator2;
        private System.Windows.Forms.PictureBox pbFavoriteUser;
        private System.Windows.Forms.Label labelFavoriteListUser;
        private System.Windows.Forms.Label labelLocalListUser;
        private System.Windows.Forms.Label labelLoclaListCountUser;
        private System.Windows.Forms.Label labelFavoriteListCountUser;
        private NewPanel panelUser;
    }
}