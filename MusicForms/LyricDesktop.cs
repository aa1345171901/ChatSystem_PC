using QQ_piracy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ_piracy.MusicForms
{
    public partial class LyricDesktop : Form
    {    
        public LyricDesktop()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// 主窗口调用用于设置两个歌词界面
        /// </summary>
        public void SetLyric(string lyric1, string lyric2)
        {
            labelLyric1.Text = lyric1;
            labelLyricIng1.Text = lyric1;
            labelLyric2.Text = lyric2;
            labelLyricIng2.Text = lyric2;
        }

        /// <summary>
        /// 主窗口调用，用于设置黄字
        /// </summary>
        public void SetLyricIng(int width1, int width2)
        {
            panelLyricIng1.Width = width1;
            panelLyricIng2.Width = width2;
        }

        private void LyricDesktop_Load(object sender, EventArgs e)
        {
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 设置窗体移动的方法
        /// </summary>
        private void FormMove_MouseMove(object sender, MouseEventArgs e)
        {
            //常量
            int WM_SYSCOMMAND = 0x0112;

            //窗体移动
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}
