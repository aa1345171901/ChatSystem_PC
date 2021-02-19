namespace QQ_piracy.MusicForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using QQ_piracy.Properties;

    public partial class MusicMainForm : Form
    {
        Point downPoint; // 用于设置拖动设置的位置

        public MusicMainForm()
        {
            InitializeComponent();
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
            pbPlay.Image = Resources.播放hover;
        }

        /// <summary>
        /// 鼠标离开播放图标时
        /// </summary>
        private void pbPlay_MouseLeave(object sender, EventArgs e)
        {
            pbPlay.Image = Resources.播放;
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
            Point p1 = new Point(this.pbVolume.Location.X, this.pbVolume.Location.Y + 523);
            Point p2 = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);

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
            pbLike.Image = Resources.收藏hover;
        }

        /// <summary>
        /// 收藏按钮鼠标移出
        /// </summary>
        private void pbLike_MouseLeave(object sender, EventArgs e)
        {
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
        /// 搜索按钮鼠标进入
        /// </summary>
        private void pbSearch_MouseHover(object sender, EventArgs e)
        {
            pbSearch.Image = Resources.搜索hover;
        }

        /// <summary>
        /// 搜索按钮鼠标离开
        /// </summary>
        private void pbSearch_MouseLeave(object sender, EventArgs e)
        {
            pbSearch.Image = Resources.搜索;
        }
    }
}
