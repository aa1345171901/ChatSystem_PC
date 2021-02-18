using QQ_piracy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ_piracy.MusicForms
{
    public partial class MusicMainForm : Form
    {
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
            // 判断鼠标是否在panelMusicVlume上，是就不执行，否则就是该panel隐藏
            bool b = this.RectangleToScreen(panelMusicVlume.ClientRectangle).Contains(MousePosition);
            if (!b)
            {
                panelMusicVlume.Visible = false;
            }
        }

        /// <summary>
        /// 鼠标离开panel
        /// </summary>
        private void panelMusicVlume_MouseLeave(object sender, EventArgs e)
        {
            panelMusicVlume.Visible = false;
        }
    }
}
