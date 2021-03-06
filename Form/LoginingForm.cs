namespace QQ_piracy
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public partial class LoginingForm : Form
    {
        public static bool IsLogin = true;

        public Form LoginForm;

        public LoginingForm(Form loginForm)
        {
            this.LoginForm = loginForm;
            InitializeComponent();

            pictureBox1.MouseMove += PictureBox1_MouseMove;
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //常量
            int WM_SYSCOMMAND = 0x0112;

            //窗体移动
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void LoginingForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;    // 隐藏窗体边框

            IsLogin = true; // 设置正常登录
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();                 // 关闭窗体

            LoginForm.Close();

            this.Dispose();               // 释放资源

            Application.Exit();           // 关闭应用程序窗体
        }

        private void giveupButton_Click(object sender, EventArgs e)
        {
            IsLogin = false;
            LoginForm.Show();
            this.Close();
        }

        // 延时
        public bool Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return IsLogin;
        }
    }
}
