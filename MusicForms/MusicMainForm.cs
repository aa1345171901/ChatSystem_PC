namespace QQ_piracy.MusicForms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Microsoft.WindowsAPICodePack.Taskbar;
    using QQ_piracy.Model;
    using QQ_piracy.Properties;
    using MenuItem = QQ_piracy.Model.MenuItem;

    public partial class MusicMainForm : Form
    {
        // 打开文件的默认文件位置
        private const string DefaultSongsFilePath = @"D:\KwDownload";
        private string localSongsFilePath = Application.StartupPath + "\\songListHistory.txt"; // 本地音乐的记录文件
        private string favoriteSongsFilePath = Application.StartupPath + "\\favoriteSongs.txt"; // 本地音乐的记录文件
        private string currentSongFilePath = Application.StartupPath + "\\currentSongs.txt"; // 记录退出前播放的歌曲以及部分用户设置

        SongsInfo currSelectedSong = new SongsInfo(null);       // 用于查看详情，打开本地歌曲右键菜单
        SongsInfo currPlaySong = new SongsInfo(null);       // 记录当前选中播放的歌曲

        // 用于保存本地歌曲的链表
        private List<SongsInfo> localSongsList = new List<SongsInfo>();
        private List<SongsInfo> favoriteSongsList = new List<SongsInfo>(); // 用于保存收藏歌曲
        private List<SongsInfo> oringinListSong;                // 用于搜索功能
        private List<SongsInfo> listSong = new List<SongsInfo>();                // 播放列表
        private int currIndex = 0; // 用于记录在播放播放列表第几首歌曲
        private int currIndexSelected = 0; // 用于记录在播放播放列表选中的索引

        private ThumbnailToolbarButton ttbbtnPlayPause;  // 用于底部的缩略图的播放按钮 ico
        private ThumbnailToolbarButton ttbbtnPre;
        private ThumbnailToolbarButton ttbbtnNext;

        private int[] randomList;           // 随机播放序列
        private int randomListIndex = 0;    // 序列索引
        private int jumpSongIndex;          // 跳过当前播放的歌曲

        private string[,] lrc = new string[2, 500]; // 保存歌词和当前进度

        // 随机0，单曲循环1，列表循环2
        public enum PlayMode
        {
            Shuffle = 0,
            SingleLoop,
            ListLoop,
        }

        public PlayMode CurrPlayMode = PlayMode.Shuffle;

        Point downPoint; // 用于设置拖动设置的位置

        List<MenuItem> menuItemList;    // 界面左边的菜单列表
        List<string> songItemList = new List<string>();    // 播放列表 显示的歌曲名

        public MusicMainForm()
        {
            InitializeComponent();
            // testAWM.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(AxWmp_PlayStateChange);

            MenuItem item1 = new MenuItem(Resources.list, "本地音乐");
            MenuItem item2 = new MenuItem(Resources.favorite, "收藏音乐");
            MenuItem item3 = new MenuItem(Resources.user, "User");
            MenuItem item4 = new MenuItem(Resources.album, "Album");
            this.menuItemList = new List<MenuItem>();
            menuItemList.Add(item1);
            menuItemList.Add(item2);
            menuItemList.Add(item3);
            menuItemList.Add(item4);

            lbMenu.Items.Add("本地音乐");
            lbMenu.Items.Add("收藏音乐");
            lbMenu.Items.Add("Music library");
            lbMenu.Items.Add("User");

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);    // 分别是宽和高
            lvSongList.SmallImageList = imgList;

            MyColorTable myColorTable = new MyColorTable();
            cmsSongListMenu.Renderer = new ToolStripProfessionalRenderer(myColorTable);
            cmsSongListMenu.ForeColor = Color.White;
            cmsSongListMenu.BackColor = Color.FromArgb(48, 47, 51);

            pbAddSong.Visible = false;
        }

        private void MusicMainForm_Load(object sender, EventArgs e)
        {
            // 设置文件打开窗口（添加音乐）可多选
            this.openFileDialog1.Multiselect = true;

            // 重置播放器状态信息
            ReloadStatus();

            // 读取用户设置
            ReadSettings(currentSongFilePath);

            // 读取播放器列表历史记录
            localSongsList = ReadHistorySongsList(localSongsFilePath);
            favoriteSongsList = ReadHistorySongsList(favoriteSongsFilePath);

            // 默认进入本地音乐列表
            AddSongsToListView(localSongsList);
            lvSongList.BringToFront();
            tsmiFavorite.Visible = true;
            pbAddSong.Visible = true;
            axWindowsMediaPlayer1.settings.volume = tbMusicVolume.Value;

            axWindowsMediaPlayer1.URL = currPlaySong.FilePath;
            lbMenu.SelectedIndex = 0;
            // 设置专辑图片控件到顶部页面（z-index)
            // pbAlbumImage.BringToFront();

            // 设置开机自启
            StarUp("0");
        }

        /// <summary>
        /// 主窗体关闭
        /// </summary>
        private void MusicMainForm_Closed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
            Application.Exit();
            this.Dispose();
        }

        private void MusicMainForm_Shown(object sender, EventArgs e)
        {
            // 暂停按钮
            ttbbtnPlayPause = new ThumbnailToolbarButton(Properties.Resources.播放1, "播放");
            ttbbtnPlayPause.Enabled = true;
            ttbbtnPlayPause.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(pbPlay_Click);

            // 上一首按钮
            ttbbtnPre = new ThumbnailToolbarButton(Properties.Resources.上一首1, "上一首");
            ttbbtnPre.Enabled = true;
            ttbbtnPre.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(pbBack_Click);

            // 下一首按钮
            ttbbtnNext = new ThumbnailToolbarButton(Properties.Resources.下一首1, "下一首");
            ttbbtnNext.Enabled = true;
            ttbbtnNext.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(pbNext_Click);
            TaskbarManager.Instance.ThumbnailToolbars.AddButtons(this.Handle, ttbbtnPre, ttbbtnPlayPause, ttbbtnNext);
        }

        /// <summary>
        /// 播放器状态改变触发事件
        /// </summary>
        private void AxWmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0: // Stopped 未知状态
                    break;

                case 1: // Stopped 停止
                    timerPlay.Stop();
                    pbPlay.Image = Resources.播放;
                    ttbbtnPlayPause.Icon = Resources.播放1;
                    ReloadStatus();
                    break;

                case 2: // Paused 暂停
                    timerPlay.Stop();
                    break;

                case 3: // Playing 正在播放
                    timerPlay.Start();

                    // 显示专辑图片
                    // pbAlbumImage.Image = currPlaySong.AlbumImage;
                    pbSmallAlbum.BackgroundImage = currPlaySong.SmallAblum;

                    // 保存用户设置
                    SaveSettings();

                    // 显示歌曲标题名字
                    labelMusicDetail.Text = currPlaySong.FileName + "-" + currPlaySong.Artist;
                    if (currPlaySong.FileName.Length > 30)
                    {
                        labelMusicDetail.Text = currPlaySong.FileName.Substring(0, 30) + "...";
                    }

                    // 播放列表数字，设置各种text
                    labelListCount.Text = listSong.Count.ToString();
                    lbListSongSetting();
                    labelListSong.Text = "   播放列表 - 共计 " + listSong.Count.ToString() + " 首歌曲";
                    toolTip1.SetToolTip(labelMusicDetail, labelMusicDetail.Text);
                    MyMusic.Text = labelMusicDetail.Text;
                    tackBarMove.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                    FavoritePictureSetting();

                    //try
                    //{
                    //    int currIndex = lvSongList.SelectedItems[0].Index;
                    //    lvSongList.SelectedItems.Clear();
                    //    lvSongList.Items[currIndex].Selected = true;    // 设定选中
                    //    lvSongList.Items[currIndex].EnsureVisible();    // 保证可见
                    //    lvSongList.Items[currIndex].Focused = true;
                    //    lvSongList.Select();
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //}

                    pbPlay.Image = Resources.暂停;
                    ttbbtnPlayPause.Icon = Resources.暂停1;
                    break;

                case 4:    // ScanForward
                    //tsslCurrentPlayState.Text = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    //tsslCurrentPlayState.Text = "ScanReverse";
                    break;
                case 6:    // Buffering
                    //tsslCurrentPlayState.Text = "正在缓冲";
                    break;

                case 7:    // Waiting
                    //tsslCurrentPlayState.Text = "Waiting";
                    break;

                case 8:    // MediaEnded
                    //tsslCurrentPlayState.Text = "MediaEnded";
                    break;

                case 9:    // Transitioning
                    //tsslCurrentPlayState.Text = "正在连接";
                    break;

                case 10:   // Ready
                    //tsslCurrentPlayState.Text = "准备就绪";
                    break;

                case 11:   // Reconnecting
                    //tsslCurrentPlayState.Text = "Reconnecting";
                    break;

                case 12:   // Last
                    //tsslCurrentPlayState.Text = "Last";
                    break;
                default:
                    //tsslCurrentPlayState.Text = ("Unknown State: " + e.newState.ToString());
                    break;
            }

            if (axWindowsMediaPlayer1.playState.ToString() == "wmppsMediaEnded")
            {
                // 获取音乐播放文件路径，并添加到播放控件
                string path = GetPath();
                WMPLib.IWMPMedia media = axWindowsMediaPlayer1.newMedia(path);
                axWindowsMediaPlayer1.currentPlaylist.appendItem(media);
                lbListSongSetting();
            }
        }

        /// <summary>
        /// 重置播放器的状态
        /// </summary>
        private void ReloadStatus()
        {
            // 设置专辑封面为默认
            pbSmallAlbum.BackgroundImage = Properties.Resources.defaultSmallAblum;
            labelMusicTimer.Text = "00:00 / 00:00";
            labelMusicDetail.Text = "音乐名 - 歌手";
            toolTip1.SetToolTip(labelMusicDetail, "音乐名 - 歌手");
            tackBarMove.Value = tackBarMove.Maximum / 2;
            tackBarMove.Value = 0;
        }

        /// <summary>
        /// 设置播放模式
        /// </summary>
        private string GetPath()
        {
            // int currIndex = lvSongList.SelectedItems[0].Index;
            switch (CurrPlayMode)
            {
                case PlayMode.ListLoop:
                    if (currIndex < listSong.Count - 1)
                    {
                        // if (currIndex != lvSongList.Items.Count - 1)
                        currIndex += 1;
                    }
                    else
                    {
                        currIndex = 0;
                    }

                    break;
                case PlayMode.SingleLoop:
                    break;
                case PlayMode.Shuffle:
                    // 当前循环结束
                    if (randomListIndex > randomList.Length - 1)
                    {
                        StarNewRound();
                    }

                    // 匹配到需要跳过的歌曲，当前循环结束
                    if (randomList[randomListIndex] == jumpSongIndex)
                    {
                        if (randomListIndex == randomList.Length - 1)
                        {
                            StarNewRound();
                        }
                        else
                        {
                            randomListIndex++;
                        }
                    }

                    currIndex = randomList[randomListIndex++];

                    break;
            }

            // lvSongList.Items[currIndex].Selected = true; // 设定选中
            // lvSongList.Items[currIndex].EnsureVisible(); // 保证可见
            // lvSongList.Items[currIndex].Focused = true;

            // currPlaySong = new SongsInfo(lvSongList.SelectedItems[0].SubItems[7].Text);
            currPlaySong = new SongsInfo(listSong[currIndex].FilePath);
            return currPlaySong.FilePath;
        }

        private void StarNewRound()
        {
            // 重新生成随机序列
            BuildRandomList(listSong.Count);

            // 第二轮开始 播放所有歌曲 不跳过
            jumpSongIndex = -1;
        }

        /// <summary>
        /// 用于创建随机序列，随机播放
        /// </summary>
        private void BuildRandomList(int songListCount)
        {
            randomListIndex = 0;
            randomList = new int[songListCount];

            // 初始化序列
            for (int i = 0; i < songListCount; i++)
            {
                randomList[i] = i;
            }

            // 随机序列
            for (int i = songListCount - 1; i >= 0; i--)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int j = r.Next(0, songListCount - 1);
                swap(randomList, i, j);
            }
        }

        private void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        /// <summary>
        /// 设置开机自启
        /// </summary>
        private void StarUp(string flag)
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("//") + 1);
            Microsoft.Win32.RegistryKey rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (flag.Equals("1"))
            {
                if (rkey == null)
                {
                    rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }

                rkey.SetValue(keyName, path + @"\SimpleMediaPlayer.exe");
            }
            else
            {
                if (rkey != null)
                {
                    rkey.DeleteValue(keyName, false);
                }
            }
        }

        /// <summary>
        /// 鼠标进入上一首图标时
        /// </summary>
        private void pbBack_MouseHover(object sender, EventArgs e)
        {
            pbBack.Image = Resources.上一首hover;
        }

        /// <summary>
        /// 鼠标离开上一首图标时
        /// </summary>
        private void pbBack_MouseLeave(object sender, EventArgs e)
        {
            pbBack.Image = Resources.上一首;
        }

        /// <summary>
        /// 鼠标进入播放图标时
        /// </summary>
        private void pbPlay_MouseHover(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                pbPlay.Image = Resources.暂停hover;
            }
            else
            {
                pbPlay.Image = Resources.播放hover;
            }
        }

        /// <summary>
        /// 鼠标离开播放图标时
        /// </summary>
        private void pbPlay_MouseLeave(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                pbPlay.Image = Resources.暂停;
            }
            else
            {
                pbPlay.Image = Resources.播放;
            }
        }

        /// <summary>
        /// 鼠标进入下一首图标时
        /// </summary>
        private void pbNext_MouseHover(object sender, EventArgs e)
        {
            pbNext.Image = Resources.下一首hover;
        }

        /// <summary>
        /// 鼠标离开下一首图标
        /// </summary>
        private void pbNext_MouseLeave(object sender, EventArgs e)
        {
            pbNext.Image = Resources.下一首;
        }

        /// <summary>
        /// 鼠标进入声音图标
        /// </summary>
        private void pbVolume_MouseHover(object sender, EventArgs e)
        {
            panelMusicVlume.Visible = true;
        }

        /// <summary>
        /// 鼠标出声音图标
        /// </summary>
        private void pbVolume_MouseLeave(object sender, EventArgs e)
        {
            Point p1 = new Point(this.pbVolume.Location.X, this.pbVolume.Location.Y + 523); // 相对mainform pbVolume位置
            Point p2 = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y); // 相对mainform 鼠标位置

            // 判断鼠标是否在panelMusicVlume上，是就不执行，否则就是该panel隐藏
            // bool b = this.RectangleToScreen(panelMusicVlume.ClientRectangle).Contains(MousePosition);
            if ((p1.X - p2.X > 0) || (p1.X - p2.X < -24) || p2.Y > 572)
            {
                panelMusicVlume.Visible = false;
            }
        }

        /// <summary>
        /// 鼠标离开panel
        /// </summary>
        private void panelMusicVlume_MouseLeave(object sender, EventArgs e)
        {
            Point p1 = new Point(this.panelMusicVlume.Location.X, this.panelMusicVlume.Location.Y);
            Point p2 = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);

            // 判断鼠标是否还在该控件上，不在再隐藏
            if ((p1.X - p2.X > 0) || (p1.X - p2.X < -24) || p2.Y < 405)
            {
                panelMusicVlume.Visible = false;
            }
        }

        /// <summary>
        /// 鼠标停留
        /// </summary>
        private void pbMusicStyle_MouseHover(object sender, EventArgs e)
        {
            pbMusicStyle.Image = Resources.音效hover;
        }

        /// <summary>
        /// 鼠标离开
        /// </summary>
        private void pbMusicStyle_MouseLeave(object sender, EventArgs e)
        {
            pbMusicStyle.Image = Resources.音效;
        }

        /// <summary>
        /// Hifi鼠标停留
        /// </summary>
        private void pbHiFi_MouseHover(object sender, EventArgs e)
        {
            pbHiFi.Image = Resources.HiFihover;
        }

        /// <summary>
        /// Hifi鼠标离开
        /// </summary>
        private void pbHiFi_MouseLeave(object sender, EventArgs e)
        {
            pbHiFi.Image = Resources.HiFi;
        }

        /// <summary>
        /// 歌词按钮鼠标停留
        /// </summary>
        private void pbLyric_MouseHover(object sender, EventArgs e)
        {
            pbLyric.Image = Resources.词hover;
        }

        /// <summary>
        /// 歌词按钮鼠标移出
        /// </summary>
        private void pbLyric_MouseLeave(object sender, EventArgs e)
        {
            pbLyric.Image = Resources.词;
        }

        /// <summary>
        /// 收藏按钮鼠标停留
        /// </summary>
        private void pbLike_MouseHover(object sender, EventArgs e)
        {
            if (pbLike.Name == "pbUnLike")
            {
                return;
            }

            pbLike.Image = Resources.收藏hover;
        }

        /// <summary>
        /// 收藏按钮鼠标移出
        /// </summary>
        private void pbLike_MouseLeave(object sender, EventArgs e)
        {
            if (pbLike.Name == "pbUnLike")
            {
                return;
            }

            pbLike.Image = Resources.收藏;
        }

        /// <summary>
        /// 播放列表按钮鼠标停留
        /// </summary>
        private void pbListCount_MouseHover(object sender, EventArgs e)
        {
            pbListCount.Image = Resources.列表hover;
            labelListCount.ForeColor = Color.White;
        }

        /// <summary>
        /// 播放列表按钮鼠标移出
        /// </summary>
        private void pbListCount_MouseLeave(object sender, EventArgs e)
        {
            pbListCount.Image = Resources.列表;
            labelListCount.ForeColor = Color.Silver;
        }

        /// <summary>
        /// 播放列表清空按钮鼠标停留
        /// </summary>
        private void labelClearListSong_MouseHover(object sender, EventArgs e)
        {
            labelClearSongList.ForeColor = Color.White;
        }

        /// <summary>
        /// 播放列表清空按钮鼠标移除
        /// </summary>
        private void labelClearListSong_MouseLeave(object sender, EventArgs e)
        {
            labelClearSongList.ForeColor = Color.LightGray;
        }

        /// <summary>
        /// 设置的panel顶部，的鼠标移入事件
        /// </summary>
        private void MoveEnter_PanelSeting(object sender, EventArgs e)
        {
            PictureBox currPicBox = (PictureBox)sender;
            if (currPicBox.Name == "pbCloseForm")
            {
                currPicBox.Image = Resources.关闭hoover;
            }
            else if (currPicBox.Name == "pbMaxForm")
            {
                currPicBox.Image = Resources.最大化hoover;
            }
            else if (currPicBox.Name == "pbMinForm")
            {
                currPicBox.Image = Resources.最小化hoover;
            }
            else if (currPicBox.Name == "pbAddSong")
            {
                currPicBox.Image = Resources.添加hoover;
            }
            else if (currPicBox.Name == "pbListSongClose")
            {
                currPicBox.Image = Resources.关闭hoover;
            }
        }

        /// <summary>
        /// 设置的panel顶部，的鼠标停留事件
        /// </summary>
        private void MoveLeave_PanelSeting(object sender, EventArgs e)
        {
            PictureBox currPicBox = (PictureBox)sender;
            if (currPicBox.Name == "pbCloseForm")
            {
                currPicBox.Image = Resources.关闭;
            }
            else if (currPicBox.Name == "pbMaxForm")
            {
                currPicBox.Image = Resources.最大化;
            }
            else if (currPicBox.Name == "pbMinForm")
            {
                currPicBox.Image = Resources.最小化;
            }
            else if (currPicBox.Name == "pbAddSong")
            {
                currPicBox.Image = Resources.添加音乐;
            }
            else if (currPicBox.Name == "pbListSongClose")
            {
                currPicBox.Image = Resources.关闭;
            }
        }

        /// <summary>
        /// 拖动窗口点击
        /// </summary>
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// 拖动窗口移动
        /// </summary>
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X, this.Location.Y + e.Y - downPoint.Y);
            }
        }

        /// <summary>
        /// 最大化，最小化，关闭按钮点击事件
        /// </summary>
        private void FormControlButton_Click(object sender, EventArgs e)
        {
            PictureBox currPicBox = (PictureBox)sender;
            if (currPicBox.Name == "pbCloseForm")
            {
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            }
            else if (currPicBox.Name == "pbMaxForm")
            {
                // this.WindowState = FormWindowState.Maximized;
            }
            else if (currPicBox.Name == "pbMinForm")
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// listViewcolumn头部列表重绘
        /// </summary>
        private void lvSongList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            /*e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.Bounds);    // 采用特定颜色绘制标题列
            using (StringFormat sf = new StringFormat())
            {
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                using (Font headerFont = new Font("Helvetica", 10, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Gray, e.Bounds, sf);
                }
            }*/
            int index = e.ColumnIndex;

            e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), e.Bounds);
            TextRenderer.DrawText(e.Graphics, lvSongList.Columns[index].Text, new Font("宋体", 10, FontStyle.Regular), e.Bounds, Color.Gray, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            Pen pen = new Pen(Color.FloralWhite, 2);
            Point p = new Point(e.Bounds.Left - 1, e.Bounds.Top + 1);
            Size s = new Size(e.Bounds.Width, e.Bounds.Height - 2);
            Rectangle r = new Rectangle(p, s);
            e.Graphics.DrawRectangle(pen, r);
        }

        /// <summary>
        /// ListView子物体重绘
        /// </summary>
        private void lvSongList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ItemIndex == -1)
            {
                return;
            }

            e.SubItem.ForeColor = Color.DimGray;

            if (!string.IsNullOrEmpty(e.SubItem.Text))
            {
                this.DrawText(e, e.Graphics, e.Bounds, 2);
            }
        }

        private void DrawText(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r, int paddingLeft)
        {
            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);

            r.X += 1 + paddingLeft; // 重绘图标时，文本右移
            TextRenderer.DrawText(
                g,
                e.SubItem.Text,
                e.SubItem.Font,
                r,
                e.SubItem.ForeColor,
                flags);
        }

        private TextFormatFlags GetFormatFlags(HorizontalAlignment align)
        {
            TextFormatFlags flags =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;

            switch (align)
            {
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
            }

            return flags;
        }

        /// <summary>
        /// 子物体选中操作
        /// </summary>
        private void lvSongList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// 添加音乐的按钮点击事件
        /// </summary>
        private void pbAddSong_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = DefaultSongsFilePath;
            this.openFileDialog1.Filter = "媒体文件|*.mp3;*.wav;*.wma;*.avi;*.mpg;*.asf;*.wmv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    string path = openFileDialog1.FileNames[i];
                    if (!IsExistInList(path))
                    {
                        SongsInfo song = new SongsInfo(path);
                        song.SaveTime = DateTime.Now.ToString();
                        this.localSongsList.Add(song);
                    }
                }
            }

            AddSongsToListView(localSongsList);
            SaveSongsListHistory(localSongsFilePath, localSongsList);

            UpdataOringinSongList();
        }

        /// <summary>
        /// 用于判断该歌曲是否在链表中
        /// </summary>
        private bool IsExistInList(string path)
        {
            for (int i = 0; i < localSongsList.Count; i++)
            {
                if (path == localSongsList[i].FilePath)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 添加歌曲到ListView（lvSongList）中
        /// </summary>
        private void AddSongsToListView(List<SongsInfo> songList)
        {
            lvSongList.BeginUpdate();
            lvSongList.Items.Clear();
            foreach (SongsInfo song in songList)
            {
                string[] songAry = new string[7];
                int currCount = lvSongList.Items.Count + 1;
                if (currCount < 10)
                {
                    songAry[0] = "0" + currCount;
                }
                else
                {
                    songAry[0] = "" + currCount;
                }

                songAry[1] = song.FileName;
                songAry[2] = song.Artist;
                songAry[3] = song.Album;
                songAry[4] = song.Duration;
                songAry[5] = song.Filesize;
                songAry[6] = song.SaveTime;

                ListViewItem lvItem = new ListViewItem(songAry);
                lvItem.SubItems.Add(song.FilePath);
                lvSongList.Items.Add(lvItem);

                WMPLib.IWMPMedia media = axWindowsMediaPlayer1.newMedia(song.FilePath);
                axWindowsMediaPlayer1.currentPlaylist.appendItem(media);
            }

            lvSongList.Columns[0].Text = songList.Count.ToString();
            lvSongList.EndUpdate();
        }

        /// <summary>
        /// 保存歌曲列表到本地的历史记录文件
        /// </summary>
        private void SaveSongsListHistory(string savePath, List<SongsInfo> songsList)
        {
            string saveString = "";
            for (int i = 0; i < songsList.Count; i++)
            {
                saveString += songsList[i].FilePath + "},{" + songsList[i].SaveTime + "};{";
            }

            File.WriteAllText(savePath, saveString);
        }

        /// <summary>
        ///  保存用户设置
        /// </summary>
        private void SaveSettings()
        {
            int volume = tbMusicVolume.Value; // 声音大小
            int palyMode = (int)CurrPlayMode; // 循环模式
            string songPath = ""; // 歌曲文件
            foreach (var item in listSong)
            {
                songPath += item.FilePath + "},{";
            }

            string saveString = volume + "};{" + palyMode + "};{" + currIndex + "};{" + songPath;

            File.WriteAllText(currentSongFilePath, saveString);
        }

        /// <summary>
        /// 读取用户设置
        /// </summary>
        private void ReadSettings(string filePath)
        {
            string readString = "";
            if (File.Exists(filePath))
            {
                readString = File.ReadAllText(filePath);
                if (readString != "")
                {
                    string[] arr = readString.Split(new string[] { "};{" }, StringSplitOptions.None);
                    try
                    {
                        tbMusicVolume.Value = int.Parse(arr[0]); // 声音大小
                        CurrPlayMode = (PlayMode)int.Parse(arr[1]); // 循环模式
                        switch (CurrPlayMode)
                        {
                            case PlayMode.Shuffle:
                                btnPlayMode.BackgroundImage = Resources.随机播放;
                                break;
                            case PlayMode.ListLoop:
                                btnPlayMode.BackgroundImage = Resources.列表循环;
                                break;
                            case PlayMode.SingleLoop:
                                btnPlayMode.BackgroundImage = Resources.单曲循环;
                                break;
                            default:
                                break;
                        }

                        currIndex = int.Parse(arr[2]);
                        string[] songsPath = arr[3].Split(new string[] { "},{" }, StringSplitOptions.None); // 歌曲文件
                        for (int i = 0; i < songsPath.Length - 1; i++)
                        {
                            listSong.Add(new SongsInfo(songsPath[i]));
                        }

                        currPlaySong = listSong[currIndex];

                        // 创建随机序列用于随机播放
                        BuildRandomList(listSong.Count);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                File.Create(filePath);
            }
        }

        /// <summary>
        /// 将历史记录文件读取出来
        /// </summary>
        private List<SongsInfo> ReadHistorySongsList(string filePath)
        {
            List<SongsInfo> resSongList = new List<SongsInfo>();
            string readString = "";
            try
            {
                if (File.Exists(filePath))
                {
                    readString = File.ReadAllText(filePath);
                    if (readString != "")
                    {
                        string[] arr = readString.Split(new string[] { "};{" }, StringSplitOptions.None);
                        for (int i = 0; i < arr.Length - 1; i++)
                        {
                            string[] filePaths = arr[i].Split(new string[] { "},{" }, StringSplitOptions.None);
                            string songFilePath = filePaths[0];
                            if (songFilePath != null && songFilePath != "" && File.Exists(songFilePath))
                            {
                                SongsInfo song = new SongsInfo(songFilePath);
                                string saveTime = filePaths[1];
                                song.SaveTime = saveTime;
                                resSongList.Add(song);
                            }
                        }
                    }
                }
                else
                {
                    File.Create(filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return resSongList;
        }

        /// <summary>
        /// 更新初始的本地音乐lvSongList列表
        /// </summary>
        private void UpdataOringinSongList()
        {
            oringinListSong = new List<SongsInfo>();
            for (int i = 0; i < lvSongList.Items.Count; i++)
            {
                oringinListSong.Add(new SongsInfo(lvSongList.Items[i].SubItems[7].Text));
            }
        }

        /// <summary>
        /// ListView鼠标按下
        /// </summary>
        private void lvSongList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = lvSongList.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    cmsSongListMenu.Visible = true;
                    currSelectedSong = new SongsInfo(lvi.SubItems[7].Text);
                    cmsSongListMenu.Show(Cursor.Position);
                }
                else
                {
                    cmsSongListMenu.Close();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                ListViewItem lvi = lvSongList.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    currPlaySong = new SongsInfo(lvi.SubItems[7].Text);

                    int index = 0;
                    foreach (var item in lvSongList.Items)
                    {
                        if (item == lvi)
                        {
                            break;
                        }

                        index++;
                    }

                    currIndex = index;
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsReady)
                    {
                        FavoritePictureSetting();

                        pbSmallAlbum.BackgroundImage = currPlaySong.SmallAblum;

                        // 显示歌曲标题名字
                        labelMusicDetail.Text = currPlaySong.FileName + "-" + currPlaySong.Artist;
                        if (currPlaySong.FileName.Length > 30)
                        {
                            labelMusicDetail.Text = currPlaySong.FileName.Substring(0, 30) + "...";
                        }

                        toolTip1.SetToolTip(labelMusicDetail, labelMusicDetail.Text);
                        MyMusic.Text = labelMusicDetail.Text;
                        labelMusicTimer.Text = "00:00 / " + currPlaySong.Duration.Remove(0, 3);
                        SettingListSong();
                    }
                    else
                    {
                        BuildRandomList(listSong.Count);
                        jumpSongIndex = currIndex;
                        SettingListSong();
                        axWindowsMediaPlayer1.URL = currPlaySong.FilePath;
                    }
                }
            }
        }

        /// <summary>
        /// 播放按钮双击，播放选中歌曲
        /// </summary>
        private void lvSongList_DoubleClick(object sender, EventArgs e)
        {
            int currIndex = lvSongList.SelectedItems[0].Index;
            this.currIndex = currIndex;
            string songFilePath = lvSongList.Items[currIndex].SubItems[7].Text;

            // 选中的歌曲为正在播放的歌曲
            if (currPlaySong != null && currPlaySong.FilePath == songFilePath)
            {
                if (axWindowsMediaPlayer1.playState.ToString() == "wmppsPlaying")
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    pbPlay.Image = Resources.播放;
                    ttbbtnPlayPause.Icon = Resources.播放1;
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    pbPlay.Image = Resources.暂停;
                    ttbbtnPlayPause.Icon = Resources.暂停1;
                }
            }
            else
            {
                // 选中的为其他歌曲
                BuildRandomList(listSong.Count);
                jumpSongIndex = currIndex;
                currPlaySong = new SongsInfo(songFilePath);
                axWindowsMediaPlayer1.URL = songFilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pbPlay.Image = Resources.暂停;
                ttbbtnPlayPause.Icon = Resources.暂停1;
            }

            SettingListSong();
        }

        string lviBackFile = "";  // 用于计算鼠标是否停留在同一物体上
        int timeCount = 0;        // 计算停留时间
        ListViewItem lvi = null;  // 保存当前物体
        Point mousePoint;  // 记录鼠标位置

        /// <summary>
        /// 歌曲列表listview 鼠标停留添加tip
        /// </summary>
        private void lvSongList_MouseMove(object sender, MouseEventArgs e)
        {
            lvi = lvSongList.GetItemAt(e.X, e.Y);

            if (lvi == null)
            {
                timer1.Stop();
                timeCount = 0;
                toolTipListView.RemoveAll();
                return;
            }

            if (lvi.SubItems[1].Text == lviBackFile)
            {
                if (timeCount < 0)
                {
                    return;
                }

                timer1.Start();
            }
            else
            {
                toolTipListView.RemoveAll();
                timeCount = 0;
                timer1.Stop();
            }

            lviBackFile = lvi.SubItems[1].Text;
        }

        /// <summary>
        /// 离开lvSongList时关闭计时器
        /// </summary>
        private void lvSongList_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            timeCount = 0;
            toolTipListView.RemoveAll();
        }

        /// <summary>
        /// 用于开启tooltip以及计时
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCount += 100;
            if (timeCount >= 1000)
            {
                mousePoint = new Point(lvi.Position.X + (Cursor.Position.X - this.Location.X) - 174, lvi.Position.Y + 20); // +鼠标相对mainForm位置,-去父物体位置
                toolTipListView.Show(
                    "歌名:" + lvi.SubItems[1].Text + "\n歌手:"
            + lvi.SubItems[2].Text + "\n专辑:" + lvi.SubItems[3].Text + "\n时长:"
            + lvi.SubItems[4].Text + "\n大小:" + lvi.SubItems[5].Text + "\n添加时间"
            + lvi.SubItems[6].Text + "\n位置:" + lvi.SubItems[7].Text, lvSongList, mousePoint);
                timeCount = -4000;
            }
        }

        /// <summary>
        /// 上一首按钮点击
        /// </summary>
        private void pbBack_Click(object sender, EventArgs e)
        {
            if (listSong.Count == 0)
            {
                // lvSongList.Items.Count == 0

                // MessageBox.Show("请先添加曲目至目录");
                return;
            }

            // int currIndex = lvSongList.SelectedItems[0].Index;
            if (currIndex > 0)
            {
                timerPlay.Stop();
                currIndex -= 1;
            }
            else
            {
                timerPlay.Stop();

                // currIndex = lvSongList.Items.Count - 1;
                currIndex = listSong.Count - 1;
            }

            // lvSongList.Items[currIndex].Focused = true;
            // lvSongList.Items[currIndex].EnsureVisible();
            // lvSongList.Items[currIndex].Selected = true;

            Play(currIndex);
        }

        /// <summary>
        /// 播放/暂停按钮点击
        /// </summary>
        private void pbPlay_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState.ToString() == "wmppsPlaying")
            {
                // 播放->暂停
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                pbPlay.Image = Resources.播放hover;
                ttbbtnPlayPause.Icon = Resources.播放1;
                return;
            }
            else if (axWindowsMediaPlayer1.playState.ToString() == "wmppsPaused")
            {
                // 暂停->播放
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pbPlay.Image = Resources.暂停hover;
                ttbbtnPlayPause.Icon = Resources.暂停1;
                return;
            }

            if (listSong.Count > 0)
            {
                // 双击播放列表控制
                // Play(lvSongList.SelectedItems[0].Index);

                Play(currIndex);
            }
            else if (currPlaySong != null && currPlaySong.FilePath != "未知")
            {
                axWindowsMediaPlayer1.URL = currPlaySong.FilePath;
            }
            else
            {
                MessageBox.Show("请选择要播放的曲目");
            }
        }

        /// <summary>
        /// 下一首按钮点击
        /// </summary>
        private void pbNext_Click(object sender, EventArgs e)
        {
            if (listSong.Count <= 0)
            {
                return;
            }

            // int currIndex = lvSongList.SelectedItems[0].Index;
            if (currIndex < listSong.Count - 1)
            {
                // currIndex < lvSongList.Items.Count - 1
                timerPlay.Stop();
                currIndex += 1;
            }
            else
            {
                timerPlay.Stop();
                currIndex = 0;
            }

            Play(currIndex);
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        private void Play(int index)
        {
            if (axWindowsMediaPlayer1.playState.ToString() != "wmppsPaused")
            {
                // 生成随机序列
                BuildRandomList(listSong.Count);
                jumpSongIndex = index;
                // currPlaySong = new SongsInfo(lvSongList.SelectedItems[0].SubItems[7].Text);
                currPlaySong = new SongsInfo(listSong[index].FilePath);
                axWindowsMediaPlayer1.URL = currPlaySong.FilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                return;
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

            pbPlay.Image = Resources.暂停hover;
            ttbbtnPlayPause.Icon = Resources.暂停1;
            ttbbtnPlayPause.Tooltip = "暂停";
        }

        /// <summary>
        /// 搜索栏选中
        /// </summary>
        private void txtSreachSongName_Enter(object sender, EventArgs e)
        {
            if (txtSreachSongName.Text == "输入要搜索的歌曲名")
            {
                this.txtSreachSongName.Text = "";
            }
        }

        /// <summary>
        /// 搜索栏非选择
        /// </summary>
        private void txtSreachSongName_Leave(object sender, EventArgs e)
        {
            if (txtSreachSongName.Text == "")
            {
                txtSreachSongName.Text = "输入要搜索的歌曲名";
            }
        }

        /// <summary>
        /// 搜索栏字符改变
        /// </summary>
        private void txtSreachSongName_TextChanged(object sender, EventArgs e)
        {
            lbNoResult.SendToBack();

            // 初始化
            if (txtSreachSongName.Text == "")
            {
                switch (lbMenu.SelectedIndex)
                {
                    case 0:
                        AddSongsToListView(localSongsList);
                        break;
                    case 1:
                        AddSongsToListView(favoriteSongsList);
                        break;
                }

                return;
            }
            else
            {
                List<SongsInfo> resultList = new List<SongsInfo>();

                Dictionary<string, SongsInfo> resultDic = new Dictionary<string, SongsInfo>();
                string strSreach = txtSreachSongName.Text;

                // 设置正则匹配
                Regex r = new Regex(Regex.Escape(strSreach), RegexOptions.IgnoreCase);

                for (int i = 0; i < localSongsList.Count; i++)
                {
                    Match m = r.Match(localSongsList[i].FileName);
                    if (m.Success)
                    {
                        resultDic.Add(localSongsList[i].FilePath, localSongsList[i]);
                    }
                }

                for (int i = 0; i < favoriteSongsList.Count; i++)
                {
                    Match m = r.Match(favoriteSongsList[i].FileName);
                    if (m.Success && !resultDic.ContainsKey(localSongsList[i].FilePath))
                    {
                        resultDic.Add(localSongsList[i].FilePath, localSongsList[i]);
                    }
                }

                if (resultDic.Count > 0)
                {
                    List<SongsInfo> resList = new List<SongsInfo>();
                    foreach (SongsInfo song in resultDic.Values)
                    {
                        resList.Add(song);
                    }

                    AddSongsToListView(resList);
                }
                else
                {
                    lvSongList.Items.Clear();

                    // 没有搜索结果
                    lbNoResult.BringToFront();
                }
            }
        }

        /// <summary>
        /// 设置歌曲的滑动条
        /// </summary>
        private void tackBarMove_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = (double)this.tackBarMove.Value;
        }

        /// <summary>
        /// 音量滑动条值改变，播放器音量也改变
        /// </summary>
        private void tbMusicVolume_ValueChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = tbMusicVolume.Value;
            SaveSettings();
        }

        /// <summary>
        /// 系统托盘显示主菜单
        /// </summary>
        private void tsmiShowMain_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 系统托盘退出
        /// </summary>
        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            MyMusic.Visible = false;
            MyMusic.Dispose();
            this.Close();
        }

        /// <summary>
        /// 系统托盘双击
        /// </summary>
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 收藏音乐,右键子菜单
        /// </summary>
        private void tsmiFavorite_Click(object sender, EventArgs e)
        {
            foreach (SongsInfo song in favoriteSongsList)
            {
                if (currSelectedSong.FilePath == song.FilePath)
                {
                    return;
                }
            }

            SongsInfo songInfo = new SongsInfo(currSelectedSong.FilePath);
            songInfo.SaveTime = DateTime.Now.ToString();
            favoriteSongsList.Add(songInfo);
            SaveSongsListHistory(favoriteSongsFilePath, favoriteSongsList);
        }

        /// <summary>
        /// 从列表中删除
        /// </summary>
        private void tsmiRemoveSongFromList_Click(object sender, EventArgs e)
        {
            DeleteSongFormList deleteSongFormList = new DeleteSongFormList(currSelectedSong.FilePath);
            if (deleteSongFormList.ShowDialog() == DialogResult.OK)
            {
                int removeIndex = lvSongList.SelectedItems[0].Index;
                if (lbMenu.SelectedIndex == 0)
                {
                    localSongsList.RemoveAt(removeIndex);
                    SaveSongsListHistory(localSongsFilePath, localSongsList);
                    AddSongsToListView(localSongsList);
                }
                else if (lbMenu.SelectedIndex == 1)
                {
                    favoriteSongsList.RemoveAt(removeIndex);
                    SaveSongsListHistory(favoriteSongsFilePath, favoriteSongsList);
                    AddSongsToListView(favoriteSongsList);
                }

                UpdataOringinSongList();
            }
        }

        /// <summary>
        /// 打开文件位置
        /// </summary>
        private void tsmiOpenFilePath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Explorer.exe", "/select,\"" + currSelectedSong.FilePath + "\"");
        }

        /// <summary>
        /// 下方收藏按钮点击
        /// </summary>
        private void pbLikeBtnClick(object sender, EventArgs e)
        {
            // 收藏
            PictureBox pb = (PictureBox)sender;
            if (pb.Name == "pbLike")
            {
                pb.Image = Resources.收藏ing;
                toolTip1.SetToolTip(pb, "取消收藏");
                pb.Name = "pbUnLike";

                SongsInfo songInfo = new SongsInfo(currPlaySong.FilePath);
                songInfo.SaveTime = DateTime.Now.ToString();
                favoriteSongsList.Add(songInfo);
                SaveSongsListHistory(favoriteSongsFilePath, favoriteSongsList);
                pb.MouseHover -= pbLike_MouseHover;
                pb.MouseLeave -= pbLike_MouseLeave;
            }
            else
            {
                // 取消收藏
                pb.Image = Resources.收藏hover;
                toolTip1.SetToolTip(pb, "收藏");
                pb.Name = "pbLike";

                int index = 0; // 记录删除的索引
                foreach (var item in favoriteSongsList)
                {
                    if (item.FileName == currPlaySong.FileName)
                    {
                        break;
                    }

                    index++;
                }

                favoriteSongsList.RemoveAt(index);

                SaveSongsListHistory(favoriteSongsFilePath, favoriteSongsList);
                UpdataOringinSongList();
                pb.MouseHover += pbLike_MouseHover;
                pb.MouseLeave += pbLike_MouseLeave;
            }
        }

        /// <summary>
        /// 设置下方收藏按钮是否收藏
        /// </summary>
        private void FavoritePictureSetting()
        {
            foreach (SongsInfo song in favoriteSongsList)
            {
                if (currPlaySong != null && currPlaySong.FilePath == song.FilePath)
                {
                    pbLike.MouseHover -= pbLike_MouseHover;
                    pbLike.MouseLeave -= pbLike_MouseLeave;
                    pbLike.Image = Resources.收藏ing;
                    toolTip1.SetToolTip(pbLike, "取消收藏");
                    pbLike.Name = "pbUnLike";
                    return;
                }
            }

            // 手动添加事件，后期需要移除
            pbLike.MouseHover += pbLike_MouseHover;
            pbLike.MouseLeave += pbLike_MouseLeave;

            pbLike.Image = Resources.收藏;
            toolTip1.SetToolTip(pbLike, "收藏");
            pbLike.Name = "pbLike";
        }

        /// <summary>
        /// 播放模式菜单弹出
        /// </summary>
        private void btnPlayMode_Click(object sender, EventArgs e)
        {
            cmsPlayModeMenu.Visible = true;
            cmsPlayModeMenu.Show(new Point(Cursor.Position.X - 50, Cursor.Position.Y - 100));
        }

        /// <summary>
        /// 播放模式按钮图片更改，toolTip也跟着更改
        /// </summary>
        private void btnPlayMode_BackgroundImageChanged(object sender, EventArgs e)
        {
            switch (CurrPlayMode)
            {
                case PlayMode.Shuffle:
                    toolTip1.SetToolTip(btnPlayMode, "随机播放");
                    break;
                case PlayMode.ListLoop:
                    toolTip1.SetToolTip(btnPlayMode, "顺序播放");
                    break;
                case PlayMode.SingleLoop:
                    toolTip1.SetToolTip(btnPlayMode, "单曲循环");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 播放模式的子菜单按钮点击
        /// </summary>
        private void tsmiPlayModeBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem currTsmi = (ToolStripMenuItem)sender;
            if (currTsmi.Name == "tsmiSingleLoop" || currTsmi.Name == "notiTsmiSingleLoop")
            {
                btnPlayMode.BackgroundImage = Resources.单曲循环1;
                CurrPlayMode = PlayMode.SingleLoop;
            }
            else if (currTsmi.Name == "tsmiShuffle" || currTsmi.Name == "notiTsmiShuffle")
            {
                btnPlayMode.BackgroundImage = Resources.随机播放;
                CurrPlayMode = PlayMode.Shuffle;
            }
            else if (currTsmi.Name == "tsmiListLoop" || currTsmi.Name == "notiTsmiListLoop")
            {
                btnPlayMode.BackgroundImage = Resources.列表循环;
                CurrPlayMode = PlayMode.ListLoop;
            }

            // 保存用户设置
            SaveSettings();
        }

        /// <summary>
        /// 左边的菜单ListBox的子物体绘制
        /// </summary>
        private void lbMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            Bitmap bitmap = new Bitmap(e.Bounds.Width, e.Bounds.Height);

            int index = e.Index;                                // 获取当前要进行绘制的行的序号，从0开始。
            Graphics g = e.Graphics;                            // 获取Graphics对象。

            Graphics tempG = Graphics.FromImage(bitmap);

            tempG.SmoothingMode = SmoothingMode.AntiAlias;          // 使绘图质量最高，即消除锯齿
            tempG.InterpolationMode = InterpolationMode.HighQualityBicubic;
            tempG.CompositingQuality = CompositingQuality.HighQuality;

            Rectangle bound = e.Bounds;                         // 获取当前要绘制的行的一个矩形范围。
            string text = this.menuItemList[index].Text.ToString();     // 获取当前要绘制的行的显示文本。

            // 绘制选中时的背景，要注意绘制的顺序，后面的会覆盖前面的
            // 绘制底色
            Color backgroundColor = Color.FromArgb(34, 35, 39);             // 背景色
            Color guideTagColor = Color.FromArgb(183, 218, 114);            // 高亮指示色
            Color selectedBackgroundColor = Color.FromArgb(46, 47, 51);     // 选中背景色
            Color fontColor = Color.Gray;                                   // 字体颜色
            Color selectedFontColor = Color.White;                          // 选中字体颜色
            Font textFont = new Font("微软雅黑", 9, FontStyle.Bold);        // 文字
            Image itmeImage = this.menuItemList[index].Img;            // 图标

            // 矩形大小
            Rectangle backgroundRect = new Rectangle(0, 0, bound.Width, bound.Height);
            Rectangle guideRect = new Rectangle(0, 4, 5, bound.Height - 8);
            Rectangle textRect = new Rectangle(55, 0, bound.Width, bound.Height);
            Rectangle imgRect = new Rectangle(20, 4, 22, bound.Height - 8);

            // 当前选中行
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = selectedBackgroundColor;
                fontColor = selectedFontColor;
            }
            else
            {
                guideTagColor = backgroundColor;
            }

            // 绘制背景色
            tempG.FillRectangle(new SolidBrush(backgroundColor), backgroundRect);

            // 绘制左前高亮指示
            tempG.FillRectangle(new SolidBrush(guideTagColor), guideRect);

            // 绘制显示文本
            TextRenderer.DrawText(tempG, text, textFont, textRect, fontColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            // 绘制图标
            tempG.DrawImage(itmeImage, imgRect);

            g.DrawImage(bitmap, bound.X, bound.Y, bitmap.Width, bitmap.Height);
            tempG.Dispose();
        }

        /// <summary>
        /// 设置listBox的item的高度
        /// </summary>
        private void lbMenu_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        /// <summary>
        /// 左边菜单选择操作
        /// </summary>
        private void lbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lbMenu.SelectedIndex)
            {
                case 0:
                    lvSongList.Items.Clear();
                    AddSongsToListView(localSongsList);

                    lvSongList.BringToFront();
                    tsmiFavorite.Visible = true;
                    pbAddSong.Visible = true;
                    break;
                case 1:
                    lvSongList.Items.Clear();
                    AddSongsToListView(favoriteSongsList);

                    lvSongList.BringToFront();
                    tsmiFavorite.Visible = false;
                    pbAddSong.Visible = false;
                    break;
            }

            int songsCount = lvSongList.Items.Count;
            lvSongList.Columns[0].Text = songsCount.ToString();
        }

        /// <summary>
        /// 设置lbListSong的Item，当listSong改变时
        /// </summary>
        private void lbListSongSetting()
        {
            string fileName = "";
            string fileArtist = "";
            string strAll = "";
            songItemList.Clear();
            lbListSong.Items.Clear();
            foreach (var item in listSong)
            {
                fileName = item.FileName;
                if (Encoding.GetEncoding("gb2312").GetBytes(fileName).Length > 32)
                {
                    fileName = SubString(fileName, 0, 32) + "...";
                }

                strAll = fileName + new string(' ', 35 - Encoding.GetEncoding("gb2312").GetBytes(fileName).Length);

                fileArtist = item.Artist;
                if (Encoding.GetEncoding("gb2312").GetBytes(fileArtist).Length > 16)
                {
                    fileArtist = SubString(fileArtist, 0, 16) + "...";
                }

                strAll += "  " + fileArtist;
                lbListSong.Items.Add(fileName + fileArtist);
                songItemList.Add(strAll);
            }
        }

        private string SubString(string toSub, int startIndex, int length)
        {
            byte[] subbyte = System.Text.Encoding.Default.GetBytes(toSub);

            string sub = System.Text.Encoding.Default.GetString(subbyte, startIndex, length);

            return sub;
        }

        /// <summary>
        /// 播放列表子物体绘制
        /// </summary>
        private void lbListSong_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Bounds.Height == 0)
            {
                return;
            }

            Bitmap bitmap = new Bitmap(e.Bounds.Width, e.Bounds.Height);

            int index = e.Index;                                // 获取当前要进行绘制的行的序号，从0开始。
            Graphics g = e.Graphics;                            // 获取Graphics对象。

            if (index >= listSong.Count)
            {
                return;
            }

            Graphics tempG = Graphics.FromImage(bitmap);

            tempG.SmoothingMode = SmoothingMode.AntiAlias;          // 使绘图质量最高，即消除锯齿
            tempG.InterpolationMode = InterpolationMode.HighQualityBicubic;
            tempG.CompositingQuality = CompositingQuality.HighQuality;

            Rectangle bound = e.Bounds;                         // 获取当前要绘制的行的一个矩形范围。
            string text = songItemList[index];     // 获取当前要绘制的行的显示文本。

            // 绘制选中时的背景，要注意绘制的顺序，后面的会覆盖前面的
            // 绘制底色
            Color backgroundColor = Color.FromArgb(40, 40, 40);             // 背景色
            Color guideTagColor = Color.WhiteSmoke;            // 高亮指示色
            Color selectedBackgroundColor = Color.FromArgb(64, 60, 66);     // 选中背景色
            Color fontColor = Color.White;                                   // 字体颜色
            Color selectedFontColor = Color.White;                          // 选中字体颜色
            Font textFont = new Font("幼圆", 9, FontStyle.Regular);        // 文字
                                                                          // Image itmeImage = Resources.user;            // 图标

            #region 绘制字体转换成图片
            string numStr = "";
            if (index < 10)
            {
                numStr = "0" + (index + 1);
            }
            else
            {
                numStr = (index + 1).ToString();
            }

            string str = numStr;
            Graphics grap = Graphics.FromImage(new Bitmap(1, 1));
            Font font = new Font("幼圆", 10.5f);
            SizeF sizeF = grap.MeasureString(str, font); // 测量出字体的高度和宽度
            Brush brush; // 笔刷，颜色
            brush = Brushes.White;
            PointF pf = new PointF(0, 0);
            Bitmap img = new Bitmap(Convert.ToInt32(sizeF.Width), Convert.ToInt32(sizeF.Height));
            grap = Graphics.FromImage(img);
            grap.DrawString(str, font, brush, pf);

            // 输出图片
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

            Image itmeImage = img;

            // 调试出图片的位置和合适大小
            int height = itmeImage.Height;
            int y = 8;
            #endregion

            // 当前播放歌曲
            if (currIndex == index)
            {
                itmeImage = Resources.声音ing;            // 图标
                height += 2;
                y -= 2;
            }

            // 矩形大小
            Rectangle backgroundRect = new Rectangle(0, 0, bound.Width, bound.Height);
            Rectangle guideRect = new Rectangle(0, 4, 5, bound.Height - 8);
            Rectangle textRect = new Rectangle(32, 0, bound.Width, bound.Height);
            Rectangle imgRect = new Rectangle(10, y, img.Width, height);

            // 当前选中行
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = selectedBackgroundColor;
                fontColor = selectedFontColor;
            }
            else
            {
                guideTagColor = backgroundColor;
            }

            // 绘制背景色
            tempG.FillRectangle(new SolidBrush(backgroundColor), backgroundRect);

            // 绘制左前高亮指示
            tempG.FillRectangle(new SolidBrush(guideTagColor), guideRect);

            // 绘制显示文本
            TextRenderer.DrawText(tempG, text, textFont, textRect, fontColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            // 绘制图标
            tempG.DrawImage(itmeImage, imgRect);

            g.DrawImage(bitmap, bound.X, bound.Y, bitmap.Width, bitmap.Height);
            tempG.Dispose();
        }

        /// <summary>
        /// 播放列表子物体ListBox(lbListSong)高度设置
        /// </summary>
        private void lbListSong_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        /// <summary>
        /// 设置ListSong
        /// </summary>
        private void SettingListSong()
        {
            listSong.Clear();

            // 设置播放列表
            switch (lbMenu.SelectedIndex)
            {
                case 0:
                    foreach (var item in localSongsList)
                    {
                        listSong.Add(item);
                    }

                    lbListSongSetting();
                    break;
                case 1:
                    foreach (var item in favoriteSongsList)
                    {
                        listSong.Add(item);
                    }

                    lbListSongSetting();
                    break;
            }
        }

        /// <summary>
        /// 记录当前歌曲播放时间
        /// </summary>
        private void timerPlay_Tick(object sender, EventArgs e)
        {
            // 设置当前播放时间
            labelMusicTimer.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString + " / " + currPlaySong.Duration.Remove(0, 3);

            // 设置滑动条值
            tackBarMove.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
        }

        /// <summary>
        /// 播放列表点击
        /// </summary>
        private void btnSongList_Click(object sender, EventArgs e)
        {
            panelListSong.Visible = true;
            panelListSong.BringToFront();
        }

        /// <summary>
        /// 播放列表上的关闭按钮点击
        /// </summary>
        private void pbListSongClose_Click(object sender, EventArgs e)
        {
            panelListSong.Visible = false;
        }

        /// <summary>
        /// 播放列表清空按钮点击
        /// </summary>
        private void labelClearSongList_Click(object sender, EventArgs e)
        {
            listSong.Clear();
            labelListSong.Text = "   播放列表为空";
            labelListCount.Text = "";
            currPlaySong = null;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            lbListSong.ClearSelected();
            lbListSongSetting();
            FavoritePictureSetting();
        }

        /// <summary>
        ///  播放列表listBox item子物体双击
        /// </summary>
        private void lbListSong_DoubleClick(object sender, EventArgs e)
        {
            currIndex = lbListSong.SelectedIndex;
            string songFilePath = listSong[currIndex].FilePath;

            // 选中的歌曲为正在播放的歌曲
            if (currPlaySong != null && currPlaySong.FilePath == songFilePath)
            {
                if (axWindowsMediaPlayer1.playState.ToString() == "wmppsPlaying")
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    pbPlay.Image = Resources.播放;
                    ttbbtnPlayPause.Icon = Resources.播放1;
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    pbPlay.Image = Resources.暂停;
                    ttbbtnPlayPause.Icon = Resources.暂停1;
                }
            }
            else
            {
                // 选中的为其他歌曲
                BuildRandomList(listSong.Count);
                jumpSongIndex = currIndex;
                currPlaySong = new SongsInfo(songFilePath);
                axWindowsMediaPlayer1.URL = songFilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pbPlay.Image = Resources.暂停;
                ttbbtnPlayPause.Icon = Resources.暂停1;
            }

            lbListSongSetting();
        }

        /// <summary>
        /// 播放列表listBox item子物体鼠标按下
        /// </summary>
        private void lbListSong_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = -1;
                index = this.lbListSong.SelectedIndex;
                if (index != -1)
                {
                    cmsListSongMenu.Visible = true;
                    currSelectedSong = new SongsInfo(listSong[index].FilePath);
                    currIndexSelected = index;
                    cmsListSongMenu.Show(Cursor.Position);
                }
                else
                {
                    cmsSongListMenu.Close();
                }
            }
        }

        /// <summary>
        /// 播放列表子物体右键菜单播放
        /// </summary>
        private void tsmiPlay_Click(object sender, EventArgs e)
        {
            pbPlay.Image = Resources.暂停hover;
            ttbbtnPlayPause.Icon = Resources.暂停1;
            currPlaySong = currSelectedSong;
            axWindowsMediaPlayer1.URL = currPlaySong.FilePath;
            currIndex = currIndexSelected;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        /// <summary>
        /// lbListSong(listBox)歌单单项删除
        /// </summary>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (listSong.Count == 1)
            {
                // 删除的是最后一首歌曲，执行与清空按钮相同的操作
                listSong.Clear();
                labelListSong.Text = "   播放列表为空";
                labelListCount.Text = "";
                currPlaySong = null;
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                lbListSong.ClearSelected();
            }
            else if (currIndex == currIndexSelected)
            {
                // 如果删除的歌曲是当前播放的歌曲，就播放下一首，删除当前,需要删掉一首，所以-2
                if (currIndex < listSong.Count - 2)
                {
                    timerPlay.Stop();
                }
                else
                {
                    timerPlay.Stop();
                    currIndex = 0;
                }

                if (currIndexSelected < currIndex)
                {
                    currIndex--;
                }

                listSong.RemoveAt(currIndexSelected);
                Play(currIndex);
                labelListCount.Text = listSong.Count.ToString();
                labelListSong.Text = "   播放列表 - 共计 " + listSong.Count.ToString() + " 首歌曲";
            }
            else
            {
                // 不是当前播放的歌曲，也不是下一首, 删除的在播放的前面就当前播放所以-1
                if (currIndexSelected < currIndex)
                {
                    currIndex--;
                }

                listSong.RemoveAt(currIndexSelected);
                labelListCount.Text = listSong.Count.ToString();
                labelListSong.Text = "   播放列表 - 共计 " + listSong.Count.ToString() + " 首歌曲";
            }

            // 最后都更新播放列表以及收藏按钮
            lbListSongSetting();
            FavoritePictureSetting();
        }

        /// <summary>
        /// 鼠标移动选中播放列表子物体lbListSong
        /// </summary>
        private void lbListSong_MouseMove(object sender, MouseEventArgs e)
        {
            if (lbListSong.Items.Count <= 0)
            {
                return;
            }

            lbListSong.SelectedIndex = this.lbListSong.IndexFromPoint(e.Location);
        }

        /// <summary>
        /// 读取并显示歌词
        /// </summary>
        private void ShowLrc()
        {
            if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(currPlaySong.FilePathLrc, Encoding.Default))
                    {
                        string line;

                        // 循环读取每一行歌词
                        while ((line = sr.ReadLine()) != null)
                        {
                            // 将读取到的歌词存放到数组中
                            for (int i = 0; i < 500; i++)
                            {
                                if (lrc[0, i] == null)
                                {
                                    lrc[0, i] = line.Substring(10, line.Length - 10);
                                    break;
                                }
                            }

                            // 将读取到的歌词时间存放到数组中
                            for (int i = 0; i < 500; i++)
                            {
                                if (lrc[1, i] == null)
                                {
                                    lrc[1, i] = line.Substring(1, 5);
                                    break;
                                }
                            }
                        }

                        // 获取播放器当前进度
                        string numss = this.axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                        for (int i = 0; i < 500; i++)
                        {
                            if (lrc[1, i].Equals(numss))
                            {
                                 //this.lableLrc.Text = lrc[0, i];
                            }
                            else
                            {
                                 //this.lableLrc.Text = "************";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("异常：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 刷新歌词
        /// </summary>
        private void timerLyrc_Tick(object sender, EventArgs e)
        {
            ShowLrc();
        }

        private void lbLyrc_DrawItem(object sender, DrawItemEventArgs e)
        {
            //获取当前绘制的行的索引
            int index = e.Index;
            Graphics g = e.Graphics;
            //得到每一项的绘制区域大小
            Rectangle bound = e.Bounds;
            //得到当前项的文本内容
            string text = lbLyrc.Items[index].ToString();

            //判断当前选择的项是正在唱的歌词，也就是中间一行歌词
            if (index == lbLyrc.Items.Count / 2)
            {//如果当前行为选中行。
             //绘制选中时要显示的蓝色边框，实际不需要就注释掉了
             // g.DrawRectangle(Pens.Blue, bound.Left, bound.Top, bound.Width - 1, bound.Height - 1);
             //绘制边框后，里面的矩形框大小改变，故重新定义一个，如果没有绘制边框就不需要重新定义
                Rectangle rect = new Rectangle(bound.Left - 1, bound.Top - 1,
                                               bound.Width - 2, bound.Height - 2);
                //绘制选中时要显示的蓝色背景。可以选中其它色，此处省略了背景绘制
                // g.FillRectangle(Brushes.Blue, rect);
                //定义一个字体，是用来绘制显示的当前歌词文本。
                Font font = new System.Drawing.Font("微软雅黑", 18, FontStyle.Bold & FontStyle.Italic);
                //绘制歌词，颜色为红色
                TextRenderer.DrawText(g, text, font, rect, Color.Red,
                                      TextFormatFlags.VerticalCenter);
            }
            else
            {
                //定义一个颜色为白色的画刷
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, bound);//绘制背景色。
                }
                //填充字体，字体的颜色为黑色
                TextRenderer.DrawText(g, text, this.Font, bound, Color.Black,
                                      TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }

        /// <summary>
        /// 音乐详情按钮点击，弹出歌词和专辑图片
        /// </summary>
        private void pbSmallAlbum_Click(object sender, EventArgs e)
        {
            panelLyrc.Visible = true;
            panelLyrc.BringToFront();
        }
    }
}
